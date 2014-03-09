﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapsInformation.Continents
{
    /// <summary>
    ///     Wraps a collection of continents.
    /// </summary>
    public class ContinentsResult : JsonObject
    {
        /// <summary>
        ///     Gets or sets a collection of continents.
        /// </summary>
        [JsonProperty("continents", Order = 0)]
        public ContinentCollection Continents { get; set; }
    }
}