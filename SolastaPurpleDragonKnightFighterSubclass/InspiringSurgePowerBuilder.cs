using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaPurpleDragonKnightFighterSubclass
{
    public class InspiringSurgePowerBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        private const string InspiringSurgePowerName = "InspiringSurgePower";
        private const string InspiringSurgePowerNameGuid = "620bab59-8dc0-4918-95fc-5065986a6737";

        protected InspiringSurgePowerBuilder(string name, string guid)
          : base(DatabaseHelper.FeatureDefinitionPowers.PowerDomainLifePreserveLife, name, guid)
        {
           Definition.SetActivationTime(RuleDefinitions.ActivationTime.BonusAction);
           Definition.SetRechargeRate(RuleDefinitions.RechargeRate.LongRest);

            SetupGUI();

            EffectDescription effectDescription = new EffectDescription();
            effectDescription.Copy(Definition.EffectDescription);
            effectDescription.SetTargetType(RuleDefinitions.TargetType.Individuals);
            effectDescription.SetTargetParameter(1);
            effectDescription.SetTargetParameter2(2);
            effectDescription.SetTargetSide(RuleDefinitions.Side.Ally);
            effectDescription.SetCanBePlacedOnCharacter(true);
            effectDescription.SetTargetFilteringMethod(RuleDefinitions.TargetFilteringMethod.CharacterOnly);
            effectDescription.DurationType = RuleDefinitions.DurationType.Round;
            effectDescription.SetRequiresVisibilityForPosition(true);
            effectDescription.SetRangeType(RuleDefinitions.RangeType.Distance);
            effectDescription.SetRangeParameter(20);

            effectDescription.EffectForms.Clear();
            foreach (EffectForm effectForm in DatabaseHelper.FeatureDefinitionPowers.PowerFighterActionSurge.EffectDescription.EffectForms)
                effectDescription.EffectForms.Add(effectForm);

            FeatureDefinitionPowerExtensions.SetEffectDescription(Definition, effectDescription);
        }

        private void SetupGUI()
        {
            Definition.GuiPresentation.Title = "Feature/&InspiringSurgePowerTitle";
            Definition.GuiPresentation.Description = "Feature/&InspiringSurgePowerDescription";
            FeatureDefinitionPowerExtensions.SetShortTitleOverride(Definition, "Feature/&InspiringSurgePowerTitleShort");
            GuiPresentationExtensions.SetSpriteReference(Definition.GuiPresentation, DatabaseHelper.SpellDefinitions.Heroism.GuiPresentation.SpriteReference);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid)
            => new InspiringSurgePowerBuilder(name, guid).AddToDB();

        public static FeatureDefinitionPower InspiringSurgePower
            => CreateAndAddToDB(InspiringSurgePowerName, InspiringSurgePowerNameGuid);
    }
}
