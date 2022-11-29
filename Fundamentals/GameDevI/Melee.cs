public class Melee : Enemy
{
    public Melee() : base("Melee", 120, new List<Attack>{
        new Attack("Punch", 20), new Attack("Kick", 15), new Attack("Tackle", 25)
    })
    { }

    public void Rage()
    {
        Random rand = new Random();
        Attack UsedAttack = Attacks[rand.Next(0, Attacks.Count)];
        UsedAttack.Damage += 10;
        Console.WriteLine($"{UsedAttack.Name}: {UsedAttack.Damage}");
    }
}