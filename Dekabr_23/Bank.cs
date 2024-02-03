

namespace Dekabr_23
{
        delegate double InterestCalculator(double principal, int years);
    internal class Bank
    {
        public double Balance { get; set; }
        
        private InterestCalculator interestCalculator;
        
        public Bank(double initialBalance, InterestCalculator calculator)
        {
            Balance = initialBalance;
            interestCalculator = calculator;
        }
        
        public double CalculateInterest(int years)
        {
            return interestCalculator(Balance, years);
        }
        }

    class InterestCalculations
    {
        public static double IpotikaCompoundInterest(double principal, int years)
        {
            double rate = 0.2; // 20%
            return principal * Math.Pow(1 + rate, years) - principal;
        }
        public static double CarCompoundInterest(double principal, int years)
        {
            double rate = 0.3; // 30%
            return principal * Math.Pow(1 + rate, years) - principal;
        }
        public static double MindlessCompoundInterest(double principal, int years)
        {
            double rate = 0.4; // 40%
            return principal * Math.Pow(1 + rate, years) - principal;
        }
        public static double PrivilegedSimpleInterest(double principal, int years)
        {
            double rate = 0.07; // 7%
            return principal * rate * years;
        }
        public static double EducationSimpleInterest(double principal, int years)
        {
            double rate = 0; // 0% 
            return principal * rate * years;
        }

    }

}
// har bir kredit tipi uchun method ochilishi kerak.
// 5xil kredit  foizlar yillik hisobida
// ipoteka 20 yil 20% -> compound  -> 100_000_000
// mashina 5 yil 30% -> compound   ->  50_000_000
// maqsadsiz kredit 3 yil 40% -> compound -> 10_000_000
// imtiyozli  20 yil 7% -> simple    -> 1_000_000_000
// ta'lim kredit 5 yil 0% -> simple  -> 8_000_000