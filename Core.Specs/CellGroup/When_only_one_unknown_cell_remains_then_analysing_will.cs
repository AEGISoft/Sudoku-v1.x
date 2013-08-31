using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    internal class When_only_one_unknown_cell_remains_then_analysing_will : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private Row _row1;

        #region Arrange

        protected override void Arrange()
        {
            _row1 = new Row(1);

            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            _row1.SetValueOfCell(2).To(Solver.CellValue.Two);
            _row1.SetValueOfCell(3).To(Solver.CellValue.Three);
            _row1.SetValueOfCell(4).To(Solver.CellValue.Four);
            _row1.SetValueOfCell(5).To(Solver.CellValue.Five);
            _row1.SetValueOfCell(6).To(Solver.CellValue.Six);
            _row1.SetValueOfCell(7).To(Solver.CellValue.Seven);
            _row1.SetValueOfCell(8).To(Solver.CellValue.Eight);
        }

        #endregion

        protected override void Act()
        {
            _row1.Analyse();
        }

        #region Assert

        [Test]
        public void Leave_the_cellgroup_with_9_known_values()
        {
            Assert.That(_row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Set_the_unknown_cell_to_the_remaining_value()
        {
            Assert.That(_row1.Cells[8].Value, Is.EqualTo(Solver.CellValue.Nine));
        }

        #endregion
    }
}