using System;

namespace PastaRecipe.Console
{
    using PastaRecipe.Console.Infra;
    using PastaRecipe.Domain;
    using PastaRecipe.Infra;

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starts the PastaRecipe service");

            var recipeRepository = new RecipeRepository();
            var pastaRecipeService = new RecipeService(recipeRepository);
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
                
                var retrievedRecipe = commandLineArgumentAdapter.RequestRecipeFor(enteredValue);

                System.Console.WriteLine(retrievedRecipe);
                System.Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
