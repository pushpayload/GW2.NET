﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Armor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for armor types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Items
{
    using System.Collections.Generic;

    using GW2DotNET.Skins;

    /// <summary>Provides the base class for armor types.</summary>
    public abstract class Armor : Item, IUpgrade, IUpgradable, ISkinnable
    {
        /// <summary>Gets or sets the item's buff.</summary>
        public virtual ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the Condition Damage modifier.</summary>
        public virtual int ConditionDamage { get; set; }

        /// <summary>Gets or sets the default skin.</summary>
        public virtual Skin DefaultSkin { get; set; }

        /// <summary>Gets or sets the default skin identifier.</summary>
        public virtual int DefaultSkinId { get; set; }

        /// <summary>Gets or sets the armor's defense stat.</summary>
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the Ferocity modifier.</summary>
        public virtual int Ferocity { get; set; }

        /// <summary>Gets or sets the Healing modifier.</summary>
        public virtual int Healing { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        public virtual ICollection<InfusionSlot> InfusionSlots { get; set; }

        /// <summary>Gets or sets the Power modifier.</summary>
        public virtual int Power { get; set; }

        /// <summary>Gets or sets the Precision modifier.</summary>
        public int Precision { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item.</summary>
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item.</summary>
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets or sets the Toughness modifier.</summary>
        public virtual int Toughness { get; set; }

        /// <summary>Gets or sets the Vitality modifier.</summary>
        public virtual int Vitality { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        public virtual ArmorWeightClass WeightClass { get; set; }
    }
}