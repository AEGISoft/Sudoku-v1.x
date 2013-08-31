using System.Collections.Generic;
using AEGIS.Specs.Framework;
using AEGIS.Sudoku.Solver.Specs.Cell.Builders;
using NUnit.Framework;
using Rhino.Mocks;

namespace AEGIS.Sudoku.Solver.Specs.Cell
{
    public class When_setting_the_value_of_a_cell : AaaStyleSpec
    {
        #region Arrange
        private ICell _cell11;
        private Solver.CellValue _value;
        private ICell _otherCellInMyRowStub;
        private ICell _otherCellInMyColStub;
        private ICell _otherCellInMySqrStub;

        protected override void Arrange()
        {
            _otherCellInMyRowStub = MockRepository.GenerateStub<ICell>();
            _otherCellInMyColStub = MockRepository.GenerateStub<ICell>();
            _otherCellInMySqrStub = MockRepository.GenerateStub<ICell>();

            _cell11 = CreateCellAndLinkItToCellsInItsRowColAndSqr();

            _value = Solver.CellValue.Seven;
        }

        private ICell CreateCellAndLinkItToCellsInItsRowColAndSqr()
        {
            var rowStub = MockRepository.GenerateStub<IRow>();
            var colStub = MockRepository.GenerateStub<ICol>();
            var sqrStub = MockRepository.GenerateStub<ISqr>();

            rowStub.Expect(x => x.Cells).Return(new List<ICell> { _otherCellInMyRowStub });
            colStub.Expect(x => x.Cells).Return(new List<ICell> { _otherCellInMyColStub });
            sqrStub.Expect(x => x.Cells).Return(new List<ICell> { _otherCellInMySqrStub });

            return CellBuilder.CreateCell(11).LinkedTo(rowStub).LinkedTo(colStub).LinkedTo(sqrStub);

        }

        #endregion

        #region Act
        protected override void Act()
        {
            ((IEditableCell)_cell11).Value = _value;
        }
        #endregion

        #region Assert

        [Test]
        public void The_cell_will_be_set_to_that_value()
        {
            Assert.That(_cell11.Value, Is.EqualTo(_value));
        }

        [Test]
        public void The_cell_can_be_no_other_value()
        {
            Assert.That(_cell11.CanBe(Solver.CellValue.One), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Two), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Three), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Six), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Seven), Is.EqualTo(Tristate.Yes));// <-- this is the one :-)
            Assert.That(_cell11.CanBe(Solver.CellValue.Eight), Is.EqualTo(Tristate.No));
            Assert.That(_cell11.CanBe(Solver.CellValue.Nine), Is.EqualTo(Tristate.No));
        }
        
        [Test]
        public void That_value_becomes_impossible_for_the_other_cells_in_my_row()
        {
            _otherCellInMyRowStub.AssertWasCalled(x => x.RememberValueCanNotBe(_value));
        }

        [Test]
        public void That_value_becomes_impossible_for_the_other_cells_in_my_col()
        {
            _otherCellInMyColStub.AssertWasCalled(x => x.RememberValueCanNotBe(_value));
        }

        [Test]
        public void That_value_becomes_impossible_for_the_other_cells_in_my_sqr()
        {
            _otherCellInMySqrStub.AssertWasCalled(x => x.RememberValueCanNotBe(_value));
        }

        #endregion

    }
}
