public class RangedFighter : Enemy
{
    public int Distance;
    public RangedFighter() : base("Ranged Fighter", 80, new List<Attack>{
        new Attack("Shoot an Arrow", 20), new Attack("Throw a Knife", 15)})
    { 
        Distance = 5;
    }

    public override void RandomAttack()
    {
        
        if(Distance >= 10)
        {
            Console.WriteLine($"Cannot Perform attack. Distance is too far. Current distance is ${Distance}");
        }
        else{
            base.RandomAttack();
        }
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"New distance is {Distance}");
    }
}