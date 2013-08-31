using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
// ReSharper disable UnusedMember.Global
    internal class At_all_times_count_knowns_plus_count_unknowns : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {

        #region Arrange
        private IRow _row1;

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
        public void Must_be_nine_when_all_is_unknown()
        {
            Assert.That(_row1.CountUnknowns, Is.EqualTo(9));

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Must_be_nine_when_eight_are_unknown()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            Assert.That(_row1.CountUnknowns, Is.EqualTo(8));

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Must_be_nine_when_seven_are_unknown()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            _row1.SetValueOfCell(2).To(Solver.CellValue.Two);
            Assert.That(_row1.CountUnknowns, Is.EqualTo(7));

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Must_be_nine_when_two_are_unknown()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            _row1.SetValueOfCell(2).To(Solver.CellValue.Two);
            _row1.SetValueOfCell(3).To(Solver.CellValue.Three);
            _row1.SetValueOfCell(4).To(Solver.CellValue.Four);
            _row1.SetValueOfCell(5).To(Solver.CellValue.Five);
            _row1.SetValueOfCell(6).To(Solver.CellValue.Six);
            _row1.SetValueOfCell(7).To(Solver.CellValue.Seven);

            Assert.That(_row1.CountUnknowns, Is.EqualTo(2));

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Must_be_nine_when_one_is_unknown()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            _row1.SetValueOfCell(2).To(Solver.CellValue.Two);
            _row1.SetValueOfCell(3).To(Solver.CellValue.Three);
            _row1.SetValueOfCell(4).To(Solver.CellValue.Four);
            _row1.SetValueOfCell(5).To(Solver.CellValue.Five);
            _row1.SetValueOfCell(6).To(Solver.CellValue.Six);
            _row1.SetValueOfCell(7).To(Solver.CellValue.Seven);
            _row1.SetValueOfCell(8).To(Solver.CellValue.Eight);

            Assert.That(_row1.CountUnknowns, Is.EqualTo(0)); //!! last value is set automatically !!

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        [Test]
        public void Must_be_nine_when_none_are_unknown()
        {
            _row1.SetValueOfCell(1).To(Solver.CellValue.One);
            _row1.SetValueOfCell(2).To(Solver.CellValue.Two);
            _row1.SetValueOfCell(3).To(Solver.CellValue.Three);
            _row1.SetValueOfCell(4).To(Solver.CellValue.Four);
            _row1.SetValueOfCell(5).To(Solver.CellValue.Five);
            _row1.SetValueOfCell(6).To(Solver.CellValue.Six);
            _row1.SetValueOfCell(7).To(Solver.CellValue.Seven);
            _row1.SetValueOfCell(8).To(Solver.CellValue.Eight);
            _row1.SetValueOfCell(9).To(Solver.CellValue.Nine);
            Assert.That(_row1.CountUnknowns, Is.EqualTo(0));

            Assert.That(_row1.CountUnknowns + _row1.CountKnownValues, Is.EqualTo(9));
        }

        #endregion
    }
}