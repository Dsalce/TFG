using Login.DAO;
using Login.ViewModel;
using puzzle;
using puzzle.View;
using System;
using System.Collections;
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

namespace Login.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

       

        
        private void registrar(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.Close();
            rw.ShowDialog();


        }

        private void login(object sender, RoutedEventArgs e)
        {
            IEnumerator enu = this.Resources.Values.GetEnumerator();
            enu.MoveNext();
            try
            {
                
                if (((UserViewModel)enu.Current).login(this.user.Text, pass.SecurePassword) == 0)
                {
                    MessageBox.Show("no existe el user");
                }
                else
                {
                    ChooseGame choose = new ChooseGame(this.user.Text);
                    
                    this.Close();
                    choose.Show();
                }
            }catch(Exception ex){
               
                MessageBox.Show("Error");
            }
        }

       

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((UserViewModel)this.DataContext).PassWord = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
