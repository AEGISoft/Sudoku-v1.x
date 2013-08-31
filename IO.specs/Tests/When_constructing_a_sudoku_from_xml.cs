using AEGIS.Specs.Framework;
using AEGIS.Sudoku.IO.specs.Mothers;
using NUnit.Framework;

namespace AEGIS.Sudoku.IO.specs.Tests
{
    public class When_constructing_a_sudoku_from_xml: AaaStyleSpec
    {
        #region Arrange
        private Sudoku _sudoku;

        #endregion

        #region Act
        protected override void Act()
        {
            _sudoku = new Sudoku(SudokuFileMother.XmlContent);
        }
        #endregion

        [Test]
        public void It_should_contain_the_right_amount_of_cells()
        {
            Assert.That(_sudoku.Cells.Count, Is.EqualTo(31));
        }

        [Test]
        public void The_first_cell_value_should_be_correct()
        {
            Assert.That(_sudoku.Cells[0].Value, Is.EqualTo(3));
        }

        [Test]
        public void The_first_cell_row_should_be_correct()
        {
            Assert.That(_sudoku.Cells[0].Row, Is.EqualTo(1));
        }

        [Test]
        public void The_first_cell_col_should_be_correct()
        {
            Assert.That(_sudoku.Cells[0].Col, Is.EqualTo(3));
        }

        [Test]
        public void The_last_cell_value_should_be_correct()
        {
            Assert.That(_sudoku.Cells[_sudoku.Cells.Count-1].Value, Is.EqualTo(2));
        }

        [Test]
        public void The_last_cell_row_should_be_correct()
        {
            Assert.That(_sudoku.Cells[_sudoku.Cells.Count - 1].Row, Is.EqualTo(9));
        }

        [Test]
        public void The_last_cell_col_should_be_correct()
        {
            Assert.That(_sudoku.Cells[_sudoku.Cells.Count - 1].Col, Is.EqualTo(7));
        }
    }
}
