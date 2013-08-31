using AEGIS.Specs.Framework;
using AEGIS.Sudoku.Solver.Specs.CellGroup.Mothers;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.SudokuMatrix
{
// ReSharper disable UnusedMember.Global
    internal class When_analysing_a_square_without_a_5_but_whos_col1_and_col2_contain_value_5 : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ISqr _sqr1;

        #region Arrange

        protected override void Arrange()
        {
            var sudoku = SudokuMother.CreateEmptySudoku();

            _sqr1 = sudoku.Sqr(1);

            sudoku.SetValueOfCell(4,1).To(Solver.CellValue.Five);
            sudoku.SetValueOfCell(7,2).To(Solver.CellValue.Five);

            Assert.That(sudoku.Col(1).Contains(Solver.CellValue.Five), Is.EqualTo(true));
            Assert.That(sudoku.Col(2).Contains(Solver.CellValue.Five), Is.EqualTo(true));
            Assert.That(sudoku.Col(3).Contains(Solver.CellValue.Five), Is.EqualTo(false));

            Assert.That(_sqr1.Cells[2].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_sqr1.Cells[5].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.DontKnow));
            Assert.That(_sqr1.Cells[8].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.DontKnow));
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
        public void All_cells_on_the_third_col_of_the_square_can_have_value_5()
        {
            Assert.That(_sqr1.Cells[2].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.Yes));
            Assert.That(_sqr1.Cells[5].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.Yes));
            Assert.That(_sqr1.Cells[8].CanBe(Solver.CellValue.Five), Is.EqualTo(Tristate.Yes));
        }

        #endregion
    }
}