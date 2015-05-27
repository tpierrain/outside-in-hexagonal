namespace PastaRecipe.Infra
{
    using System.Linq;

    using PastaRecipe.Domain;

    public class CommandLineAdapter
    {
        private readonly IProvideRecipes pastaRecipeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineAdapter"/> class.
        /// </summary>
        /// <param name="pastaRecipeProvider">The pasta recipe service.</param>
        public CommandLineAdapter(IProvideRecipes pastaRecipeProvider)
        {
            this.pastaRecipeProvider = pastaRecipeProvider;
        }

        public string RequestRecipeFor(string pastaName)
        {
            // the simplest possible adapter on earth here; no need to translate model
            var recipe = this.pastaRecipeProvider.GetRecipeFor(pastaName);

            // adapt from the domain model to the output representation
            var output = string.Format("The recipe for the pasta '{0}' is '{1}'", recipe.PastaName, this.PrintIngredients(recipe));

            return output;
        }

        private string PrintIngredients(PastaRecipe recipe)
        {
            return string.Join(", ", recipe.Ingredients.ToArray());
        }
    }
}