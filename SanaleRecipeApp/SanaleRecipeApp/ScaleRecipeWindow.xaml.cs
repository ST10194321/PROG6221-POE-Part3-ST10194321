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
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private RecipeMethods recipeMethods;
        private Recipe recipe;

        public ScaleRecipeWindow(RecipeMethods recipeMethods, Recipe recipe)
        {
            InitializeComponent();
            this.recipeMethods = recipeMethods;
            this.recipe = recipe;
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            double scaleFactor = 1;
            if (HalfScaleRadioButton.IsChecked == true)
            {
                scaleFactor = 0.5;
            }
            else if (DoubleScaleRadioButton.IsChecked == true)
            {
                scaleFactor = 2;
            }
            else if (TripleScaleRadioButton.IsChecked == true)
            {
                scaleFactor = 3;
            }

            recipeMethods.ScaleRecipe(recipe.Name, scaleFactor);
            MessageBox.Show("Recipe has been scaled.");
            this.Close();
        }
    }
}