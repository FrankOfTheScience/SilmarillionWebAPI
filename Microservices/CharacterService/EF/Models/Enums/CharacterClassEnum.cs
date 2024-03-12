using System.ComponentModel;

namespace CharacterService.EF.Models.Enums
{
    public enum CharacterClassEnum
    {
        [Description("Bard")]
        Bard = 0,
        [Description("Druid")]
        Druid = 1,
        [Description("Paladine")]
        Paladine = 2,
        [Description("Ranger")]
        Ranger = 3,
        [Description("Thief")]
        Thief = 4,
        [Description("Warrior")]
        Warrior = 5
    }
}
