

namespace YUGIOH_Master.Models
{
    using SQLite;

    public class SavedCards
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string CardType { get; set; }
        public string title_english { get; set; }
        public string monster_type { get; set; }
        public string card_type { get; set; }
        public string rarity { get; set; }
        public string identifier { get; set; }
        public string url { get => $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{identifier}/image"; }
    }
}
