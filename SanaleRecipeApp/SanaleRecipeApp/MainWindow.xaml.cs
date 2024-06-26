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

        public MainWindow()
        {
            InitializeComponent();
            recipeMethods.CalorieExceeded += NotifyCalorieExceeded;
        }

        private void NotifyCalorieExceeded(string recipeName)
        {
            MessageBox.Show($"Warning: The total calories of {recipeName} exceed 300!", "Calorie Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(recipeMethods);
            addRecipeWindow.ShowDialog();
            UpdateRecipeList();
        }

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

        private void ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                recipeMethods.ClearRecipes();
                UpdateRecipeList();
            }
        }

        private void ExitAppButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateRecipeList()
        {
            RecipeListBox.ItemsSource = recipeMethods.GetRecipeNames();
        }
    }
}
