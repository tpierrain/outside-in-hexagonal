namespace PastaRecipe.Domain
{
    public interface IProvideRecipes
    {
        PastaRecipe GetRecipeFor(string pastaName);
    }
}