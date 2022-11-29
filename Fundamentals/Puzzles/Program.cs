static void CoinFlip()
{
    Random rand = new Random();
    int coin = rand.Next(2);
    if (coin == 1)
    {
        Console.WriteLine("Heads");
    }
    else
    {
        Console.WriteLine("Tails");
    }
}

static int DiceRoll()
{
    Random rand = new Random();
    return rand.Next(1, 7);
}

// Console.WriteLine(DiceRoll());

static List<int> StatRoll(int rollsUpTo = 4)
{
    Random rand = new Random();
    List<int> rolls = new List<int>();
    int count = 0;
    while (count < rollsUpTo)
    {
        rolls.Add(rand.Next(1, 7));
        count++;
    }
    return rolls;
}

// foreach (int roll in StatRoll(8))
// {
//     Console.WriteLine(roll);
// }

static string RollUntil(int DesiredRoll)
{
    if(DesiredRoll > 6)
    {
        return "Invalid Input. Desired Roll must be less than 6";
    }
    int count = 1;
    Random rand = new Random();
    int roll = rand.Next(1, 7);
    while (roll != DesiredRoll)
    {
        roll = rand.Next(1, 7);
        count++;
    }
    return $"Rolled a {DesiredRoll} after {count} tries";
}

Console.WriteLine(RollUntil(7));