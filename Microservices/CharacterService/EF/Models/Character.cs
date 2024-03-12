using CharacterService.EF.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterService.EF.Models
{
    [Table("Characters", Schema = "dbo")]
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterAlignmentEnum Alignment { get; set; }

        [ForeignKey("CharacterClass")]
        public int CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }

        [ForeignKey("CharacterRace")]
        public int CharacterRaceId { get; set; }
        public virtual CharacterRace CharacterRace { get; set; }
        public CharacterEquipmentEnum Equipment { get; set; }
        public int HealthPoints { get; set; }
        public int ExperiencePoints { get; set; } = 0;
        public int Level { get => Math.Max(1, (ExperiencePoints + 9) / 10); }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }
        public int Wisdom { get; set; }
        public virtual IEnumerable<string> Abilities { get; set; } = new List<string>();

        public Character()
        { }
        public Character(string name, CharacterAlignmentEnum alignment, CharacterClass characterClass, CharacterRace characterRace, int baseHealthPoints, CharacterEquipmentEnum equipment, int baseStrength, int baseIntelligence, int baseDexterity, int baseConstitution, int baseCharisma, int baseWisdom, List<string> newAbilities)
        {
            Name = name;
            Alignment = alignment;
            CharacterClass = characterClass;
            CharacterRace = characterRace;
            Equipment = equipment;

            HealthPoints = baseHealthPoints;
            Strength = baseStrength + this.CharacterClass!.StrengthModifier + this.CharacterRace!.StrengthModifier;
            Intelligence = baseIntelligence + this.CharacterClass.IntelligenceModifier + this.CharacterRace.IntelligenceModifier;
            Dexterity = baseDexterity + this.CharacterClass.DexterityModifier + this.CharacterRace.DexterityModifier;
            Constitution = baseConstitution + this.CharacterClass.ConstitutionModifier + this.CharacterRace.ConstitutionModifier;
            Charisma = baseCharisma + this.CharacterClass.CharismaModifier + this.CharacterRace.CharismaModifier;
            Wisdom = baseWisdom + this.CharacterClass.WisdomModifier + this.CharacterRace.WisdomModifier;

            var abilitiesSet = new HashSet<string>(this.CharacterClass.CommonAbilities);
            abilitiesSet.UnionWith(this.CharacterRace.CommonAbilities);
            abilitiesSet.UnionWith(newAbilities);
            Abilities = abilitiesSet;
        }
    }
}
