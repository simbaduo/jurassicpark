using System;
using System.Collections.Generic;
using System.Linq;
namespace JurassicPark
{
  class Program
  {
    static List<Dinosaur> dinoList = new List<Dinosaur>();


    static void dinosaursInPark()
    {
      dinoList.AddRange(new List<Dinosaur> {
    new Dinosaur {
      Name = "Devlin",
      Type = "Brontosaurus",
      Diet = "Herbivore",
      DateAdded = DateTime.Parse("06/14/1947"),
      Weight = 40000,
      EnclosureNo = 1
    },
        new Dinosaur {
      Name = "Argus",
      Type = "Ankylosaurus",
      Diet = "Herbivore",
      DateAdded = DateTime.Parse("09/22/1918"),
      Weight = 17500,
      EnclosureNo = 2
    },
        new Dinosaur {
      Name = "Zantor",
      Type = "Tyrannosaurus Rex",
      Diet = "Carnivore",
      DateAdded = DateTime.Parse("11/08/1979"),
      Weight = 26000,
      EnclosureNo = 3
    },
        new Dinosaur {
      Name = "Ragnar",
      Type = "Velociraptor",
      Diet = "Carnivore",
      DateAdded = DateTime.Parse("03/02/1902"),
      Weight = 50,
      EnclosureNo = 4
    },


  });
    }
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

      dinoList.Add(dino);
    }

    static void displayDinosaur(IEnumerable<Dinosaur> dinoList) //explanation
    {
      foreach (var Dino in dinoList)
      {
        Console.WriteLine($"\n\nDino Name: {Dino.Name}\n");
        Console.WriteLine($"Dino Type: {Dino.Type}\n");
        Console.WriteLine($"Diet Type: {Dino.Diet}\n");
        Console.WriteLine($"Dino Weight: {Dino.Weight} lbs\n");
        Console.WriteLine($"Enclosure No.: {Dino.EnclosureNo}\n");
        Console.WriteLine($"Date Entered Park: {Dino.DateAdded}\n\n");
      }
    }


    static void dinoInventory() //why do I have to make this a 2 step function in the menu selection?
    {
      displayDinosaur(dinoList);
    }

    static void deleteDinosaur()
    {
      Console.WriteLine("\nPlease enter the name of the dino you wish to remove:\n");
      var eraseDino = Console.ReadLine();
      dinoList.RemoveAll(temp => temp.Name == eraseDino);
    }

    static void transferDinosaur()
    {
      Console.WriteLine("\nWhich dinosaur needs to be moved? Enter dino name.\n");
      var transferName = Console.ReadLine();

      Console.WriteLine($"\nWhere do you need to move {transferName}? Choose from 1-4.\n");
      var transferEnclosureNumber = Console.ReadLine();

      var transfer = dinoList.FirstOrDefault(temp => temp.Name.ToUpper() == transferName.ToUpper());
      transfer.EnclosureNo = int.Parse(transferEnclosureNumber);
      //how do i prevent from choosing an occupied enclosure
      //how do i prevent from choosing an invalid name
    }

    static void dietaryDinosaur()
    {
      Console.WriteLine("\nDisplay Dino Diet\n");
      var dietaryDinoDiet = Console.ReadLine();
      var dietCount = dinoList.Count(temp => temp.Diet.ToUpper() == dietaryDinoDiet.ToUpper());
      Console.WriteLine($"\nThere are {dietCount} {dietaryDinoDiet}s\n\n");


    }

    static void weightsOfDinosaur()
    {
      Console.WriteLine("\nJurassic Park's Heavy 3:\n");
      displayDinosaur(dinoList.OrderByDescending(temp => temp.Weight).Take(3));

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
      dinosaursInPark();
      Console.WriteLine("Welcome To Jurassic Park\n\nThe Secret Island");

      var userInput = "";


      while ((userInput) != "exit")
      {

        Console.WriteLine("\nPlease Choose Your Survival Path\n\n\nSelect from the list below.");
        Console.WriteLine("\nV: View List\n\nA: Add Dino\n\nD: Delete Dino\n\nT: Transfer Location\n\nN: Nutrition\n\nW: Dino Weights\n\nE: Exit at anytime\n\n");

        userInput = Console.ReadLine().ToUpper();

        if (userInput == "V")
        {
          dinoInventory();
          Console.WriteLine("\nDino Inventory:\n");
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