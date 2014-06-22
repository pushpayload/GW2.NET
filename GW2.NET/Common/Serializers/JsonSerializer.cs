﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for serializing JSON objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Serializers
{
    using System.IO;

    using GW2DotNET.Utilities;

    using Newtonsoft.Json;

    /// <summary>Provides methods for serializing JSON objects.</summary>
    /// <typeparam name="T">The type that is being serialized.</typeparam>
    public class JsonSerializer<T> : ISerializer<T>
    {
        /// <summary>Infrastructure. Holds a reference to the JSON.NET serializer.</summary>
        private readonly JsonSerializer jsonSerializer;

        /// <summary>Initializes a new instance of the <see cref="JsonSerializer{T}"/> class.</summary>
        public JsonSerializer()
        {
            this.jsonSerializer = JsonSerializer.CreateDefault();
        }

        /// <summary>Initializes a new instance of the <see cref="JsonSerializer{T}"/> class.</summary>
        /// <param name="settings">The settings to be applied to the <see cref="JsonSerializer"/>.</param>
        public JsonSerializer(JsonSerializerSettings settings)
        {
            Preconditions.EnsureNotNull(paramName: "settings", value: settings);
            this.jsonSerializer = JsonSerializer.CreateDefault(settings);
        }

        /// <summary>Converts the input stream to the specified type.</summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>An instance of the specified type.</returns>
        public T Deserialize(Stream stream)
        {
            using (stream)
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return this.jsonSerializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>Converts the specified value to an output stream.</summary>
        /// <param name="value">An instance of the specified type.</param>
        /// <param name="stream">The output stream.</param>
        public void Serialize(T value, Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            {
                this.jsonSerializer.Serialize(streamWriter, value, typeof(T));
            }
        }
    }
}