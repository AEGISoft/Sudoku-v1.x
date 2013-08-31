using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    internal class When_setting_a_cell_to_value_5 : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {

        #region Arrange
        private Row _row1;

        protected override void Arrange()
        {
            _row1 = new Row(1);
        }

        #endregion

        protected override void Act()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.Five);
        }

        #region Assert

        [Test]
        public void All_other_cells_cannot_be_value_5()
        {
            Assert.That(_row1.Cells[1].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[2].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[3].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[4].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[5].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[6].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[7].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_row1.Cells[8].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
        }

        [Test]
        public void It_should_know_5_is_already_used()
        {
            Assert.That(_row1.Contains(Solver.CellValue.Five));
        }

        [Test]
        public void Value_5_should_not_be_in_the_possible_values()
        {
            Assert.That(!_row1.PossibleValues.Contains(Solver.CellValue.Five));
        }

        #endregion
    }
}