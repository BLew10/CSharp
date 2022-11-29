public class Soda : Drink
{
    public bool IsDiet;

    public Soda(string name, string color, double temp,int calories, bool isDiet) : base(name, color, temp, calories, true)
    {
        IsDiet = isDiet;
    }

        public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine(IsDiet);
    }
}