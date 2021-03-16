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
                AddBack(initArray[i]);
            }
        }

        public void AddBack(int value)
        {
            if (Length == _array.Length)
            {
                ReSizeArray(true);
            }

            _array[Length++] = value;
        }

        public void AddFront(int value)
        {
            if (Length == _array.Length)
            {
                ReSizeArray(true);
            }

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
                ReSizeArray(true);
            }

            for (int i = Length + 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[index] = value;
            Length++;
        }

        public void DeleteBack()
        {
            if (Length < _array.Length / 2)
            {
                ReSizeArray(false);
            }

            Length--;
        }

        public void DeleteFront()
        {
            if (Length <= _array.Length / 2)
            {
                ReSizeArray(false);
            }
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void DeleteOneByIndex(int index)
        {
            if (Length <= _array.Length / 2)
            {
                ReSizeArray(false);
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void DeleteNValuesBack(int nElements)
        {
            Length -= Length >= nElements ? nElements : Length;

            if (Length <= _array.Length / 2)
            {
                ReSizeArray(false);
            }
        }

        public void DeleteNValuesToFront(int nElements)
        {
            if (nElements > 0)
            {
                Length -= Length >= nElements ? nElements : Length;

                if (Length != 0 && Length <= _array.Length / 2)
                {
                    ReSizeArray(false);
                }
                for (int i = 0; i < Length; i++)
                {
                    _array[i] = _array[i + nElements];
                }

            }
        }

        public void DeleteSomeValuesByIndex(int nElements, int index)
        {
            if (Length / 2 == _array.Length)
            {
                ReSizeArray(false);
            }
            if (Length - index >= nElements)
            {
                Length -= nElements;

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

        public int IndexAccess(int index)
        {
            if (index < Length && index >= 0)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
        }

        public int FirstIndexByValue(int value)
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

        public int MaxIndexOfElement()
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

        public int MinIndexOfElement()
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

        public int MaxElement()
        {
            return _array[MaxIndexOfElement()];
        }

        public int MinElement()
        {
            return _array[MinIndexOfElement()];
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

        public void DeleteFirstValue(int value)
        {
            DeleteOneByIndex(FirstIndexByValue(value));
        }

        public int DeleteAllForValue(int value)
        {
            int count = 0;
            int index = FirstIndexByValue(value);

            while (index != -1)
            {
                DeleteOneByIndex(index);
                count++;
            }

            return count;
        }

        private void ReSizeArray(bool isUpOrDoun)
        {
            int newLength = isUpOrDoun ? (int)(_array.Length * 1.33d + 1) : (int)(_array.Length * 0.66d + 1);
            int[] tempArray = new int[newLength];
            for (int i = 0; i < Length; i++)
            {

                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
    }


}
