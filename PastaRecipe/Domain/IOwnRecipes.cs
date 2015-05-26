namespace PastaRecipe.Domain
{
    using System.Collections.Generic;

    public interface IOwnRecipes
    {
        PastaRecipe GetRecipeFor(string pastaName);

        IEnumerable<string> FindPastaWithRecipeIncludingTheIngredient(string ingredientName);
    }
}