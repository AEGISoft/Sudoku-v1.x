namespace AEGIS.Sudoku.Solver
{
    public interface ICol: ICellGroup {}

    public sealed class Col : CellGroup, ICol
    {
        #region constructor
        public Col(int oneBasedColumnIndex, IRow row1, IRow row2, IRow row3, IRow row4, IRow row5, IRow row6, IRow row7, IRow row8, IRow row9)
        {

            Id = oneBasedColumnIndex;

            Add(row1.Cell(oneBasedColumnIndex));
            Add(row2.Cell(oneBasedColumnIndex));
            Add(row3.Cell(oneBasedColumnIndex));
            Add(row4.Cell(oneBasedColumnIndex));
            Add(row5.Cell(oneBasedColumnIndex));
            Add(row6.Cell(oneBasedColumnIndex));
            Add(row7.Cell(oneBasedColumnIndex));
            Add(row8.Cell(oneBasedColumnIndex));
            Add(row9.Cell(oneBasedColumnIndex));
        }

        protected override ICell Add(ICell cell)
        {
            base.Add(cell);
            Link.A((ICellUnderConstruction)cell).To(this);
            return cell;
        }
        #endregion
    }

    public class NullableCol: NullableCellGroup, ICol {}
}