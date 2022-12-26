namespace StructTest;

internal struct Dog
{
    public string Name { get; set; }
    public string Breed { get; set; }

    public Dog(string name, string breed)
    {
        this.Name = name;
        this.Breed = breed;
    }

    public void Speak() => Console.WriteLine($"My name is {this.Name} and I'm a {this.Breed}");
}
