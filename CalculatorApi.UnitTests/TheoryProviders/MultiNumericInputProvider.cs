
using System.Collections;
using System.Collections.Generic;
using CalculatorApi.Models;

namespace CalculatorApi.UnitTests.TheoryProviders
{
    /// <summary>
    /// Returns input for addition tests via ClassData
    /// </summary>
    public class MultiNumericInputProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new MultiInputModel
            {
                Inputs = new List<decimal>{ 1, 2, 3, 4, 5}
            }};

            yield return new object[] {new MultiInputModel
            {
                Inputs = new List<decimal>{ 2, 4, 6, 8, 10, 12, 14, 16}
            }};

            yield return new object[] {new MultiInputModel
            {
                Inputs = new List<decimal>{ 100, 200, 300, 400, 500}
            }};

            yield return new object[] {new MultiInputModel
            {
                Inputs = new List<decimal>{ 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
            }};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
