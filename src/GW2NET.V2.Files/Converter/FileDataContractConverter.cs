﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDataContractConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileDataContractConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System;

    using GW2NET.Common;
    using GW2NET.Files;

    /// <summary>Converts a <see cref="FileDataContract"/> to an <see cref="AssetV2"/>.</summary>
    internal sealed class FileDataContractConverter : IConverter<FileDataContract, AssetV2>
    {
        /// <inheritdoc />
        public AssetV2 Convert(FileDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new AssetV2 { FileId = value.Id, IconUrl = value.Icon };
        }
    }
}