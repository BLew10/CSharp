List<Drink> AllBeverages = new List<Drink>();
Soda sodaOne = new Soda("Coca Cola", "brown", 35.0, 100, true);
Coffee CoffeeOne = new Coffee("Pete's", "brown", 90.0, 100, false, "dark", "Columbian");
Wine WineOne = new Wine("Pinot Grigo", "white", 35.0, 100, true, "Napa", 2001);
AllBeverages.Add(sodaOne);
AllBeverages.Add(CoffeeOne);
AllBeverages.Add(WineOne);

foreach(Drink beverage in AllBeverages)
{
    beverage.ShowInfo();
}
