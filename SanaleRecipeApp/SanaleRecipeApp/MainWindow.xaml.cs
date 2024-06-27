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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SanaleRecipeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecipeMethods recipeMethods = new RecipeMethods();

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        public MainWindow()
        {
            InitializeComponent();
            recipeMethods.CalorieExceeded += NotifyCalorieExceeded;

            // gets food groups set all as defult and set as the item source for the ComboBox
            var foodGroups = recipeMethods.FoodGroups.Prepend("All").ToList();
            FoodGroupComboBox.ItemsSource = foodGroups;
            FoodGroupComboBox.SelectedIndex = 0;
            // updates the list of recipes displayed
            UpdateRecipeList();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for CalorieExceeded event
        private void NotifyCalorieExceeded(string recipeName)
        {
            MessageBox.Show($"Warning: The total calories of {recipeName} exceed 300!", "Calorie Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for AddRecipeButton click
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(recipeMethods);
            addRecipeWindow.ShowDialog();
            UpdateRecipeList();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for DisplayRecipeButton click
        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var recipeName = RecipeListBox.SelectedItem.ToString();
                var recipe = recipeMethods.GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    var displayRecipeWindow = new DisplayRecipeWindow(recipe);
                    displayRecipeWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to display.");
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for ScaleRecipeButton click
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var recipeName = RecipeListBox.SelectedItem.ToString();
                var recipe = recipeMethods.GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    var scaleRecipeWindow = new ScaleRecipeWindow(recipeMethods, recipe);
                    scaleRecipeWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for ResetRecipeButton click
        private void ResetRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var recipeName = RecipeListBox.SelectedItem.ToString();
                recipeMethods.ResetRecipe(recipeName);
                MessageBox.Show("Recipe has been reset to original quantities.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.");
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for ClearAllRecipesButton click
        private void ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                recipeMethods.ClearRecipes();
                UpdateRecipeList();
            }
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // event handler for ExitAppButton click
        private void ExitAppButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        // method to update the list of recipes displayed in the ListBox
        private void UpdateRecipeList()
        {
            RecipeListBox.ItemsSource = recipeMethods.GetRecipeNames();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        //Author:Microsoft
        //Availability:https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-filter-data-in-a-view?view=netframeworkdesktop-4.8
        //Date Accessed: 26 June 2024
        // event handler for FilterButton click
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = IngredientTextBox.Text.ToLower();
            var foodGroup = FoodGroupComboBox.SelectedItem?.ToString();
            var maxCaloriesText = MaxCaloriesTextBox.Text;

            int? maxCalories = null;
            if (int.TryParse(maxCaloriesText, out int calories))
            {
                maxCalories = calories;
            }

            var filteredRecipes = recipeMethods.FilterRecipes(ingredient, foodGroup, maxCalories);
            RecipeListBox.ItemsSource = filteredRecipes.Select(r => r.Name).ToList();
        }

        //Author:Troelsen, A. & Japikse, P.
        //Availability:Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. 11 ed.
        //Date Accessed: 25 June 2024
        //Author:Microsoft
        //Availability:https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-filter-data-in-a-view?view=netframeworkdesktop-4.8
        //Date Accessed: 26 June 2024
        // event handler for ClearFilterButton click
        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientTextBox.Text = string.Empty;
            FoodGroupComboBox.SelectedIndex = 0;
            MaxCaloriesTextBox.Text = string.Empty;
            UpdateRecipeList();
        }
    }
}