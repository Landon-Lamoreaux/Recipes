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

namespace Recipes
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string username = "";

        #region getters

        public string recipename = null;
        public string RecipeName
        {
            get { return recipename; }
            set { recipename = value; OnPropertyChanged(nameof(RecipeName)); }
        }

        public string type = null;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(nameof(Type)); }
        }

        public string desc = null;
        public string Desc
        {
            get { return desc; }
            set { desc = value; OnPropertyChanged(nameof(Desc)); }
        }

        public string step = null;
        public string Step
        {
            get { return step; }
            set { step = value; OnPropertyChanged(nameof(Step)); }
        }


        public int stepnum;
        public int StepNum
        {
            get { return stepnum; }
            set { stepnum = value; OnPropertyChanged(nameof(StepNum)); }
        }


        public int recipeid;
        public int RecipeID
        {
            get { return recipeid; }
            set { recipeid = value; OnPropertyChanged(nameof(RecipeID)); }
        }

        public string ingredient;
        public string Ingredient
        {
            get { return ingredient; }
            set { ingredient = value; OnPropertyChanged(nameof(Ingredient)); }
        }

        public double cost;
        public double Cost
        {
            get { return cost; }
            set { cost = value; OnPropertyChanged(nameof(Cost)); }
        }

        public double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        public string unit;
        public string Unit
        {
            get { return unit; }
            set { unit = value; OnPropertyChanged(nameof(Unit)); }
        }

        public int recipenumber;
        public int RecipeNumber
        {
            get { return recipenumber; }
            set { recipenumber = value; OnPropertyChanged(nameof(RecipeNumber)); }
        }

        #endregion getters

        private RecipeAPI api;
        private Display display;
        public AddRecipe(Display display)
        {
            InitializeComponent();
            DataContext = this;
            api = new RecipeAPI();
            this.display = display;
        }

        private void onCreateClick(object sender, RoutedEventArgs e)
        {
            api.createRecipe(RecipeName, Type, Desc, username);
            display.updateView();
            clearValues();
        }

        private void onAddStep(object sender, RoutedEventArgs e)
        {
            api.addStep(Step, RecipeID, StepNum);
            display.updateDetails();
            clearValues();
        }

        private void onAddIngredient(object sender, RoutedEventArgs e)
        {
            api.addIngredient(this.Ingredient, RecipeNumber, Amount, Cost, Unit);
            display.updateDetails();
            clearValues();
        }

        private void clearValues()
        {
            RecipeNameBox.Clear();
            RecipeTypeBox.Clear();
            RecipeDescBox.Clear();
            StepNumBox.Clear();
            RecipeIDBox.Clear();
            StepBox.Clear();
            IngredientBox.Clear();
            CostBox.Clear();
            AmountBox.Clear();
            UnitBox.Clear();
            RecipeNumberBox.Clear();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void setUsername(string username)
        {
            this.username = username;
        }
    }
}
