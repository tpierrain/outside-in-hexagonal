using System.Collections.Generic;
using System.Linq;

namespace PastaRecipe.Console.Infra
{
    using PastaRecipe.Domain;

    public class RecipeRepository : IOwnRecipes
    {
        private Dictionary<string, PastaRecipe> recipes;

        public RecipeRepository()
        {
            this.recipes = new Dictionary<string, PastaRecipe>
                               {
                                   { "gnocchi", PastaRecipe.Parse("gnocchi(eggs-potatoes-flour)") },
                                   { "spaghetti", PastaRecipe.Parse("spaghetti(eggs-flour)") },
                                   { "organic spaghetti", PastaRecipe.Parse("organic spaghetti(organic eggs-flour)") },
                                   { "spinach farfalle", PastaRecipe.Parse("spinach farfalle(eggs-flour-spinach)") },
                                   { "tagliatelle", PastaRecipe.Parse("tagliatelle(eggs-flour)") }
                               };
        }

        public PastaRecipe GetRecipeFor(string pastaName)
        {
            return this.recipes[pastaName];
        }

        public IEnumerable<string> FindPastaWithRecipeIncludingTheIngredient(string ingredientName)
        {
            var result = new List<string>();

            foreach (var recipe in this.recipes.Values)
            {
                if (recipe.Ingredients.Contains(ingredientName))
                {
                    result.Add(recipe.PastaName);
                }
            }

            return result;
        }
    }
}
