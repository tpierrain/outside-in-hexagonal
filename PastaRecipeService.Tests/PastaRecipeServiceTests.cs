namespace PastaRecipeService.Tests
{
    using System;
    using System.Collections.Generic;

    using NFluent;

    using NUnit.Framework;

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

    public class RecipeService
    {
        public PastaRecipe GetRecipeFor(string pastaName)
        {
            return null;
        }
    }

    public class PastaRecipe
    {
        public string PastaName { get; private set; };

        public IEnumerable<string> Ingredients { get; private set; } 
    }
}