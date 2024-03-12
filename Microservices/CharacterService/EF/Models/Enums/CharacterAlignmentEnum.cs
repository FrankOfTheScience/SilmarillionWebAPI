using System.ComponentModel;

namespace CharacterService.EF.Models.Enums
{
    public enum CharacterAlignmentEnum
    {
        [Description("LawfulGood")]
        LawfulGood = 0,
        [Description("LawfullNeutral")]
        LawfullNeutral = 1,
        [Description("LawfullEvil")]
        LawfullEvil = 2,
        [Description("NeutralGood")]
        NeutralGood = 3,
        [Description("PureNeutral")]
        PureNeutral = 4,
        [Description("NeutralEvil")]
        NeutralEvil = 5,
        [Description("ChaoticGood")]
        ChaoticGood = 6,
        [Description("ChaoticNeutral")]
        ChaoticNeutral = 7,
        [Description("ChaoticEvil")]
        ChaoticEvil = 8
    }
}
