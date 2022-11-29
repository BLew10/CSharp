
abstract class Vehicle
{
   public string Name;
    public int Passengers;

    public string Color;

    public bool HasEngine;

    public int TopSpeed;

    public int NumMiles;

    public Vehicle(string name, int passengers, string color, bool hasEngine, int topSpeed, int numMiles)
    {
        Name = name;

        Passengers = passengers;

        Color = color;

        HasEngine = hasEngine;

        TopSpeed = topSpeed;

        NumMiles = numMiles;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name:{Name} - Passengers:{Passengers} Color: {Color} Engine: {HasEngine} Top Speed: {TopSpeed} Total Miles: {NumMiles}");
    }

    public virtual void Travel(int miles)
    {
        NumMiles += miles;
        Console.WriteLine($"Number of Miles: {NumMiles}");
    }

}


