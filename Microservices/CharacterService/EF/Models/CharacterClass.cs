using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterService.EF.Models
{
    [Table("CharacterClass", Schema = "dbo")]
    public class CharacterClass
    {
        [Key]
        public int Id { get; set; }
        public Enums.CharacterClassEnum ClassName { get; set; }
        public virtual IEnumerable<string> CommonAbilities { get; set; } = new List<string>();
        public int StrengthModifier { get; set; }
        public int IntelligenceModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int ConstitutionModifier { get; set; }
        public int CharismaModifier { get; set; }
        public int WisdomModifier { get; set; }

        public CharacterClass()
        { }
    }
}
