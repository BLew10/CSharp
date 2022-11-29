public class Drink
{
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;
    
    // We need a basic constructor that takes all these features in
    public Drink(string name, string color, double temp, int calories, bool isCarb)
    {
    	Name = name;
    	Color = color;
    	Temperature = temp;
    	IsCarbonated = isCarb;
    	Calories = calories;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Color);
        Console.WriteLine(Temperature);
        Console.WriteLine(Calories);
        Console.WriteLine(IsCarbonated);
    }
}

