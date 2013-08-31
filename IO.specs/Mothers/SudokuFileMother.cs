using System.IO;

namespace AEGIS.Sudoku.IO.specs.Mothers
{
    public static class SudokuFileMother
    {
            public const string XmlContent = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + 
"<Sudoku>" + 
"  <Cell row=\"1\" col=\"3\" value=\"3\"/>" +
"  <Cell row=\"1\" col=\"8\" value=\"6\"/>" +

"  <Cell row=\"2\" col=\"3\" value=\"2\"/>" +
"  <Cell row=\"2\" col=\"4\" value=\"1\"/>" +

"  <Cell row=\"2\" col=\"6\" value=\"9\"/>" +
"  <Cell row=\"2\" col=\"9\" value=\"8\"/>" +

"  <Cell row=\"3\" col=\"2\" value=\"5\"/>" +
"  <Cell row=\"3\" col=\"5\" value=\"6\"/>" +
"  <Cell row=\"3\" col=\"7\" value=\"1\"/>" +
"  <Cell row=\"3\" col=\"9\" value=\"9\"/>" +

"  <Cell row=\"4\" col=\"2\" value=\"6\"/>" +
"  <Cell row=\"4\" col=\"3\" value=\"4\"/>" +
"  <Cell row=\"4\" col=\"7\" value=\"9\"/>" +
"  <Cell row=\"4\" col=\"8\" value=\"8\"/>" +

"  <Cell row=\"5\" col=\"1\" value=\"2\"/>" +
"  <Cell row=\"5\" col=\"6\" value=\"5\"/>" +

"  <Cell row=\"6\" col=\"5\" value=\"2\"/>" +
"  <Cell row=\"6\" col=\"7\" value=\"6\"/>" +
"  <Cell row=\"6\" col=\"8\" value=\"4\"/>" +

"  <Cell row=\"7\" col=\"1\" value=\"4\"/>" +
"  <Cell row=\"7\" col=\"3\" value=\"5\"/>" +
"  <Cell row=\"7\" col=\"8\" value=\"3\"/>" +

"  <Cell row=\"8\" col=\"1\" value=\"9\"/>" +
"  <Cell row=\"8\" col=\"4\" value=\"4\"/>" +
"  <Cell row=\"8\" col=\"5\" value=\"1\"/>" +
"  <Cell row=\"8\" col=\"7\" value=\"5\"/>" +
        
"  <Cell row=\"9\" col=\"1\" value=\"3\"/>" +
"  <Cell row=\"9\" col=\"2\" value=\"1\"/>" +
"  <Cell row=\"9\" col=\"4\" value=\"8\"/>" +
"  <Cell row=\"9\" col=\"6\" value=\"7\"/>" +
"  <Cell row=\"9\" col=\"7\" value=\"2\"/>" +
"</Sudoku>";

        public static string CreateFile(string xmlFileName)
        {

            using (var tw = new StreamWriter(xmlFileName))
            {
                tw.Write(XmlContent);
            }

            return XmlContent;
        }
    }
}