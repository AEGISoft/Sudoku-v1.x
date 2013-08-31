using System.Collections.Generic;
using System.Reflection;
using AEGIS.Specs.Framework;
using NUnit.Framework;

namespace AEGIS.Sudoku.Solver.Specs.CellGroup
{
    public class When_creating_a_cellgroup_other_than_row: AaaStyleSpec
    {
        #region Arrange

        private ConstructorInfo[] _colConstructors;
        private ConstructorInfo[] _sqrConstructors;

        protected override void Arrange()
        {
            _colConstructors = typeof(Col).GetConstructors();
            _sqrConstructors = typeof(Sqr).GetConstructors();
        }
        #endregion

        [Test]
        public void All_column_constructors_have_only_row_parametertypes()
        {
            AssertConstructorParametersAreRows(_colConstructors);
        }

        [Test]
        public void All_square_constructors_have_only_row_parametertypes()
        {
            AssertConstructorParametersAreRows(_sqrConstructors);
        }


        #region helpers
        private static void AssertConstructorParametersAreRows(IEnumerable<ConstructorInfo> constructors)
        {
            foreach (var constructor in constructors)
            {
                foreach (var parameter in constructor.GetParameters())
                {
                    if (parameter.ParameterType == typeof(int)) continue; //to define which cellgroup to create

                    Assert.That(parameter.ParameterType.FullName,
                                Is.EqualTo(typeof(IRow).FullName));
                }
            }
        }


        #endregion
    }
}
