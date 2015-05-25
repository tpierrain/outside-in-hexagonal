namespace PastaRecipeService.Tests
{
    using NFluent;

    using NUnit.Framework;

    using PastaRecipeService.Domain;

    [TestFixture]
    public class PastaRecipeTests
    {
        [Test]
        public void ShouldParsePastaLine()
        {
            const string PastaLine = "spinach farfalle(eggs-flour-spinach)";

            var recipe = PastaRecipe.Parse(PastaLine);
            Check.That(recipe.PastaName).IsEqualTo("spinach farfalle");
            Check.That(recipe.Ingredients).Contains("eggs", "flour", "spinach");
        }
    }
}
