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
        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for displaying  recipe details
        private void DisplayRecipe(Recipe recipe)
        {
            RecipeNameTextBlock.Text = recipe.Name;
            IngredientsItemsControl.ItemsSource = recipe.Ingredients.Select(ingredient => $"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            StepsItemsControl.ItemsSource = recipe.Steps.Select((step, index) => $"{index + 1}. {step}");
            TotalCaloriesTextBlock.Text = $"Total calories: {recipe.Ingredients.Sum(ingredient => ingredient.Calories)}";
        }
        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler to closeButton when clicked
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}