#nullable enable
using Newtonsoft.Json;

namespace HGV.Euls.Server.Models
{
    public static class GAMESTATE
    {
        public const string HERO_SELECTION = "DOTA_GAMERULES_STATE_HERO_SELECTION";
        public const string STRATEGY_TIME = "DOTA_GAMERULES_STATE_STRATEGY_TIME";
        public const string PRE_GAME = "DOTA_GAMERULES_STATE_PRE_GAME";
        public const string GAME_IN_PROGRESS = "DOTA_GAMERULES_STATE_GAME_IN_PROGRESS";
        public const string POST_GAME = "DOTA_GAMERULES_STATE_POST_GAME";
    }

    
    public class BuildingHealth
    {
        [JsonProperty("health")]
        public int? Health { get; set; }

        [JsonProperty("max_health")]
        public int? MaxHealth { get; set; }
    }

    public class RadiantBuildings
    {
        [JsonProperty("dota_goodguys_tower1_top")]
        public BuildingHealth DotaGoodguysTower1Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower2_top")]
        public BuildingHealth DotaGoodguysTower2Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower3_top")]
        public BuildingHealth DotaGoodguysTower3Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower1_mid")]
        public BuildingHealth DotaGoodguysTower1Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower2_mid")]
        public BuildingHealth DotaGoodguysTower2Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower3_mid")]
        public BuildingHealth DotaGoodguysTower3Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower1_bot")]
        public BuildingHealth DotaGoodguysTower1Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower2_bot")]
        public BuildingHealth DotaGoodguysTower2Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower3_bot")]
        public BuildingHealth DotaGoodguysTower3Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower4_top")]
        public BuildingHealth DotaGoodguysTower4Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_tower4_bot")]
        public BuildingHealth DotaGoodguysTower4Bot { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_melee_top")]
        public BuildingHealth GoodRaxMeleeTop { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_range_top")]
        public BuildingHealth GoodRaxRangeTop { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_melee_mid")]
        public BuildingHealth GoodRaxMeleeMid { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_range_mid")]
        public BuildingHealth GoodRaxRangeMid { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_melee_bot")]
        public BuildingHealth GoodRaxMeleeBot { get; set; } = new BuildingHealth();

        [JsonProperty("good_rax_range_bot")]
        public BuildingHealth GoodRaxRangeBot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_goodguys_fort")]
        public BuildingHealth DotaGoodguysFort { get; set; } = new BuildingHealth();
    }

    public class DireBuilding
    {
        [JsonProperty("dota_badguys_tower1_top")]
        public BuildingHealth DotaBadguysTower1Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower2_top")]
        public BuildingHealth DotaBadguysTower2Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower3_top")]
        public BuildingHealth DotaBadguysTower3Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower1_mid")]
        public BuildingHealth DotaBadguysTower1Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower2_mid")]
        public BuildingHealth DotaBadguysTower2Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower3_mid")]
        public BuildingHealth DotaBadguysTower3Mid { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower1_bot")]
        public BuildingHealth DotaBadguysTower1Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower2_bot")]
        public BuildingHealth DotaBadguysTower2Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower3_bot")]
        public BuildingHealth DotaBadguysTower3Bot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower4_top")]
        public BuildingHealth DotaBadguysTower4Top { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_tower4_bot")]
        public BuildingHealth DotaBadguysTower4Bot { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_melee_top")]
        public BuildingHealth BadRaxMeleeTop { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_range_top")]
        public BuildingHealth BadRaxRangeTop { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_melee_mid")]
        public BuildingHealth BadRaxMeleeMid { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_range_mid")]
        public BuildingHealth BadRaxRangeMid { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_melee_bot")]
        public BuildingHealth BadRaxMeleeBot { get; set; } = new BuildingHealth();

        [JsonProperty("bad_rax_range_bot")]
        public BuildingHealth BadRaxRangeBot { get; set; } = new BuildingHealth();

        [JsonProperty("dota_badguys_fort")]
        public BuildingHealth DotaBadguysFort { get; set; } = new BuildingHealth();
    }

    public class Buildings
    {
        [JsonProperty("radiant")]
        public RadiantBuildings Radiant { get; set; } = new RadiantBuildings();

        [JsonProperty("dire")]
        public DireBuilding Dire { get; set; } = new DireBuilding();
    }

    

    public class PlayerInfo
    {
        [JsonProperty("steamid")]
        public string? Steamid { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("activity")]
        public string? Activity { get; set; } // playing

        [JsonProperty("kills")]
        public int? Kills { get; set; }

        [JsonProperty("deaths")]
        public int? Deaths { get; set; }

        [JsonProperty("assists")]
        public int? Assists { get; set; }

        [JsonProperty("last_hits")]
        public int? LastHits { get; set; }

        [JsonProperty("denies")]
        public int? Denies { get; set; }

        [JsonProperty("kill_streak")]
        public int? KillStreak { get; set; }

        [JsonProperty("commands_issued")]
        public int? CommandsIssued { get; set; }

        //[JsonProperty("kill_list")]
        //public KillList KillList { get; set; } = new KillList();

        [JsonProperty("team_name")]
        public string? TeamName { get; set; } // radiant or dire

        [JsonProperty("gold")]
        public int? Gold { get; set; }

        [JsonProperty("gold_reliable")]
        public int? GoldReliable { get; set; }

        [JsonProperty("gold_unreliable")]
        public int? GoldUnreliable { get; set; }

        [JsonProperty("gold_from_hero_kills")]
        public int? GoldFromHeroKills { get; set; }

        [JsonProperty("gold_from_creep_kills")]
        public int? GoldFromCreepKills { get; set; }

        [JsonProperty("gold_from_income")]
        public int? GoldFromIncome { get; set; }

        [JsonProperty("gold_from_shared")]
        public int? GoldFromShared { get; set; }

        [JsonProperty("gpm")]
        public int? Gpm { get; set; }

        [JsonProperty("xpm")]
        public int? Xpm { get; set; }

        [JsonProperty("net_worth")]
        public int? NetWorth { get; set; }

        [JsonProperty("hero_damage")]
        public int? HeroDamage { get; set; }

        [JsonProperty("wards_purchased")]
        public int? WardsPurchased { get; set; }

        [JsonProperty("wards_placed")]
        public int? WardsPlaced { get; set; }

        [JsonProperty("wards_destroyed")]
        public int? WardsDestroyed { get; set; }

        [JsonProperty("runes_activated")]
        public int? RunesActivated { get; set; }

        [JsonProperty("camps_stacked")]
        public int? CampsStacked { get; set; }

        [JsonProperty("support_gold_spent")]
        public int? SupportGoldSpent { get; set; }

        [JsonProperty("consumable_gold_spent")]
        public int? ConsumableGoldSpent { get; set; }

        [JsonProperty("item_gold_spent")]
        public int? ItemGoldSpent { get; set; }

        [JsonProperty("gold_lost_to_death")]
        public int? GoldLostToDeath { get; set; }

        [JsonProperty("gold_spent_on_buybacks")]
        public int? GoldSpentOnBuybacks { get; set; }

    }

    public class PlayersRadiant
    {
        [JsonProperty("player0")]
        public PlayerInfo Player0 { get; set; } = new PlayerInfo();

        [JsonProperty("player1")]
        public PlayerInfo Player1 { get; set; } = new PlayerInfo();

        [JsonProperty("player2")]
        public PlayerInfo Player2 { get; set; } = new PlayerInfo();

        [JsonProperty("player3")]
        public PlayerInfo Player3 { get; set; } = new PlayerInfo();

        [JsonProperty("player4")]
        public PlayerInfo Player4 { get; set; } = new PlayerInfo();
    }

    public class PlayersDire
    {
        [JsonProperty("player5")]
        public PlayerInfo Player5 { get; set; } = new PlayerInfo();

        [JsonProperty("player6")]
        public PlayerInfo Player6 { get; set; } = new PlayerInfo();

        [JsonProperty("player7")]
        public PlayerInfo Player7 { get; set; } = new PlayerInfo();

        [JsonProperty("player8")]
        public PlayerInfo Player8 { get; set; } = new PlayerInfo();

        [JsonProperty("player9")]
        public PlayerInfo Player9 { get; set; } = new PlayerInfo();
    }

    public class Players
    {
        [JsonProperty("team2")]
        public PlayersRadiant Radiant { get; set; } = new PlayersRadiant();

        [JsonProperty("team3")]
        public PlayersDire Dire { get; set; } = new PlayersDire();
    }



    public class HeroPlayer
    {
        [JsonProperty("xpos")]
        public int? Xpos { get; set; }

        [JsonProperty("ypos")]
        public int? Ypos { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("xp")]
        public int? Xp { get; set; }

        [JsonProperty("alive")]
        public bool? Alive { get; set; }

        [JsonProperty("respawn_seconds")]
        public int? RespawnSeconds { get; set; }

        [JsonProperty("buyback_cost")]
        public int? BuybackCost { get; set; }

        [JsonProperty("buyback_cooldown")]
        public int? BuybackCooldown { get; set; }

        [JsonProperty("health")]
        public int? Health { get; set; }

        [JsonProperty("max_health")]
        public int? MaxHealth { get; set; }

        [JsonProperty("health_percent")]
        public int? HealthPercent { get; set; }

        [JsonProperty("mana")]
        public int? Mana { get; set; }

        [JsonProperty("max_mana")]
        public int? MaxMana { get; set; }

        [JsonProperty("mana_percent")]
        public int? ManaPercent { get; set; }

        [JsonProperty("silenced")]
        public bool? Silenced { get; set; }

        [JsonProperty("stunned")]
        public bool? Stunned { get; set; }

        [JsonProperty("disarmed")]
        public bool? Disarmed { get; set; }

        [JsonProperty("magicimmune")]
        public bool? Magicimmune { get; set; }

        [JsonProperty("hexed")]
        public bool? Hexed { get; set; }

        [JsonProperty("muted")]
        public bool? Muted { get; set; }

        [JsonProperty("break")]
        public bool? Break { get; set; }

        [JsonProperty("aghanims_scepter")]
        public bool? AghanimsScepter { get; set; }

        [JsonProperty("aghanims_shard")]
        public bool? AghanimsShard { get; set; }

        [JsonProperty("smoked")]
        public bool? Smoked { get; set; }

        [JsonProperty("has_debuff")]
        public bool? HasDebuff { get; set; }

        [JsonProperty("selected_unit")]
        public bool? SelectedUnit { get; set; }

        [JsonProperty("talent_1")]
        public bool? Talent1 { get; set; }

        [JsonProperty("talent_2")]
        public bool? Talent2 { get; set; }

        [JsonProperty("talent_3")]
        public bool? Talent3 { get; set; }

        [JsonProperty("talent_4")]
        public bool? Talent4 { get; set; }

        [JsonProperty("talent_5")]
        public bool? Talent5 { get; set; }

        [JsonProperty("talent_6")]
        public bool? Talent6 { get; set; }

        [JsonProperty("talent_7")]
        public bool? Talent7 { get; set; }

        [JsonProperty("talent_8")]
        public bool? Talent8 { get; set; }
    }

    public class HeroesRadiant
    {
        [JsonProperty("player0")]
        public HeroPlayer Player0 { get; set; } = new HeroPlayer();

        [JsonProperty("player1")]
        public HeroPlayer Player1 { get; set; } = new HeroPlayer();

        [JsonProperty("player2")]
        public HeroPlayer Player2 { get; set; } = new HeroPlayer();

        [JsonProperty("player3")]
        public HeroPlayer Player3 { get; set; } = new HeroPlayer();

        [JsonProperty("player4")]
        public HeroPlayer Player4 { get; set; } = new HeroPlayer();
    }

    public class HeroesDire
    {
        [JsonProperty("player5")]
        public HeroPlayer Player5 { get; set; } = new HeroPlayer();

        [JsonProperty("player6")]
        public HeroPlayer Player6 { get; set; } = new HeroPlayer();

        [JsonProperty("player7")]
        public HeroPlayer Player7 { get; set; } = new HeroPlayer();

        [JsonProperty("player8")]
        public HeroPlayer Player8 { get; set; } = new HeroPlayer();

        [JsonProperty("player9")]
        public HeroPlayer Player9 { get; set; } = new HeroPlayer();
    }

    public class Heroes
    {
        [JsonProperty("team2")]
        public HeroesRadiant Radiant { get; set; } = new HeroesRadiant();

        [JsonProperty("team3")]
        public HeroesDire Dire { get; set; } = new HeroesDire();
    }

    

    public class AbilityInfo
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("can_cast")]
        public bool? CanCast { get; set; }

        [JsonProperty("passive")]
        public bool? Passive { get; set; }

        [JsonProperty("ability_active")]
        public bool? AbilityActive { get; set; }

        [JsonProperty("cooldown")]
        public int? Cooldown { get; set; }

        [JsonProperty("ultimate")]
        public bool? Ultimate { get; set; }
    }

    public class AbilitiesPlayer
    {
        [JsonProperty("ability0")]
        public AbilityInfo Ability0 { get; set; } = new AbilityInfo();

        [JsonProperty("ability1")]
        public AbilityInfo Ability1 { get; set; } = new AbilityInfo();

        [JsonProperty("ability2")]
        public AbilityInfo Ability2 { get; set; } = new AbilityInfo();

        [JsonProperty("ability3")]
        public AbilityInfo Ability3 { get; set; } = new AbilityInfo(); // Ultimate

        [JsonProperty("ability4")]
        public AbilityInfo Ability4 { get; set; } = new AbilityInfo(); // plus_high_five

        [JsonProperty("ability5")]
        public AbilityInfo Ability5 { get; set; } = new AbilityInfo(); // plus_guild_banner
    }

    public class AbilitiesRadiant
    {
        [JsonProperty("player0")]
        public AbilitiesPlayer Player0 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player1")]
        public AbilitiesPlayer Player1 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player2")]
        public AbilitiesPlayer Player2 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player3")]
        public AbilitiesPlayer Player3 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player4")]
        public AbilitiesPlayer Player4 { get; set; } = new AbilitiesPlayer();
    }

    public class AbilitiesDire
    {
        [JsonProperty("player5")]
        public AbilitiesPlayer Player5 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player6")]
        public AbilitiesPlayer Player6 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player7")]
        public AbilitiesPlayer Player7 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player8")]
        public AbilitiesPlayer Player8 { get; set; } = new AbilitiesPlayer();

        [JsonProperty("player9")]
        public AbilitiesPlayer Player9 { get; set; } = new AbilitiesPlayer();
    }

    public class Abilities
    {
        [JsonProperty("team2")]
        public AbilitiesRadiant Radiant { get; set; } = new AbilitiesRadiant();

        [JsonProperty("team3")]
        public AbilitiesDire Dire { get; set; } = new AbilitiesDire();
    }



    public class ItemSlot
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("purchaser")]
        public int? Purchaser { get; set; }

        [JsonProperty("passive")]
        public bool? Passive { get; set; }

        [JsonProperty("can_cast")]
        public bool? CanCast { get; set; }

        [JsonProperty("cooldown")]
        public int? Cooldown { get; set; }

        [JsonProperty("charges")]
        public int? Charges { get; set; }
    }

    public class ItemsPlayer
    {

        [JsonProperty("slot0")]
        public ItemSlot Slot0 { get; set; } = new ItemSlot();

        [JsonProperty("slot1")]
        public ItemSlot Slot1 { get; set; } = new ItemSlot();

        [JsonProperty("slot2")]
        public ItemSlot Slot2 { get; set; } = new ItemSlot();

        [JsonProperty("slot3")]
        public ItemSlot Slot3 { get; set; } = new ItemSlot();

        [JsonProperty("slot4")]
        public ItemSlot Slot4 { get; set; } = new ItemSlot();

        [JsonProperty("slot5")]
        public ItemSlot Slot5 { get; set; } = new ItemSlot();

        [JsonProperty("slot6")]
        public ItemSlot Slot6 { get; set; } = new ItemSlot();

        [JsonProperty("slot7")]
        public ItemSlot Slot7 { get; set; } = new ItemSlot();

        [JsonProperty("slot8")]
        public ItemSlot Slot8 { get; set; } = new ItemSlot();

        [JsonProperty("stash0")]
        public ItemSlot Stash0 { get; set; } = new ItemSlot();

        [JsonProperty("stash1")]
        public ItemSlot Stash1 { get; set; } = new ItemSlot();

        [JsonProperty("stash2")]
        public ItemSlot Stash2 { get; set; } = new ItemSlot();

        [JsonProperty("stash3")]
        public ItemSlot Stash3 { get; set; } = new ItemSlot();

        [JsonProperty("stash4")]
        public ItemSlot Stash4 { get; set; } = new ItemSlot();

        [JsonProperty("stash5")]
        public ItemSlot Stash5 { get; set; } = new ItemSlot();

        [JsonProperty("teleport0")]
        public ItemSlot Teleport { get; set; } = new ItemSlot();

        [JsonProperty("neutral0")]
        public ItemSlot Neutral { get; set; } = new ItemSlot();
    }

    public class ItemsRadiant
    {
        [JsonProperty("player0")]
        public ItemsPlayer Player0 { get; set; } = new ItemsPlayer();

        [JsonProperty("player1")]
        public ItemsPlayer Player1 { get; set; } = new ItemsPlayer();

        [JsonProperty("player2")]
        public ItemsPlayer Player2 { get; set; } = new ItemsPlayer();

        [JsonProperty("player3")]
        public ItemsPlayer Player3 { get; set; } = new ItemsPlayer();

        [JsonProperty("player4")]
        public ItemsPlayer Player4 { get; set; } = new ItemsPlayer();
    }

    public class ItemsDire
    {
        [JsonProperty("player5")]
        public ItemsPlayer Player5 { get; set; } = new ItemsPlayer();

        [JsonProperty("player6")]
        public ItemsPlayer Player6 { get; set; } = new ItemsPlayer();

        [JsonProperty("player7")]
        public ItemsPlayer Player7 { get; set; } = new ItemsPlayer();

        [JsonProperty("player8")]
        public ItemsPlayer Player8 { get; set; } = new ItemsPlayer();

        [JsonProperty("player9")]
        public ItemsPlayer Player9 { get; set; } = new ItemsPlayer();
    }

    public class Items
    {
        [JsonProperty("team2")]
        public ItemsRadiant Radiant { get; set; } = new ItemsRadiant();

        [JsonProperty("team3")]
        public ItemsDire Dire { get; set; } = new ItemsDire();
    }



    public class CosmeticPlayer
    {
        [JsonProperty("wearable0")]
        public int? Wearable0 { get; set; }

        [JsonProperty("wearable1")]
        public int? Wearable1 { get; set; }

        [JsonProperty("wearable2")]
        public int? Wearable2 { get; set; }

        [JsonProperty("wearable3")]
        public int? Wearable3 { get; set; }

        [JsonProperty("wearable4")]
        public int? Wearable4 { get; set; }

        [JsonProperty("wearable5")]
        public int? Wearable5 { get; set; }

        [JsonProperty("wearable6")]
        public int? Wearable6 { get; set; }

        [JsonProperty("wearable7")]
        public int? Wearable7 { get; set; }

        [JsonProperty("wearable8")]
        public int? Wearable8 { get; set; }
    }

    public class WearablesRadiant
    {
        [JsonProperty("player0")]
        public CosmeticPlayer Player0 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player1")]
        public CosmeticPlayer Player1 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player2")]
        public CosmeticPlayer Player2 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player3")]
        public CosmeticPlayer Player3 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player4")]
        public CosmeticPlayer Player4 { get; set; } = new CosmeticPlayer();
    }

    public class WearablesDire
    {
        [JsonProperty("player5")]
        public CosmeticPlayer Player5 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player6")]
        public CosmeticPlayer Player6 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player7")]
        public CosmeticPlayer Player7 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player8")]
        public CosmeticPlayer Player8 { get; set; } = new CosmeticPlayer();

        [JsonProperty("player9")]
        public CosmeticPlayer Player9 { get; set; } = new CosmeticPlayer();
    }

    public class Wearables
    {
        [JsonProperty("team2")]
        public WearablesRadiant Radiant { get; set; } = new WearablesRadiant();

        [JsonProperty("team3")]
        public WearablesDire Dire { get; set; } = new WearablesDire();
    }

    
    public class Provider
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("appid")]
        public int? Appid { get; set; }

        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("timestamp")]
        public int? Timestamp { get; set; }
    }

    public class Map
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("matchid")]
        public string? Matchid { get; set; }

        [JsonProperty("game_time")]
        public int? GameTime { get; set; }

        [JsonProperty("clock_time")]
        public int? ClockTime { get; set; }

        [JsonProperty("daytime")]
        public bool? Daytime { get; set; }

        [JsonProperty("nightstalker_night")]
        public bool? NightstalkerNight { get; set; }

        [JsonProperty("game_state")]
        public string? GameState { get; set; } // GAMESTATE

        [JsonProperty("paused")]
        public bool? Paused { get; set; }

        [JsonProperty("win_team")]
        public string? WinTeam { get; set; }

        [JsonProperty("customgamename")]
        public string? Customgamename { get; set; }

        [JsonProperty("radiant_ward_purchase_cooldown")]
        public int? RadiantWardPurchaseCooldown { get; set; }

        [JsonProperty("dire_ward_purchase_cooldown")]
        public int? DireWardPurchaseCooldown { get; set; }

        [JsonProperty("roshan_state")]
        public string? RoshanState { get; set; }

        [JsonProperty("roshan_state_end_seconds")]
        public int? RoshanStateEndSeconds { get; set; }

        [JsonProperty("radiant_win_chance")]
        public int? RadiantWinChance { get; set; }
    }

    public class Auth
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
    }


    //public class Draft
    //{
    //}

    public class Previously
    {
        [JsonProperty("map")]
        public Map Map { get; set; } = new Map();

        //[JsonProperty("hero")]
        //public Heroes Hero { get; set; } = new Heroes();

        //[JsonProperty("items")]
        //public Items Items { get; set; } = new Items();
    }

    public class Root
    {
        //[JsonProperty("buildings")]
        //public Buildings Buildings { get; set; } = new Buildings();

        [JsonProperty("provider")]
        public Provider Provider { get; set; } = new Provider();

        //[JsonProperty("map")]
        //public Map Map { get; set; } = new Map();

        [JsonProperty("player")]
        public Players Players { get; set; } = new Players();

        [JsonProperty("hero")]
        public Heroes Heroes { get; set; } = new Heroes();

        [JsonProperty("abilities")]
        public Abilities Abilities { get; set; } = new Abilities();

        //[JsonProperty("items")]
        //public Items Items { get; set; } = new Items();

        //[JsonProperty("wearables")]
        //public Wearables Wearables { get; set; } = new Wearables();

        [JsonProperty("auth")]
        public Auth Auth { get; set; } = new Auth();

        [JsonProperty("token")]
        public string Token => Auth.Token;


        //[JsonProperty("draft")]
        //public Draft Draft { get; set; } = new Draft();


        //[JsonProperty("previously")]
        //public Previously Previously { get; set; } = new Previously();
    }
}
