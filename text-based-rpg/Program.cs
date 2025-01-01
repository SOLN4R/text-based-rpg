// Arrays

Console.WriteLine("Welcome to the text-based role-playing game!");

string? name;
var health = 100;
var level = 1;
var strength = 10;

// Requesting a character name
while (true)
{
    Console.Write("Enter the character's name: ");
    name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("The name can't be empty! Try again.");
        continue;
    }
    break;
}

// Character information output
Console.WriteLine("\nYour character has been created!");
Console.WriteLine($"Name:\t\t{name}");
Console.WriteLine($"Health:\t\t{health}");
Console.WriteLine($"Level:\t\t{level}");
Console.WriteLine($"Strength:\t{strength}");

// Enemies
string[] enemyNames = ["Goblin", "Orc", "Troll", "Bandit", "Wolf"];
var destroyedEnemies = new List<string>();
var destroyedEnemiesCount = 0;

// Game cycle
var random = new Random();
var isPlaying = true;
while (isPlaying)
{
    var enemyName = enemyNames[random.Next(enemyNames.Length)];
    var enemyHealth = random.Next(30, 100);
    var enemyStrength = random.Next(5, 24);
    var enemyMaxHealth = enemyHealth;
    Console.WriteLine($"\nYou have met the enemy:\nName: {enemyName} | Health: {enemyHealth} | Strength: {enemyStrength}).");
    var isFighting = true;
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
                health -= enemyStrength;
                if (health <= 0)
                {
                    Console.WriteLine("You are destroyed!");
                    isPlaying = false;
                    isFighting = false;
                    break;
                }
                enemyHealth -= strength;
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("You have destroyed the enemy.");
                    level++;
                    strength += 5;
                    if (health <= 90)
                    {
                        health += 10;
                    }
                    Console.WriteLine($"Your level has increased to {level}! Strength: {strength}, Health: {health}");
                    destroyedEnemies.Add($"{enemyName} (Strength: {enemyStrength} | Health: {enemyMaxHealth})");
                    destroyedEnemiesCount++;
                    if (destroyedEnemiesCount >= 100)
                    {
                        Console.WriteLine("You have completed the game!");
                        isPlaying = false;
                    }
                    isFighting = false;
                }
                break;
            }
            case 2: // defend
            {
                Console.WriteLine("You chose to defend yourself!");
                if (health <= 90)
                {
                    health += 10;
                    Console.WriteLine("Your health is increased.");
                }
                break;
            }
            case 3: // quit
            {
                Console.Write("Are you sure you want to quit? (yes/no): ");
                var confirmation = Console.ReadLine()?.ToLower();
                switch (confirmation)
                {
                    case "yes" or "y":
                        isFighting = false;
                        isPlaying = false;
                        Console.WriteLine("You chose to quit!");
                        break;
                    case "no" or "n":
                        Console.WriteLine("Returning to the fight!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
                        break;
                }
                break;
            }
        }
    }
}
Console.WriteLine("\nThe game has ended.");

// Enemies defeated history
Console.WriteLine("Enemies defeated:");
for (var i = 0; i < destroyedEnemies.Count; i++)
{
    Console.WriteLine($"{i+1}. {destroyedEnemies[i]}");
}