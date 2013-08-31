using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.Cell
{
// ReSharper disable UnusedMember.Global
    internal class When_cell_can_be_9 : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ICell _cell11;

        #region Arrange

        protected override void Arrange()
        {
            _cell11 = new Row(1).Cell(1);
        }

        #endregion

        protected override void Act()
        {
            _cell11.RememberValueCanBe(Solver.CellValue.Nine);
        }

        #region Assert

        [Test]
        public void Value_9_becomes_a_possible_value()
        {
            Assert.That(_cell11.CanBe(Solver.CellValue.One), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Two), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Three), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Six), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Seven), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Eight), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_cell11.CanBe(Solver.CellValue.Nine), Is.EqualTo(Tristate.Yes));
        }

        #endregion
    }
}