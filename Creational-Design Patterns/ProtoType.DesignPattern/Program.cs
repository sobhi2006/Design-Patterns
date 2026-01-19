using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        Person person1 = new Person()
        {
            Name = "Sobhi",
            Age = 20,
            Address = new Address()
            {
                Country = "Syria",
                City = "Aleppo"
            }
        };
        // Reference Way
        var person2 = person1;

        System.Console.WriteLine("Reference Way: ");
        System.Console.WriteLine("Before Edit: ");
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person2);

        System.Console.WriteLine("After Edit: ");
        person2.Address.City = "Damascus";
        person2.Name = "Mohammad";
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person2);


        // Shallow Clone Way

        Person person3 = (Person)person1.Clone();

        System.Console.WriteLine("\nShallow Clone Way: ");
        System.Console.WriteLine("Before Edit: ");
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person3);

        System.Console.WriteLine("After Edit: ");
        person3.Address.City = "Homs";
        person3.Name = "Ahmed";
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person3);
        
        // Deep Clone Way
        Person person4 = person1.DeepClone();

        System.Console.WriteLine("\nDeep Clone Way: ");
        System.Console.WriteLine("Before Edit: ");
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person4);

        System.Console.WriteLine("After Edit: ");
        person4.Address.City = "Latakia";
        person4.Name = "Omar";
        System.Console.WriteLine("      " + person1);
        System.Console.WriteLine("      " + person4);
    }
}

public class Person : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }
    public object Clone()
    {
        return ShallowClone();
    }
    private object ShallowClone()
    {
        return this.MemberwiseClone();
    }
    public Person DeepClone()
    {
        var serializeObj = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Person>(serializeObj);
    }

    override public string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Address: [ Country: {Address.Country}, City: {Address.City} ]";
    }
}

public class Address
{
    public string Country { get; set; }
    public string City { get; set; }
}