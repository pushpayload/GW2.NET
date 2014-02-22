﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesResponseConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Files.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Files.Converters
{
    /// <summary>
    /// Converts a JSON dictionary of named files to and from a <see cref="FilesResponse"/>.
    /// </summary>
    /// <remarks>
    /// This converter exists because it is not normally possible to map a JSON dictionary to a single .NET property.
    /// For bonus points: figure out a way to make this converter generic so that it will work for any .NET type that requires this behavior.
    /// </remarks>
    public class FilesResponseConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(FilesResponse) == objectType;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new FilesResponse(serializer.Deserialize<Assets>(reader));
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((FilesResponse)value).Files);
        }
    }
}