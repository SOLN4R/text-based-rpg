// Variables and data types

Console.WriteLine("Welcome to the text-based role-playing game!");

string? name;
int health = 100;
int level = 1;
int strength = 10;

// Requesting a character name
while (true)
{
    Console.Write("\nEnter the character's name: ");
    name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("The name can't be empty! Try again.");
        continue;
    }
    break;
}

// Character information output
Console.WriteLine("Your character has been created!");
Console.WriteLine($"Name:\t\t{name}");
Console.WriteLine($"Health:\t\t{health}");
Console.WriteLine($"Level:\t\t{level}");
Console.WriteLine($"Strength:\t{strength}");