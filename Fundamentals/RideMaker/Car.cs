class Car : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Car(string fType, int fTotal) : base("car", 5, "black", false, 120, 10000)
    {
        FuelTotal = fTotal;
        FuelType = fType;
    }

    public void GiveFuel(int Amount)
    {
        Console.WriteLine($"Given {Amount} gallons of {FuelType}");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Fuel Total:{FuelTotal} - Fuel Type:{FuelType}");
    }
}