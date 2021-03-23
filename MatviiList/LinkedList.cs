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

                return GetNodeByIndex(index).Value;
               
            }
            set
            {
                if (index >= 0 && index <= Length)
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
            if (Length != 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root;
            }
        }

        public void AddLast(LinkedList list)
        {
            if (!(list is null))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    AddLast(list[i]);
                }
            }
            else
            {
                throw new ArgumentException("");
            }
        }

        public void AddFirst(int value)
        {
            Length++;
            Node node = new Node(value);
            node.Next = _root;
            _root = node;
        }

        public void AddFirst(LinkedList list)
        {
            if (!(list is null))
            {
                for (int i = list.Length - 1; i >= 0; i--)
                {
                    AddFirst(list[i]);
                }
            }
            else
            {
                throw new ArgumentException("");
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                if (Length != 0)
                {
                    Node node = new Node(value);
                    Node current = GetNodeByIndex(index - 1);

                    node.Next = current.Next;
                    current.Next = node;
                }
                else
                {
                    _root = new Node(value);
                    _tail = _root;
                }
                Length++;
            }
        }

        public void AddByIndex(int index, LinkedList list)
        {
            if (index != 0)
            {
                if (list.Length != 0)
                {

                    Node current = GetNodeByIndex(index - 1);

                    list._tail.Next = current.Next;
                    list._tail = _tail;
                    _tail = current;

                    int newLengthList = list.Length + Length - index;
                    Length = index;

                    for (int i = 0; i < newLengthList; i++)
                    {
                        AddLast(list[i]);
                    }
                }
            }
            else
            {
                AddFirst(list);
            }

        }

        public void RemoveLast()
        {
            RemoveByIndex(Length - 1);
        }

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                --Length;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                if (Length != 0)
                {
                    if (Length != 1)
                    {
                        Node current = GetNodeByIndex(index - 1);
                        current.Next = current.Next.Next;
                        _tail = current;

                    }
                    else
                    {
                        _root = null;
                        _tail = null;
                    }
                    Length--;
                }
            }
        }

        public void RemoveLast(int nElements)
        {
            if (Length != 0)
            {
                if (Length > nElements)
                {
                    Length -= nElements;
                    _tail = GetNodeByIndex(Length - 1);
                    _tail.Next = null;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (Length != 0)
            {
                if (Length > nElements)
                {
                    _root = GetNodeByIndex(nElements);
                    Length -= nElements;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if (Length != 0)
            {
                if (Length - nElements > 0)
                {
                    if (index != 0)
                    {
                        Node indexNode = GetNodeByIndex(index - 1);
                        Node nElementNode = GetNodeByIndex(index + nElements);
                        indexNode.Next = nElementNode;
                        Length -= nElements;
                    }
                    else
                    {
                        RemoveFirst(nElements);
                    }
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }

        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            GetNodeByIndex(index).Value = value;
        }

        public void Revers()
        {
            Node _tail = null, current = _root, Next = null;
            while (current != null)
            {
                Next = current.Next;
                current.Next = _tail;
                _tail = current;
                current = _tail;
            }
            _root = _tail;
        }

        public int FindMaxIndex()
        {
            int index = GetIndexByValue(FindMaxElement());
            return index;
        }

        public int FindMaxElement()
        {
            int max = _root.Value;

            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value > max)
                {
                    max = GetNodeByIndex(i).Value;
                }
            }
            
            return max;
        }

        public int FindMinIndex()
        {
           int index = GetIndexByValue(FindMinElement());

            return index;
        }

        public int FindMinElement()
        {
            int min = _root.Value;

            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value < min)
                {
                    min = GetNodeByIndex(i).Value;
                }
            }
            return min;
        }
        public void SortIncrease()
        {

        }
        public void SortDecrease()
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
            if (obj is LinkedList || obj is null)
            {

                LinkedList list = (LinkedList)obj;
                bool iseqvel = false;

                if (this.Length == list.Length)
                {
                    iseqvel = true;

                    Node currentThis = this._root;
                    Node currentList = list._root;

                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            iseqvel = false;
                            break;
                        }
                        currentList = currentList.Next;
                        currentThis = currentThis.Next;

                    }
                }
                return iseqvel;
            }
            throw new ArgumentException("obj is null");
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

