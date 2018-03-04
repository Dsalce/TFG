

using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Win32.SafeHandles;
using Supermarket.View;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SelecGame.xaml
    /// </summary>
    public partial class SelecGameSuper : Window

    {
      
        private KinectChooser sensorChooser;
        public SelecGameSuper(String user)
        {
            InitializeComponent();
            this.nameUser.Content = user;
            
        }
   
        
     
        public void returnWindow(){
          
            this.sensorChooser.Start();
            this.Show();
        }
        private void selectBuy(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            int aux = Int32.Parse(((KinectTileButton)sender).Tag.ToString());
            ShoppingList sL = new ShoppingList(aux, this);
            sL.Show();
        }
     
           

      

        private void exitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void helpButton(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            HelpWindowSuper hw = new HelpWindowSuper(this);
            hw.Show();
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion,this.sensorChooserUi);
          
        }

        }
    
}
