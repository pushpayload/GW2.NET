﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Bags
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a bag.</summary>
    public class BagDetails : ItemDetails
    {
        /// <summary>Gets or sets a value indicating whether this is an invisible bag.</summary>
        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        [JsonConverter(typeof(JsonBooleanConverter))]
        public bool NoSellOrSort { get; set; }

        /// <summary>Gets or sets the bag's capacity.</summary>
        [DataMember(Name = "size", Order = 1)]
        public int Size { get; set; }
    }
}