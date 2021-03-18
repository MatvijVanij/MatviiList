using System;
using System.Collections.Generic;
using System.Text;

namespace MatviiList
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public int this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int element)
        {
            Length = 1;

            _array = new int[10];
            _array[0] = element;
        }

        public ArrayList(int[] initArray)
        {
            Length = 0;
            _array = new int[initArray.Length];

            for (int i = 0; i < initArray.Length; i++)
            {
                Add(initArray[i]);
            }
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                Resize(Length);
            }

            _array[Length++] = value;
        }

        public void AddFront(int value)
        {
            if (Length == _array.Length)
            {
                Resize(Length);
            }

            //SwapInOf(0, 1);
            for (int i = Length; i <= 0; --i)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = value;
            Length++;
        }

        public void AddByIndex(int value, int index)
        {
            if (Length >= _array.Length)
            {
                Resize(Length);
            }

            //SwapInOf(index, index + 1);
            for (int i = Length + 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = value;
            Length++;
        }

        public void RemoveBack()
        {
            if (Length <= _array.Length / 2)
            {
                Resize(Length);
            }

            Length--;
        }

        public void RemoveFront()
        {
            if (Length <= _array.Length / 2)
            {
                Resize(Length);
            }

            //SwapInOf(0, 1);
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void RemoveByIndex(int index)
        {
            if (Length <= _array.Length / 2)
            {
                Resize(Length);
            }
            //SwapInOf(index, index + 1);
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void RemoveBack(int nElements)
        {
            Length -= Length >= nElements ? nElements : Length;

            if (Length - nElements <= _array.Length / 2)
            {
                Resize(Length);
            }
        }

        public void RemoveFront(int nElements)
        {
            if (nElements > 0)
            {
                Length -= Length >= nElements ? nElements : Length;

                if (Length != 0 && Length - nElements <= _array.Length / 2)
                {
                    Resize(Length);
                }
                //SwapInOf(0, nElements);
                for (int i = 0; i < Length; i++)
                {
                    _array[i] = _array[i + nElements];
                }

            }
        }

        public void RemoveByIndex(int nElements, int index)
        {
            if (Length / 2 == _array.Length)
            {
                Resize(Length);
            }
            if (Length - index >= nElements)
            {
                Length -= nElements;

                //SwapInOf(index, index + nElements);
                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + nElements];
                }
            }
            else
            {
                Length = index;
            }
        }

        public void ReternLength()
        {
        }

        public int GetValueByIndex(int index)
        {
            if (index < Length && index >= 0)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
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

        public void ChangeByIndex(int value, int index)
        {
            if (index < Length && index >= 0)
            {

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void Revers()
        {
            int swapIndex;
            for (int i = 0; i < Length / 2; i++)
            {
                swapIndex = Length - i - 1;
                Swap(ref _array[i], ref _array[swapIndex]);
            }
        }

        public int GetMaxIndex()
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

        public int GetMinIndex()
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

        public int Max()
        {
            return _array[GetMaxIndex()];
        }

        public int Min()
        {
            return _array[GetMinIndex()];
        }

        public void SortIncrease(int array)
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

        public void SortDecrease(int array)
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

        public void RemoveByValue(int value)
        {
            RemoveByIndex(GetIndexByValue(value));
        }

        public int RemoveAllByValue(int value)
        {
            int count = 0;
            int index = GetIndexByValue(value);

            while (index != -1)
            {
                RemoveByIndex(index);
                count++;
            }

            return count;
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
            if (obj is ArrayList)
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
            else
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }
        }

        private void Resize(int newLength)
        {
            if (newLength >= _array.Length)
            {
                newLength = (int)(newLength * 1.33d + 1);
                newArray(newLength);
            }
            else if ((newLength <= _array.Length / 2) && (newLength > 10))
            {
                newLength = (int)(newLength * 0.66d + 1);
                newArray(newLength);
            }
            else if (newLength < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void newArray(int newLength)
        {
            if (newLength >= 0)
            {
                int[] tempArray = new int[newLength];

                for (int i = 0; i < Length; ++i)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private static void Swap(ref int indexI, ref int indexJ)
        {
            int c = indexI;
            indexI = indexJ;
            indexJ = c;
        }

        //private void SwapInOf(int firstIndex, int lastIndex)
        //{
        //    for (int i = firstIndex; i < Length; i++)
        //    {
        //        _array[i] = _array[lastIndex];

        //        lastIndex++;
        //    }
        //}

    }


}
