Car newCar = new Car("gas", 10);
Horse newHorse = new Horse("hay", 3);
Bicycle newBicycle = new Bicycle();

List <Vehicle> allVehicles = new List<Vehicle>();
List <INeedFuel> allINeedFuels = new List<INeedFuel>();

allVehicles.Add(newCar);
allVehicles.Add(newHorse);
allVehicles.Add(newBicycle);

foreach(Vehicle vehicle in allVehicles)
{
    vehicle.ShowInfo();
    if(vehicle is INeedFuel)
    {
        
        allINeedFuels.Add((INeedFuel)vehicle);
    }
}

foreach(INeedFuel vehicle in allINeedFuels)
{
    vehicle.GiveFuel(10);
}