using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellValue
{
// ReSharper disable UnusedMember.Global
    internal class When_trying_to_convert_34_into_a_cellvalue: WrongCellValueConversionTester
// ReSharper restore UnusedMember.Global
    {
        protected override void Arrange()
        {
            _ValueToTest = 34;
        }

        [Test]
        public void It_should_set_its_value_to_error()
        {
            AssertCorrectConvertException();
        }        
    }
}
