using System.ComponentModel;

namespace CharacterService.EF.Models.Enums
{
    public enum CharacterEquipmentEnum
    {
        [Description("LongSword")]
        LongSword = 0,
        [Description("Sword")]
        Sword = 1,
        [Description("Bow")]
        Bow = 2,
        [Description("MagicWound")]
        MagicWound = 3,
        [Description("RingOfPower")]
        RingOfPower = 4,
        [Description("WarHammer")]
        WarHammer = 5,
        [Description("Axe")]
        Axe = 6
    }
}
