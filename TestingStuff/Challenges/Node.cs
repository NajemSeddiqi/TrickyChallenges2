using System;
using System.Collections.Generic;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff.Challenges
{
    /*
     * Create a generic class, Node<T> that can manage a binary search tree containing data of any type T
     * which implements the IComparable interface.
     * Tests include multiple data types all of which implement the IComparable interface.
     */
    public class Node<T> : IChallenge where T : IComparable
    {
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public readonly T Data;
        private readonly List<Node<T>> _list = new List<Node<T>>();

        public Node()
        {
        }

        public Node(T data)
        {
            Data = data;
            _list.Add(this);
        }

        public void Insert(T data)
        {
            if (Data.CompareTo(data) == 1)
                TraverseLeft(data);

            if (Data.CompareTo(data) != -1) return;

            TraverseRight(data);
        }

        private void TraverseLeft(T data)
        {
            var curr = new Node<T>(data);
            if (Left != null)
            {
                if (Left.Data.CompareTo(curr.Data) == 1)
                    Left.Left = curr;
                else
                    Left.Right = curr;

                _list.Add(curr);
            }
            else
            {
                Left = new Node<T>(data);
                _list.Add(Left);
            }
        }

        private void TraverseRight(T data)
        {
            var curr = new Node<T>(data);
            if (Right != null)
            {
                if (Right.Data.CompareTo(curr.Data) == 1)
                    Right.Left = curr;
                else
                    Right.Right = curr;

                _list.Add(curr);
            }
            else
            {
                Right = new Node<T>(data);
                _list.Add(Right);
            }
        }

        public IEnumerable<T> GetTreeData()
        {
            return _list.OrderBy(x => x.Data).Select(x => x.Data);
        }

        public void Show()
        {
            var root = new Node<int>(10);
            root.Insert(5);
            root.Insert(11);
            root.Insert(3);
            root.Insert(6);

            Console.WriteLine($"Left: {root.Left.Data}, Right: {root.Right.Data}");
            Console.WriteLine($"Data: {root.Data}");
            Console.WriteLine();

            foreach (var i in root.GetTreeData())
                Console.Write(i + ", ");
        }
    }
}