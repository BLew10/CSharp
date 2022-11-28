class Enemy 
{
    string Name;

    private int Health;
    public int _Health
    {
        get{ return Health;}
    }

    List<Attack> Attacks;

    public Enemy(string name, List<Attack> attacks)
    {
        Health = 100;
        Name = name;
        Attacks = attacks;
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        Console.WriteLine(Attacks[rand.Next(0,Attacks.Count)].Name);
    }

    public void AddAttack(Attack NewAttack)
    {
        Attacks.Add(NewAttack);
    }
}