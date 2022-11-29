public class Wine : Drink
{
    public string Region;

    public int YearBottled;


    public Wine(string name, string color, double temp, int calories, bool isCarb, string region, int yearBottled) : base(name, color, temp, calories, true)
    {
        Region = region;
        YearBottled = yearBottled;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine(Region);
        Console.WriteLine(YearBottled);
    }
}