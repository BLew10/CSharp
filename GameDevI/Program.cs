Attack FireBlast = new Attack("Fire Blast", 10);
Attack WaterBlast = new Attack("Water Blast", 15);
Attack RockBlast = new Attack("Rock Blast", 22);
Attack PlantBlast = new Attack("Plant Blast", 12);

Enemy Bowser = new Enemy("Bowser", new List<Attack> {FireBlast, WaterBlast});


Bowser.AddAttack(PlantBlast);
Bowser.RandomAttack();
Bowser.RandomAttack();
Bowser.RandomAttack();


