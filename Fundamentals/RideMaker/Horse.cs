class Horse : Vehicle, INeedFuel
{
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    public Horse(string fType, int fTotal) : base("Horse", 1, "brown", false, 50, 0)
    {
        FuelTotal = fTotal;
        FuelType = fType;
    }

    public void GiveFuel(int Amount)
    {
        Console.WriteLine($"Given {Amount} bales of {FuelType}");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Fuel Total:{FuelTotal} - Fuel Type:{FuelType}");
    }
}