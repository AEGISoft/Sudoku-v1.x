namespace AEGIS.Sudoku.Solver.Specs.Cell.Builders
{
    public static class CellBuilder
    {
        public static ICell CreateCell(int id)
        {
            return new Row(1).Cell(1);
        }

        public static ICell WithValue(this ICell cell, Solver.CellValue value)
        {
            ((IEditableCell)cell).Value = value;
            return cell;
        }

        public static ICell LinkedTo(this ICell cell, IRow row)
        {
            ((ICellUnderConstruction)cell).Row = row;
            return cell;
        }

        public static ICell LinkedTo(this ICell cell, ICol col)
        {
            ((ICellUnderConstruction) cell).Col = col;
            return cell;
        }

        public static ICell LinkedTo(this ICell cell, ISqr sqr)
        {
            ((ICellUnderConstruction)cell).Sqr = sqr;
            return cell;
        }

    }
}
