using Dekabr_23;


Bank account1 = new Bank(100_000_000, InterestCalculations.IpotikaCompoundInterest);
Bank account2 = new Bank(50_000_000, InterestCalculations.CarCompoundInterest);
Bank account3 = new Bank(10_000_000, InterestCalculations.MindlessCompoundInterest);
Bank account4 = new Bank(1_000_000_000, InterestCalculations.PrivilegedSimpleInterest);
Bank account5 = new Bank(8_000_000, InterestCalculations.EducationSimpleInterest);

Console.WriteLine("Compound Interest for Ipotika Bank after 20 years: $" + account1.CalculateInterest(20));
Console.WriteLine("Compound Interest for Car Bank after 5 years: $" + account2.CalculateInterest(5));
Console.WriteLine("Compound Interest for Maqsadsiz kridet Bank after 3 years: $" + account3.CalculateInterest(3));
Console.WriteLine("Simple Interest for Imtiyozli kridet Bank after 20 years: $" + account4.CalculateInterest(20));
Console.WriteLine("Simple Interest for Ta'lim kridet Bank after 5 years: $" + account5.CalculateInterest(5));

// har bir kredit tipi uchun method ochilishi kerak.
// 5xil kredit  foizlar yillik hisobida
// ipoteka 20 yil 20% -> compound  -> 100_000_000
// mashina 5 yil 30% -> compound   ->  50_000_000
// maqsadsiz kredit 3 yil 40% -> compound -> 10_000_000
// imtiyozli  20 yil 7% -> simple    -> 1_000_000_000
// ta'lim kredit 5 yil 0% -> simple  -> 8_000_000
