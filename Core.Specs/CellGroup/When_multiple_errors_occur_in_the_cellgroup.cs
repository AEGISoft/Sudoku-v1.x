using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    public class When_multiple_errors_occur_in_the_cellgroup: AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private Row _row1;
        protected override void Arrange()
        {
            _row1 = new Row(1);
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
        }

        protected override void Act()
        {
            _row1.SetValueOfCell(2).To(Solver.CellValue.One);
            _row1.SetValueOfCell(3).To(Solver.CellValue.One);
        }

    
        [Test]
        public void All_those_cells_should_have_value_error()
        {
            Assert.That(_row1.Cell(2).Value, Is.EqualTo(Solver.CellValue.Error));
            Assert.That(_row1.Cell(3).Value, Is.EqualTo(Solver.CellValue.Error));
        }
    }
}
