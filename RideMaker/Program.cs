
Vehicle Car = new Vehicle("Shaq", 5, "blue", true, 140, 180000);
Vehicle CarTwo = new Vehicle("Shaq", 5, "red", true, 140, 180000);
Vehicle CarThree = new Vehicle("Shaq", 5, "yellow", true, 140, 180000);
Vehicle CarFour = new Vehicle("Shaq", 5, "green", true, 140, 180000);

List <Vehicle> allVehicles = new List<Vehicle>();

allVehicles.Add(Car);
allVehicles.Add(CarTwo);
allVehicles.Add(CarThree);
allVehicles.Add(CarFour);

foreach(Vehicle car in allVehicles)
{
    car.ShowInfo();
}