using System;
using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void Reset()
    {

    }

    public void Setup()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
      System.Console.WriteLine();
      Player CurrentPlayer = new Player(null);
      string room1des = "You are in the first room. Directions are ";
      string room2des = "You are in the Second room. Directions are ";
      Room room1 = new Room("Room1", room1des);
      setCurrentRoom(room1);
      Room room2 = new Room("Room2", room2des);
      room1.AddDirection("north", room2);
      room2.AddDirection("south", room1);





    }
    public void Help()
    {
      System.Console.WriteLine("To Move Type 'go +Direction'");
      System.Console.WriteLine("To get Type 'get +Item'");
      System.Console.WriteLine("To use Type 'use +Item'");
      //   System.Console.WriteLine($"There May be other actions you can use from the room description Dont be afraid to experiment!");
    }
    public void action()
    {

      Console.Write(CurrentRoom.Description);
      foreach (var item in CurrentRoom.Directions)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("'");
        Console.Write(item.Key);
        Console.Write("'");

      }
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine(".");
      System.Console.WriteLine("What would you like to do? (type 'help' for help)");
      string[] command = Console.ReadLine().Split(' ');
      for (int i = 2; i < command.Length; i++)
      {
          command[1]+= " ";
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
            System.Console.WriteLine($"you used {command[1]}...  Nothing Happend.");
          }
          break;
        case "help":
          Console.Clear();
          Help();
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("I dont Understand");
          break;
      }
    }
    public void Get(string newItem)
    {
        foreach (var item in CurrentRoom.Items)
        {
        if (item.Name==newItem)
        {
            CurrentPlayer.addItem(item);
            Console.WriteLine($"you got {item.Name}");
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

    }

    public Game()
    {

      CurrentRoom = null;
      CurrentPlayer = null;
    }
  }
}