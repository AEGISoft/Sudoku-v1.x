using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.Cell
{
// ReSharper disable UnusedMember.Global
    internal class When_value_is_possible : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ICell _cell11;

        #region Arrange

        protected override void Arrange()
        {
            _cell11 = new Row(1).Cell(1);
            _cell11.RememberValueCanBe(Solver.CellValue.Nine);
        }

        #endregion

        protected override void Act()
        {
            _cell11.RememberValueCanNotBe(Solver.CellValue.Nine);
        }

        #region Assert

        [Test]
        public void It_can_become_impossible()
        {
            Assert.That(_cell11.CanBe(Solver.CellValue.Nine), Is.EqualTo(Tristate.No));
        }

        #endregion
    }
}