using System;
using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Room : IRoom
  {


    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, Room> Directions { get; set; }
    public Dictionary<string, Item> Specials {get; set;}
    public string Name { get; set; }
    public Room(string name, string description)
    {
      Name = name;
      Directions = new Dictionary<string, Room>();
      Items = new List<Item>();
      Description = description;
      Specials = new Dictionary<string, Item>();
    }

    public void AddDirection(string key, Room room)
    {
      Directions.Add(key, room);
    }
    public void AddItem(Item item)
    {
      Items.Add(item);
    }
    public void RemoveItem(string itemName)
    {
      for (int i = 0; i < Items.Count; i++)

      {
        if (itemName == Items[i].Name)
        {

          Items.RemoveAt(i);
          // System.Console.WriteLine("removed");
        }
      }
    }

    public bool UseItem(Item item)
    {
        if (item.Name  == "torch" && Name == "dark room")
        {
            string room3des = "You are in the third room.  ";
            string room4des = "You are in the fourth room.  ";
            Room room3 = new Room("Room3", room3des);
            Room room4 = new Room("Room4", room4des);
            AddDirection("north", room3);
            Description = "It appears to be a hallway with one side door and a door opposite the way you came.  Strange Colorfull yet indecipherable imagery adorn the walls.";
            Console.WriteLine("The room blazes with light.  You can finally see!  ");
        }
        else if (item.Name  == "torch" && Name == "party room")
        {
            Console.WriteLine("The room is now LIT! Goblins start raving you get moshed to death...");
            return false;
        }
        return true;
    }
  }
}