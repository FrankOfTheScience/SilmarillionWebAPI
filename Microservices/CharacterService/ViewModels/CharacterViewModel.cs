using CharacterService.EF.Models.Enums;
using Newtonsoft.Json;

namespace CharacterService.ViewModels
{
    public class CharacterViewModel
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = string.Empty;
        [JsonProperty(nameof(Alignment))]
        public CharacterAlignmentEnum Alignment { get; set; }
        [JsonProperty(nameof(CharacterClass))]
        public CharacterClassEnum CharacterClass { get; set; }
        [JsonProperty(nameof(CharacterRace))]
        public CharacterRaceEnum CharacterRace { get; set; }
        [JsonProperty(nameof(Abilities))]
        public IEnumerable<string> Abilities { get; set; } = new List<string>();
        [JsonProperty(nameof(Equipment))]
        public CharacterEquipmentEnum Equipment { get; set; }
        [JsonProperty(nameof(Strength))]
        public int Strength { get; set; }
        [JsonProperty(nameof(Intelligence))]
        public int Intelligence { get; set; }
        [JsonProperty(nameof(Dexterity))]
        public int Dexterity { get; set; }
        [JsonProperty(nameof(Constitution))]
        public int Constitution { get; set; }
        [JsonProperty(nameof(Charisma))]
        public int Charisma { get; set; }
        [JsonProperty(nameof(Wisdom))]
        public int Wisdom { get; set; }
        [JsonProperty(nameof(Health))]
        public int Health { get; set; }
    }
}
