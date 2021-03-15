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

        public void InitializationArray(int[] initArray)
        {
            for (int i = 0; i < initArray.Length; i++)
            {
                AddingOneValuesToTheEnd(initArray[i]);
            }
        }

        public void AddingOneValuesToTheEnd(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseTheArrayByAThird();
            }
            _array[Length] = value;
            Length++;
        }

        private void IncreaseTheArrayByAThird()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);

            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
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
        public void AddingOneValuesToTheBeginning(int value)
        {
            if (Length == _array.Length)
            {
                IncreaseTheArrayByAThird();
            }
            int[] tempArray = new int[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                tempArray[i + 1] = _array[i];
            }
            tempArray[0] = value;
            _array = tempArray;
            Length++;
        }
        public void AddingOneValuesByIndex(int value, int index)
        {
            if (Length == _array.Length)
            {
                IncreaseTheArrayByAThird();
            }
            int[] tempArray = new int[Length + 1];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = index; i < Length; i++)
            {
                tempArray[i + 1] = _array[i];
            }
            tempArray[index] = value;
            _array = tempArray;
            Length++;
        }
        public void DeleteOneValuesToTheEnd()
        {
            if (Length / 2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int[] tempArray = new int[Length];
            for (int i = 0; i < Length - 1; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
            Length--;
        }
        public void DeleteOneValuesToTheBeginning()
        {
            if (Length / 2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int[] tempArray = new int[Length - 1];
            for (int i = 0; i < Length - 1; i++)
            {
                tempArray[i] = _array[i + 1];
            }
            _array = tempArray;
            Length--;
        }
        public void DeleteOneValuesByIndex(int index)
        {
            if (Length / 2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int[] tempArray = new int[Length - 1];
            for (int i = 0; i < index; i++)
            {
                tempArray[i] = _array[i];
            }
            for (int i = index; i < Length; i++)
            {
                tempArray[i] = _array[i + 1];
            }
            _array = tempArray;
            Length--;
        }
        public void DeleteSomeValuesToTheEnd(int quantity)
        {
            if (Length/2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int newlenght = Length - quantity;
            int[] tempArray = new int[newlenght];
            for (int i = 0; i < newlenght; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
            Length = newlenght;
        }
        public void DeleteSomeValuesToTheBeginning(int quantity)
        {
            if (Length/2 == _array.Length)
            {
                DecreaseTheArrayByAThird();
            }
            int newlenght = Length - quantity;
            int[] tempArray = new int[newlenght];
            for (int i = quantity; i < Length; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
            Length = newlenght;
        }
        public void DeleteSomeValuesByIndex(int quantity, int index)
        {
            if (Length/2 == _array.Length)
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
    }
}
