using System.Collections.Generic;
using TextGame.Models;

namespace TextGame.Interfaces
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }

        Dictionary<string, Room> Directions {get; set;}
        Dictionary<string, Item> Specials {get; set;}


        bool UseItem(Item item);

    }
}