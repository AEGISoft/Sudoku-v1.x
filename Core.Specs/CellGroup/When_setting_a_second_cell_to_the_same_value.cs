using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    internal class When_setting_a_second_cell_to_the_same_value : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private Row _row1;

        #region Arrange

        protected override void Arrange()
        {
            _row1 = new Row(1);
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
        }

        #endregion

        protected override void Act()
        {
            _row1.SetValueOfCell(2).To(Solver.CellValue.One);
        }

        #region Assert

        [Test]
        public void It_should_return_an_error()
        {
            Assert.That(_row1.Cell(2).Value, Is.EqualTo(Solver.CellValue.Error));
        }

        #endregion
    }
}