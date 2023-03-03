using AMONIC_Airlines.Classes;
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
using System.Windows.Threading;

namespace AMONIC_Airlines.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        
        public Login()
        {
            InitializeComponent();
            reklama.Interval = TimeSpan.FromSeconds(1);
            reklama.Tick += Reklama_Tick;
            login.Text = "j.doe@amonic.com";
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        int TryForLogin = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TryForLogin++;
            
                bool secondEqual = true;
                int SecondEqual = 0;
                
                List<User> users = new ConnectToDB().GetUsersByLogin(login.Text);
                int equal = 0;
                if (login.Text == "" || Password.Password == "")
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    
                    foreach (User user in users)
                    {
                        if (login.Text == user.Email)
                        {
                            
                            equal = 1;


                            if (user.Password == Password.Password)
                            {

                                User users1 = new ConnectToDB().GetUsersForLogin(login.Text);
                                // Post post = new FastConnection().GetPostByID(personal_Card.Post_ID)[0];
                                int Rolll = 0;
                                SecondEqual = 1;
                                //Успешная авторизация
                                secondEqual = false;
                                if (user.Active == false)
                                {
                                    MessageBox.Show("Авторизация невозможна, вы заблокированы");
                                    TryForLogin= 0;
                                }
                                else
                                {


                                    if (users1.RoleID == 2)
                                    {

                                    NavigationService.Navigate(new UserPage());
                                        TryForLogin = 0;
                                    }
                                    else if (users1.RoleID == 1)
                                    {
                                    NavigationService.Navigate(new AdminPage());
                                    TryForLogin = 0;
                                    }
                                }
                            }
                            else if (secondEqual == true && SecondEqual != 1)
                            {
                               
                                MessageBox.Show("Неверный пароль");
                                SecondEqual = 1;
                                
                            }

                            
                        }


                    }
                    if (equal == 0)
                    {
                        MessageBox.Show("Такого пользователя нет");
                    }
                    if (TryForLogin >= 3)
                    {
                        TimerForLogin.Visibility = Visibility.Visible;
                        loginButton.IsEnabled = false;
                        reklama.Start();

                        //  }
                    }
                }
            
        }
        DispatcherTimer reklama = new DispatcherTimer();
        int TIck = 1;
        private void Reklama_Tick(object sender, EventArgs e)
        {
           
            if (TIck == 10)
            {

                TIck = 0;
                loginButton.IsEnabled = true;
                TimerForLogin.Visibility = Visibility.Hidden;
                reklama.Stop();
            }
            TimerForLogin.Content = (TIck + "/10");
            TIck++;

        }
    }
}
