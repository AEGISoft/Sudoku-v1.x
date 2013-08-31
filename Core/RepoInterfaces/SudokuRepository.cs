namespace AEGIS.Sudoku.Solver.RepoInterfaces
{
    public interface SudokuRepository
    {
        Sudoku Get(string sudokuName);
    }
}