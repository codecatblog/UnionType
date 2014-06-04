using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType
{
    public class Examples
    {
        public void ExampleCode()
        {
            var tree = new Node<string>("root");

            var tree2 = new Node<string>("root", "left", "right");

            var tree3 = new Node<string>("root", new Node<string>("1", "a", "b"), "d");
        }


        public class Node<T> : Either<Empty, Tuple<T, Node<T>, Node<T>>> // Node := Empty | int * Node * Node
        {
            public static implicit operator Node<T>(Empty empty)
            {
                return new Node<T>(empty);
            }

            public static implicit operator Node<T>(T t)
            {
                return new Node<T>(t, Empty.Empty, Empty.Empty);
            }

            public IEnumerable<T> Traverse()
            {
                return this.Reduce<IEnumerable<T>>(
                    // Base case
                    t => new T[] {}, 
                    // Recursive step
                    tuple => new T[] { tuple.Item1 }.Concat(tuple.Item2.Traverse()).Concat(tuple.Item3.Traverse()));
            }

            public Node(Empty empty) : base(empty)
            {
            }

            public Node(T value) : base(new Tuple<T, Node<T>, Node<T>>(value, Empty.Empty, Empty.Empty))
            {
            }

            public Node(T value, Node<T> left, Node<T> right) : base(new Tuple<T, Node<T>, Node<T>>(value, left, right))
            {
            }
        }

        public enum Empty { Empty }
    }
}
