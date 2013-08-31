using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Core.Specs.Cell
{
// ReSharper disable UnusedMember.Global
    internal class When_setting_the_value_of_a_cell_to_an_invalid_value: AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private ICell _cell11;

        protected override void Arrange()
        {
            _cell11 = new Row(1).Cell(1);
        }

        protected override void Act()
        {
            SetValue.Of((IEditableCell)_cell11).To(CellValue.From(34));
        }

        [Test]
        public void It_should_set_its_value_to_error()
        {
            Assert.That(_cell11.Value,Is.EqualTo(SudokuValue.Error));
        }

        [Test]
        public void It_should_return_errorcode_invalid_input()
        {
            Assert.That(_cell11.Errorcode,Is.EqualTo(CellErrorCode.InvalidInput));


        }
    }
}
