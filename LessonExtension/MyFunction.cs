
namespace LessonExtension
{
    static class MyFunction
    {
        public static void ConsolgaChiqar(this string value)
        {
            Console.WriteLine(value);
        }

        public static int Kvadrat(this int value)
        {
            return value * value;
        }

    }

}
