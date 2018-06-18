using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Player : IPlayer
  {
    public List<Item> Inventory { get; set; }
    public int Health {get; set;}

    public Player(List<Item> inventory)
    {
        Inventory = inventory;
        Health = 100;

    }
    public void addItem(Item item)
    {
        Inventory.Add(item);
    }
  }
}