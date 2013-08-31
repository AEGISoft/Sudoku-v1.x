namespace AEGIS.Sudoku.Solver
{
    public interface ISqr : ICellGroup { }

    public sealed class Sqr : CellGroup, ISqr
    {
        #region constructors

        public Sqr(int oneBasedSquareIndex, IRow row1, IRow row2, IRow row3, IRow row4, IRow row5, IRow row6, IRow row7, IRow row8, IRow row9)
        {
            Id = oneBasedSquareIndex;

            var rowA = GetRowAFrom(oneBasedSquareIndex, row1, row4, row7);
            var rowB = GetRowBFrom(oneBasedSquareIndex, row2, row5, row8);
            var rowC = GetRowCFrom(oneBasedSquareIndex, row3, row6, row9);
            var colA = GetColAFrom(oneBasedSquareIndex);
            var colB = GetColBFrom(oneBasedSquareIndex);
            var colC = GetColCFrom(oneBasedSquareIndex);

            Add(rowA.Cell(colA));
            Add(rowA.Cell(colB));
            Add(rowA.Cell(colC));
            Add(rowB.Cell(colA));
            Add(rowB.Cell(colB));
            Add(rowB.Cell(colC));
            Add(rowC.Cell(colA));
            Add(rowC.Cell(colB));
            Add(rowC.Cell(colC));
        }

        private static int GetColAFrom(int oneBasedSquareIndex)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 4: case 7: return 1;
                case 2: case 5: case 8: return 4;
                case 3: case 6: case 9: return 7;
                default : return -1;
            }
        }
        private static int GetColBFrom(int oneBasedSquareIndex)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 4: case 7: return 2;
                case 2: case 5: case 8: return 5;
                case 3: case 6: case 9: return 8;
                default: return -1;
            }
        }
        private static int GetColCFrom(int oneBasedSquareIndex)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 4: case 7: return 3;
                case 2: case 5: case 8: return 6;
                case 3: case 6: case 9: return 9;
                default: return -1;
            }
        }

        private static IRow GetRowAFrom(int oneBasedSquareIndex, IRow row1, IRow row4, IRow row7)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 2: case 3: return row1;
                case 4: case 5: case 6: return row4;
                case 7: case 8: case 9: return row7;
                default: return new Row(-1);
            }
        }
        private static IRow GetRowBFrom(int oneBasedSquareIndex, IRow row2, IRow row5, IRow row8)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 2: case 3: return row2;
                case 4: case 5: case 6: return row5;
                case 7: case 8: case 9: return row8;
                default: return new Row(-1);
            }
        }
        private static IRow GetRowCFrom(int oneBasedSquareIndex, IRow row3, IRow row6, IRow row9)
        {
            switch (oneBasedSquareIndex)
            {
                case 1: case 2: case 3: return row3;
                case 4: case 5: case 6: return row6;
                case 7: case 8: case 9: return row9;
                default: return new Row(-1);
            }
        }

        protected override ICell Add(ICell cell)
        {
            base.Add(cell);
            Link.A((ICellUnderConstruction)cell).To(this);
            return cell;
        }

        #endregion
    }

    public class NullableSqr : NullableCellGroup, ISqr { }
}