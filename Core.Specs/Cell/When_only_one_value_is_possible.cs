using AEGIS.Specs.Framework;
using NUnit.Framework;
using Rhino.Mocks;

namespace AEGIS.Sudoku.Solver.Specs.Cell
{
// ReSharper disable UnusedMember.Global
    internal class When_only_one_value_is_possible : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {

        #region Arrange
        private ICell _cell11;
        private ISudoku _sudokuStub;

        protected override void Arrange()
        {
            var row1 = new Row(1);
            _cell11 = row1.Cell(1);
            _cell11.RememberValueCanNotBe(Solver.CellValue.One);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Two);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Three);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Four);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Five);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Six);
            _cell11.RememberValueCanNotBe(Solver.CellValue.Seven);

            Assert.That(_cell11.Value, Is.EqualTo(Solver.CellValue.Unknown));

            _sudokuStub = MockRepository.GenerateStub<ISudoku>();
            foreach (var cell in row1.Cells)
            {
                Link.A((ICellUnderConstruction)cell).To(_sudokuStub);
            }
        
        }

        #endregion

        protected override void Act()
        {
            Assert.That(_cell11.CanBe(Solver.CellValue.Nine), Is.EqualTo(Tristate.DontKnow));

            _cell11.RememberValueCanNotBe(Solver.CellValue.Eight);

        }

        #region Assert
        [Test]
        public void Cell_should_notify_his_sudoku_something_changed()
        {
            _sudokuStub.AssertWasCalled(x => x.RememberSomethingChanged());
        }

        [Test]
        public void Cell_should_get_that_value()
        {
            Assert.That(_cell11.Value, Is.EqualTo(Solver.CellValue.Nine));
        }

        #endregion
    }
}