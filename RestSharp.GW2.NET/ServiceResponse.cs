﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides a RestSharp-specific implementation of the  interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Mime;

    using global::GW2DotNET.Utilities;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.Common;

    using global::GW2DotNET.V1.Core.Errors;

    using Newtonsoft.Json;

    /// <summary>Provides a RestSharp-specific implementation of the <see cref="IServiceResponse{TResult}"/> interface.</summary>
    /// <typeparam name="TResult">The type of the response content.</typeparam>
    public class ServiceResponse<TResult> : IServiceResponse<TResult>
        where TResult : class
    {
        /// <summary>Infrastructure. Stores the inner <see cref="IRestResponse" />.</summary>
        private readonly IRestResponse innerRestResponse;

        /// <summary>Infrastructure. Stores a JSON result.</summary>
        private ErrorResult errorResult;

        /// <summary>Infrastructure. Stores a JSON result.</summary>
        private TResult result;

        /// <summary>Initializes a new instance of the <see cref="ServiceResponse{TResult}"/> class.</summary>
        /// <param name="restResponse">The <see cref="IRestResponse"/>.</param>
        public ServiceResponse(IRestResponse restResponse)
        {
            Preconditions.EnsureNotNull(paramName: "restResponse", value: restResponse);

            this.innerRestResponse = restResponse;
        }

        /// <summary>Gets a value indicating the Internet media type of the message content.</summary>
        public ContentType ContentType
        {
            get
            {
                if (string.IsNullOrEmpty(this.innerRestResponse.ContentType))
                {
                    return null;
                }

                return new ContentType(this.innerRestResponse.ContentType);
            }
        }

        /// <summary>Gets a value indicating whether the service returned an image response.</summary>
        public bool IsImageResponse
        {
            get
            {
                if (this.ContentType == null)
                {
                    return false;
                }

                return this.ContentType.MediaType.StartsWith("image", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>Gets a value indicating whether the service returned a JSON response.</summary>
        public bool IsJsonResponse
        {
            get
            {
                if (this.ContentType == null)
                {
                    return false;
                }

                return string.Equals(this.ContentType.MediaType, "application/json", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>Gets a value indicating whether the service returned a success status code.</summary>
        public bool IsSuccessStatusCode
        {
            get
            {
                var status = this.StatusCode;
                return status == HttpStatusCode.OK || ((int)status > 200 && (int)status < 300);
            }
        }

        /// <summary>Gets the status code.</summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return this.innerRestResponse.StatusCode;
            }
        }

        /// <summary>Gets the response content as an object of the specified type.</summary>
        /// <returns>Returns the response as an instance of the specified type.</returns>
        public TResult Deserialize()
        {
            if (!this.IsSuccessStatusCode)
            {
                // if the service returned an error code
                throw new InvalidOperationException("Unable to deserialize the response content: the service returned an error code.");
            }

            if (typeof(JsonObject).IsAssignableFrom(typeof(TResult)))
            {
                // if the expected result is a JSON object
                if (!this.IsJsonResponse)
                {
                    // if the service didn't include a JSON result object
                    throw new InvalidOperationException("Unable to deserialize the response content: the service did not return a JSON result.");
                }

                return this.result ?? (this.result = DeserializeJson<TResult>(this.innerRestResponse));
            }

            if (typeof(Image).IsAssignableFrom(typeof(TResult)))
            {
                // if the expected result is an image
                if (!this.IsImageResponse)
                {
                    // if the service didn't include an image result
                    throw new InvalidOperationException("Unable to deserialize the response content: the service did not return an image result.");
                }

                return this.result ?? (this.result = DeserializeImage(this.innerRestResponse));
            }

            throw new NotSupportedException("Unable to deserialize the response content: the type of 'TResult' is unsupported.");
        }

        /// <summary>Gets the error result if the request was unsuccessful.</summary>
        /// <returns>Return the error response as an instance of the <see cref="ErrorResult" /> class.</returns>
        public ErrorResult DeserializeError()
        {
            if (this.IsSuccessStatusCode)
            {
                // if the service returned a success code
                throw new InvalidOperationException();
            }

            if (!this.IsJsonResponse)
            {
                // if the service didn't include a JSON result object
                return this.errorResult ?? (this.errorResult = new ErrorResult { Text = this.innerRestResponse.ErrorMessage });
            }

            return this.errorResult ?? (this.errorResult = DeserializeJson<ErrorResult>(this.innerRestResponse));
        }

        /// <summary>Throws an exception if the request did not return a success status code.</summary>
        /// <returns>Returns the current instance.</returns>
        /// <remarks>The current instance is returned to allow chaining method calls.</remarks>
        public IServiceResponse<TResult> EnsureSuccessStatusCode()
        {
            if (this.IsSuccessStatusCode)
            {
                return this;
            }

            throw new ServiceException(this.DeserializeError(), this.innerRestResponse.ErrorException);
        }

        /// <summary>Infrastructure. Gets the response content.</summary>
        /// <param name="restResponse">The web response.</param>
        /// <returns>The response content.</returns>
        private static TResult DeserializeImage(IRestResponse restResponse)
        {
            var stream = new MemoryStream(restResponse.RawBytes);

            return (TResult)(object)Image.FromStream(stream);
        }

        /// <summary>Infrastructure. Gets the response content.</summary>
        /// <param name="restResponse">The web response.</param>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <returns>The response content.</returns>
        private static T DeserializeJson<T>(IRestResponse restResponse)
        {
            using (var streamReader = new StreamReader(new MemoryStream(restResponse.RawBytes)))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.Create();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
}