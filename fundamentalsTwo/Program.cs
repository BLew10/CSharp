int[] newArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] stringArr = { "Tim", "Martin", "Nikki", "Sara" };
bool[] boolArr = new bool[10];

for (int idx = 0; idx < boolArr.Length; idx++)
{
    if (idx % 2 == 0)
    {
        boolArr[idx] = true;
    }
    else
    {
        boolArr[idx] = false;

    }
}

List<string> flavors = new List<string>();

flavors.Add("Vanilla");
flavors.Add("Strawberry");
flavors.Add("Chocolate");
flavors.Add("Rocky Road");
flavors.Add("Cookies and Cream");
flavors.RemoveAt(2);
flavors.Count();


Dictionary<string, string> names = new Dictionary<string, string>();
Random rand = new Random();

foreach(string name in stringArr )
{
names.Add(name, flavors[rand.Next(0,flavors.Count)]);
}

foreach(KeyValuePair<string,string> entry in names)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}