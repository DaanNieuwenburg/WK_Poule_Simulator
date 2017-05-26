using Newtonsoft.Json;


namespace WK_SIMULATOR.Model
{
    public class Player
    {
        [JsonProperty("Name")]
        public string Name { get; set; }        // The Player's name
        [JsonProperty("Number")]
        public int Number { get; set; }         // Shirtnumber of the player
        [JsonProperty("Teamname")]
        public string Teamname { get; set; }    // Name of Player's team
        [JsonProperty("Skill_lvl")]
        public int SkillLvl { get; set; }       // Skill level from 1 (low) to 5(high)
        [JsonProperty("Position")]          
        public char Position { get; set; }      // 'K' = keeper 'A' = attacker  'M' = mid  'D' = defender
    }
}
