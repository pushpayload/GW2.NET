﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RestSharp.GW2DotNET.Requests
{
    using System.Threading;
    using System.Threading.Tasks;

    using global::GW2DotNET.V1.Core;

    using global::GW2DotNET.V1.Core.ItemsInformation.Details;

    /// <summary>
    ///     Represents a request for information regarding a specific recipe.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details" /> for more information.
    /// </remarks>
    public class RecipeDetailsRequest : ServiceRequest
    {
        #region Fields

        /// <summary>Infrastructure. Stores the recipe ID parameter.</summary>
        private readonly Parameter recipeIdParameter;

        /// <summary>Infrastructure. Stores the recipe ID.</summary>
        private int recipeId;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="RecipeDetailsRequest"/> class.</summary>
        public RecipeDetailsRequest()
            : base(Resources.RecipeDetails)
        {
            this.AddParameter(this.recipeIdParameter = new Parameter { Name = "recipe_id", Value = default(int), Type = ParameterType.GetOrPost });
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the recipe ID.</summary>
        public int RecipeId
        {
            get
            {
                return this.recipeId;
            }

            set
            {
                this.recipeIdParameter.Value = this.recipeId = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Recipe> GetResponse(IServiceClient serviceClient)
        {
            return this.GetResponse<Recipe>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Recipe>> GetResponseAsync(IServiceClient serviceClient)
        {
            return this.GetResponseAsync<Recipe>(serviceClient);
        }

        /// <summary>Sends the current request and returns a response.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Recipe>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return this.GetResponseAsync<Recipe>(serviceClient, cancellationToken);
        }

        #endregion
    }
}