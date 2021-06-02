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
        private const string PurpleDragonKnightFighterSubclassNameGuid = "f5efd735-ff95-4256-ad17-dde585aeb4e2";

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
