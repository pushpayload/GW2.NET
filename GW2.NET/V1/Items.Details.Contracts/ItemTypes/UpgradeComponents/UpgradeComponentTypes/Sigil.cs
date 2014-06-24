﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sigil.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a sigil upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents.UpgradeComponentTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a sigil upgrade component.</summary>
    [TypeDiscriminator(Value = "Sigil", BaseType = typeof(UpgradeComponent))]
    public class Sigil : UpgradeComponent
    {
    }
}