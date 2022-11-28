
 class Vehicle
{
    string Name;
    int Passengers;

    string Color;

    bool HasEngine;

    int TopSpeed;

    int NumMiles;

    public Vehicle(string name, int passengers, string color, bool hasEngine, int topSpeed, int numMiles)
    {
        Name = name;

        Passengers = passengers;

        Color = color;

        HasEngine = hasEngine;

        TopSpeed = topSpeed;

        NumMiles = numMiles;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name:{Name} - Passengers:{Passengers} Color: {Color} Engine: {HasEngine} Top Speed: {TopSpeed} Total Miles: {NumMiles}");
    }

    public void Travel(int miles)
    {
        NumMiles += miles;
        Console.WriteLine($"Number of Miles: {NumMiles}");
    }

}


