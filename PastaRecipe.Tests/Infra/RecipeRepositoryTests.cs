namespace PastaRecipe.Tests.Infra
{
    using NFluent;

    using NUnit.Framework;

    using PastaRecipe.Console.Infra;
    using PastaRecipe.Domain;

    [TestFixture]
    public class RecipeRepositoryTests
    {
        [Test]
        public void ShouldAddRecipe()
        {
            var newRecipe = PastaRecipe.Parse("superPastaDelAmore(eggs-water-salt-flour-amore)");

            var recipesRepository = new RecipeRepository();
            Check.That(recipesRepository.GetRecipeFor("superPastaDelAmore")).IsNull();

            recipesRepository.AddRecipe(newRecipe);

            Check.That(recipesRepository.GetRecipeFor("superPastaDelAmore")).IsEqualTo(newRecipe);
        }
    }
}
