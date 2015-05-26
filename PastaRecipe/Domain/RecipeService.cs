namespace PastaRecipe.Domain
{
    using System.Collections.Generic;

    public class RecipeService : IProvideRecipes, IOwnRecipes
    {
        private IOwnRecipes recipeRepository;

        public RecipeService(IOwnRecipes recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public PastaRecipe GetRecipeFor(string pastaName)
        {
            return this.recipeRepository.GetRecipeFor(pastaName);
        }

        public IEnumerable<string> FindPastaWithRecipeIncludingTheIngredient(string ingredientName)
        {
            return this.recipeRepository.FindPastaWithRecipeIncludingTheIngredient(ingredientName);
        }

        public void AddRecipe(PastaRecipe newRecipe)
        {
            this.recipeRepository.AddRecipe(newRecipe);
        }
    }
}