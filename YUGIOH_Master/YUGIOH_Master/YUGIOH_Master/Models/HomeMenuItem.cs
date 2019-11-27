namespace YUGIOH_Master.Models
{
    public enum MenuItemType
    {
        AllCards,
        MyCards
    }
    public class HomeMenuItem
    {
        public MenuItemType Type { get; set; }

        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
