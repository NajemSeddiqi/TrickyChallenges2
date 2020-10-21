using System;
using System.Collections.Generic;
using System.Linq;
using TestingStuff.Models;

namespace TestingStuff
{
    public class Node<T> : IChallenge where T : IComparable
    {
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public readonly T Data;
        private readonly List<Node<T>> List = new List<Node<T>>();
        private readonly IEnumerable<T> TreeData = new List<T>();

        public Node()
        {
        }

        public Node(T data)
        {
            Data = data;
            List.Add(this);
        }

        public void Insert(T data)
        {
            if (Data.CompareTo(data) == 1)
            {
                var curr = new Node<T>(data);
                if (Left != null)
                {
                    if (Left.Data.CompareTo(curr.Data) == 1)
                    {
                        Left.Left = curr;
                        List.Add(curr);
                    }
                    else
                    {
                        Left.Right = curr;
                        List.Add(curr);
                    }
                }
                else
                {
                    Left = new Node<T>(data);
                    List.Add(Left);
                }
            }

            if (Data.CompareTo(data) == -1)
            {
                var curr = new Node<T>(data);
                if (Right != null)
                {
                    if (Right.Data.CompareTo(curr.Data) == 1)
                    {
                        Right.Left = curr;
                        List.Add(curr);
                    }
                    else
                    {
                        Right.Right = curr;
                        List.Add(curr);
                    }
                }
                else
                {
                    Right = new Node<T>(data);
                    List.Add(Right);
                }
            }
        }


        private IEnumerable<Node<T>> GetList()
        {
            return List;
        }

        public IEnumerable<T> GetTreeData()
        {
            return GetList().OrderBy(x => x.Data).Select(x => x.Data);
        }

        public override string ToString()
        {
            return "Node: " + Data;
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