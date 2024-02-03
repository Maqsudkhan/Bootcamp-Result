using System.Collections;

namespace _21_12_2023
{
    public class MyCollection
    {
        private int[] array;
        private int LeftPointer;
        private int RightPointer;
        public MyCollection()
        {
            array = new int[10];
            LeftPointer = 0;
            RightPointer = 0;
        }

        public void Add(int value)
        {
            if(RightPointer == array.Length)
            {
                Array.Resize(ref array, array.Length*2);
            }
            array[RightPointer] = value;
            RightPointer ++;
        }

        public void RemoveFromStart()
        {
            LeftPointer++;
        }

        public void GetAllItems()
        {
            for (int i = LeftPointer; i < RightPointer; i++)
            {
                Console.WriteLine(array[i]);

            }
        }
        public void RemoveFromEnd()
        {
            if(RightPointer > LeftPointer)
            RightPointer--;
        }
    }
}
