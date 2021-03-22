using System;
using System.Collections.Generic;
using System.Text;

namespace MatviiList
{
    public class LinkedList
    {
        private Node _root;

        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 && index >= Length)
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
                if (index < 0 && index >= Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
        }

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
            if (!(values is null))
            {
                Length = values.Length;

                if (values.Length != 0)
                {

                    _root = new Node(values[0]);
                    _tail = _root;

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
            else
            {
                throw new NullReferenceException();
            }

        }

        public void AddLast(int value)
        {
            Length++;
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }

        public void AddFirst(int value)
        {
            Node node = new Node(value);
            _root.Value = value;
            _root.Next = node;
            Length++;

        }

        public void AddByIndex(int index, int value)
        {
            Length++;
            Node current = GetNodeByIndex(index);
            Node tmp = current.Next;
            current = new Node(value);
            current.Next = tmp;

        }

        public void RemoveLast()
        {
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                Length--;
            }
        }

        public void RemoveByIndex(int index)
        {
            Node current = GetNodeByIndex(index);
            current.Next = current.Next.Next;
            Length--;
        }

        public void RemoveLast(int nElements)
        {
        }

        public void RemoveFirst(int nElements)
        {
        }

        public void RemoveByIndex(int index, int nElements)
        {
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
            LinkedList list = (LinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            Node currentThis = this._root;
            Node currentList = list._root;

            if (currentList.Next == null && currentThis.Next == null && currentThis.Value == currentList.Value)
            {
                return true;
            }
            else
            {
                do
                {
                    if (currentThis.Value != currentList.Value)
                    {
                        return false;
                    }
                    currentList = currentList.Next;
                    currentThis = currentThis.Next;

                }
                while (!(currentThis.Next is null));
            }
            return true;
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

    }
}
