﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemAttribute.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Common
{
    /// <summary>
    /// Represents one of an item's attributes.
    /// </summary>
    public class ItemAttribute : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAttribute"/> class.
        /// </summary>
        public ItemAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAttribute"/> class using the specified values.
        /// </summary>
        /// <param name="type">The attribute's type.</param>
        /// <param name="modifier">The attribute's modifier.</param>
        public ItemAttribute(ItemAttributeType type, string modifier)
        {
            this.Type = type;
            this.Modifier = modifier;
        }

        /// <summary>
        /// Gets or sets the attribute's modifier.
        /// </summary>
        [JsonProperty("modifier", Order = 1)]
        public string Modifier { get; set; }

        /// <summary>
        /// Gets or sets the attribute's type.
        /// </summary>
        [JsonProperty("attribute", Order = 0)]
        public ItemAttributeType Type { get; set; }
    }
}