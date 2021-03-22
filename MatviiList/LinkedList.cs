using System;
using System.Collections.Generic;
using System.Text;

namespace MatviiList
{
    class LinkedList
    {
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 && index > Length)
                {
                    return GetNodeByIndex(index).Value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
            set
            {
                if (index < 0 && index > Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
        }

        private Node _root;

        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (values is null)
            {
                if (values.Length != 0)
                {
                    Length = values.Length;
                    _root = new Node(values[0]);
                    _root = _tail;

                    for (int i = 1; i < values.Length; i++)
                    {
                        _tail.Next = new Node(values[i]);
                        _tail = _tail.Next;
                    }
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }
            throw new NullReferenceException("no value in list");
        }

        public void AddLast(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public void AddFirst(int value)
        {
            Length++;
            _root.Next = new Node(value);
            _root = _root.Next;
        }

        private Node GetNodeByIndex(int index)
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override string ToString()
        {
            if (Length != 0)
            {


                Node current = _root;
                string str = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    str += current.Value + " ";
                }
                return str;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
