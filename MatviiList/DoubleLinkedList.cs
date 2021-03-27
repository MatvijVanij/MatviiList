using System;
using System.Collections.Generic;
using System.Text;

namespace MatviiList
{
    public class DoubleLinkedList
    {
        private DoubleNode _root;

        private DoubleNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("");
                }
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _root;
        }

        public DoubleLinkedList(int[] values)
        {
            if (!(values is null))
            {
                Length = values.Length;

                if (values.Length != 0)
                {
                    DoubleNode node = new DoubleNode(values[0]);
                    _root = node;
                    _tail = _root;

                    for (int i = 1; i < values.Length; i++)
                    {
                        DoubleNode current = new DoubleNode(values[i]);
                        _tail.Next = current;
                        current.Previous = _tail;
                        _tail = _tail.Next;
                    }
                }
                else
                {
                    _tail = null;
                    _root = null;

                }
            }
            else
            {
                throw new NullReferenceException("Double List is null");
            }
        }

        public void AddLast(int value)
        {
            if (Length != 0)
            {
                DoubleNode node = new DoubleNode(value);

                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
                Length++;
            }
            else
            {
                Length = 1;
                _root = new DoubleNode(value);
                _tail = _root;
            }
        }

        public void AddLast(DoubleLinkedList list)
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
                throw new ArgumentException("null is list for add");
            }

        }

        public void AddFirst(int value)
        {
            if (Length != 0)
            {
                Length++;
                DoubleNode node = new DoubleNode(value);

                _root.Previous = node;
                node.Next = _root;

                _root = node;
            }
            else
            {
                Length = 1;
                _root = new DoubleNode(value);
                _tail = _root;
            }

        }

        public void AddFirst(DoubleLinkedList list)
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
                throw new ArgumentException("null is list for add");
            }

        }

        public void AddByIndex(int index, int value)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (Length != 0)
                    {
                        DoubleNode node = new DoubleNode(value);
                        if (index < Length / 2)
                        {
                            DoubleNode current = GetNodeByIndex(index - 1);

                            node.Next = current.Next;
                            current.Next.Previous = node;
                            current.Next = node;
                            node.Previous = current;
                        }
                        else
                        {
                            DoubleNode current = GetNodeByIndex(index);

                            node.Next = current;
                            node.Previous = current.Previous;
                            current.Previous = node;
                            node.Previous.Next = node;
                        }
                        Length++;

                    }
                    else
                    {
                        Length = 1;
                        _root = new DoubleNode(value);
                        _tail = _root;
                    }
                }
                else
                {
                    AddFirst(value);
                }

            }
            else
            {
                throw new IndexOutOfRangeException(" ");
            }
        }

        //public void AddByIndex(int index, DoubleLinkedList list)
        //{
        //    if (index >= 0 && index < Length)
        //    {
        //        if (index != 0)
        //        {
        //            if (Length != index)
        //            {
        //                DoubleNode current = GetNodeByIndex(index);
        //                list._tail = current.Next;
        //                current.Next.Previous = _tail;
        //                current.Next = list._root;
        //                list._root.Previous = current;


        //                Length += list.Length;

        //            }
        //            else
        //            {
        //                AddLast(list);
        //            }
        //        }
        //        else
        //        {
        //            AddFirst(list);
        //        }

        //    }
        //    else
        //    {
        //        throw new IndexOutOfRangeException("");
        //    }
        //}

        public void RemoveFirst()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                Length--;
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

        public void RemoveLast()
        {
            if (Length != 0)
            {
                if (Length != 1)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    Length--;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;

                }

            }
        }

        public void RemoveLast(int nElements)
        {
            if (Length != 0 && nElements != 0)
            {
                if (Length > nElements)
                {
                    _tail = GetNodeByIndex(Length - nElements - 1);
                    _tail.Next = null;
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

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (index != Length - 1)
                    {
                        DoubleNode current = GetNodeByIndex(index);
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Length--;
                    }
                    else
                    {
                        RemoveLast();
                    }

                }
                else
                {
                    RemoveFirst();
                }
            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if (index >= 0 && index < Length)
            {
                if (Length > nElements)
                {
                    if (Length > index + nElements)
                    {
                        if (index != 0)
                        {
                            DoubleNode currentFirst = GetNodeByIndex(index);
                            DoubleNode currentSecond = GetNodeByIndex(index + nElements);

                            currentFirst.Previous.Next = currentSecond;
                            currentSecond.Previous = currentFirst.Previous;
                            Length -= nElements;
                        }
                        else
                        {
                            RemoveFirst(nElements);
                        }
                    }
                    else
                    {
                        RemoveLast(nElements);
                    }
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public int GetIndexByValue(int value)
        {
            DoubleNode current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            GetNodeByIndex(index).Value = value;
        }

        public int FindMaxElement()
        {
            if (Length != 0)
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
            else
            {
                throw new ArgumentException("Length is 0 , no elements");
            }
        }

        public int FindMaxIndex()
        {
            int index = GetIndexByValue(FindMaxElement());

            return index;
        }

        public int FindMinElements()
        {
            if (Length != 0)
            {
                int min = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    if (min > GetNodeByIndex(i).Value)
                    {
                        min = GetNodeByIndex(i).Value;
                    }
                }
                return min;
            }
            else
            {
                throw new ArgumentException("Length list is  zero");
            }
        }

        public int FindMinIndex()
        {
            int index = GetIndexByValue(FindMinElements());
            return index;
        }

        //public void Revers()
        //{
        //    DoubleNode current = _root;
        //    DoubleNode tmp;

        //    for (int i = 0; i < Length-1; i++)
        //    {

        //        tmp = current.Next;
        //        current.Next = current.Previous;
        //        current.Previous = tmp;

        //        current = current.Next;
        //    }

        //    _root = _tail;
        //}

        public override bool Equals(object obj)
        {
            if (obj is DoubleLinkedList || obj is null)
            {
                DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;
                bool isflag = false;
                if (this.Length == doubleLinkedList.Length)
                {
                    isflag = true;

                    DoubleNode currentThis = this._root;
                    DoubleNode currentList = doubleLinkedList._root;
                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isflag = false;
                            break;
                        }
                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }
                return isflag;
            }
            throw new ArgumentException("obj is null");
        }

        public override string ToString()
        {
            if (Length != 0)
            {

                DoubleNode current = _root;

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

        private DoubleNode GetNodeByIndex(int index)
        {

            DoubleNode current;

            if (index <= Length / 2)
            {
                current = _root;

                for (int i = 1; i < index + 1; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _tail;

                for (int i = Length - 1; i > index; --i)
                {
                    current = current.Previous;
                }
            }
            return current;

        }

    }
}
