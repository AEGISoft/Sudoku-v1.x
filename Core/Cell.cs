using System.Collections.Generic;
using System.Linq;

namespace AEGIS.Sudoku.Solver
{
    public interface ICellUnderConstruction
    {
        ICellGroup Row { set; }
        ICellGroup Col { set; }
        ICellGroup Sqr { set; }
        ISudoku Sudoku { set; }        
    }

    public interface  IEditableCell
    {
        CellValue Value { get; set; }
        ICellGroup Row { get; }
        ICellGroup Col { get; }
        ICellGroup Sqr { get; }
        ISudoku Sudoku { get; }
    }

    public interface ICell
    {
        int Id { get; }
        CellValue Value { get; }
        CellErrorCode Errorcode { get; }
        ICellGroup Row { get; }
        ICellGroup Col { get; }
        ICellGroup Sqr { get; }
        ISudoku Sudoku { get; }

        Tristate CanBe(CellValue value);
        void RememberValueCanBe(CellValue value);
        void RememberValueCanNotBe(CellValue value);
        void Analyse();
    }

    public class Cell : ICell, IEditableCell, ICellUnderConstruction
    {

        #region constructor
        /// <summary>
        /// Factory to indicate that creating cells is special
        /// Only 'rows' are allowed to make new Cells.  all other constructions, should reuse the instances created by the rows.
        /// 
        /// IMPORTANT to not have different instances of the same cell !!!
        /// </summary>
        public static class Factory
        {
            public static Cell CreateCell(int id)
            {
                return new Cell(id); // reason for this factory see summmary above !!!
            }
        }

        public int Id { get; private set; }

        private Cell(int id)
        {
            Id = id;

            Row = new NullableRow();
            Col = new NullableCol();
            Sqr = new NullableSqr();
            Sudoku = new NullableSudoku();

            _memory = new Dictionary<CellValue, Tristate>
                          {
                              {CellValue.One   , Tristate.DontKnow},
                              {CellValue.Two   , Tristate.DontKnow},
                              {CellValue.Three , Tristate.DontKnow},
                              {CellValue.Four  , Tristate.DontKnow},
                              {CellValue.Five  , Tristate.DontKnow},
                              {CellValue.Six   , Tristate.DontKnow},
                              {CellValue.Seven , Tristate.DontKnow},
                              {CellValue.Eight , Tristate.DontKnow},
                              {CellValue.Nine  , Tristate.DontKnow}
                          };

            _value = CellValue.Unknown;
        }
        #endregion

        #region properties
        #region backing fields 
        private readonly Dictionary<CellValue, Tristate> _memory; 
        private CellValue _value;
        #endregion

        public CellValue Value
        {
            get { return _value; }
            set 
            {
                if (_value == value) return;  //nothing new here ...

                if (Invalid(value))
                {
                    _value = CellValue.Error;
                    Errorcode = GetErrorCodeFrom(value);
                }
                else
                {
                    _value = value;
                    RememberValueCanBe(value);
                    RememberValueIsNowInvalidForTheRestOfTheCellsOfMy(Row, value);
                    RememberValueIsNowInvalidForTheRestOfTheCellsOfMy(Col, value);
                    RememberValueIsNowInvalidForTheRestOfTheCellsOfMy(Sqr, value);
                    Sudoku.RememberSomethingChanged();
                }
            }
        }

        public CellErrorCode Errorcode { get; private set; }

        public ICellGroup Row { get; set; }
        public ICellGroup Col { get; set; }
        public ICellGroup Sqr { get; set; }

        public ISudoku Sudoku { get; set; }
        #endregion

        #region public methods
        public Tristate CanBe(CellValue value)
        {
            return Value == CellValue.Unknown ? _memory[value] : (Value == value ? Tristate.Yes : Tristate.No);
        }

        public void RememberValueCanBe(CellValue value)
        {
            //Validate)
            if (!CellValue.RealValue(value)) return;
            if (IsImpossible(value)) { Process(); return; }
            
            //Do it !!
            RememberPossibleValue(value);
            if (!CellValue.RealValue(Value) && CountPossibleValues == 1) Value = FirstPossibleValue;
        }

        public void RememberValueCanNotBe(CellValue value)
        {
            if (!CellValue.RealValue(value)) return;
            if (Value != CellValue.Unknown) return;

            _memory[value] = Tristate.No;

            if (CountPossibleValues == 1) Value = FirstPossibleValue;
            
        }

        public void Analyse()
        {
            RememberPossibleCellValues();
        }
        #endregion

        #region helpers

