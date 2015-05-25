namespace PastaRecipeService.Tests
{
    using NFluent;

    using NUnit.Framework;

    using PastaRecipeService.Domain;

    [TestFixture]
    public class RecipeServiceTests
    {
        [Test]
        public void ShouldProvideTheRecipeGivenAPastaName()
        {
            var recipeService = new RecipeService();
            var gnocchiRecipe = recipeService.GetRecipeFor(pastaName: "gnocchi");
            Check.That(gnocchiRecipe.Ingredients).Contains("eggs", "potatoes", "flour");
            Check.That(gnocchiRecipe.PastaName).IsEqualTo("gnocchi");
        }
    }
}