

/*
using System;
namespace dot_net_uz
{
    class Program
    {
        // params parametrni o'z ichiga olgan metod
        // object turidagi parametrlardan foydalanilgan funksiya
        public static void Print(params object[] royxat)
        {
            for (int i = 0; i < royxat.Length; i++)
            {
                // Natijalarni chop etish
                Console.WriteLine(royxat[i]);
            }
        }
        static void Main(string[] args)
        {
            object[] obj = new object[] { "hamroliyev", 'a', 19, 9, 12.8 };
            Console.WriteLine("1-usul:");
            //Print metodini chaqiramiz.
            Print(obj);
            Console.WriteLine();

            Console.WriteLine("2-usul:");
            //Print metodini chaqiramiz.
            Print(19, "dot-net", 20, "Hamroliyev");

            Console.WriteLine("3-usul:");
            Print();
            Console.ReadKey();
        }
    }
}*/






/*int[,] arr = new int[2, 5];
Random rand = new Random();
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 5; j++)
    {
        arr[i, j] = rand.Next(1, 10);
    }
}


for (int i = 0;i < 2; i++)
{
    for(int j = 0;j < 5; j++)
    {
        Console.Write(" " +  arr[i, j]);
    }
    Console.WriteLine();
}
*/






/*void chiqar (params int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write("  " + item);
    }
}
chiqar(999, 5, 8,11, 6, 74, -99, 9, 55, 7, 85, 8, 77);
*/


//ternary operator
/*int a = 5, b = 6;
string x = "hello", y = "saalom", c;
Console.WriteLine(a > b ? x : y); */


//switch

/*int day = int.Parse(Console.ReadLine()); 

switch (day)
{
    case 1: Console.WriteLine("dushanba");        
        break;
    case 2: Console.WriteLine("sewanba");        
        break;
    case 3: Console.WriteLine("chorshanba");       
        break;
    case 4: Console.WriteLine("payshanba");        
        break;
    case 5: Console.WriteLine("juma");        
        break;
    case 6: Console.WriteLine("shanba");     
        break;
    case 7: Console.WriteLine("yakshanba");
        break;
    default: Console.WriteLine("Bunday kun yuq!");
        break;
}*/


// new switch
/*int day = int.Parse(Console.ReadLine());
string result = day switch
{
    1 => "Dushanba",
    2 => "Seshanba",
    3 => "Chorshanba",
    4 => "Payshanba",
    5 => "Juma",
    6 => "Shanba",
    7 => "Yakshanba",
    _=> "Wrong day"
};
Console.WriteLine(result);*/



// for
/*for( int i = 1; i <= 10; i++ )
{
    Console.Write(i + " ");
}*/



// while 
/*int i = 1;
while(i <= 10) // i != 11
{
    Console.Write(i + " ");
    i++;
}*/



// do while
/*int i = 1;
do
{
    Console.Write(i + " ");
    i++;
} while (i != 11); // i<11
*/



// foreach
/*int[] numbers = { 1, 2, 3, 4, -9, 7, 8, 1, 8 };
foreach (var number in numbers)
{
    Console.Write(number + " ");
}
*/



// continue
/*for (int i = 1; i <= 10; i++)
{
    if (i == 7) continue;
    Console.Write(i + " ");
}*/



// goto
/*bool a = false;
string say = "goto ishlayapti!";
key:
if (a)
{
    Console.WriteLine(say);
}
if (a==false)
{
    a = true;
    goto key;
    Console.WriteLine("goto ishlamayapti!");
}*/




/*int n = 0;
if (n == 0)
{
    while (true)
    {
        if (n == 10)
        {
            goto key;
        }
        n += 2;
    }
}
Console.WriteLine("Asosiy");
while (true)
{
    Console.WriteLine("Salom");
}
key:
Console.WriteLine("Qalaysiz!");*/


/*if (true)
{
    goto key;
}
Console.WriteLine("123");

key:
Console.WriteLine("hello");
*/




// qiymat qayataradigan function
/*int max (int a, int b)
{
    int maxx;
    if (a > b) maxx = a;
    else maxx = b;
    return maxx;
}
Console.WriteLine(max(-9, 8));
*/



/*class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxFunc(77, 88));
    }
    static int MaxFunc(int x, int y)
    {
        if (x > y) return x;
        else return y;
    }

}*/



// qiymat qaytarmaydigan function
/*void chiqar(string txt, int n)
{
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"{i + 1}-{txt}");
    }
}
chiqar("Maqsudkhan", 7);*/


