using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.Cell
{
// ReSharper disable UnusedMember.Global
    internal class When_value_is_impossible_and_trying_to_make_it_possible_again : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ICell _cell11;

        #region Arrange

        protected override void Arrange()
        {
            _cell11 = new Row(1).Cell(1);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Nine);
        }

        #endregion

        protected override void Act()
        {
            _cell11.RememberValueCanBe(Solver.CellValue.Nine);
        }

        #region Assert

        [Test]
        public void It_stays_impossible()
        {
            Assert.That(_cell11.CanBe(Solver.CellValue.Nine), Is.EqualTo(Tristate.No));
        }

        [Test]
        public void Cellvalue_becomes_error()
        {
            Assert.That(_cell11.Value, Is.EqualTo(Solver.CellValue.Error));
        }

        [Test]
        public void It_should_return_the_correct_errorcode()
        {
            Assert.That(_cell11.Errorcode, Is.EqualTo(CellErrorCode.AValueCantBePossibleAndImpossibleAtTheSameTime));
        }
        #endregion
    }
}