using System.Collections;
using System.Collections.Generic;

namespace Vip.Extensions.Tests.Helpers
{
    public class TestNotNegativeInteger : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {-1},
            new object[] {-2},
            new object[] {-10}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}