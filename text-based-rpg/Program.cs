// OOP: Inheritance and Polymorphism
namespace text_based_rpg;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the text-based role-playing game!");

        var character = new Character(InputText("Enter the character's name:"));
        character.PrintCharacterInfo("Your character has been created!");

        // Enemies
        var enemiesList = new List<Enemy>
        {
            new BasicEnemy("Goblin", 50, 10),
            new BasicEnemy("Orc", 70, 15),
            new BasicEnemy("Troll", 100, 20),
            new BasicEnemy("Bandit", 60, 12),
            new BasicEnemy("Wolf", 40, 8),
            new BossEnemy("BigWolf", 80, 8)
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
                        enemy.Attack(character);
                        
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
                            enemiesList.Remove(enemy);
                            if (enemiesList.Count == 0)
                            {
                                Console.WriteLine("All enemies have been defeated! You win!");
                                isPlaying = false;
                            }
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
                    case 4: // inventory
                    {
                        ManageInventory(character);
                        break;
                    }
                }
            }
        }
        Console.WriteLine("\nThe game has ended.");

        PrintDefeatedEnemies(destroyedEnemies);
    }

    private static string InputText(string header)
    {
        string? input;
        while (true)
        {
            Console.Write($"\n{header} ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input! Try again.");
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
        Console.WriteLine("\nSelect an action:\n1. Attack\n2. Defend\n3. Quit\n4. Inventory");
        while (true)
        {
            Console.Write("\nEnter the action: ");
            if (int.TryParse(Console.ReadLine(), out var action) && action is >= 1 and <= 4) return action;
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

    private static void ManageInventory(Character character)
    {
        while (true)
        {
            Console.WriteLine("\nInventory Menu:");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Show Inventory");
            Console.WriteLine("4. Quit to Main Menu");
            Console.Write("\nEnter the action: ");

            switch (Console.ReadLine())
            {
                case "1":
                {
                    character.AddItem(InputText("Enter the name of the item to add:"));
                    break;
                }
                case "2":
                {
                    if (character.IsInventoryEmpty()) break;
                    character.RemoveItem(InputText("Enter the name of the item to delete:"));
                    break;
                }
                case "3":
                {
                    if (character.IsInventoryEmpty()) break;
                    character.ShowInventory();
                    break;
                }
                case "4":
                {
                    return;
                }
                default:
                {
                    Console.WriteLine("Invalid input. Try again.");
                    break;
                }
            }
        }
    }
}