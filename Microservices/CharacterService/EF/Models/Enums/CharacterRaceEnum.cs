using System.ComponentModel;

namespace CharacterService.EF.Models.Enums
{
    public enum CharacterRaceEnum
    {
        [Description("Dwarf")]
        Dwarf = 0,
        [Description("Elf")]
        Elf = 1,
        [Description("Hobbit")]
        Hobbit = 2,
        [Description("Human")]
        Human = 3,
        [Description("Orc")]
        Orc = 4,
        [Description("Wizard")]
        Wizard = 5
    }
}
