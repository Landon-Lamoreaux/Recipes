using Recipes.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MessageBox = System.Windows.MessageBox;

namespace Recipes
{
    /// <summary>
    /// Interaction logic for display.xaml
    /// </summary>
    public partial class Display : System.Windows.Controls.UserControl
    {
        private RecipeAPI api;
        private List<Recipies> Recipes;
        private List<Ingredient> Ingredients;
        private List<RecipeSteps> Steps;
        private Recipies SingleRecipe;
        private Ingredient SingleIngredient;
        private RecipeSteps SingleStep;
        public Display()
        {
            InitializeComponent();
            api = new RecipeAPI();

            Recipes = api.getRecipes();
            NameList.ItemsSource = Recipes;
            SingleRecipe = (Recipies)NameList.SelectedItem;
        }

        private void onSelectionChange(object? sender, SelectionChangedEventArgs e)
        {
            if (NameList.SelectedItem != null)
            {
                SingleRecipe = (Recipies)NameList.SelectedItem;
                Ingredients = api.GetIngredients(SingleRecipe.ID);
                Steps = api.GetSteps(SingleRecipe.ID);
                StepList.ItemsSource = Steps;
                StepList.Items.Refresh();
                IngredientList.ItemsSource = Ingredients;
                IngredientList.Items.Refresh();
            }
        }

        public void updateView()
        {
            Recipes = api.getRecipes();
            NameList.ItemsSource = Recipes;
        }

        public void updateDetails()
        {
            if (SingleRecipe == null)
                return;
            Ingredients = api.GetIngredients(SingleRecipe.ID);
            Steps = api.GetSteps(SingleRecipe.ID);
            StepList.ItemsSource = Steps;
            IngredientList.ItemsSource = Ingredients;
        }


        private void onDelete(object? sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this recipe?";
            string title = "Delete Check";
            MessageBoxButton buttons = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(msg, title, buttons);
            SingleRecipe = (Recipies)NameList.SelectedItem;

            switch (result)
            {
                case MessageBoxResult.Yes:
                    api.deleteRecipe(SingleRecipe.ID);
                    updateView();
                    updateDetails();
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void onIngredientCellEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            SingleIngredient = (Ingredient)IngredientList.SelectedItem;
            var column = e.Column.DisplayIndex;

            switch (column)
            {
                case 0:
                    SingleIngredient.Name = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
                    break;
                case 1:
                    SingleIngredient.Amount = Convert.ToDouble(((System.Windows.Controls.TextBox)e.EditingElement).Text);
                    break;
                case 2:
                    SingleIngredient.Unit = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
                    break;
                case 3:
                    SingleIngredient.Cost = Convert.ToDouble(((System.Windows.Controls.TextBox)e.EditingElement).Text);
                    break;
            }

            api.updateIngredients(SingleIngredient);
            updateDetails();
        }

        private void onStepCellEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            SingleStep = (RecipeSteps)StepList.SelectedItem;
            var column = e.Column.DisplayIndex;

            switch (column)
            {
                case 1:
                    SingleStep.Step = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
                    break;
            }

            api.updateSteps(SingleStep);
            updateDetails();
        }

        private void onRecipeCellEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            SingleRecipe = (Recipies)NameList.SelectedItem;
            var column = e.Column.DisplayIndex;

            switch (column)
            {
                case 2:
                    SingleRecipe.Name = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
                    break;
            }

            api.updateRecipe(SingleRecipe);
            updateDetails();
        }
    }
}
