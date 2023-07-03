using OOPExercise;

//Animal animal = new Animal();                                 //ne može se instancirati jer je abstraktna klasa


Animal horse = new Horse();                                     //ISoundable, Animal
Pig pig = new Pig();                                            //ISoundable, Animal
Chicken chicken = new Chicken();                                //ISoundable, Animal
Fish fish = new Fish(true);                                     //Animal



try
{
    int proteinCount = Int32.Parse(Console.ReadLine());
    int fatCount = Int32.Parse(Console.ReadLine());
    int omegaOilCount = Int32.Parse(Console.ReadLine());
    Algae algae = new Algae(proteinCount, fatCount, omegaOilCount);
    fish.Eat(algae);
    fish.Eat(algae, 2);                                         //overload metode


    if (fish.IsSaltWater)
    {
        Console.WriteLine("This fish is salt water fish!");
    }
    else
    {
        Console.WriteLine("This fish is salt water fish!");
    }

    //fish.IsSaltWater = false;                                 //get svojstvo je privatno, ne može se postaviti izvan klase
}
catch (Exception exception)
{
    Console.WriteLine(exception);
}



List<Animal> animals = new List<Animal>();                      //lista svih životnja
animals.Add(horse);
animals.Add(pig);
animals.Add(chicken);
animals.Add(fish);

foreach (Animal animal in animals)                     
{
    Console.WriteLine(animal);    
    animal.Sleep();
    Console.WriteLine("-------------");
}
Console.WriteLine(Environment.NewLine);



List<ISoundable> animalsWithSounds = new List<ISoundable>();    //lista svih životinja koje se glasaju
animalsWithSounds.Add((ISoundable)horse);
animalsWithSounds.Add(pig);
animalsWithSounds.Add(chicken);

foreach (ISoundable animalWithSound in animalsWithSounds)
{
    Console.WriteLine(animalWithSound);
    animalWithSound.MakeNoise();
    Console.WriteLine("-------------");
}
