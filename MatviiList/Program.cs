using System;

namespace MatviiList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            int[] ar = new int[] { 1, 4, 5, 7, 8, 9, 0 };
            ArrayList arrayList = new ArrayList(ar);
            arrayList.GetType();
           
        }
    }
}
