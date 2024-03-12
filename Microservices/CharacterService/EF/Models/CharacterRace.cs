using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterService.EF.Models
{
    [Table("CharacterRace", Schema = "dbo")]
    public class CharacterRace
    {
        [Key]
        public int Id { get; set; }
        public Enums.CharacterRaceEnum RaceName { get; set; }
        public virtual IEnumerable<string> CommonAbilities { get; set; } = new List<string>();
        public int StrengthModifier { get; set; }
        public int IntelligenceModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int ConstitutionModifier { get; set; }
        public int CharismaModifier { get; set; }
        public int WisdomModifier { get; set; }

        public CharacterRace()
        { }
    }
}
