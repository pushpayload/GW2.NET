namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class CombatAttributeConverterFactory : ITypeConverterFactory<AttributeDTO, CombatAttribute>
    {
        public IConverter<AttributeDTO, CombatAttribute> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "ConditionDamage":
                    return new ConditionDamageModifierConverter();
                case "CritDamage":
                    return new FerocityModifierConverter();
                case "Healing":
                    return new HealingModifierConverter();
                case "Power":
                    return new PowerModifierConverter();
                case "Precision":
                    return new PrecisionModifierConverter();
                case "Toughness":
                    return new ToughnessModifierConverter();
                case "Vitality":
                    return new VitalityModifierConverter();
                default:
                    return new UnknownModifierConverter();
            }
        }
    }
}