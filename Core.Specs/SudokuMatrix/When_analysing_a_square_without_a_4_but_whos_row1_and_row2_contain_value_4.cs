using AEGIS.Specs.Framework;
using AEGIS.Sudoku.Solver.Specs.CellGroup.Mothers;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.SudokuMatrix
{
// ReSharper disable UnusedMember.Global
    internal class When_analysing_a_square_without_a_4_but_whos_row1_and_row2_contain_value_4 : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ISqr _sqr1;

        #region Arrange

        protected override void Arrange()
        {
            var sudoku = SudokuMother.CreateEmptySudoku();

            _sqr1 = sudoku.Sqr(1);

            sudoku.Row(1).SetValueOfCell(4).To(Solver.CellValue.Four);
            sudoku.Row(2).SetValueOfCell(7).To(Solver.CellValue.Four);

            Assert.That(sudoku.Row(1).Contains(Solver.CellValue.Four), Is.EqualTo(true));
            Assert.That(sudoku.Row(2).Contains(Solver.CellValue.Four), Is.EqualTo(true));
            Assert.That(sudoku.Row(3).Contains(Solver.CellValue.Four), Is.EqualTo(false));

            Assert.That(_sqr1.Cell(7).CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_sqr1.Cell(8).CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_sqr1.Cell(9).CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.DontKnow));
        }

        #endregion

        protected override void Act()
        {
            _sqr1.Cell(1).Analyse();
            _sqr1.Cell(2).Analyse();
            _sqr1.Cell(3).Analyse();
            _sqr1.Cell(4).Analyse();
            _sqr1.Cell(5).Analyse();
            _sqr1.Cell(6).Analyse();
            _sqr1.Cell(7).Analyse();
            _sqr1.Cell(8).Analyse();
            _sqr1.Cell(9).Analyse();
        }

        #region Assert

        [Test]
        public void All_cells_on_the_third_row_of_the_square_can_have_value_4()
        {
            Assert.That(_sqr1.Cells[6].CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.Yes));
            Assert.That(_sqr1.Cells[7].CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.Yes));
            Assert.That(_sqr1.Cells[8].CanBe(Solver.CellValue.Four), Is.EqualTo(Tristate.Yes));
        }

        #endregion
    }
}