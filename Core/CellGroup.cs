using System.Collections.Generic;
using System.Linq;

namespace AEGIS.Sudoku.Solver
{
    public interface ICellGroup
    {
        IList<ICell> Cells { get; }
        ICell Cell(int oneBasedIndex);
        bool Contains(CellValue value);
        void Analyse();
        int CountUnknowns { get; }
        int CountKnownValues { get; }
        IList<CellValue> ImpossibleValues { get; }
        IList<CellValue> PossibleValues { get; }
        int Id { get; }
        CellValueSetter SetValueOfCell(int oneBasedCellIndex);
    }

    public class CellGroup : ICellGroup
    {
        #region constructors
        public int Id { get; protected set; }

        protected virtual ICell Add(ICell cell)
        {
            Cells.Add(cell);
            return cell;
        }
        #endregion

        #region properties
        private readonly List<ICell> _cells= new List<ICell>();
        public IList<ICell> Cells { get { return _cells; } }

        public ICell Cell(int oneBasedIndex)
        {
            //ToDo: add parameter check (plus adequate errorhandling)

            return Cells[oneBasedIndex-1];
        }
        #endregion

        #region methods
        public int CountUnknowns
        {
            get
            {
                return Cells.Count(cell => cell.Value == CellValue.Unknown);
            }
        }
        public int CountKnownValues
        {
            get
            {
                return Cells.Count(cell => (cell.Value != CellValue.Unknown && cell.Value != CellValue.Error));
            }
        }

        public CellValueSetter SetValueOfCell(int oneBasedCellIndex)
        {
            //ToDo: add parameter check (plus adequate errorhandling)

            return SetValue.Of((IEditableCell)Cell(oneBasedCellIndex));
        }

        public void Analyse()
        {
            SetLastUnknownCellToLastPossibleValue();
        }

        public bool Contains(CellValue value)
        {
            return Cells.Any(cell => cell.Value == value);
        }

        public IList<CellValue> ImpossibleValues
        {
            get
            {
                var impossibleValues = new List<CellValue>();
                var possibleValues = CellValue.RealValues;
                foreach (var cell in Cells)
                {
                    if (possibleValues.Contains(cell.Value)) impossibleValues.Add(cell.Value);
                }
                return impossibleValues;
            }
        }
        public IList<CellValue> PossibleValues
        {
            get
            {
                var possibleValues = CellValue.RealValues;
                foreach (var cell in Cells)
                {
                    if (possibleValues.Contains(cell.Value)) possibleValues.Remove(cell.Value);
                }
                return possibleValues;
            }
        }

        #endregion

        #region helpers
        private void SetLastUnknownCellToLastPossibleValue()
        {
            if (CountUnknowns == 1) SetValue.Of((IEditableCell)FirstUnknownCell).To(FirstPossibleValue);
        }

        private CellValue FirstPossibleValue
        {
            get
            {
                var possibleValues = PossibleValues;
                return possibleValues.Count < 1 ? CellValue.Error : possibleValues[0];
            }
        }

        private ICell FirstUnknownCell
        {
            get
            {
                if (Cells[0].Value == CellValue.Unknown) return Cells[0];
                if (Cells[1].Value == CellValue.Unknown) return Cells[1];
                if (Cells[2].Value == CellValue.Unknown) return Cells[2];
                if (Cells[3].Value == CellValue.Unknown) return Cells[3];
                if (Cells[4].Value == CellValue.Unknown) return Cells[4];
                if (Cells[5].Value == CellValue.Unknown) return Cells[5];
                if (Cells[6].Value == CellValue.Unknown) return Cells[6];
                if (Cells[7].Value == CellValue.Unknown) return Cells[7];
                if (Cells[8].Value == CellValue.Unknown) return Cells[8];
                return null;
            }
        }
        #endregion
    }

    public class NullableCellGroup : ICellGroup
    {
        public virtual IList<ICell> Cells
        {
            get { return new List<ICell>();}
        }

        public virtual ICell Cell(int oneBasedIndex)
        {
            return new NullableCell();
        }

        public virtual bool Contains(CellValue value) { return false; }

        public virtual void Analyse() { }

        public virtual int CountUnknowns
        {
            get { return 9; }
        }
        public virtual int CountKnownValues
        {
            get { return 0; }
        }

        public virtual IList<CellValue> ImpossibleValues
        {
            get { return new List<CellValue>(); }
        }
        public virtual IList<CellValue> PossibleValues
        {
            get { return CellValue.RealValues; }
        }

        public virtual int Id
        {
            get { return 0; }
        }

        public CellValueSetter SetValueOfCell(int oneBasedCellIndex)
        {
            return SetValue.Of(new NullableCell());
        }
    }
}