using System;
using AEGIS.Specs.Framework;
using AEGIS.Sudoku.IO.specs.Mothers;
using NUnit.Framework;

namespace AEGIS.Sudoku.IO.specs.Tests
{
// ReSharper disable UnusedMember.Global
    public class When_loading_sudokuxml: AaaStyleSpec 
// ReSharper restore UnusedMember.Global
    {
        #region Arrange
        private String _readsudoku;
        private String _originalsudoku;
        private string _xmlFileName;

        protected override void Arrange()
        {
            _xmlFileName = "Sudoku-1star.xml";
            _originalsudoku = SudokuFileMother.CreateFile(_xmlFileName);
        }
        #endregion

        #region Act
        protected override void Act()
        {
            _readsudoku = SudokuXmlReader.Load(_xmlFileName);
        }

        #endregion

        [Test]
        public void The_correct_content_is_loaded()
        {
            Assert.That(_readsudoku, Is.EqualTo(_originalsudoku));
        }
    }
}
