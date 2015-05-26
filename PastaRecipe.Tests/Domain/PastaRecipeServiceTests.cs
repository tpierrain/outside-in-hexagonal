namespace PastaRecipe.Tests.Domain
{
    using NFluent;

    using NUnit.Framework;

    using PastaRecipe.Console.Infra;
    using PastaRecipe.Domain;

    [TestFixture]
    public class RecipeServiceTests
    {
        [Test]
        public void ShouldProvideTheRecipeGivenAPastaName()
        {
            var recipeService = new RecipeService(new RecipeRepository());
            var gnocchiRecipe = recipeService.GetRecipeFor(pastaName: "gnocchi");
            Check.That(gnocchiRecipe.Ingredients).Contains("eggs", "potatoes", "flour");
            Check.That(gnocchiRecipe.PastaName).IsEqualTo("gnocchi");
        }

        [Test]
        public void ShouldProvideTheListOfAllPastaGivenAnIngredient()
        {
            var recipeService = new RecipeService(new RecipeRepository());
            Check.That(recipeService.FindPastaWithRecipeIncludingTheIngredient("eggs")).Contains("gnocchi", "spaghetti", "spinach farfalle", "tagliatelle");
        }
    }
}