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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        private RecipeMethods recipeMethods;

        public AddRecipeWindow(RecipeMethods recipeMethods)
        {
            InitializeComponent();
            this.recipeMethods = recipeMethods;
        }

        private void NumIngredientsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            IngredientsPanel.Children.Clear();
            if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    AddIngredientControls(i);
                }
            }
        }

        private void NumStepsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StepsPanel.Children.Clear();
            if (int.TryParse(NumStepsTextBox.Text, out int numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    AddStepControls(i);
                }
            }
        }

        private void AddIngredientControls(int index)
        {
            IngredientsPanel.Children.Add(new TextBlock { Text = $"Ingredient {index + 1} Name:" });
            IngredientsPanel.Children.Add(new TextBox { Name = $"IngredientName{index}" });

            IngredientsPanel.Children.Add(new TextBlock { Text = $"Ingredient {index + 1} Quantity:" });
            IngredientsPanel.Children.Add(new TextBox { Name = $"IngredientQuantity{index}" });

            IngredientsPanel.Children.Add(new TextBlock { Text = $"Ingredient {index + 1} Unit:" });
            IngredientsPanel.Children.Add(new TextBox { Name = $"IngredientUnit{index}" });

            IngredientsPanel.Children.Add(new TextBlock { Text = $"Ingredient {index + 1} Calories:" });
            IngredientsPanel.Children.Add(new TextBox { Name = $"IngredientCalories{index}" });

            IngredientsPanel.Children.Add(new TextBlock { Text = $"Ingredient {index + 1} Food Group:" });
            IngredientsPanel.Children.Add(new ComboBox
            {
                Name = $"IngredientFoodGroup{index}",
                ItemsSource = recipeMethods.FoodGroups,
                SelectedIndex = 0
            });
        }

        private void AddStepControls(int index)
        {
            StepsPanel.Children.Add(new TextBlock { Text = $"Step {index + 1} Description:" });
            StepsPanel.Children.Add(new TextBox { Name = $"StepDescription{index}" });
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string recipeName = RecipeNameTextBox.Text;
                int numIngredients = int.Parse(NumIngredientsTextBox.Text);
                int numSteps = int.Parse(NumStepsTextBox.Text);

                // Create new recipe
                Recipe recipe = new Recipe { Name = recipeName };

                for (int i = 0; i < numIngredients; i++)
                {
                    string ingredientName = ((TextBox)IngredientsPanel.Children[i * 10 + 1]).Text;
                    double quantity = double.Parse(((TextBox)IngredientsPanel.Children[i * 10 + 3]).Text);
                    string unit = ((TextBox)IngredientsPanel.Children[i * 10 + 5]).Text;
                    int calories = int.Parse(((TextBox)IngredientsPanel.Children[i * 10 + 7]).Text);
                    string foodGroup = ((ComboBox)IngredientsPanel.Children[i * 10 + 9]).Text;

                    recipe.Ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
                }

                for (int i = 0; i < numSteps; i++)
                {
                    string stepDescription = ((TextBox)StepsPanel.Children[i * 2 + 1]).Text;
                    recipe.Steps.Add(stepDescription);
                }

                // Add recipe to the list
                recipeMethods.AddRecipe(recipe);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
