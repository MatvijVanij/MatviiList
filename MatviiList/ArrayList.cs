using System;
using System.Collections.Generic;
using System.Text;

namespace MatviiList
{
    public class ArrayList
    {

        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int el)
        {
            Length = 0;
            _array = new int[10];

            AddFirst(el);
        }

        public ArrayList(int[] initArray)
        {
            if (!(initArray == null))
            {
                Length = 0;
                _array = new int[initArray.Length];

                for (int i = 0; i < initArray.Length; i++)
                {
                    AddLast(initArray[i]);
                }
            }
            else
            {
                throw new ArgumentException("Ti she duurak? kuda null pihaech?");
            }
        }

        public int this[int index]
        {
            get
            {
                return _array[index];
            }

            set
            {
                if (!(index >= Length || index <= 0))
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }

        public void AddLast(int value)
        {
            Resize(Length);

            _array[Length++] = value;
        }
        public void AddLast(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;

            Resize(oldLength);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[oldLength + i] = list[i];
            }

        }

        public void AddFirst(int value)
        {
            Resize(Length);

            Length++;
            ShiftRight(0, 1);

            _array[0] = value;
        }
        public void AddFirst(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;
            Resize(oldLength);
            ShiftRight(list.Length - 1, list.Length);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[i] = list[i];
            }
        }


        public void AddByIndex(int index, int value)
        {
            if (index >= 0 && index <= Length)
            {
                Resize(Length);

                Length++;
                ShiftRight(index, 1);

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void AddByIndex(int index, ArrayList list)
        {
            if (index < Length && index >= 0)
            {
                int oldLength = Length;
                Length += list.Length;
                Resize(oldLength);
                ShiftRight(index + list.Length - 1, list.Length);

                for (int i = 0; i < list.Length; ++i)
                {
                    _array[i + index] = list[i];
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast()
        {
            if (!(Length == 0))
            {
                Length--;
            }

            Resize(Length);
        }

        public void RemoveFirst()
        {
            if (!(Length == 0))
            {
                Length--;
                ShiftLeft(0, 1);
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (!(Length == 0))
                {
                    Length--;
                    ShiftLeft(index, 1);
                }

                Resize(Length);
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void RemoveLast(int nElelements)
        {
            if (Length >= nElelements)
            {
                if (nElelements >= 0)
                {

                    Length -= nElelements;
                }
            }
            else
            {
                Length = 0;
            }

            Resize(Length);

        }

        public void RemoveFirst(int nElelements)
        {
            if (!(Length <= nElelements))
            {
                if (nElelements >= 0)
                {
                    Length -= nElelements;
                    ShiftLeft(0, nElelements);
                }
            }
            else
            {
                Length = 0;
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index, int nElelements)
        {
            if (Length - index >= nElelements)
            {
                Length -= nElelements;
                ShiftLeft(index, nElelements);
            }
            else
            {
                Length = index;
            }

            Resize(Length);
        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Revers()
        {
            int temp;
            int swapIndex;
            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                temp = _array[i];

                _array[i] = _array[swapIndex];
                _array[swapIndex] = temp;
            }
        }

        public int FindMaxIndex()
        {
            int maxIndexOfElement = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[maxIndexOfElement] < _array[i])
                {
                    maxIndexOfElement = i;
                }
            }

            return maxIndexOfElement;
        }

        public int FindMinIndex()
        {
            int minIndexOfElement = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[minIndexOfElement] > _array[i])
                {
                    minIndexOfElement = i;
                }
            }

            return minIndexOfElement;
        }

        public int FindMaxElement()
        {
            return _array[FindMaxIndex()];
        }

        public int FindMinElement()
        {
            return _array[FindMinIndex()];
        }

        public void RemoveByValue(int value)
        {
            RemoveByIndex(GetIndexByValue(value));
        }

        public void RemoveAllByValue(int value)
        {
            int indexOfElements = GetIndexByValue(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }
        }


        public void SortIncrease()
        {
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public void SortDecrease()
        {
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] < _array[j])
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public void ZAdd(ArrayList list)
        {
            int oldLenght = Length;
            Length += list.Length;
            Resize(oldLenght);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[oldLenght + i] = list[i];
            }
        }

        public void ZAddFirst(ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;
            Resize(oldLength);
            ShiftRight(list.Length - 1, list.Length);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[i] = list[i];
            }
        }
        public void ZAddByIndex(int index, ArrayList list)
        {
            int oldLength = Length;
            Length += list.Length;
            Resize(oldLength);
            ShiftRight(index, list.Length);

            for (int i = 0; i < list.Length; ++i)
            {
                _array[i + index] = list[i];
            }
        }

        public override string ToString()
        {
            string str = " ";
            for (int i = 0; i < Length; i++)
            {
                str += _array[i] + " ";
            }
            return str;
        }

        public override bool Equals(object obj)
        {
            ArrayList List = (ArrayList)obj;
            if (this.Length != List.Length)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != List._array[i])
                {
                    return false;
                }
            }

            return true;
        }
        private void Resize(int oldLength)
        {
            if ((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[newLength];

                for (int i = 0; i < oldLength; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        private static void Swap(ref int indexI, ref int indexJ)
        {
            int c = indexI;
            indexI = indexJ;
            indexJ = c;
        }

        //shift to the right ------->
        private void ShiftRight(int index, int nElements)
        {

            for (int i = Length - 1; i > index; i--)
            {
                _array[i] = _array[i - nElements];
            }
        }

        // left shift    <-------
        private void ShiftLeft(int index, int nElements)
        {

            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + nElements];
            }

        }


    }
}



