// Methods

Console.WriteLine("Welcome to the text-based role-playing game!");

var characterName = InputCharacterName();
var characterHealth = 100;
var characterLevel = 1;
var characterStrength = 10;

PrintCharacterInfo("Your character has been created!", characterName, characterHealth, characterLevel, characterStrength);

// Enemies
var destroyedEnemies = new List<string>();

// Game cycle
var random = new Random();
var isPlaying = true;
while (isPlaying)
{
    
    var (enemyName, enemyHealth, enemyStrength) = GenerateEnemy(random);
    var enemyMaxHealth = enemyHealth;
    
    var isFighting = true;
    while (isFighting)
    {
        // Fight status
        Console.WriteLine($"\nFight stats:\nYour health: {characterHealth}\nEnemy health: {enemyHealth}");
        
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
                characterHealth -= enemyStrength;
                if (characterHealth <= 0)
                {
                    Console.WriteLine("You are destroyed!");
                    isPlaying = false;
                    isFighting = false;
                    break;
                }
                enemyHealth -= characterStrength;
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("You have destroyed the enemy.");
                    characterLevel++;
                    characterStrength += 5;
                    if (characterHealth <= 90)
                    {
                        characterHealth += 10;
                    }
                    Console.WriteLine($"Your level has increased to {characterLevel}! Strength: {characterStrength}, Health: {characterHealth}");
                    destroyedEnemies.Add($"{enemyName}: Health: {enemyMaxHealth} | Strength: {enemyStrength}");
                    isFighting = false;
                }
                break;
            }
            case 2: // defend
            {
                Console.WriteLine("You chose to defend yourself!");
                if (characterHealth <= 90)
                {
                    characterHealth += 10;
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

PrintDefeatedEnemies(destroyedEnemies);

return;

string InputCharacterName()
{
    string? input;
    while (true)
    {
        Console.Write("Enter the character's name: ");
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The name can't be empty! Try again.");
            continue;
        }
        break;
    }
    return input;
}

void PrintCharacterInfo(string message, string name, int health, int level, int strength)
{
    Console.WriteLine($"\n{message}");
    Console.WriteLine($"Name:\t\t{name}");
    Console.WriteLine($"Health:\t\t{health}");
    Console.WriteLine($"Level:\t\t{level}");
    Console.WriteLine($"Strength:\t{strength}");
}

(string, int, int) GenerateEnemy(Random rand)
{
    List<string> enemyNames = ["Goblin", "Orc", "Troll", "Bandit", "Wolf"];
    var name = enemyNames[rand.Next(enemyNames.Count)];
    var health = rand.Next(30, 100);
    var strength = rand.Next(5, 24);
    Console.WriteLine($"\nYou have met the enemy:\nName: {name} | Health: {health} | Strength: {strength}).");
    return (name, health, strength);
}

void PrintDefeatedEnemies(List<string> enemies)
{
    if (enemies.Count == 0)
    {
        return;
    }
    Console.WriteLine("Enemies defeated:");
    for (var i = 0; i < enemies.Count; i++)
    {
        Console.WriteLine($"{i+1}. {enemies[i]}");
    }
}