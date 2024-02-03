using HmJson;
MethodsAll Methodsall = new MethodsAll();
Methodsall.GetAll<Product>();
Methodsall.Add<Person>(new Person() { Id = 1, Name = "Maqsudkhan", Surname = "Torayev" });
Methodsall.Add<Person>(new Person() { Id = 2, Name = "Maqsudkhan", Surname = "Torayev" });
Methodsall.GetAll<Person>();
Methodsall.Add<Product>(new Product() { Id = 1, Name = "Captiva", CompanyName = "Chevrolet", Data = "07.07.07" });
Methodsall.Update<Product>(1, new Product() { Id = 1, Name = "Captivaaaaaa", CompanyName = "Chevrolet", Data = "07.07.07" });

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Data { get; set; }

}