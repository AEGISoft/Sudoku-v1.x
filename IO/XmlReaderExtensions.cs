using System;
using System.IO;
using System.Xml.Linq;

namespace AEGIS.Sudoku.IO
{
    static class XmlReaderExtensions
    {
        public static int GetIntegerAttributeValue(this XElement element, XName attributeName)
        {
            //get attribute
            var attribute = element.Attribute(attributeName);

            //validate
            Int32 number;
            if (attribute == null || !Int32.TryParse(attribute.Value, out number))
            {
                throw new InvalidDataException(element + " doesn't have a valid value for " + attributeName);
            }

            //return
            return number;
        }
    }
}