namespace AEGIS.Sudoku.Solver.Specs.CellGroup.Mothers
{
    internal static class SudokuMother
    {
        internal static ISudoku CreateEmptySudoku()
        {
            return Sudoku.CreateEmptySudoku();
        }

        public static ISudoku Create1StarSudoku()
        {
            var sudoku = CreateEmptySudoku();
            sudoku.SetValueOfCell(1, 3).To(Solver.CellValue.Three);
            sudoku.SetValueOfCell(1, 8).To(Solver.CellValue.Six);

            sudoku.SetValueOfCell(2, 3).To(Solver.CellValue.Two);
            sudoku.SetValueOfCell(2, 4).To(Solver.CellValue.One);
            sudoku.SetValueOfCell(2, 6).To(Solver.CellValue.Nine);
            sudoku.SetValueOfCell(2, 9).To(Solver.CellValue.Eight);

            sudoku.SetValueOfCell(3, 2).To(Solver.CellValue.Five);
            sudoku.SetValueOfCell(3, 5).To(Solver.CellValue.Six);
            sudoku.SetValueOfCell(3, 7).To(Solver.CellValue.One);
            sudoku.SetValueOfCell(3, 9).To(Solver.CellValue.Nine);

            sudoku.SetValueOfCell(4, 2).To(Solver.CellValue.Six);
            sudoku.SetValueOfCell(4, 3).To(Solver.CellValue.Four);
            sudoku.SetValueOfCell(4, 7).To(Solver.CellValue.Nine);
            sudoku.SetValueOfCell(4, 8).To(Solver.CellValue.Eight);

            sudoku.SetValueOfCell(5, 1).To(Solver.CellValue.Two);
            sudoku.SetValueOfCell(5, 6).To(Solver.CellValue.Five);

            sudoku.SetValueOfCell(6, 5).To(Solver.CellValue.Two);
            sudoku.SetValueOfCell(6, 7).To(Solver.CellValue.Six);
            sudoku.SetValueOfCell(6, 8).To(Solver.CellValue.Four);

            sudoku.SetValueOfCell(7, 1).To(Solver.CellValue.Four);
            sudoku.SetValueOfCell(7, 3).To(Solver.CellValue.Five);
            sudoku.SetValueOfCell(7, 8).To(Solver.CellValue.Three);

            sudoku.SetValueOfCell(8, 1).To(Solver.CellValue.Nine);
            sudoku.SetValueOfCell(8, 4).To(Solver.CellValue.Four);
            sudoku.SetValueOfCell(8, 5).To(Solver.CellValue.One);
            sudoku.SetValueOfCell(8, 7).To(Solver.CellValue.Five);

            sudoku.SetValueOfCell(9, 1).To(Solver.CellValue.Three);
            sudoku.SetValueOfCell(9, 2).To(Solver.CellValue.One);
            sudoku.SetValueOfCell(9, 4).To(Solver.CellValue.Eight);
            sudoku.SetValueOfCell(9, 6).To(Solver.CellValue.Seven);
            sudoku.SetValueOfCell(9, 7).To(Solver.CellValue.Two);

            return sudoku;
        }
    }
}