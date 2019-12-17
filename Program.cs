using System;
using System.Collections.Generic;
using System.Linq;

namespace jurassicpark
{
  class Program
  {

    static DinoContext Db = new DinoContext();


    // static List<Dinosaur> dinoList = new List<Dinosaur>();

    //   static void dinosaursInPark()
    //   {
    //     dinoList.AddRange(new List<Dinosaur> {
    //     new Dinosaur
    //     {
    //       Name = "Devlin",
    //       Type = "Brontosaurus",
    //       Diet = "Herbivore",
    //       DateAdded = DateTime.Parse("06/14/1947"),
    //       Weight = 40000,
    //       EnclosureNo = 1
    //     },
    //       new Dinosaur
    //       {
    //         Name = "Argus",
    //         Type = "Ankylosaurus",
    //         Diet = "Herbivore",
    //         DateAdded = DateTime.Parse("09/22/1918"),
    //         Weight = 17500,
    //         EnclosureNo = 2
    //       },
    //       new Dinosaur
    //       {
    //         Name = "Zantor",
    //         Type = "Tyrannosaurus Rex",
    //         Diet = "Carnivore",
    //         DateAdded = DateTime.Parse("11/08/1979"),
    //         Weight = 26000,
    //         EnclosureNo = 3
    //       },
    //       new Dinosaur
    //       {
    //         Name = "Ragnar",
    //         Type = "Velociraptor",
    //         Diet = "Carnivore",
    //         DateAdded = DateTime.Parse("03/02/1902"),
    //         Weight = 50,
    //         EnclosureNo = 4
    //       },


    // });
    //   }
    static void addDinosaur()
    {
      Console.WriteLine("\nAdd Dino\n");
      Console.WriteLine("\nEnter dino name into inventory:\n"); var dinoName = Console.ReadLine(); //could also use string in place of var
      Console.WriteLine($"\nWhat dino type is {dinoName}\n"); var dinoType = Console.ReadLine(); //could also use string in place of var
      Console.WriteLine($"\nEnter {dinoName}'s dietary type. H for Herbivore || C for Carnivore:\n"); var dinoDiet = Console.ReadLine();
      Console.WriteLine($"\nHow much does {dinoName} weigh?\n"); var dinoWeight = Console.ReadLine();
      Console.WriteLine($"\nWhen did {dinoName} enter the park?\n"); var dinoDate = Console.ReadLine();
      Console.WriteLine($"\nWhich enclosure is {dinoName} located in?\n"); var dinoEnclosure = Console.ReadLine();

      var dino = new Dinosaur();
      dino.Name = dinoName;
      dino.Type = dinoType;
      dino.Diet = dinoDiet;
      dino.Weight = int.Parse(dinoWeight);
      dino.DateAdded = DateTime.Parse(dinoDate); //DateTime.Now?
      dino.EnclosureNo = int.Parse(dinoEnclosure);

      // var db = new DinoContext();

      // dinoList.Add(dino);
      Db.Dinosaurs.Add(dino);
      Db.SaveChanges();
    }

    static void displayDinosaur(IEnumerable<Dinosaur> dinoList) //explanation
    {
      foreach (var Dino in dinoList)
      {
        Console.WriteLine($"\n\nDino Name: {Dino.Name}\n");
        Console.WriteLine($"Dino Type: {Dino.Type}\n");
        Console.WriteLine($"Diet Diet: {Dino.Diet}\n");
        Console.WriteLine($"Dino Weight: {Dino.Weight} lbs\n");
        Console.WriteLine($"Enclosure No.: {Dino.EnclosureNo}\n");
        Console.WriteLine($"Date Entered Park: {Dino.DateAdded}\n\n");
      }
    }

    static void hatchDino()
    {
      string[] hatchNames = { "Andor", "Gildas", "Halvor",
                "Jarvis", "Kosoko", "Magnus", "Ragnar", "Sadiki"};
      string[] hatchDiet = { "carnivore", "herbivore" };

      var hatchDino = new Dinosaur();
      Random rand = new Random();

      hatchDino.Name = hatchNames[rand.Next(0, 11)];
      hatchDino.Diet = hatchDiet[rand.Next(0, 2)];
      hatchDino.DateAdded = DateTime.Now;
      hatchDino.Weight = rand.Next(50, 25000);
      hatchDino.EnclosureNo = rand.Next(0, 8);
      Console.WriteLine($"{hatchDino.Name} has hatched!!\n\nA stunning {hatchDino.Diet} that weighs {hatchDino.Weight} lbs\n\nLet's place this beautiful creature in Enclosure No. {hatchDino.EnclosureNo}");
      Db.Dinosaurs.Add(hatchDino);
      Db.SaveChanges();







    }

