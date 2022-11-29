public class Coffee : Drink
{
    public string RoastValue;

    public string BeanType;


    public Coffee(string name, string color, double temp, int calories, bool isCarb, string roastValue, string beanType) : base(name, color, temp, calories, true)
    {
        RoastValue = roastValue;
        BeanType = beanType;
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine(RoastValue);
        Console.WriteLine(BeanType);
    }
}