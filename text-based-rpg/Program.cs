// OOP Basics (Classes and Objects)
namespace text_based_rpg;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the text-based role-playing game!");

        var character = new Character(InputCharacterName());
        character.PrintCharacterInfo("Your character has been created!");

        // Enemies
        var enemiesList = new List<Enemy>
        {
            new Enemy("Goblin", 50, 10),
            new Enemy("Orc", 70, 15),
            new Enemy("Troll", 100, 20),
            new Enemy("Bandit", 60, 12),
            new Enemy("Wolf", 40, 8)
        };
        
        var destroyedEnemies = new List<string>();

        // Game cycle
        var random = new Random();
        var isPlaying = true;
        while (isPlaying)
        {

            var enemy = enemiesList[random.Next(enemiesList.Count)];
            enemy.PrintEnemyInfo("You have met the enemy:");
            
            var isFighting = true;
            while (isFighting)
            {
                PrintFightingStatus(character.GetHealth(), enemy.GetName(), enemy.GetHealth());
                
                // Action processing
                switch (ChoosingAction())
                {
                    case 1: // attack
                    {
                        Console.WriteLine("You have chosen to attack the enemy!");
                        character.TakeDamage(enemy.GetStrength());
                        if (!character.IsAlive())
                        {
                            isPlaying = false;
                            isFighting = false;
                            break;
                        }
                        
                        enemy.TakeDamage(character.GetStrength());
                        
                        if (enemy.IsDead())
                        {
                            character.LevelUp();
                            destroyedEnemies.Add($"{enemy.GetName()}: Health: {enemy.GetHealthMax()} | Strength: {enemy.GetStrength()}");
                            isFighting = false;
                        }
                        break;
                    }
                    case 2: // defend
                    {
                        Console.WriteLine("You chose to defend yourself!");
                        character.Heal(10);
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
    }

    private static string InputCharacterName()
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

    private static void PrintFightingStatus(int characterHealth, string enemyName, int enemyHealth)
    {
        Console.WriteLine($"\nFight stats:\nYour health: {characterHealth}\n{enemyName} health: {enemyHealth}");
    }

    private static int ChoosingAction()
    {
        Console.WriteLine("\nSelect an action:\n1. Attack\n2. Defend\n3. Quit");
        while (true)
        {
            Console.Write("\nEnter the action: ");
            if (int.TryParse(Console.ReadLine(), out var action) && action is >= 1 and <= 3) return action;
            Console.WriteLine("Wrong input, try again.");
        }
    }
    private static void PrintDefeatedEnemies(List<string> enemies)
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
}