// Conditional constructions

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

// Fight with enemy
int enemyHealth = 50;
bool isFighting = true;

Console.WriteLine($"\nYou have met the enemy (Health: {enemyHealth}).");

while (isFighting)
{
    // Fight status
    Console.WriteLine($"\nFight stats:\nYour health: {health}\nEnemy health: {enemyHealth}");
    
    // Choosing an action
    Console.WriteLine("\nSelect an action:\n1. Attack\n2. Defend\n3. Quit");
    int action;
    while (true)
    {
        Console.Write("\nEnter the action: ");
        if (!int.TryParse(Console.ReadLine(), out action) || action < 1 || action > 3)
        {
            Console.WriteLine("Wrong input, try again.");
            continue;
        }
        break;
    }
    
    // Action processing
    switch (action)
    {
        case 1: // attack
        {
            Console.WriteLine("You have chosen to attack the enemy!");
            enemyHealth -= strength;
            if (enemyHealth <= 0)
            {
                Console.WriteLine("You have destroyed the enemy.");
                isFighting = false;
            }
            break;
        }
        case 2: // defend
        {
            Console.WriteLine("You chose to defend yourself!");
            if (enemyHealth < 50)
            {
                enemyHealth += 5;
                Console.WriteLine("Enemy used the opportunity to recover!");
            }
            break;
        }
        case 3: // quit
        {
            Console.Write("Are you sure you want to quit? (yes/no): ");
            string? confirmation = Console.ReadLine()?.ToLower();
            if (confirmation is "yes" or "y")
            {
                isFighting = false;
                Console.WriteLine("You chose to quit!");
            }
            else if (confirmation is "no" or "n")
            {
                Console.WriteLine("Returning to the fight!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
            }
            break;
        }
    }
}

Console.WriteLine("The game has ended.");