/*class Program
{
    static void Main(string[] args)
    {
        chiqar("Hello Maqsudkhan", 3);
    }
    static void chiqar(string word, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i+1}.{word}");
        }
    }
}*/




/*void swapp( int a, int b)
{
    int k = a;
    a = b;
    b = k;
    Console.WriteLine($"{a} {b}");
}
swapp(8, 5);*/



// ref kalit so'zidan foydalansh
/*
class Program
{
    static void Main(string[] args)
    {
        int x = 8, y = 5;
        Swap(ref x, ref y);
        Console.WriteLine($"{x}, {y} ");
    }
    static void Swap(ref int x, ref int y)
    {
        int k = x;
        x = y;
        y = k;
    }
}
*/




// out parametri
/*void kvadrat(float a, out float s, out float p, out float r)
{
    s = a * a;
    p = 4 * a;
    r = a / 2;
    Console.WriteLine($"S = {s}\nP = {p}\nR = {r}");
}
kvadrat(8, out float s, out float p, out float r);
Console.WriteLine("Yuza = " + s);*/



/*class Programm
{
    static void Main(string[] args)
    {
        kvadrat(10, out float s, out float p, out float r);
        Console.WriteLine("Yuzaning 4/1 qismi = " + s/4);
    }

    static void kvadrat(float a, out float s, out float p, out float r)
    {
        s = a * a;
        p = 4 * a;
        r = a / 2;
        Console.WriteLine($"S = {s}\nP = {p}\nR = {r}");
    }
}
*/




// statik massivlar
/*int[] massivInt = { 1, 2, 8, 9, 7, -8, -7, 8 };
string[] massivString = { "hello", "good", "bad", "angry", "agree" };
double[] massivDouble = { 0.007, -0.007, 0.7, 78, -98, 0.000000000001 };
foreach(var  massiv in massivDouble)
{
    Console.Write(massiv + "  ");
}
*/




// dinamik massivlar
/*int n = 10;
int[] massivInt = new int[4];
string[] massivString = new string[20];
double[] massivDouble = new double[n];

massivInt[0] = 1;
massivInt[1] = 2;
massivInt[2] = 3;
massivInt[3] = 4;
//foreach(int i in massivInt) Console.WriteLine(i);

for (int i = 0; i < 10; i++)
{
    Console.Write($"{i}-index: ");
    massivDouble[i] = double.Parse(Console.ReadLine());
}
foreach (var item in massivDouble) Console.Write(item + "  ");*/





// Funksiyalarda massivlardan foydalanish

/*int[] Range(int start, int end)
{
    int[] range = new int[end - start];
    int k = 0;
    for(int i = start; i < end; i++)
    {
        range[k++] = i;
    }
    return range;
}
Console.WriteLine(Range(1, 10).Sum());*/




/*void Sort(int[] massiv)
{
    int x;
    for(int i =  0; i < massiv.Length - 1; i++)
    {
        for(int j = i + 1; j < massiv.Length; j++ )
        {
            if (massiv[j] < massiv[i])
            {
                x = massiv[i];
                massiv[i] = massiv[j];
                massiv[j] = x;
            }
        }
    }
}

int[] massiv = { 11, 2, 108, 9, 7, -8, -7, 8 };
Sort(massiv);
foreach(var i in massiv) Console.Write(i + " ");

Console.WriteLine();
Console.WriteLine(massiv[0]);
*/



//ko'p o'lchanli massivlar

/*int[,] nums2 = new int[2, 3] { { 1,2,3}, { 4,5,6} };
int[,] nums3 = new int[,] { { 1, 2 }, { 3, 4 }, { 4, 5 }, { 6, 7 } };

int[,] myArray = new int[4, 6];
Random rand = new Random();
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 6; j++)
    {
        myArray[i, j] = rand.Next(10, 100);
        Console.Write("{0}\t", myArray[i, j]);
    }
    Console.WriteLine();
}
*/




int[,] myArr = new int[3, 4];
Random random = new Random();

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        myArr[i, j] = random.Next(3, 5);
        Console.Write("{0}\t", myArr[i, j]);
    }
    Console.WriteLine();
}

int sum = 0;
double average = 0.0d;
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        sum += myArr[i, j];
    }
}

average = Convert.ToDouble(sum) / 12;
Console.WriteLine($"Sinfning umumiy bahosi: {sum}");
Console.WriteLine($"Sinfning o'rtacha bahosi: {average}");























