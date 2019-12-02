namespace YUGIOH_Master.Models
{
    public enum MenuItemType
    {
        AllCards,
        MyCards,
        monster_cards,
        ritual_monster_cards,
        link_monster_cards,
        synchro_monster_cards,
        xyz_monster_cards,
        pendulum_monster_cards,
        spell_cards,
        trap_cards
    }
    public class HomeMenuItem
    {
        public MenuItemType Type { get; set; }

        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
