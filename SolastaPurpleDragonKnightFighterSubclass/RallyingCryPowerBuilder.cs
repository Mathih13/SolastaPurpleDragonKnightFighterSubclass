using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaPurpleDragonKnightFighterSubclass
{
    public class RallyingCryPowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        private const string RallyingCryPowerName = "CounterStrikePower";
        private const string RallyingCryPowerGuid = "88c294ce-14fa-4f7e-8b81-ea4d289e3d8b";

        protected RallyingCryPowerBuilder(string name, string guid)
          : base(DatabaseHelper.FeatureDefinitionPowers.PowerDomainLifePreserveLife, name, guid)
        {
            Definition.SetOverriddenPower(DatabaseHelper.FeatureDefinitionPowers.PowerFighterSecondWind);
            Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
            Definition.SetRechargeRate(RuleDefinitions.RechargeRate.None);
            Definition.SetAbilityScore("Charisma");
            Definition.SetUsesAbilityScoreName("Charisma");

            SetupGUI();

            EffectDescription effectDescription = new EffectDescription();
            effectDescription.Copy(Definition.EffectDescription);
            effectDescription.EffectForms[0].HealingForm.HealingCap = RuleDefinitions.HealingCap.MaximumHitPoints;
            effectDescription.EffectForms[0].HealingForm.DiceNumber = 4;
            FeatureDefinitionPowerExtensions.SetEffectDescription(Definition, effectDescription);
        }

        private void SetupGUI()
        {
            Definition.GuiPresentation.Title = "Feature/&RallyingCryPowerTitle";
            Definition.GuiPresentation.Description = "Feature/&RallyingCryPowerDescription";
            FeatureDefinitionPowerExtensions.SetShortTitleOverride(Definition, "Feature/&RallyingCryPowerTitleShort");
            GuiPresentationExtensions.SetSpriteReference(Definition.GuiPresentation, DatabaseHelper.SpellDefinitions.HealingWord.GuiPresentation.SpriteReference);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new RallyingCryPowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower RallyingCryPower
            => CreateAndAddToDB(RallyingCryPowerName, RallyingCryPowerGuid);
    }
}
