namespace text_based_rpg;

public class Character(string name)
{
    private string Name { get; } = name;
    private int Health { get; set; } = 100;
    private int Level { get; set; } = 1;
    private int Strength { get; set; } = 10;
    
    private List<string> Inventory { get; set; } = new List<string>();

    public string GetName()
    {
        return Name;
    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetLevel()
    {
        return Level;
    }

    public int GetStrength()
    {
        return Strength;
    }

    public void PrintCharacterInfo(string header)
    {
        Console.WriteLine($"\n{header}");
        Console.WriteLine($"Name:\t\t{Name}");
        Console.WriteLine($"Health:\t\t{Health}");
        Console.WriteLine($"Level:\t\t{Level}");
        Console.WriteLine($"Strength:\t{Strength}");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void TakeDamage(int damage, string source)
    {
        Health -= damage;
        Console.WriteLine($"You've been dealt {damage} damage by {source}.");
    }

    public bool IsAlive()
    {
        if (Health <= 0)
        {
            Console.WriteLine("You are destroyed!");
        }
        return Health > 0;
    }

    public void LevelUp()
    {
        Level++;
        Strength += 5;
        if (Health <= 90)
        {
            Health += 10;
        }
        Console.WriteLine($"Your level has increased to {Level}! Strength: {Strength}, Health: {Health}");
    }

    public void Heal(int amount)
    {
        Health = Math.Min(Health + amount, 100);
        Console.WriteLine($"Health restored by {amount}. Current health: {Health}");
    }

    public void AddItem(string item)
    {
        Inventory.Add(item);
        Console.WriteLine($"Added item: {item}");
    }

    public void RemoveItem(string item)
    {
        Console.WriteLine(Inventory.Remove(item) ? $"Removed item: {item}" : $"Item {item} not found");
    }

    public void ShowInventory()
    {
        Console.WriteLine("\nInventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }

    public bool IsInventoryEmpty()
    {
        if (Inventory.Count != 0) return false;
        Console.WriteLine("Inventory is empty!");
        return true;
    }
}