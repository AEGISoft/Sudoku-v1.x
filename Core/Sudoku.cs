using System.Collections.Generic;

namespace AEGIS.Sudoku.Solver
{
    public interface ISudoku
    {
        ICell Cell(int onebasedRowIndex , int onebaseColIndex );
        IRow Row(int onebasedRowIndex);
        ICol Col(int onebasedRowIndex);
        ISqr Sqr(int onebasedRowIndex);

        void RememberSomethingChanged();
        void Analyse();
        CellValue ReadValueOfCell(int oneBaseRowIndex, int oneBasedColIndex);
        CellValueSetter SetValueOfCell(int oneBasedRowIndex, int oneBasedColIndex);
    }

    public class Sudoku : ISudoku
    {
        #region constructor
        public static Sudoku CreateEmptySudoku()
        {
            var row1 = new Row(1);
            var row2 = new Row(2);
            var row3 = new Row(3);
            var row4 = new Row(4);
            var row5 = new Row(5);
            var row6 = new Row(6);
            var row7 = new Row(7);
            var row8 = new Row(8);
            var row9 = new Row(9);

            var col1 = new Col(1, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col2 = new Col(2, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col3 = new Col(3, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col4 = new Col(4, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col5 = new Col(5, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col6 = new Col(6, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col7 = new Col(7, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col8 = new Col(8, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var col9 = new Col(9, row1, row2, row3, row4, row5, row6, row7, row8, row9);

            var sqr1 = new Sqr(1, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr2 = new Sqr(2, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr3 = new Sqr(3, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr4 = new Sqr(4, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr5 = new Sqr(5, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr6 = new Sqr(6, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr7 = new Sqr(7, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr8 = new Sqr(8, row1, row2, row3, row4, row5, row6, row7, row8, row9);
            var sqr9 = new Sqr(9, row1, row2, row3, row4, row5, row6, row7, row8, row9);

            return new Sudoku(row1, row2, row3, row4, row5, row6, row7, row8, row9,
                              col1, col2, col3, col4, col5, col6, col7, col8, col9,
                              sqr1, sqr2, sqr3, sqr4, sqr5, sqr6, sqr7, sqr8, sqr9);
        }

        //only Factory Methods are allowed to make Sudoku's
        private Sudoku(IRow row1, IRow row2, IRow row3, IRow row4, IRow row5, IRow row6, IRow row7, IRow row8, IRow row9, 
                      ICol col1, ICol col2, ICol col3, ICol col4, ICol col5, ICol col6, ICol col7, ICol col8, ICol col9, 
                      ISqr sqr1, ISqr sqr2, ISqr sqr3, ISqr sqr4, ISqr sqr5, ISqr sqr6, ISqr sqr7, ISqr sqr8, ISqr sqr9)
        {
            _rows = new List<IRow> { row1, row2, row3, row4, row5, row6, row7, row8, row9 };
            _cols = new List<ICol> { col1, col2, col3, col4, col5, col6, col7, col8, col9 };
            _sqrs = new List<ISqr> { sqr1, sqr2, sqr3, sqr4, sqr5, sqr6, sqr7, sqr8, sqr9 };

            LinkCellsToThisSudoku();
        }

        private void LinkCellsToThisSudoku()
        {
            foreach (var row in _rows)
            {
                foreach (var cell in row.Cells)
                {
                    Link.A((ICellUnderConstruction)cell).To(this);
                    _cells.Add(cell);
                }
            }
        }

        #endregion

        #region private properties
        readonly IList<IRow> _rows = new List<IRow>();
        readonly IList<ICol> _cols = new List<ICol>();
        readonly IList<ISqr> _sqrs = new List<ISqr>();
        readonly IList<ICell> _cells = new List<ICell>();

        private bool Changed { get; set; }
        #endregion

        #region public methods
        public void RememberSomethingChanged()
        {
            Changed = true;
        }

        public ICell Cell(int onebasedRowIndex, int onebaseColIndex)
        {
            return Row(onebasedRowIndex).Cell(onebaseColIndex);
        }

        public IRow Row(int onebasedRowIndex)
        {
            return _rows[onebasedRowIndex - 1];
        }

        public ICol Col(int onebasedColIndex)
        {
            return _cols[onebasedColIndex - 1];
        }

        public ISqr Sqr(int onebasedSqrIndex)
        {
            return _sqrs[onebasedSqrIndex - 1];
        }

        public CellValueSetter SetValueOfCell(int oneBasedRowIndex, int oneBasedColIndex)
        {
            return SetValue.Of((IEditableCell)Row(oneBasedRowIndex).Cell(oneBasedColIndex));
        }

        public void Analyse()
        {
            do
            {
                Changed = false;
                foreach (var cell in _cells) { cell.Analyse(); }
                foreach (var sqr in _sqrs) { sqr.Analyse(); }
                foreach (var col in _cols) { col.Analyse(); }
                foreach (var row in _rows) { row.Analyse(); }
            } while (Changed);
        }

        public CellValue ReadValueOfCell(int oneBaseRowIndex, int oneBasedColIndex)
        {
            return _rows[oneBaseRowIndex - 1].Cells[oneBasedColIndex - 1].Value;
        }
        #endregion
    }

    public class NullableSudoku : ISudoku
    {

        public ICell Cell(int onebasedRowIndex, int onebaseColIndex)
        {
            return new NullableCell();
        }

        public IRow Row(int onebasedRowIndex)
        {
            return new NullableRow();
        }

        public ICol Col(int onebasedRowIndex)
        {
            return new NullableCol();
        }

        public ISqr Sqr(int onebasedRowIndex)
        {
            return new NullableSqr();
        }

        public void RememberSomethingChanged() { }

        public void Analyse() { }

        public CellValue ReadValueOfCell(int oneBaseRowIndex, int oneBasedColIndex) { return CellValue.Unknown; }

        public CellValueSetter SetValueOfCell(int oneBasedRowIndex, int oneBasedColIndex)
        {
            return SetValue.Of(new NullableCell());
        }
    }
}