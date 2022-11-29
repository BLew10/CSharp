Car newCar = new Car("gas", 10);
Horse newHorse = new Horse("hay", 3);
Bicycle newBicycle = new Bicycle();

List <Vehicle> allVehicles = new List<Vehicle>();
List <INeedFuel> allINeedFuels = new List<INeedFuel>();

allVehicles.Add(newCar);
allVehicles.Add(newHorse);
allVehicles.Add(newBicycle);

// allINeedFuels.Add(newCar);
// allINeedFuels.Add(newHorse);

foreach(var vehicle in allVehicles)
{
    vehicle.ShowInfo();
    // Console.WriteLine(vehicle is INeedFuel);
    if(vehicle is INeedFuel)
    {
        
        allINeedFuels.Add((INeedFuel)vehicle);
    }
}

foreach(INeedFuel vehicle in allINeedFuels)
{
    vehicle.GiveFuel(10);
}