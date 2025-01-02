namespace text_based_rpg;

public class Enemy(string name, int health, int strength)
{
    private string Name { get; set; } = name;
    private int Health { get; set; } = health;
    private int HealthMax { get; set; } = health;
    private int Strength { get; set; } = strength;

    public string GetName()
    {
        return Name;
    }

    public int GetHealth()
    {
        return Health;
    }
    
    public int GetHealthMax()
    {
        return HealthMax;
    }

    public int GetStrength()
    {
        return Strength;
    }

    public void PrintEnemyInfo(string header = "")
    {
        Console.WriteLine($"\n{header}");
        Console.WriteLine($"Name:\t\t{Name}");
        Console.WriteLine($"Health:\t\t{Health}");
        Console.WriteLine($"Strength:\t{Strength}");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public bool IsDead()
    {
        if (Health > 0) return false;
        Console.WriteLine($"{Name} is dead.");
        return true;
    }
}