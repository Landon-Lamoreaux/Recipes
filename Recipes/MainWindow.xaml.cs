using Recipes.API;
using System.ComponentModel;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private RecipeAPI api;
        private Login login;
        private MainPage mainPage;
        public string username;
        public MainWindow()
        {
            // var hashPass = Hasher.Hash("robots");
            InitializeComponent();
            login = new Login(this);
            mainPage = new MainPage();
            // api.login("Landon", "robots");
            mainContentControl.Content = login;
        }

        public void changeContent(string content)
        {
            switch(content)
            {
                case "login":
                    mainContentControl.Content = mainPage;
                    mainPage.setUsername(username);
                    break;
            }
        }
    }
}