        private void Process()
        {
            Value = CellValue.Error; //when impossible, can't become possible anymore
            Errorcode = CellErrorCode.AValueCantBePossibleAndImpossibleAtTheSameTime;
        }
        private bool IsImpossible(CellValue value)
        {
            if (!CellValue.RealValue(value)) return false;

            return CanBe(value) == Tristate.No;
        }
        private void RememberPossibleValue(CellValue value)
        {
            if (!CellValue.RealValue(value)) return;

            _memory[value] = Tristate.Yes;
        }
        private int CountPossibleValues { get { return CellValue.RealValues.Count(value => CanBe(value) != Tristate.No); } }
        private CellValue FirstPossibleValue
        {
            get
            {
                foreach (var value in CellValue.RealValues.Where(value => CanBe(value) != Tristate.No))
                {
                    return value;
                }

                return CellValue.Unknown;
            }
        }
        private void RememberPossibleCellValues()
        {
            if (CellValue.RealValues.Contains(Value)) return;

            foreach (var value in Sqr.ImpossibleValues)
            {
                RememberValueCanNotBe(value);
            }

            foreach (var value in Sqr.PossibleValues)
            {
                if (CanBe(value) == Tristate.No) continue;

                if (Row.Contains(value)) { RememberValueCanNotBe(value); continue; }
                if (Col.Contains(value)) { RememberValueCanNotBe(value); continue; }

                RememberValueCanBe(value);
            }
        }
        private void RememberValueIsNowInvalidForTheRestOfTheCellsOfMy(ICellGroup cellgroup, CellValue value)
        {
            foreach (var cell in cellgroup.Cells.Where(cell => cell != this))
            {
                cell.RememberValueCanNotBe(value);
            }
        }

        #endregion

        #region Validation rules
        private bool Invalid(CellValue value)
        {
            return (IsInvalid(value) || ExistsAlreadyInGroup(value));
        }

        private CellErrorCode GetErrorCodeFrom(CellValue value)
        {
            if (IsInvalid(value)) return CellErrorCode.InvalidInput;
            if (ExistsAlreadyInGroup(value)) return CellErrorCode.ExistsAlreadyInGroup;
            return CellErrorCode.Unknown;
        }

        private bool ExistsAlreadyInGroup(CellValue value)
        {
            if (Row.Contains(value)) return true;
            if (Col.Contains(value)) return true;
            if (Sqr.Contains(value)) return true;

            return false;
        }

        private static bool IsInvalid(CellValue value)
        {
            return !CellValue.RealValues.Contains(value);
        }
        #endregion

    }

    public class NullableCell: ICell, IEditableCell
    {
        public int Id
        {
            get { return 0; }
        }

        public CellValue Value
        {
            get { return CellValue.Unknown; }
            set { }
        }

        public CellErrorCode Errorcode
        {
            get { return CellErrorCode.Unknown; }
        }

        public ICellGroup Row
        {
            get { return new NullableRow(); }
        }

        public ICellGroup Col
        {
            get { return new NullableCol(); }
        }

        public ICellGroup Sqr
        {
            get { return new NullableSqr(); }
        }

        public ISudoku Sudoku
        {
            get { return new NullableSudoku(); }
        }

        public Tristate CanBe(CellValue value)
        {
            return Tristate.DontKnow;
        }

        public void RememberValueCanBe(CellValue value)
        {}

        public void RememberValueCanNotBe(CellValue value)
        {}

        public void Analyse()
        {}
    }

    #region Cell enums
    public enum CellErrorCode
    {
        AllIsWell, 
        InvalidInput, 
        AtLeastOneValueShouldBePossible, 
        AValueCantBePossibleAndImpossibleAtTheSameTime,
        Unknown,
        ExistsAlreadyInGroup
    }

    public enum Tristate
    {
        DontKnow, Yes, No
    }
    #endregion

    #region Cell Value helpers
    public static class SetValue
    {
        public static CellValueSetter Of(IEditableCell cell)
        {
            return new CellValueSetter(cell);
        }
    }

    public class CellValueSetter
    {
        #region constructor
        private readonly IEditableCell _cell;

        public CellValueSetter(IEditableCell cell)
        {
            _cell = cell;
        }
        #endregion

        #region public methods

        public void To(CellValue value)
        {
            _cell.Value = value;
        }

        #endregion

    }
    #endregion

    #region Cell linkers
    public static class Link
    {
        public static CellLinker A(ICellUnderConstruction cell)
        {
            return new CellLinker(cell);
        }
    }

    public class CellLinker
    {
        #region constructor
        private readonly ICellUnderConstruction _cell;

        public CellLinker(ICellUnderConstruction cell)
        {
            _cell = cell;
        }
        #endregion

        #region public methods
        public void To(ISudoku sudoku) { _cell.Sudoku = sudoku; }

        public void To(Row row) { _cell.Row = row; }
        public void To(Col col) { _cell.Col = col; }
        public void To(Sqr sqr) { _cell.Sqr = sqr; }
        #endregion
    }
    #endregion
}