using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
using Recipes.API;

namespace Recipes
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public string username = null;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(nameof(Username)); }
        }

        public String Password;
        private RecipeAPI api;
        private MainWindow main;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = this;

            main = mainWindow;
            api = new RecipeAPI();
            statusText.Text = String.Empty;
        }

        private void password_changed(object sender, RoutedEventArgs e)
        {
            Password = PasswordBox.Password;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            if (Username != null && Password != null)
            {
                if(api.login(Username, Password))
                {
                    main.username = Username;
                    main.changeContent("login");
                    statusText.Text = String.Empty;
                }
                else
                {
                    statusText.Text = "Username or password incorrect.";
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
