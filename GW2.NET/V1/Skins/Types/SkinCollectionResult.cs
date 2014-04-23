﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinCollectionResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of skin identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Types
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Wraps a collection of skin identifiers.</summary>
    public class SkinCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of skin identifiers.</summary>
        [DataMember(Name = "skins", Order = 0)]
        public SkinCollection Skins { get; set; }
    }
}