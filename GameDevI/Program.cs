Attack FireBlast = new Attack("Fire Blast", 10);
Attack WaterBlast = new Attack("Water Blast", 15);
Attack RockBlast = new Attack("Rock Blast", 22);
Attack PlantBlast = new Attack("Plant Blast", 12);

Enemy Bowser = new Enemy("Bowser", 80, new List<Attack> {FireBlast, WaterBlast});


MagicCaster MagicGuy = new MagicCaster();
Melee MeleeGuy =  new Melee();
RangedFighter RangedGuy = new RangedFighter();

MeleeGuy.Rage();
MeleeGuy.RandomAttack();
RangedGuy.RandomAttack();
RangedGuy.Dash();
MagicGuy.RandomAttack();
MagicGuy.Heal(RangedGuy);


