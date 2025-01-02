namespace text_based_rpg;

public class Enemy(string name, int health, int strength)
{
    protected string Name { get; set; } = name;
    private int Health { get; set; } = health;
    private int HealthMax { get; set; } = health;
    protected int Strength { get; set; } = strength;

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

    public virtual void Attack(Character character)
    {
        character.TakeDamage(Strength);
        Console.WriteLine($"{Name} attacks {character.GetName()} for {Strength} damage!");
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

public class BasicEnemy(string name, int health, int strength) 
    : Enemy(name, health, strength) {}

public class BossEnemy(string name, int health, int strength) 
    : Enemy(name, health, strength)
{
    public override void Attack(Character character)
    {
        character.TakeDamage(Strength * 2); 
        Console.WriteLine($"{Name} attacks {character.GetName()} for {Strength} damage!");
    }
}