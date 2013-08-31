using AEGIS.Specs.Framework;
using AEGIS.Sudoku.Solver.Specs.CellGroup.Mothers;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.SudokuMatrix
{
// ReSharper disable UnusedMember.Global
    internal class When_solving_1_star_sudoku : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ISudoku _sudoku;

        #region Arrange

        protected override void Arrange()
        {
            _sudoku = SudokuMother.Create1StarSudoku();
        }

        #endregion

        protected override void Act()
        {
            _sudoku.Analyse();
        }

        #region Assert

        [Test]
        public void Suduko_should_be_solved()
        {
            Assert.That(_sudoku.Cell(1, 1).Value, Is.EqualTo(Solver.CellValue.One),"1.1");
            Assert.That(_sudoku.Cell(1, 2).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(1, 3).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(1, 4).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(1, 5).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(1, 6).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(1, 7).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(1, 8).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(1, 9).Value, Is.EqualTo(Solver.CellValue.Seven));

            Assert.That(_sudoku.Cell(2, 1).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(2, 2).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(2, 3).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(2, 4).Value, Is.EqualTo(Solver.CellValue.One), "2, 4");
            Assert.That(_sudoku.Cell(2, 5).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(2, 6).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(2, 7).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(2, 8).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(2, 9).Value, Is.EqualTo(Solver.CellValue.Eight));

            Assert.That(_sudoku.Cell(3, 1).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(3, 2).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(3, 3).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(3, 4).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(3, 5).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(3, 6).Value, Is.EqualTo(Solver.CellValue.Four), "3, 6");
            Assert.That(_sudoku.Cell(3, 7).Value, Is.EqualTo(Solver.CellValue.One));
            Assert.That(_sudoku.Cell(3, 8).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(3, 9).Value, Is.EqualTo(Solver.CellValue.Nine));

            Assert.That(_sudoku.Cell(4, 1).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(4, 2).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(4, 3).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(4, 4).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(4, 5).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(4, 6).Value, Is.EqualTo(Solver.CellValue.One), "4, 6");
            Assert.That(_sudoku.Cell(4, 7).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(4, 8).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(4, 9).Value, Is.EqualTo(Solver.CellValue.Two));
            
            Assert.That(_sudoku.Cell(5, 1).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(5, 2).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(5, 3).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(5, 4).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(5, 5).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(5, 6).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(5, 7).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(5, 8).Value, Is.EqualTo(Solver.CellValue.One), "5, 8");
            Assert.That(_sudoku.Cell(5, 9).Value, Is.EqualTo(Solver.CellValue.Three));

            Assert.That(_sudoku.Cell(6, 1).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(6, 2).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(6, 3).Value, Is.EqualTo(Solver.CellValue.One), "6, 3");
            Assert.That(_sudoku.Cell(6, 4).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(6, 5).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(6, 6).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(6, 7).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(6, 8).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(6, 9).Value, Is.EqualTo(Solver.CellValue.Five));

            Assert.That(_sudoku.Cell(7, 1).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(7, 2).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(7, 3).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(7, 4).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(7, 5).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(7, 6).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(7, 7).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(7, 8).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(7, 9).Value, Is.EqualTo(Solver.CellValue.One), "7, 9");

            Assert.That(_sudoku.Cell(8, 1).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(8, 2).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(8, 3).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(8, 4).Value, Is.EqualTo(Solver.CellValue.Four));
            Assert.That(_sudoku.Cell(8, 5).Value, Is.EqualTo(Solver.CellValue.One), "8, 5");
            Assert.That(_sudoku.Cell(8, 6).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(8, 7).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(8, 8).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(8, 9).Value, Is.EqualTo(Solver.CellValue.Six));

            Assert.That(_sudoku.Cell(9, 1).Value, Is.EqualTo(Solver.CellValue.Three));
            Assert.That(_sudoku.Cell(9, 2).Value, Is.EqualTo(Solver.CellValue.One), "9, 2");
            Assert.That(_sudoku.Cell(9, 3).Value, Is.EqualTo(Solver.CellValue.Six));
            Assert.That(_sudoku.Cell(9, 4).Value, Is.EqualTo(Solver.CellValue.Eight));
            Assert.That(_sudoku.Cell(9, 5).Value, Is.EqualTo(Solver.CellValue.Five));
            Assert.That(_sudoku.Cell(9, 6).Value, Is.EqualTo(Solver.CellValue.Seven));
            Assert.That(_sudoku.Cell(9, 7).Value, Is.EqualTo(Solver.CellValue.Two));
            Assert.That(_sudoku.Cell(9, 8).Value, Is.EqualTo(Solver.CellValue.Nine));
            Assert.That(_sudoku.Cell(9, 9).Value, Is.EqualTo(Solver.CellValue.Four));
        }

        #endregion
    }
}