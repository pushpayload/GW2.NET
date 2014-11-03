﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Unlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Unlocker"/>.</summary>
    internal sealed class ConverterForUnlocker : IConverter<DetailsDataContract, Unlocker>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Unlocker>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUnlocker"/> class.</summary>
        public ConverterForUnlocker()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUnlocker"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        public ConverterForUnlocker(IDictionary<string, IConverter<DetailsDataContract, Unlocker>> typeConverters)
        {
            Contract.Requires(typeConverters != null);
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Unlocker"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Unlocker Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            IConverter<DetailsDataContract, Unlocker> converter;
            if (this.typeConverters.TryGetValue(value.UnlockType, out converter))
            {
                return converter.Convert(value);
            }

            return new UnknownUnlocker();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Unlocker>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Unlocker>>
            {
                { "BagSlot", new ConverterForBagSlotUnlocker() },
                { "BankTab", new ConverterForBankTabUnlocker() },
                { "CollectibleCapacity", new ConverterForCollectibleCapacityUnlocker() },
                { "Content", new ConverterForContentUnlocker() },
                { "CraftingRecipe", new ConverterForCraftingRecipeUnlocker() },
                { "Dye", new ConverterForDyeUnlocker() }
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
        }
    }
}