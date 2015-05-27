namespace PastaRecipe.Tests.Domain
{
    using NFluent;
    using NUnit.Framework;
    using PastaRecipe.Console.Infra;
    using PastaRecipe.Domain;

    [TestFixture]
    public class RecipeEngineTests
    {
        [Test]
        public void ShouldProvideTheRecipeGivenAPastaName()
        {
            var recipeEngine = new RecipeEngine(new RecipeRepository());
            var gnocchiRecipe = recipeEngine.GetRecipeFor(pastaName: "gnocchi");
            Check.That(gnocchiRecipe.Ingredients).Contains("eggs", "potatoes", "flour");
            Check.That(gnocchiRecipe.PastaName).IsEqualTo("gnocchi");
        }

        [Test]
        public void ShouldProvideTheListOfAllPastaGivenAnIngredient()
        {
            var recipeEngine = new RecipeEngine(new RecipeRepository());
            Check.That(recipeEngine.FindPastaWithRecipeIncludingTheIngredient("eggs")).Contains("gnocchi", "spaghetti", "spinach farfalle", "tagliatelle");
        }

        [Test]
        public void ShouldAddRecipe()
        {
            var newRecipe = PastaRecipe.Parse("superPastaDelAmore(eggs-water-salt-flour-amore)");

            var recipeEngine = new RecipeEngine(new RecipeRepository());

            Check.That(recipeEngine.GetRecipeFor("superPastaDelAmore")).IsNull();

            recipeEngine.AddRecipe(newRecipe);

            Check.That(recipeEngine.GetRecipeFor("superPastaDelAmore")).IsEqualTo(newRecipe);
        }
    }
}