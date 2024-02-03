/*Console.WriteLine("Hello, \"Maqsudkhan!\"");
Console.Write("Hello, \"Maqsudkhan!\"");
Console.Write("Hello, \"Maqsudkhan!\"");
*/

/*// implicit casting
int value = 45;
double value1 = value;

//expilicit casting
double value2 = 45.666;
int value3 = (int)value2;
int a = value2;*/



//                                   Homework!!!

/*//boolean 34
Console.Write("x ni kiritng: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("y ni kiritng: ");
int y = Convert.ToInt32(Console.ReadLine());

if ((x + y) % 2 == 0)
{
    Console.WriteLine("Qora");
}
else
{
    Console.WriteLine("Oq");
}
*/





/*
Console.Write("Nuqtalar sonini kiriting: ");
int n = int.Parse(Console.ReadLine());
double[][] lst = new double[n][];

for (int i = 0; i < n; i++)
{
    Console.Write($"{"x"+(i+1)} ni kiriting: ");
    double x = double.Parse(Console.ReadLine()); 
    Console.Write($"{"y"+(i+1)} ni kiriting: ");
    double y = double.Parse(Console.ReadLine());
    lst[i] = [x, y];
}

double MaxElement = double.MaxValue;
for (int i = 0; i < n-1; i++)
{
    for (int j = 0; j < n; j++)
    {
        double masofa = Math.Sqrt(Math.Pow(lst[i][0] - lst[j][0], 2) + Math.Pow(lst[i][1] - lst[j][1], 2));
        if (MaxElement > masofa && i != j) MaxElement = masofa;
    }
}
Console.WriteLine($"Eng yaqin masofa => {MaxElement}");*/








//// 1
/*Console.Write("Istalgan butun son kiriting: ");
int x = Convert.ToInt32(Console.ReadLine());
var result = 0;
var a = 0;
while (x != 0)
{
    a = result;
    result = result * 10 + x % 10;
    x = x / 10;
}
Console.WriteLine(result / 10 == a ? result : 0);*/




/*////2
Console.Write("Nechinchi Fibanachi kerak: ");
int n = int.Parse(Console.ReadLine());
var f1 = 0;
var f2 = 1;
for (var i = 0; i < n; i++)
{
    f2 = f1 + f2;
    f1 = f2 - f1;
}
Console.WriteLine(f1);*/


/*//3

var dict = new Dictionary<char, int>() 
    {
    {'I', 1 },
    {'V' , 5},
    {'X' , 10},
    {'L' , 50},
    {'C' , 100},
    {'D' , 500},
    {'M'  , 1000}
        };

int sum = 0;
int i = 0;
string str = "LVIII" + "I";

while (i < str.Length-1)
{
    if (dict[str[i]] < dict[str[i + 1]])
    {
        sum += dict[str[i]] - dict[str[i + 1]];
        i += 2;
    }
    else
    {
        sum += dict[str[i]];
        i += 1;
    }
}  
Console.WriteLine(sum);*/






/*//4
Console.Write("Son kiriting: " );
int num = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 1; i <= num / 2; i++)
{
    if (num % i == 0)
    {
        sum += i;
    }
}
Console.WriteLine(num == sum ? true : false);*/



//int[][] myarray = new int[][]



//int[,] myarray = { { 1, 2, 3 }, { 4, 5, 6 } };
//Console.WriteLine(myarray[1,0]);



/*
int[][] myJaggedArray = new int[4][];

myJaggedArray[0] = new int[] { 1, 2, 6 };
myJaggedArray[1] = new int[] { 1, 2, 6, 56, 3, 1 };
myJaggedArray[2] = new int[] { 1, 1 };
myJaggedArray[3] = new int[] { 1, 1, 34, 434, 34, 3, 4, 34, 3, 43, 43 };

Console.WriteLine(myJaggedArray[1][3]);
Console.WriteLine(myJaggedArray[3][4]);*/





/*char[] str = ['h', 'e', 'l', 'l', 'o'];
char[] new_str = new char[str.Length];
int j = 0;
for (int i = str.Length-1; i >= 0; )
{
    new_str[j] = str[i];
    i--;
    j++;
}



Console.WriteLine(new_str);*/







/// 1-usul
/*int? a = null; 
int? b = 77; 
int c=0;
if (a == null)
{
    if (b == null) Console.WriteLine("null");
    else c = (int)b;
} 
else c = (int)a;Console.WriteLine(c);*/



///2-usul
/*int? x = 11;
int? y = null;
int? z = x ?? y;
Console.WriteLine(z);*/