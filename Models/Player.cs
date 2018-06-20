using System;
using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Player : IPlayer
  {
    public List<Item> Inventory { get; set; }
    public int Health {get; set;}
    public Item HasItem(string name)
    {
      foreach (var item in Inventory)
      {
          if (item.Name ==name)
          {
            return item;
          }
      }
      return null;
    }

    public void addItem(Item item)
    {
      // System.Console.WriteLine(item.Name);
        Inventory.Add(item);
    }
    public Player()
    {
        Inventory = new List<Item>();
        
        Health = 100;

    }

    internal List<Item> GetInventory()
    {
      
      return Inventory;
    }
  }
}