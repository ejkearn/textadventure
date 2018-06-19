using System.Collections.Generic;
using TextGame.Interfaces;

namespace TextGame.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string DescriptionStart { get; set; }
    public string DescriptionEnd { get; set; }


    public Item(string name, string description1, string description2)
    {
        Name = name;
        DescriptionStart = description1;
        DescriptionEnd = description2;
    }
  }
}