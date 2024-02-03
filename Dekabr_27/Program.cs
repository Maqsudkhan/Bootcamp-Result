
using System.Text.RegularExpressions;

/*class Program
{
    static void Main()
    {
        Console.WriteLine("Emailni kiriting: ");
        string email = Console.ReadLine();

        Console.WriteLine("Telefon raqamini kiriting (+998xxxxxxxxx): ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Parolni kiriting: ");
        string password = Console.ReadLine();

        if (ValidateEmail(email) && ValidatePhoneNumber(phoneNumber) && ValidatePassword(password))
        {
            Console.WriteLine("Muvaffaqiyatli registratsiya!");
        }
        else
        {
            Console.WriteLine("Xatolik yuz berdi. Iltimos, ma'lumotlarni to'g'ri  kiriting.");
        }
    }

    static bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    static bool ValidatePhoneNumber(string phoneNumber)
    {
        string pattern = @"^\+\d{12}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }

    static bool ValidatePassword(string password)
    {
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()+=_\-{}\[\]:;""'<>.,?]).{8,16}$";
        return Regex.IsMatch(password, pattern);
    }
}
*/









class Program
{
    static void Main()
    {

        Console.Write("Matnni kiriting: ");
        string matn = Console.ReadLine();
        Console.WriteLine(RemoveSpecialCharacters(matn));     

    }

    static string RemoveSpecialCharacters(string input)
    {
        // Regex orqali maxsus belgilarni olib tashlash
        string pattern = "[^a-zA-Z0-9]";
        return Regex.Replace(input, pattern, "");
    }
}




