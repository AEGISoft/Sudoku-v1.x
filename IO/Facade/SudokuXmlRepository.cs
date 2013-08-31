using AEGIS.Sudoku.Solver;
using AEGIS.Sudoku.Solver.RepoInterfaces;

namespace AEGIS.Sudoku.IO.Facade
{
    public class SudokuXmlRepository : SudokuRepository
    {
        public Solver.Sudoku Get(string sudokuName)
        {
            var xmlContent = SudokuXmlReader.Load(sudokuName);
            var sudoku = new Sudoku(xmlContent);

            var sudokuModel = Solver.Sudoku.CreateEmptySudoku();

            foreach (var cell in sudoku.Cells)
            {
                sudokuModel.SetValueOfCell(cell.Row, cell.Col).To(CellValue.From(cell.Value));
            }
            
            return sudokuModel;
        }
    }
}