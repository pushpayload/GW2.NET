﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPalette.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a named color and its color component information for cloth, leather and metal materials.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a named color and its color component information for cloth, leather and metal materials.</summary>
    public class ColorPalette : JsonObject, IEquatable<ColorPalette>
    {
        /// <summary>Gets or sets the base RGB values.</summary>
        [DataMember(Name = "base_rgb")]
        public Color BaseRgb { get; set; }

        /// <summary>Gets or sets the color model for cloth armor.</summary>
        [DataMember(Name = "cloth")]
        public ColorModel Cloth { get; set; }

        /// <summary>Gets or sets the color identifier.</summary>
        [DataMember(Name = "color_id")]
        public int ColorId { get; set; }

        /// <summary>Gets or sets the language.</summary>
        [DataMember(Name = "lang")]
        public string Language { get; set; }

        /// <summary>Gets or sets the color model for leather armor.</summary>
        [DataMember(Name = "leather")]
        public ColorModel Leather { get; set; }

        /// <summary>Gets or sets the color model for metal armor.</summary>
        [DataMember(Name = "metal")]
        public ColorModel Metal { get; set; }

        /// <summary>Gets or sets the name of the color.</summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(ColorPalette left, ColorPalette right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(ColorPalette left, ColorPalette right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ColorPalette other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ColorId == other.ColorId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((ColorPalette)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ColorId;
        }
    }
}