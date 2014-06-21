﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V2.Builds;
    using GW2DotNET.V2.Builds.Contracts;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public class ServiceManager : IBuildService
    {
        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Build GetBuild()
        {
            return new BuildService().GetBuild();
        }

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync()
        {
            return new BuildService().GetBuildAsync(CancellationToken.None);
        }

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        public Task<Build> GetBuildAsync(CancellationToken cancellationToken)
        {
            return new BuildService().GetBuildAsync(cancellationToken);
        }
    }
}