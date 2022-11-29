public class MagicCaster : Enemy
{
    public MagicCaster() : base("Magic Caster", 80, new List<Attack>{
        new Attack("Fireball", 25), new Attack("Shield", 0), new Attack("Staff Strike", 15)
    })
    { }

    public void Heal(Enemy enemy)
    {
        enemy.Health+=40;
        Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");
    }
}