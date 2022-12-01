List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

//1 chile 
Eruption chileEruption = eruptions.FirstOrDefault(c => c.Location == "Chile");
// PrintEach(chileEruption, "Chile eruption.");

//2 Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."

IEnumerable<Eruption> HawaiianEruptions = eruptions.Where(c => c.Location == "Hawaiian Is");

// if (HawaiianEruptions.Count() == 0)
// {
//     Console.WriteLine("No Hawaiian Eruptions");
// }
// else
// {
//     PrintEach(HawaiianEruptions, "Hawaiian Eruptions");
// }

//3 Greenland
Eruption GreenlandEruptions = eruptions.FirstOrDefault(c => c.Location == "Greenland");
// if (GreenlandEruptions == null)
// {
//     Console.WriteLine(GreenlandEruptions);
//     Console.WriteLine("No Greenland Eruptions");
// }
// else
// {
// Console.WriteLine(GreenlandEruptions.Location);
// }


//
Eruption newZealand1900 = eruptions.FirstOrDefault(c => c.Location == "New Zealand" && c.Year > 1900);
// Console.WriteLine(newZealand1900.Location);
// Console.WriteLine(newZealand1900.Year);


//4 over 2000 elevation

IEnumerable<Eruption> Elevation2000 = eruptions.Where(c => c.ElevationInMeters > 2000);
// PrintEach(Elevation2000, "Elevation 2000");


// 5 Starts with L
IEnumerable<Eruption> LEruptions = eruptions.Where(c => c.Volcano.StartsWith("L"));
// PrintEach(LEruptions, "Starts with L");


// 6 Max
int max = eruptions.Max(c => c.ElevationInMeters);
// Console.WriteLine(max);

//7 Use max to find tallest name
Eruption TallestVolcano = eruptions.FirstOrDefault(c => c.ElevationInMeters == max);
// Console.WriteLine(TallestVolcano.Volcano);

// 8 Alphabetically
IEnumerable<Eruption> Alpha = eruptions.OrderBy(c => c.Volcano);
// PrintEach(Alpha, "Alphabetical Order");

// 9 Sum
int sum = eruptions.Sum(c => c.ElevationInMeters);
// Console.WriteLine(sum);

// 10 Erupted after 2000
bool After2000 = eruptions.Any(c => c.Year > 2000);
// Console.WriteLine(After2000);


//11 Take 3 Strato Volcanos
IEnumerable<Eruption> stratovolcanoEruptionsThree = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
// PrintEach(stratovolcanoEruptionsThree, "Three Stratos");

// 12 ALl Eruptions Before 1000 and sort alpha
IEnumerable<Eruption> Before1000 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
PrintEach(Before1000, "Before 1000");

// 12 ALl Eruptions Before 1000 and sort alpha and only grab names
IEnumerable<string> Before1000Names = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(c => c.Volcano);
foreach(string volcano in Before1000Names)
{
    Console.WriteLine(volcano);
}

