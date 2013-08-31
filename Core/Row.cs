namespace AEGIS.Sudoku.Solver
{
    public interface IRow: ICellGroup {}

    public sealed class Row : CellGroup, IRow 
    {
        #region constructor

        public Row(int oneBasedRowIndex)
        {
            Id = oneBasedRowIndex;

            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 1)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 2)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 3)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 4)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 5)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 6)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 7)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 8)).To(this);
            Link.A(NewCellWithId(oneBasedRowIndex * 10 + 9)).To(this);
        }

        private ICellUnderConstruction NewCellWithId(int cellId)
        {
            return (ICellUnderConstruction) Add(Solver.Cell.Factory.CreateCell(cellId));
        }

        #endregion
    }

    public class NullableRow : NullableCellGroup, IRow { }
}