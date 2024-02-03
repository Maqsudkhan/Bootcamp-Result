

class Program
{
    static void Main()
    {
        int[] array = { 1,4,9542,8,59,85,7777,-985,575522,999999999 };

        BubbleSort(array, (item1, item2) => item1 > item2);

        Console.WriteLine("O'sish tartibida:");
        ConsolePrintArray(array);

        BubbleSort(array, (item1, item2) => item1 < item2);

        Console.WriteLine("\nKamayish tartibida:");
        ConsolePrintArray(array);


    }

    static void BubbleSort<Type>(Type[] array, Func<Type, Type, bool> mysorter)
    {
        int len = array.Length;
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = 0; j < len - i - 1; j++)
            {
                if (typeof(Type) == typeof(string))
                {


                }
                    if (mysorter(array[j], array[j + 1]))
                    {
                        Type temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
            }
        }
    }

    private static bool GetType<Type>(Type? type1, Type? type2)
    {
        throw new NotImplementedException();
    }

    static void ConsolePrintArray<Type>(Type[] array)
    {
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}






/*
public class Program
{
    public static List<int> BubbleSortUsish(List<int> myArray, Func<List<int>, List<int>> fanction) => fanction(myArray);
    public static List<int> BubbleSortKamayish(List<int> myArray, Func<List<int>, List<int>> fanction) => fanction(myArray);
    public static List<string> BubbleSortAlphabitical(List<int> myArray, Func<List<int>, List<string>> fanction) => fanction(myArray);
    static void Main(string[] args)
    {
        List<int> lst = [178, 100, 700, 4000, 56565, -5697, 77, 777778, 9];

        Func<List<int>, List<int>> SortUp = (arr) =>
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        };
        Func<List<int>, List<int>> SortDown = (arr) =>
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        };
        Func<List<int>, List<string>> SortUpForString = (arr) =>
        {
            List<string> newArr = new List<string>();
            for (int i = 0; i < arr.Count; i++)
                newArr.Add(arr[i].ToString());
            int n = newArr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(newArr[j], newArr[j + 1], StringComparison.Ordinal) > 0)
                    {
                        string temp = newArr[j];
                        newArr[j] = newArr[j + 1];
                        newArr[j + 1] = temp;
                    }
                }
            }
            return newArr;
        };



        *//*        BubbleSortUsish(lst, SortUp);
                foreach (int el in lst)
                {
                    Console.WriteLine(el);
                }*/


/*
        BubbleSortKamayish(lst, SortDown);
        foreach (int el in lst)
        {
            Console.WriteLine(el);
        }
*/


/*        List<string> AfterSortString = BubbleSortAlphabitical(lst, SortUpForString);
        foreach (string el in AfterSortString)
        {
            Console.WriteLine(el);
        }*//*

}


}

*/