    static void dinoInventory() //why do I have to make this a 2 step function in the menu selection?
    {
      displayDinosaur(Db.Dinosaurs);
    }

    static void deleteDinosaur()
    {
      Console.WriteLine("\nPlease enter the name of the dino you wish to remove:\n");
      var deleteDinoName = Console.ReadLine();
      var removeDino = Db.Dinosaurs.FirstOrDefault(dino => dino.Name == deleteDinoName);
      Db.SaveChanges();
      // dinoList.RemoveAll(temp => temp.Name == eraseDino);
    }

    static void transferDinosaur()
    {
      Console.WriteLine("\nWhich dinosaur needs to be moved? Enter dino name.\n");
      var transferName = Console.ReadLine();

      Console.WriteLine($"\nWhere do you need to move {transferName}? Choose from 1-4.\n");
      var transferEnclosureNumber = Console.ReadLine();

      // var transfer = dinoList.FirstOrDefault(temp => temp.Name.ToUpper() == transferName.ToUpper());
      var transferEnclosure = Db.Dinosaurs.FirstOrDefault(temp => temp.Name.ToUpper() == transferName.ToUpper());
      // transfer.EnclosureNo = int.Parse(transferEnclosureNumber);
      //how do i prevent from choosing an occupied enclosure
      //how do i prevent from choosing an invalid name
    }

    static void dietaryDinosaur()
    {
      Console.WriteLine("\nDisplay Dino Diet\n");
      var dietaryDinoDiet = Console.ReadLine();
      // var dietCount = dinoList.Count(temp => temp.Diet.ToUpper() == dietaryDinoDiet.ToUpper());
      var dinoDiets = Db.Dinosaurs.Count(temp => temp.Diet == dietaryDinoDiet);
      Console.WriteLine($"\nThere are {dinoDiets} {dietaryDinoDiet}s\n\n");


    }

    static void weightsOfDinosaur()
    {
      Console.WriteLine("\nJurassic Park's Heavy 3:\n");
      // displayDinosaur(dinoList.OrderByDescending(temp => temp.Weight).Take(3));

    }

    static void exitProgram()
    {
      Console.WriteLine("\nExiting Program\n"); //stop menu from reloading?
      Environment.Exit(0); //explanation
    }
    static void invalidInput()
    {
      Console.WriteLine("\nInvalid Entry. Try Again\n");
    }


    static void Main(string[] args)
    {
      // dinosaursInPark();
      Console.WriteLine("Welcome To Jurassic Park\n\nThe Secret Island");

      var userInput = "";


      while ((userInput) != "exit")
      {

        Console.WriteLine("\nPlease Choose Your Survival Path\n\n\nSelect from the list below.");
        Console.WriteLine("\nV: View List\n\nA: Add Dino\n\nD: Delete Dino\n\nT: Transfer Location\n\nN: Nutrition\n\nW: Dino Weights\n\nH: Hatch a Dino\n\nE: Exit at anytime\n\n");

        userInput = Console.ReadLine().ToUpper();

        if (userInput == "V")
        {
          Console.WriteLine("\nDino Inventory:\n");
          dinoInventory();
        }
        else if (userInput == "A")
        {
          addDinosaur();
        }
        else if (userInput == "D")
        {
          deleteDinosaur();
        }
        else if (userInput == "T")
        {
          transferDinosaur();
        }
        else if (userInput == "N")
        {
          dietaryDinosaur();
        }
        else if (userInput == "W")
        {
          weightsOfDinosaur();
        }
        else if (userInput == "H") //how do i also allow exit and Exit and EXIT
        {
          hatchDino();
        }
        else if (userInput == "E") //how do i also allow exit and Exit and EXIT
        {
          exitProgram();
        }
        else
        {
          invalidInput();
        }

      }
    }
  }
}