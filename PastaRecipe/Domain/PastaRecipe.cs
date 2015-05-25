namespace PastaRecipe.Domain
{
    using System.Collections.Generic;

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