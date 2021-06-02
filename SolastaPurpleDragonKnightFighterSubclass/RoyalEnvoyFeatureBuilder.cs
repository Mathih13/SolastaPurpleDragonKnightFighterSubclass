using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;

namespace SolastaPurpleDragonKnightFighterSubclass
{
    internal class RoyalEnvoyAbilityCheckAffinityBuilder :
    BaseDefinitionBuilder<FeatureDefinitionAbilityCheckAffinity>
    {
        private const string RoyalEnvoyAbilityCheckName = "RoyalEnvoyAbilityCheckAffinity";
        private const string RoyalEnvoyAbilityCheckGuid = "f60028d4-1c53-4e51-b1a6-07f38f1cbcf5";

        protected RoyalEnvoyAbilityCheckAffinityBuilder(string name, string guid)
          : base(DatabaseHelper.FeatureDefinitionAbilityCheckAffinitys.AbilityCheckAffinityChampionRemarkableAthlete, name, guid)
        {
            Definition.AffinityGroups.Clear();
            Definition.AffinityGroups.Add(new FeatureDefinitionAbilityCheckAffinity.AbilityCheckAffinityGroup()
            {
                abilityScoreName = "Charisma",
                affinity = RuleDefinitions.CharacterAbilityCheckAffinity.HalfProficiencyWhenNotProficient
            });
        }

        public static FeatureDefinitionAbilityCheckAffinity CreateAndAddToDB(string name, string guid)
            => new RoyalEnvoyAbilityCheckAffinityBuilder(name, guid).AddToDB();

        public static FeatureDefinitionAbilityCheckAffinity RoyalEnvoyAbilityCheckAffinity
            => CreateAndAddToDB(RoyalEnvoyAbilityCheckName, RoyalEnvoyAbilityCheckGuid);
    }

    public class RoyalEnvoyFeatureBuilder : BaseDefinitionBuilder<FeatureDefinitionFeatureSet>
    {
        private const string RoyalEnvoyFeatureName = "RoyalEnvoyFeature";
        private const string RoyalEnvoyFeatureGuid = "14382b16-e88e-48a0-9ea4-82e353b41136";

        protected RoyalEnvoyFeatureBuilder(string name, string guid)
          : base(DatabaseHelper.FeatureDefinitionFeatureSets.FeatureSetChampionRemarkableAthlete, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&RoyalEnvoyFeatureTitle";
            Definition.GuiPresentation.Description = "Feature/&RoyalEnvoyFeatureDescription";
            Definition.FeatureSet.Clear();
            Definition.FeatureSet.Add(RoyalEnvoyAbilityCheckAffinityBuilder.RoyalEnvoyAbilityCheckAffinity);
            Definition.FeatureSet.Add(DatabaseHelper.FeatureDefinitionSavingThrowAffinitys.SavingThrowAffinityCreedOfSolasta);
        }

        public static FeatureDefinitionFeatureSet CreateAndAddToDB(string name, string guid)
             => new RoyalEnvoyFeatureBuilder(name, guid).AddToDB();

        public static FeatureDefinitionFeatureSet RoyalEnvoyFeatureSet
            => CreateAndAddToDB(RoyalEnvoyFeatureName, RoyalEnvoyFeatureGuid);
    }
}
