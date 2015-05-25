namespace PastaRecipeService.Tests
{
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

    public class PastaRecipe
    {
        public string PastaName { get; private set; }

        public IEnumerable<string> Ingredients { get; private set; }

        private PastaRecipe(string pastaName, IEnumerable<string> ingredients)
        {
            this.PastaName = pastaName;
            this.Ingredients = ingredients;
        }

        public static PastaRecipe Parse(string pastaNameAndRecipe)
        {
            var pastaName = pastaNameAndRecipe.Substring(0, pastaNameAndRecipe.IndexOf('('));
            var ingredientsList = pastaNameAndRecipe.Substring(pastaNameAndRecipe.IndexOf('(') + 1, pastaNameAndRecipe.Length - pastaNameAndRecipe.IndexOf('(') - 2);

            return new PastaRecipe(pastaName, ingredientsList.Split('-'));
        }
    }
}