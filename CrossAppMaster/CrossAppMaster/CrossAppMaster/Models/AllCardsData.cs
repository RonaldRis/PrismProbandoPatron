using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossAppMaster.Models
{
    public class AllCardsData
    {
        public Info info { get; set; }
        public List<MonsterCard> monster_cards { get; set; }
        public List<RitualMonsterCard> ritual_monster_cards { get; set; }
        public List<LinkMonsterCard> link_monster_cards { get; set; }
        public List<SynchroMonsterCard> synchro_monster_cards { get; set; }
        public List<XyzMonsterCard> xyz_monster_cards { get; set; }
        public List<PendulumMonsterCard> pendulum_monster_cards { get; set; }
        public List<SpellCard> spell_cards { get; set; }
        public List<TrapCard> trap_cards { get; set; }
    }


    public class Info
    {
        public int last_page { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string title_german { get; set; }
        public string title_english { get; set; }
        public string attribute { get; set; }
        public int level { get; set; }
        public string monster_type { get; set; }
        public string card_type { get; set; }
        public string atk { get; set; }
        public string def { get; set; }
        public string card_text_german { get; set; }
        public string card_text_english { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public bool is_forbidden { get; set; }
        public bool is_limited { get; set; }
    }

    public class CardSet
    {
        public string rarity { get; set; }
        public string identifier { get; set; }
    }

    public class MonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
        [JsonIgnore]
        public string url { get=> $"https://yugioh-card-api.kaishiyoku.rocks/api/v1/cards/from_set/{card_sets[0].identifier}/image"; }
    }


    public class RitualMonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }


    public class LinkMonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }


    public class SynchroMonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }


    public class XyzMonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }



    public class PendulumMonsterCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }


    public class SpellCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }


    public class TrapCard
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }

    
}
