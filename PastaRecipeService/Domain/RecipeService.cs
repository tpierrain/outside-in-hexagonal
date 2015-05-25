namespace PastaRecipeService.Domain
{
    using System.Collections.Generic;

    public class RecipeService
    {
        private Dictionary<string, PastaRecipe> recipes;

        public RecipeService()
        {
            this.InitializeRecipes();
        }

        private void InitializeRecipes()
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
    }
}