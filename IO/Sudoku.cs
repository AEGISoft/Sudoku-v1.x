using System.Collections.Generic;
using System.Xml.Linq;

namespace AEGIS.Sudoku.IO
{
    internal class Sudoku
    {
        const string CellElement = "Cell";
        const string RowAttribute = "row";
        const string ColAttribute = "col";
        const string ValueAttribute = "value";

        public Sudoku(string xmlContent)
        {
            Cells = new List<Cell>();

            var doc = XDocument.Parse(xmlContent);
            foreach (var cellElement in doc.Descendants(CellElement))
            {
                Cells.Add
                (
                    new Cell
                    {
                        Row = cellElement.GetIntegerAttributeValue(RowAttribute),
                        Col = cellElement.GetIntegerAttributeValue(ColAttribute),
                        Value = cellElement.GetIntegerAttributeValue(ValueAttribute)
                    }
                );
            }
        }

        public List<Cell> Cells { get; private set; }

        internal class Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Value { get; set; }
        }
    }

}
