
static void PrintList(List<string> MyList)
{
    foreach (string val in MyList)
    {
        Console.WriteLine(val);
    }
}

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (int num in IntList)
    {
        sum += num;
    }
    Console.WriteLine(sum);
}

static void FindMax(List<int> IntList)
{
    int max = IntList[0];
    foreach (int num in IntList)
    {
        if (num > max)
        {
            max = num;
        }
    }

    Console.WriteLine(max);
}

static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] = IntList[i] * IntList[i];
    }
    return IntList;
}

static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}

static void PrintDictionary(Dictionary<string, int> MyDictionary)
{
    foreach (KeyValuePair<string, int> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    if (MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    }
    else
    {
        return false;
    }
}



// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
List<string> names = new List<string>(){"Julie", "Harold", "James", "Monica"};
List<int> numbers = new List<int>(){6,12,7,10};

static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
 Dictionary<string, int> dict = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        dict.Add(Names[i], Numbers[i] );
    }
    return dict;
}

Dictionary<string, int> generated = (GenerateDictionary(names, numbers));
PrintDictionary(generated);