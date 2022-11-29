public class Enemy 
{
    public string Name;

    public int Health;

    public List<Attack> Attacks;

    public Enemy(string name, int health, List<Attack> attacks)
    {
        Health = health;
        Name = name;
        Attacks = attacks;
    }

    public virtual void RandomAttack()
    {
        Random rand = new Random();
        Console.WriteLine(Attacks[rand.Next(0,Attacks.Count)].Name);
    }

    public void AddAttack(Attack NewAttack)
    {
        Attacks.Add(NewAttack);
    }
}