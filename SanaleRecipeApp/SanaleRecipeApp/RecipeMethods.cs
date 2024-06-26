using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaleRecipeApp
{
    public class RecipeMethods
    {
        private List<Recipe> recipes = new List<Recipe>();

        public event CalorieNotification CalorieExceeded;

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

        public List<string> GetRecipeNames()
        {
            return recipes.Select(r => r.Name).ToList();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            int totalCalories = CalculateTotalCalories(recipe);
            if (totalCalories > 300)
            {
                CalorieExceeded?.Invoke(recipe.Name);
            }
        }

        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name == name);
        }

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

        public void ClearRecipes()
        {
            recipes.Clear();
        }

        private int CalculateTotalCalories(Recipe recipe)
        {
            return recipe.Ingredients.Sum(ingredient => ingredient.Calories);
        }

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