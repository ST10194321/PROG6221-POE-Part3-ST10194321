using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SanaleRecipeApp
{
    /// <summary>
    /// Interaction logic for DisplayRecipeWindow.xaml
    /// </summary>
    public partial class DisplayRecipeWindow : Window
    {
        public DisplayRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipe(recipe);
        }

        private void DisplayRecipe(Recipe recipe)
        {
            RecipeNameTextBlock.Text = recipe.Name;
            IngredientsItemsControl.ItemsSource = recipe.Ingredients.Select(ingredient => $"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            StepsItemsControl.ItemsSource = recipe.Steps.Select((step, index) => $"{index + 1}. {step}");
            TotalCaloriesTextBlock.Text = $"Total calories: {recipe.Ingredients.Sum(ingredient => ingredient.Calories)}";
        }
    }
}