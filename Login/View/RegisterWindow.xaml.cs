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
using System.Windows.Shapes;

namespace Login.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void registrar(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerator enu = this.Resources.Values.GetEnumerator();
                enu.MoveNext();
                
                ((UserViewModel)enu.Current).inserta(this.user.Text, this.name.Text, this.ape1.Text, this.ape2.Text, pass.SecurePassword);
                 SelecGame selec = new SelecGame(this.user.Text);
                this.Close();
                selec.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

           


        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((UserViewModel)this.DataContext).PassWord = ((PasswordBox)sender).SecurePassword; }
        }
       
    }
}
