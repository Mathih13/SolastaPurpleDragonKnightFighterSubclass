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
        private const string RoyalEnvoyAbilityCheckGuid = "b16f8b68-0dab-49e5-b1a2-6fdfd8836849";

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
        private const string RoyalEnvoyFeatureGuid = "c8299685-d806-4e20-aff0-ca3dd4000e05";

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
