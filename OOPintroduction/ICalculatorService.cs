
using OOPintroduction;
using System.Numerics;

namespace OOPintroduction
{
    internal interface ICalculator<GenericType>
    {
        GenericType qushish(GenericType x, GenericType y);
        GenericType ayirish(GenericType x, GenericType y);
        GenericType bulish(GenericType x, GenericType y);
        GenericType kupaytirish(GenericType x, GenericType y);

    }



    internal class Calculator<GenericType> : ICalculator
        where GenericType : INumber<GenericType>
    {
        internal void qushish(GenericType x, GenericType y)
        {
            Console.WriteLine(x + y);
        }
        internal void ayirish(GenericType x, GenericType y)
        {
            Console.WriteLine(x - y);
        }
        internal void bulish(GenericType x, GenericType y)
        {
            Console.WriteLine(x / y);
        }
        internal void kupaytirish(GenericType x, GenericType y)
        {
            Console.WriteLine(x * y);
        }
    }


}





