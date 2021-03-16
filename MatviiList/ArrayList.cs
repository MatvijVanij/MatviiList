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
                IncreaseTheArrayByAThird();
            }

            _array[Length++] = value;
        }

        public void AddFront(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseTheArrayByAThird();
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
                IncreaseTheArrayByAThird();
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
            if (Length == _array.Length / 2)
            {
                DecreaseTheArrayByAThird();
            }
            Length--;
        }

        public void DeleteFront()
        {
            if (Length <= _array.Length / 2)
            {
                DecreaseTheArrayByAThird();
            }
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void DeleteOneValuesByIndex(int index)
        {
            if (Length <= _array.Length / 2)
            {
                DecreaseTheArrayByAThird();
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }

            Length--;
        }

        public void DeleteSomeValuesBack(int quantity)
        {
            Length -= Length >= quantity ? quantity : Length;
            if (Length <= _array.Length / 2)
            {
                DecreaseTheArrayByAThird();
            }
        }

        public void DeleteSomeValuesToFront(int quantity)
        {
            if (quantity > 0)
            {
                Length -= Length >= quantity ? quantity : Length;
                if (Length == _array.Length)
                {
                    IncreaseTheArrayByAThird();
                }

                for (int i = quantity - 1; i < Length; --i)
                {
                    _array[i + 1] = _array[i];
                }
                Length++;
            }
        }


        public void DeleteSomeValuesByIndex(int quantity, int index)
        {
            if (Length / 2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int newlenght = Length - quantity;
            int[] tempArray = new int[newlenght];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = index; i < newlenght; i++)
            {
                tempArray[i] = _array[i - quantity];
            }
            _array = tempArray;
            Length = newlenght;
        }

        public void Reverse()
        {

        }

        private void IncreaseTheArrayByAThird()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DecreaseTheArrayByAThird()
        {
            int newLength = (int)(_array.Length * 0.66d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
        private void ResizeTheArrayByAThird(bool updoun)
        {
            int newLength = updoun ? (int)(_array.Length * 0.66d + 1) : (int)(_array.Length * 0.66d + 1);
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }

}
