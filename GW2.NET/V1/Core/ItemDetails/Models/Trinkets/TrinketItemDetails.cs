﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Trinkets
{
    /// <summary>
    /// Represents detailed information about a trinket.
    /// </summary>
    public class TrinketItemDetails : EquipmentItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrinketItemDetails"/> class.
        /// </summary>
        public TrinketItemDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrinketItemDetails"/> class using the specified values.
        /// </summary>
        /// <param name="infusionSlots">The trinket's infusion slots.</param>
        /// <param name="infixUpgrade">The trinket's infix upgrade.</param>
        /// <param name="suffixItemId">The trinket's suffix item ID.</param>
        /// <param name="type">The trinket's type.</param>
        public TrinketItemDetails(IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int? suffixItemId, TrinketType type)
            : base(infusionSlots, infixUpgrade, suffixItemId)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the trinket's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public TrinketType Type { get; set; }
    }
}