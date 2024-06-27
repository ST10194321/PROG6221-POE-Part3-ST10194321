# Sanele’s Recipe Management Application

This WPF application allows users to manage recipes by adding, displaying, scaling, resetting, and clearing recipes. It offers a user-friendly interface for inputting recipe details, including ingredients, quantities, units, calories, and food groups. The application also features functionality for scaling ingredient quantities and notifying users when the total calories of a recipe exceed 300.

## Installation Instructions

1. Install the latest version of [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/).
2. Ensure you have the following packages installed:
   - .NET Core
   - WPF
     Follow this [guide](https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022) if lost with installation.
3. Download the zipped file named `SanaleRecipeApp` from the GitHub repository and unzip it on your computer.
4. Open Visual Studio and select “Open a local project”. Select the `.sln` file to open the application.

## Usage Instructions

### Adding a New Recipe

1. Click the "Add New Recipe" button.
2. Enter the recipe name, number of ingredients, and details for each ingredient.
3. Select the appropriate food group for each ingredient from the provided list.
4. Enter the number of steps and descriptions for each step.
5. Click the "Save Recipe" button to save the recipe.

### Displaying a Recipe

1. Click the "Display Recipe" button.
2. The application will list all recipes in alphabetical order.
3. Select the recipe you want to display from the list.

### Scaling a Recipe

1. Click the "Scale Recipe" button.
2. Select the recipe you want to scale from the list.
3. Choose the scaling factor (0.5, 2, or 3).

### Resetting a Recipe

1. Click the "Reset Recipe" button.
2. Select the recipe you want to reset from the list.

### Clearing All Recipes

1. Click the "Clear All Recipes" button.
2. Confirm the action by clicking "Yes" or "No".

### Exiting the Application

1. Click the "Exit App" button.

## Class Structure

### RecipeMethods.cs

**Fields:**
- `List<Recipe> recipes`: Stores all recipes.
- `List<string> foodGroups`: Predefined list of food groups.

**Methods:**
- `AddRecipe(Recipe recipe)`: Adds a new recipe to the list.
- `DisplayRecipe()`: Displays a selected recipe.
- `ScaleRecipe()`: Scales a selected recipe.
- `ResetRecipe()`: Resets a selected recipe.
- `ClearRecipes()`: Clears all recipes.
- `CalculateTotalCalories(Recipe recipe)`: Calculates the total calories of all ingredients in a recipe.

### Recipe.cs

**Fields:**
- `string Name`: Recipe name.
- `List<Ingredient> Ingredients`: List of ingredients.
- `List<string> Steps`: List of steps.

### Ingredient.cs

**Fields:**
- `string Name`: Ingredient name.
- `double Quantity`: Ingredient quantity.
- `string Unit`: Unit of measurement.
- `int Calories`: Calorie content.
- `string FoodGroup`: Food group.
- `double OriginalQuantity`: Original quantity.

### MainWindow.xaml.cs

**Methods:**
- `MainWindow()`: Initializes the main window.
- `AddRecipeButton_Click(object sender, RoutedEventArgs e)`: Opens the Add Recipe window.
- `DisplayRecipeButton_Click(object sender, RoutedEventArgs e)`: Opens the Display Recipe window.
- `ScaleRecipeButton_Click(object sender, RoutedEventArgs e)`: Opens the Scale Recipe window.
- `ResetRecipeButton_Click(object sender, RoutedEventArgs e)`: Opens the Reset Recipe window.
- `ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)`: Clears all recipes.
- `ExitAppButton_Click(object sender, RoutedEventArgs e)`: Exits the application.

### AddRecipeWindow.xaml.cs

**Fields:**
- `RecipeMethods recipeMethods`: Instance of RecipeMethods for managing recipes.

**Methods:**
- `AddRecipeWindow(RecipeMethods recipeMethods)`: Initializes the Add Recipe window.
- `NumIngredientsTextBox_TextChanged(object sender, TextChangedEventArgs e)`: Handles changes in the number of ingredients.
- `NumStepsTextBox_TextChanged(object sender, TextChangedEventArgs e)`: Handles changes in the number of steps.
- `AddIngredientControls(int index)`: Adds input controls for an ingredient.
- `AddStepControls(int index)`: Adds input controls for a step.
- `SaveRecipeButton_Click(object sender, RoutedEventArgs e)`: Saves the recipe.

### DisplayRecipeWindow.xaml.cs

**Methods:**
- `DisplayRecipeWindow(Recipe recipe)`: Initializes the Display Recipe window and displays the recipe.
- `DisplayRecipe(Recipe recipe)`: Displays the recipe's details.

### ScaleRecipeWindow.xaml.cs

**Methods:**
- `ScaleRecipeWindow(RecipeMethods recipeMethods)`: Initializes the Scale Recipe window.
- `RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)`: Handles recipe selection.
- `ScaleButton_Click(object sender, RoutedEventArgs e)`: Scales the selected recipe.

### ResetRecipeWindow.xaml.cs

**Methods:**
- `ResetRecipeWindow(RecipeMethods recipeMethods)`: Initializes the Reset Recipe window.
- `RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)`: Handles recipe selection.
- `ResetButton_Click(object sender, RoutedEventArgs e)`: Resets the selected recipe.

### ClearRecipesWindow.xaml.cs

**Methods:**
- `ClearRecipesWindow(RecipeMethods recipeMethods)`: Initializes the Clear Recipes window.
- `ClearButton_Click(object sender, RoutedEventArgs e)`: Clears all recipes.

(Troelsen & Japikse, 2022)


## Scaling Functionality

The `ScaleRecipe` method allows users to scale ingredient quantities by a factor of 0.5, 2, or 3. The application updates each ingredient's quantity based on the selected factor and ensures accurate scaling.

## Error Handling

The program handles invalid inputs using if statements. If a user enters an invalid number, the program prompts the user to enter a valid number.

```csharp
if (!int.TryParse(NumIngredientsTextBox.Text, out int numIngredients))
{
    MessageBox.Show("Please enter a valid number for ingredients.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
    return;
}

if (!int.TryParse(NumStepsTextBox.Text, out int numSteps))
{
    MessageBox.Show("Please enter a valid number for steps.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
    return;
}
