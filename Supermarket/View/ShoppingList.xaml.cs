using KinectToolsBox;
using Supermarket.Controller;
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

namespace Supermarket.View
{
    /// <summary>
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Window
    {
        private KinectChooser sensorChooser;
        private SelecGameSuper selectSuper;
        private ControllerBookStand control;
        private int num;
        public ShoppingList(int num, SelecGameSuper select)
        {
            InitializeComponent();
            this.num = num;
            this.selectSuper = select;
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);
            control = new ControllerBookStand(num);
            ArrayList list = new ArrayList();
            list=control.generateListShopping();
            int aux = 0;
            foreach (int i in list)
            {
                Image image = new Image();
                
                image.Width = double.NaN;
                image.Height = double.NaN;
                image.Stretch = Stretch.Fill;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(@"Imagenes/Estanterias/" + i + ".png", UriKind.Relative);
                img.EndInit();
                Label l = new Label();
                l.Width = 200;
                l.Height = 200;
                l.Content = image;

                image.Source = img;
                if (aux % 3 == 0)
                {
                    Col1.Children.Add(l);
                }
                else if (aux % 3 == 1)
                {
                    Col2.Children.Add(l);
                }
                else if (aux % 3 == 2)
                {
                    Col3.Children.Add(l);
                }
                aux++;
            }

        }

        private void acceptEvent(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            ShelvesFront book = new ShelvesFront(num, this.selectSuper,this.control);
            this.Close();
            book.Show();
        }

        private void CancelEvent(object sender, RoutedEventArgs e)
        {
            
            this.sensorChooser.Stop();
            this.selectSuper.returnWindow();
            this.Close();
        }
    }
}
