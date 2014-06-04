using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType
{
    public class Either<T,U>
    {
        private readonly bool _typeIsT;
        private readonly T _t;
        private readonly U _u;

        public static implicit operator Either<T, U>(T value)
        {
            return new Either<T, U>(value);
        }

        public static implicit operator Either<T, U>(U value)
        {
            return new Either<T, U>(value);
        }

        public V Reduce<V>(Func<T, V> func1, Func<U, V> func2)
        {
            if (_typeIsT)
            {
                return func1(_t);
            }

            return func2(_u);
        }

        public Either(T value)
        {
            _typeIsT = true;
            _t = value;
        }

        public Either(U value)
        {
            _typeIsT = false;
            _u = value;
        }
    }

    public class Either<T, U, V>
    {
        private enum Tag { T, U, V }

        private readonly Tag _tag;
        private readonly T _t;
        private readonly U _u;
        private readonly V _v;

        public W Join<W>(Func<T, W> func1, Func<U, W> func2, Func<V, W> func3)
        {
            switch (_tag)
            {
                case Tag.T:
                    return func1(_t);
                case Tag.U:
                    return func2(_u);
                case Tag.V:
                    return func3(_v);
                default:
                    throw new InvalidOperationException(string.Format("Unknown internal Tag state of Tag.{0}", _tag));
            }
        }

        public Either(T value)
        {
            _tag = Tag.T;
            _t = value;
        }

        public Either(U value)
        {
            _tag = Tag.U;
            _u = value;
        }

        public Either(V value)
        {
            _tag = Tag.V;
            _v = value;
        }
    }

    public class Either<T, U, V, W>
    {
        private enum Tag { T, U, V, W }

        private readonly Tag _tag;
        private readonly T _t;
        private readonly U _u;
        private readonly V _v;
        private readonly W _w;

        public X Reduce<X>(Func<T, X> func1, Func<U, X> func2, Func<V, X> func3, Func<W, X> func4)
        {
            switch (_tag)
            {
                case Tag.T:
                    return func1(_t);
                case Tag.U:
                    return func2(_u);
                case Tag.V:
                    return func3(_v);
                case Tag.W:
                    return func4(_w);
                default:
                    throw new InvalidOperationException(string.Format("Unknown internal Tag state of Tag.{0}", _tag));
            }
        }

        public Either(T value)
        {
            _tag = Tag.T;
            _t = value;
        }

        public Either(U value)
        {
            _tag = Tag.U;
            _u = value;
        }

        public Either(V value)
        {
            _tag = Tag.V;
            _v = value;
        }

        public Either(W value)
        {
            _tag = Tag.W;
            _w = value;
        }
    }
}
 