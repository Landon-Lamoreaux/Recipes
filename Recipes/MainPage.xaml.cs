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

namespace Recipes
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : System.Windows.Controls.UserControl
    {
        Display Display;
        AddRecipe AddRecipe;
        public string username;
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;

            Display = new Display();
            AddRecipe = new AddRecipe(Display);

            DisplayTab.Content = Display;
            AddTab.Content = AddRecipe;
        }

        public void setUsername(string username)
        {
            this.username = username;
            AddRecipe.setUsername(username);
        }
    }
}
