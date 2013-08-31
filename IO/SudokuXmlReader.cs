using System.IO;

namespace AEGIS.Sudoku.IO
{
    static class SudokuXmlReader
    {
        public static string Load(string xmlFileName)
        {
            using (var reader = new StreamReader(xmlFileName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}