using KinectToolsBox;
using Microsoft.Kinect.Toolkit.Controls;
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
using System.Windows.Threading;
using ViewCommon;

namespace Supermarket.View
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShelvesRight : Window
    {
      
       
       private KinectChooser sensorChooser;

       private SelecGameSuper selectSuper;
      private ShelvesFront bF;
      public ShelvesRight(int num,ShelvesFront bF, SelecGameSuper select)
        {
            this.selectSuper = select;
            InitializeComponent();
           this.bF = bF;
          
           //this.cesta.createBasket(num);
        }
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);
            sensorChooser.Stop();
            this.Hide();
         
        }



      

        private void frontBookStand(object sender, RoutedEventArgs e)
        {
            /*BasketProduct aux = new BasketProduct();
            aux.createBasket(cesta.N);
            aux.scrollView.Content = this.bF.cesta.scrollView.Content;

            this.bF.cesta.scrollView.Content = this.cesta.scrollView.Content;

            this.cesta.scrollView.Content = aux.scrollView.Content;*/
            this.sensorChooser.Stop();
            this.Hide();
            this.bF.returnWindow();


        }
        public void returnWindow()
        {

            this.sensorChooser.Start();
            this.Show();
        }
        private void exitevent(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.selectSuper.returnWindow();
            this.Close();
        }
        private void finish(object sender, MouseEventArgs e)
        {

            if (this.cesta.isFinish())
            {
                this.sensorChooser.Stop();
                this.selectSuper.returnWindow();
                this.Close();
            }
        }
   

    }
}
