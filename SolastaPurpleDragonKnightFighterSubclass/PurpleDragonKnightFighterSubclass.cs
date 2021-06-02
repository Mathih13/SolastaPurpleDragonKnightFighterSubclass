using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaPurpleDragonKnightFighterSubclass
{
    public static class PurpleDragonKnightFighterSubclassBuilder
    {
        private const string PurpleDragonKnightFighterSubclassName = "PurpleDragonKnight";
        private const string PurpleDragonKnightFighterSubclassNameGuid = "2314d5a2-0a7d-471e-849d-7f8825c2523e";

        public static FeatureDefinitionPower RallyingCryPower;
        public static FeatureDefinitionFeatureSet RoyalEnvoy;
        public static FeatureDefinitionPower InspiringSurgePower;

        public static void BuildAndAddSubclass()
        {
            SetupPowers();
            DatabaseHelper.FeatureDefinitionSubclassChoices.SubclassChoiceFighterMartialArchetypes.Subclasses.Add((
                new CharacterSubclassDefinitionBuilder(PurpleDragonKnightFighterSubclassName, PurpleDragonKnightFighterSubclassNameGuid)
                .SetGuiPresentation(new GuiPresentationBuilder("Subclass/&PurpleDragonKnightFighterSubclassDescription", "Subclass/&PurpleDragonKnightFighterSubclassTitle").SetSpriteReference(DatabaseHelper.FightingStyleDefinitions.Protection.GuiPresentation.SpriteReference).Build())
                .AddFeatureAtLevel(RallyingCryPower, 3)
                .AddFeatureAtLevel(RoyalEnvoy, 7)
                .AddFeatureAtLevel(InspiringSurgePower, 10))
                .AddToDB(true).Name);
        }

        public static void SetupPowers()
        {
            RallyingCryPower = RallyingCryPowerBuilder.RallyingCryPower;
            RoyalEnvoy = RoyalEnvoyFeatureBuilder.RoyalEnvoyFeatureSet;
            InspiringSurgePower = InspiringSurgePowerBuilder.InspiringSurgePower;
        }
    }    
}
