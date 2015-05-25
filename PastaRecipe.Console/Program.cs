using System;

namespace PastaRecipe.Console
{
    using PastaRecipe.Domain;

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starts the PastaRecipe service");

            var pastaRecipeService = new RecipeService();
            var commandLineArgumentAdapter = new CommandLineAdapter(pastaRecipeService);

            string enteredValue = null;
            while (enteredValue != "q")
            {
                System.Console.WriteLine("Enter the name of the pasta, and we provide you its recipe (Enter 'q' to quit):");
                enteredValue = System.Console.ReadLine();
                
                if (enteredValue.ToLower() == "q")
                {
                    break;
                }
                
                var pastaRecipe = commandLineArgumentAdapter.RequestRecipeFor(enteredValue);

                System.Console.WriteLine("The recipe for the pasta '{0}' is '{1}'", pastaRecipe.PastaName, pastaRecipe.Ingredients);
                System.Console.WriteLine(Environment.NewLine);
            }
        }
    }

    internal class CommandLineAdapter
    {
        private readonly RecipeService pastaRecipeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineAdapter"/> class.
        /// </summary>
        /// <param name="pastaRecipeService">The pasta recipe service.</param>
        public CommandLineAdapter(RecipeService pastaRecipeService)
        {
            this.pastaRecipeService = pastaRecipeService;
        }

        public PastaRecipe RequestRecipeFor(string pastaName)
        {
            // the simplest possible adapter on earth here; no need to translate model
            return this.pastaRecipeService.GetRecipeFor(pastaName);
        }
    }
}
