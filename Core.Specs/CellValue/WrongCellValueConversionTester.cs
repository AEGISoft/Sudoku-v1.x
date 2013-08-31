using System;
using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellValue
{
    internal abstract class WrongCellValueConversionTester : AaaStyleSpec
    {
        private Exception _expectedException;
        protected int _ValueToTest;

        protected override void Act()
        {
            try
            {
                Solver.CellValue.From(_ValueToTest);
            }
            catch (ArgumentOutOfRangeException expectedException)
            {
                _expectedException = expectedException;
            }
        }

        protected void AssertCorrectConvertException()
        {
            Assert.That(_expectedException, Is.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}