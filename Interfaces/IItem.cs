using System.Collections.Generic;
using TextGame.Models;

namespace TextGame.Interfaces
{
  public interface IItem
  {
    string Name { get; set; }
    string DescriptionStart { get; set; }
    string DescriptionEnd { get; set; }


  }
}