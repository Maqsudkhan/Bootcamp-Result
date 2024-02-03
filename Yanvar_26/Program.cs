using System;

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        this.Name = name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        // To'g'riligi tekshirish uchun ishlatiladi.
        Person person = (Person)obj;
        return Name == person.Name;
    }

    // GetHashCode metodini muvaffaqiyatli ishga tushirish uchun Equals metodini o'zgartirish tavsiya etiladi.
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var a = new Person("John");
        var b = new Person("John");

        Console.WriteLine(a.Equals(b)); // Natija: True
    }
}
