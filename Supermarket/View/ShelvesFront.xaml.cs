using KinectToolsBox;
using Microsoft.Kinect.Toolkit.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewCommon;

namespace Supermarket.View
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShelvesFront : Window
    {
        private ShelvesRight bR;
        private ShelvesLeft bL;
       private KinectChooser sensorChooser;
       private SelecGameSuper selectSuper;
       
        public ShelvesFront(int num,SelecGameSuper select,ControllerBookStand controller)
        {
            
            this.selectSuper = select;
            InitializeComponent();
            bR = new ShelvesRight(num,this, this.selectSuper);

             bL= new ShelvesLeft(num,this, this.selectSuper);
             
             this.cesta.createBasket(num);
             this.cesta.controller = controller;
             bR.cesta = this.cesta;
             bL.cesta = this.cesta;
            
             //this.time.startCrono();
        }
        private void loadWindow(object sender, RoutedEventArgs e)
        {

            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);
            this.sensorChooser.Stop();
            this.bR.Show();
            
            this.bL.Show();

            this.sensorChooser.Start();
        }


    
        private void rightBookStand(object sender, RoutedEventArgs e)

        {
            /*  BasketProduct aux = new BasketProduct();
              aux.createBasket(cesta.N);
              aux.scrollView.Content = this.bR.cesta.scrollView.Content;


              this.bR.cesta.scrollView.Content = this.cesta.scrollView.Content;
            //  this.bR.cesta = this.cesta;
              this.cesta.scrollView.Content = aux.scrollView.Content;


              this.bR.cesta.controller = this.cesta.controller;
               IEnumerator iter= ((StackPanel)this.cesta.scrollView.Content).Children.GetEnumerator();
               IEnumerator iterBr = ((StackPanel)this.cesta.scrollView.Content).Children.GetEnumerator();
               while (iter.MoveNext())
               {

               }*/

           //this.bR.time= this.time;

            this.sensorChooser.Stop();
            this.Hide();
            this.bR.returnWindow();
         
            
        }

        public void returnWindow()
        {

            this.sensorChooser.Start();
            this.Show();
        }
        private void leftBookStand(object sender, RoutedEventArgs e)
        {
           /* BasketProduct aux = new BasketProduct();
            aux.createBasket(cesta.N);
            aux.scrollView.Content = this.bL.cesta.scrollView.Content;

            //this.bL.cesta = this.cesta;
            this.bL.cesta.scrollView.Content = this.cesta.scrollView.Content;
           
            this.cesta.scrollView.Content =aux.scrollView.Content;*/

           // this.bL.time = this.time;
        
            this.sensorChooser.Stop();
            this.Hide();
            this.bL.returnWindow();
            
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
                this.time.stopCrono();
                this.sensorChooser.Stop();
                this.selectSuper.returnWindow();
                this.Close();
            }
            
        }
   
       

       
    }
}
