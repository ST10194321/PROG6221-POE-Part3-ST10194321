using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaleRecipeApp
{
     //Author:Troelsen, A. & Japikse, P.
     //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
     //Date Accessed: 25 June 2024
                                 
    public class RecipeMethods
    {
        // list to store recipes
        private List<Recipe> recipes = new List<Recipe>();

        // event to notify when calories exceed limit
        public event CalorieNotification CalorieExceeded;

        // A list of predefined food groups
        public List<string> FoodGroups { get; } = new List<string>
        {
            "Starchy foods",
            "Vegetables and fruits",
            "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs",
            "Milk and dairy products",
            "Fats and oil",
            "Water"
        };

        // method to get the names of all recipes
        public List<string> GetRecipeNames()
        {
            return recipes.Select(r => r.Name).ToList();
        }

        // method to add a new recipe

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            // calculate total calories of the new recipe
            int totalCalories = CalculateTotalCalories(recipe);
            // if total calories exceed 300, tell user 
            if (totalCalories > 300)
            {
                CalorieExceeded?.Invoke(recipe.Name);
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // method to retrieve a recipe by its name
        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name == name);
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // method to scale the recipe
        public void ScaleRecipe(string recipeName, double scaleFactor)
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= scaleFactor;
                    ingredient.Calories = (int)Math.Round(ingredient.OriginalCalories * scaleFactor);
                }
            }
        }
        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // method to reset the quantities and calories
        public void ResetRecipe(string recipeName)
        {
            var recipe = GetRecipeByName(recipeName);
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                    ingredient.Calories = ingredient.OriginalCalories;
                }
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // method to clear all recipes from the list
        public void ClearRecipes()
        {
            recipes.Clear();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        //method to calculate the total calories of a recipe
        private int CalculateTotalCalories(Recipe recipe)
        {
            return recipe.Ingredients.Sum(ingredient => ingredient.Calories);
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        //Author:Microsoft
        //Availability:https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-filter-data-in-a-view?view=netframeworkdesktop-4.8
        //Date Accessed: 26 June 2024
        // method to filter recipes based on ingredient, food group, and maximum calories
        public IEnumerable<Recipe> FilterRecipes(string ingredient, string foodGroup, int? maxCalories)
        {
            return recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (foodGroup == "All" || string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup == foodGroup)) &&
                (!maxCalories.HasValue || CalculateTotalCalories(r) <= maxCalories.Value)
            );
        }
    }
}