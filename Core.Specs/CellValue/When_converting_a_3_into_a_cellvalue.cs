using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellValue
{
// ReSharper disable UnusedMember.Global
    internal class When_converting_a_3_into_a_cellvalue : AaaStyleSpec
// ReSharper restore UnusedMember.Global
    {
        private Solver.CellValue _actual;

        protected override void Act()
        {
            _actual = Solver.CellValue.From(3);
        }

        [Test]
        public void It_should_be_converted_into_a_three()
        {
            Assert.That(_actual, Is.InstanceOf<Three>());
        }
    }
}
