using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    internal class When_a_row_is_created : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private IRow _row1;

        #region Arrange

        protected override void Arrange()
        {
            _row1 = new Row(1);
        }

        #endregion

        protected override void Act()
        {
        }

        #region Assert

        [Test]
        public void It_has_9_cells_with_unknown_values()
        {
            Assert.That(_row1.CountUnknowns, Is.EqualTo(9));
        }

        [Test]
        public void It_has_9_cells_with_value_unknown()
        {
            Assert.That(_row1.Cell(1).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(2).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(3).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(4).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(5).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(6).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(7).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(8).Value, Is.EqualTo(Solver.CellValue.Unknown));
            Assert.That(_row1.Cell(9).Value, Is.EqualTo(Solver.CellValue.Unknown));
        }

        [Test]
        public void It_has_0_cells_with_a_known_value()
        {
            Assert.That(_row1.CountKnownValues, Is.EqualTo(0));
        }

        #endregion
    }
}