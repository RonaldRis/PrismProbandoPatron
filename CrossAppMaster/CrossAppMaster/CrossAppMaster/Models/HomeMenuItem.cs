using System;
using System.Collections.Generic;
using System.Text;

namespace CrossAppMaster.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        MyPokemons
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string imgIcon { get; set; }
    }
}
