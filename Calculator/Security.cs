
namespace Calculator
{
    internal class Security
    {
        public void CheckPasswor()
        {
            string password = "";
            do
            {
                Console.Write("Enter password => ");
                password = Console.ReadLine();
            } while (password != "Maqsudkhan");
        }
    }
}
