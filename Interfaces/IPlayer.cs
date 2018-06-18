using System.Collections.Generic;
using TextGame.Models;

namespace TextGame.Interfaces
{
    public interface IPlayer
    {
      
        List<Item> Inventory { get; set; }
        int Health{get; set;}

    }
}