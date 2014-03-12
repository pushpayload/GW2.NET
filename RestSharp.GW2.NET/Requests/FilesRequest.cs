﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for commonly requested in-game assets.
//   The returned information can be used with the render service to retrieve assets.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.FilesInformation.Catalogs;

    /// <summary>
    ///     Represents a request for commonly requested in-game assets.
    ///     The returned information can be used with the render service to retrieve assets.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/files" /> for more information.
    /// </remarks>
    public class FilesRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FilesRequest" /> class.
        /// </summary>
        public FilesRequest()
            : base(Services.Files)
        {
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<AssetCollection> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<AssetCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<AssetCollection>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<AssetCollection>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<AssetCollection>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<AssetCollection>(serviceClient, cancellationToken);
        }
    }
}