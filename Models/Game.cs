using System;
using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing { get; set; } = true;
    public Room room1 { get; set; }
    public Room room2 { get; set; }
    public Room room3 { get; set; }
    public Room room4 { get; set; }
    public Room room5 { get; set; }
    public int goblinHealth { get; set; } = 3;

    public void Reset()
    {

    }

    public void Setup()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
      System.Console.WriteLine("Opening your blurry eyes, and look around. You cant remember What happened, or where you are.  A faint throbbing pusates through your head.  A single thought 'What did I do last night'.");
      Player plr = new Player();
      CurrentPlayer = plr;
      string room1des = "The room is bare with small colorfull bits of papper scattered around on the floor. The floor consists of large colored Squares illuminated by a reflective glass ball from the celing. A faint 'Thump', 'Thump', 'Un Tiss', 'Un Tiss' is heard from large black boxes laid out in each corrner of the room";
      string room2des = "You find yourself in a dark room. All you can see is the door behind you and darkness before you...";

      room1 = new Room("party room", room1des);
      setCurrentRoom(room1);
      room2 = new Room("dark room", room2des);
      string room3des = "Upon entering the room you are greeted by a goblin.  Sluring his words he exclames 'You shall never leave this place! for I challange you to a game of wits!  Thus I know you are only armed with a ham Sandwich in combat of the mind!' as the goblin jests and belittles you. you find yourself becomming increasingly angry.  After many inslts He finaly says 'Here is Your Riddle. I'm older than time and older than space but never died. Who am I? <answer with 'answer +(your answer)'  REMEMBER! Case matters!>";
      string room4des = "In this small side room you see just some holes in the ground with a foul Smell eminating from them.  Dont linger here to long... But wait!  from behind a large goblin Slams the door and bolts it shut!  She screeches 'This is the ladies room!  you dont belong! I chalange you to a battle!'  You must Fight!  You have 3 fight commands <'fight +(command)'>  the three commands are 'rock' 'paper' 'or' 'scissors'.";
      room3 = new Room("goblin room", room3des);
      room4 = new Room("bathroom", room4des);
      room5 = new Room("Win Room", "You have made it out of the dungeon!  Upon leaving you turn around and see you are leaving the 'Crunky Green Skins!' the areas hottest goblin club.  I remember now! you drank to much grog and mead last night and passed out on the dance floor!  You hope the bouncer is ok after that torch to the nose.  but you may be banned for life...");

      Item torch = new Item("torch", "You See a ", ".  It could be useful");
      Item poop = new Item("goo", "You see a strange ", ".  Do you dare touch it? it may be usefull?... Maybe...");
      room4.AddItem(poop);
      room1.AddItem(torch);
      room1.AddDirection("north", room2);
      room2.AddDirection("south", room1);
      room3.AddDirection("south", room2);
      // room4.AddDirection("west", room2);





    }
    public void Help()
    {
      System.Console.WriteLine("To Move Type 'go +Direction'");
      System.Console.WriteLine("To get Type 'get +Item'");
      System.Console.WriteLine("To use Type 'use +Item'");
      System.Console.WriteLine("To quit Type 'quit'");
      //   System.Console.WriteLine($"There May be other actions you can use from the room description Dont be afraid to experiment!");
    }
    public void Gaming()
    {
      while (Playing)
      {
        action();
      }

    }
    public void action()
    {

      Console.WriteLine(CurrentRoom.Description);
      if (CurrentRoom.Items.Count > 0)
      {

        foreach (var item in CurrentRoom.Items)
        {
          Console.Write(item.DescriptionStart);
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("'");
          Console.Write(item.Name);
          Console.Write("'");
          Console.ForegroundColor = ConsoleColor.White;
          Console.WriteLine(item.DescriptionEnd);
        }
      }
      if (CurrentRoom.Directions.Count > 0)
      {
        Console.Write("Directions are");
        foreach (var item in CurrentRoom.Directions)
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write(" '");
          Console.Write(item.Key);
          Console.Write("'");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(".");
      }
      System.Console.WriteLine("What would you like to do? (type 'help' for help)");
      string[] command = Console.ReadLine().ToLower().Split(' ');
      for (int i = 2; i < command.Length; i++)
      {
        command[1] += " ";
        command[1] += command[i];
      }
      switch (command[0])
      {
        case "go":
          if (command.Length > 1)
          {
            Console.Clear();
            Move(command[1]);
          }
          break;
        case "get":
          if (command.Length > 1)
          {
            Console.Clear();
            Get(command[1]);
          }
          break;
        case "use":
          if (command.Length > 1)
          {
            Console.Clear();
            UseItem(command[1]);
          }
          break;
        case "help":
          Console.Clear();
          Help();
          break;
        case "answer":
          if (CurrentRoom.Name == "goblin room")
          {
            System.Console.WriteLine("The Goblin Laughs at your attempt. And Jeers 'Not even close!  I thought you armed with a Ham Sandwich, but now I doubt if you are that well equiped.'");
          }
          else
          {
            System.Console.WriteLine("the winds aroud say 'wrong answer...");
          }
          break;
        case "fight":
          Battle(command[1]);
          break;
        case "inventory":
          var PlayerInv = CurrentPlayer.GetInventory();
          if (PlayerInv.Count == 0)
          {
            System.Console.WriteLine("you don't have any Items.");
              return;
          }
          Console.Write("You currently have: ");
          foreach (var item in PlayerInv)
          {
            Console.Write(item.Name);
          }
          Console.WriteLine(".");
          break;
        case "quit":
          SetPlaying(false);
          // System.Net.Mime.MediaTypeNames.Application.Exit();
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("I dont Understand");
          break;
      }
    }

    private void Battle(string v)
    {

      CurrentRoom.Description = "An angry Goblin waits for you to Fight!  You have 3 fight commands <'fight +(command)'>  the three commands are 'rock' 'paper' 'or' 'scissors'.";
      // while (goblinHealth > 0)
      // {
      if (!BattleLogic(v))
      {
        CurrentPlayer.Health -= 25;

        if (CurrentPlayer.Health < 0)
        {
          System.Console.WriteLine("The Goblin Killed you for your digressions.");
          SetPlaying(false);
        }
        else
        {
          System.Console.WriteLine("You have Lost the Battle but not the war! Keep fighting!");
        }
      }
      else
      {
        goblinHealth--;
        if (goblinHealth > 0)
        {
          System.Console.WriteLine("The Goblin Looks Stund having Lost a Round. but comes back for more!");
        }
        else
        {
          System.Console.WriteLine("Defeted The goblin slumps to the Floor. Dead... Tired from battle.");
          CurrentRoom.Description = "With the Goblin defeated you are free to leave the room.";
          room4.AddDirection("west", room2);
        }
        // }

      }
    }

    private bool BattleLogic(string v)
    {
      Random r = new Random();
      int rInt = (r.Next(0, 2)) * 2;
      System.Console.WriteLine(rInt);
      int pInt = 1;
      switch (v)
      {
        case "rock":
          if (pInt > rInt)
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Scissors!");
            return true;
          }
          else
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Paper!");
            return false;
          }

        case "scissors":
          if (pInt > rInt)
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Paper!");
            return true;
          }
          else
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Rock!");
            return false;
          }

        case "paper":
          if (pInt > rInt)
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Rock!");
            return true;
          }
          else
          {
            Console.Clear();
            System.Console.WriteLine("The Goblin Threw Scissors!");
            return false;
          }

        default:
          Console.Clear();
          System.Console.WriteLine("Invalid Attack!");
          return false;
      }


    }

    public void SetPlaying(bool ling)
    {
      Playing = ling;
    }
    public void Get(string newItem)
    {
      foreach (var item in CurrentRoom.Items)
      {
        if (item.Name == newItem)
        {
          Item TestItem = new Item(item.Name, item.DescriptionStart, item.DescriptionEnd);
          CurrentPlayer.addItem(TestItem);
          Console.WriteLine($"you got {item.Name}");
          CurrentRoom.RemoveItem(item.Name);
          return;
        }
      }
      Console.WriteLine($"You look for {newItem}... but can't fine any.");
    }
    public void Move(string dir)
    {

      if (CurrentRoom.Directions.ContainsKey(dir))
      {
        setCurrentRoom(CurrentRoom.Directions[dir]);

        return;
      }
      Console.WriteLine($"You try to go {dir}... but can't.");
    }
    public void setCurrentRoom(Room newCurrent)
    {
      CurrentRoom = newCurrent;
    }

    public void UseItem(string itemName)
    {
      Item TestItem = CurrentPlayer.HasItem(itemName);
      if (TestItem != null)
      {
        if (itemName == "torch" && CurrentRoom.Name == "dark room")
        {
          CurrentRoom.AddDirection("north", room3);
          CurrentRoom.AddDirection("east", room4);
          CurrentRoom.Description = "It appears to be a hallway with one side door and a door opposite the way you came.  Strange Colorfull yet indecipherable imagery adorn the walls.";
          Console.WriteLine("The room blazes with light.  You can finally see!  ");
          return;
        }
        else if (itemName == "torch" && CurrentRoom.Name == "party room")
        {
          Console.WriteLine("The room is now LIT! Goblins pour from unseen cracks and paths, loud banging and rhythems start from the strange Boxes. They all start start raving you get crushed to death...");
          SetPlaying(false);
          return;
        }
        else if (itemName == "torch" && CurrentRoom.Name == "goblin room")
        {
          Console.WriteLine("You solve the goblin's Riddle by shoving a burning torch right up his nose! the gobin screeches you see a new path open.");
          CurrentRoom.AddDirection("east", room5);
          CurrentRoom.Description = "A burning Goblin in the corner and the Exit to the east.";
          return;
        }
        else if (itemName == "torch")
        {

          return;
        }

      }
      else
      {
        System.Console.WriteLine($"You don't Have {itemName}");
      }
    }

    public Game()
    {

      CurrentRoom = null;
      CurrentPlayer = null;
      // Room room1 = null;
      // Room room2 = null;
      // Room room3 = null;
      // Room room4 = null;
      // Room room5 = null;
    }
  }
}