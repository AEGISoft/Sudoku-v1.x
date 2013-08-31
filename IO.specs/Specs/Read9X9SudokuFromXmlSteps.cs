using System.IO;
using AEGIS.Sudoku.IO.Facade;
using AEGIS.Sudoku.IO.specs.Mothers;
using AEGIS.Sudoku.Solver;
using AEGIS.Sudoku.Solver.RepoInterfaces;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AEGIS.Sudoku.IO.specs.Specs
{
    [Binding]
    public class Read9X9SudokuFromXmlSteps
    {
        #region Given
        private string _xmlFile;
        private Solver.Sudoku _sudoku;

        [Given(@"I have a one star nine by nine sudoku with values between one and nine in xml format")]
        public void GivenIHaveAOneStarNineByNineSudokuWithValuesBetweenOneAndNineInXmlFormat()
        {
            var testFileFolder = Path.Combine(FileAndFolderHelpers.GetAssemblyDirectory, "TestFiles");
            if (!Directory.Exists(testFileFolder))Directory.CreateDirectory(testFileFolder);
            _xmlFile = Path.Combine(FileAndFolderHelpers.GetAssemblyDirectory, "TestFiles", "Sudoku-1star.xml");
            SudokuFileMother.CreateFile(_xmlFile);
        }
        #endregion

        #region When
        [When(@"I load the xml")]
        public void WhenILoadTheXml()
        {
            SudokuRepository sudokuRepo = new SudokuXmlRepository();
            _sudoku = sudokuRepo.Get(_xmlFile);
        }
        #endregion

        #region Then
        [Then(@"the result should be the one star sudoku in memory")]
        public void ThenTheResultShouldBeTheOneStarSudokuInMemory()
        {
            Assert.That(_sudoku.ReadValueOfCell(1, 3), Is.EqualTo(CellValue.Three));
            Assert.That(_sudoku.ReadValueOfCell(1, 8), Is.EqualTo(CellValue.Six));

            Assert.That(_sudoku.ReadValueOfCell(2, 3), Is.EqualTo(CellValue.Two));
            Assert.That(_sudoku.ReadValueOfCell(2, 4), Is.EqualTo(CellValue.One));

            Assert.That(_sudoku.ReadValueOfCell(2, 6), Is.EqualTo(CellValue.Nine));
            Assert.That(_sudoku.ReadValueOfCell(2, 9), Is.EqualTo(CellValue.Eight));

            Assert.That(_sudoku.ReadValueOfCell(3, 2), Is.EqualTo(CellValue.Five));
            Assert.That(_sudoku.ReadValueOfCell(3, 5), Is.EqualTo(CellValue.Six));
            Assert.That(_sudoku.ReadValueOfCell(3, 7), Is.EqualTo(CellValue.One));
            Assert.That(_sudoku.ReadValueOfCell(3, 9), Is.EqualTo(CellValue.Nine));

            Assert.That(_sudoku.ReadValueOfCell(4, 2), Is.EqualTo(CellValue.Six));
            Assert.That(_sudoku.ReadValueOfCell(4, 3), Is.EqualTo(CellValue.Four));
            Assert.That(_sudoku.ReadValueOfCell(4, 7), Is.EqualTo(CellValue.Nine));
            Assert.That(_sudoku.ReadValueOfCell(4, 8), Is.EqualTo(CellValue.Eight));

            Assert.That(_sudoku.ReadValueOfCell(5, 1), Is.EqualTo(CellValue.Two));
            Assert.That(_sudoku.ReadValueOfCell(5, 6), Is.EqualTo(CellValue.Five));

            Assert.That(_sudoku.ReadValueOfCell(6, 5), Is.EqualTo(CellValue.Two));
            Assert.That(_sudoku.ReadValueOfCell(6, 7), Is.EqualTo(CellValue.Six));
            Assert.That(_sudoku.ReadValueOfCell(6, 8), Is.EqualTo(CellValue.Four));

            Assert.That(_sudoku.ReadValueOfCell(7, 1), Is.EqualTo(CellValue.Four));
            Assert.That(_sudoku.ReadValueOfCell(7, 3), Is.EqualTo(CellValue.Five));
            Assert.That(_sudoku.ReadValueOfCell(7, 8), Is.EqualTo(CellValue.Three));

            Assert.That(_sudoku.ReadValueOfCell(8, 1), Is.EqualTo(CellValue.Nine));
            Assert.That(_sudoku.ReadValueOfCell(8, 4), Is.EqualTo(CellValue.Four));
            Assert.That(_sudoku.ReadValueOfCell(8, 5), Is.EqualTo(CellValue.One));
            Assert.That(_sudoku.ReadValueOfCell(8, 7), Is.EqualTo(CellValue.Five));

            Assert.That(_sudoku.ReadValueOfCell(9, 1), Is.EqualTo(CellValue.Three));
            Assert.That(_sudoku.ReadValueOfCell(9, 2), Is.EqualTo(CellValue.One));
            Assert.That(_sudoku.ReadValueOfCell(9, 4), Is.EqualTo(CellValue.Eight));
            Assert.That(_sudoku.ReadValueOfCell(9, 6), Is.EqualTo(CellValue.Seven));
            Assert.That(_sudoku.ReadValueOfCell(9, 7), Is.EqualTo(CellValue.Two));

        }
        #endregion

        #region Clean up
        [AfterScenario]
        public void CloseResources()
        {
            File.Delete(_xmlFile);
        }
        #endregion
    }
}
