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
    public string Name { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Directions = new Dictionary<string, Room>();
            Items = new List<Item>();
            
            Description = description;


        }

    public void AddDirection(string key, Room room)
    {
        Directions.Add(key, room);
    }

    public void UseItem(Item item)
    {
        
    }
  }
}