﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a region on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;
    using GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a region on the map.
    /// </summary>
    public class Region : JsonObject
    {
        /// <summary>
        ///     Gets or sets the coordinates of the region label.
        /// </summary>
        [JsonProperty("label_coord", Order = 2)]
        [JsonConverter(typeof(JsonPointFConverter))]
        public PointF LabelCoordinates { get; set; }

        /// <summary>
        ///     Gets or sets a collection of maps and their details.
        /// </summary>
        [JsonProperty("maps", Order = 3)]
        public SubregionCollection Maps { get; set; }

        /// <summary>
        ///     Gets or sets the region's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the region's ID.
        /// </summary>
        [JsonProperty("region_id", Order = 0)]
        public int RegionId { get; set; }
    }
}