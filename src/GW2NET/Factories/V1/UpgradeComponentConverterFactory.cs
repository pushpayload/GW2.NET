namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class UpgradeComponentConverterFactory : ITypeConverterFactory<ItemDTO, UpgradeComponent>
    {
        public IConverter<ItemDTO, UpgradeComponent> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Default":
                    return new DefaultUpgradeComponentConverter();
                case "Gem":
                    return new GemConverter();
                case "Sigil":
                    return new SigilConverter();
                case "Rune":
                    return new RuneConverter();
                default:
                    return new UnknownUpgradeComponentConverter();
            }
        }
    }
}