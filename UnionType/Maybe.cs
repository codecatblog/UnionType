using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType
{
    public class Maybe<T> where T : class
    {
        private readonly bool _hasValue;
        private readonly T _value;

        public V Reduce<V>(Func<T, V> func1, Func<V> func2)
        {
            if (_hasValue)
            {
                return func1(_value);
            }

            return func2();
        }

        public Maybe()
        {
        }

        public Maybe(T value)
        {
            _hasValue = true;
            _value = value;
        }
    }
}
