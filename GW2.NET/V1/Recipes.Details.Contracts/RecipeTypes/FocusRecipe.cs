﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a focus crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts.RecipeTypes
{
    /// <summary>Represents a focus crafting recipe.</summary>
    public class FocusRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="FocusRecipe" /> class.</summary>
        public FocusRecipe()
            : base(RecipeType.Focus)
        {
        }
    }
}