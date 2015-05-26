namespace PastaRecipe.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class RecipeService : IProvideRecipes, IOwnRecipes
    {
        private IOwnRecipes recipesOwner;

        public RecipeService(IOwnRecipes recipesOwner)
        {
            this.recipesOwner = recipesOwner;
        }

        public PastaRecipe GetRecipeFor(string pastaName)
        {
            return this.recipesOwner.GetRecipeFor(pastaName);
        }

        public IEnumerable<string> FindPastaWithRecipeIncludingTheIngredient(string ingredientName)
        {
            return this.recipesOwner.FindPastaWithRecipeIncludingTheIngredient(ingredientName);
        }
    }
}