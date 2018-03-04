

using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Win32.SafeHandles;
using puzzle.View;
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

namespace Login.View
{
    /// <summary>
    /// Interaction logic for SelecGame.xaml
    /// </summary>
    public partial class ChooseGame : Window

    {
      
        private KinectChooser sensorChooser;
      
        public ChooseGame(String user)
        {
            InitializeComponent();
            this.nameUser.Content = user;
            
        }
   
        
     
        public void returnWindow(){
          
            this.sensorChooser.Start();
            this.Show();
        }
        private void selectPuzzle(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            int aux = Int32.Parse(((KinectTileButton)sender).Tag.ToString());
            SelecGame selec = new SelecGame(this.nameUser.Content.ToString());
            this.Hide();
            selec.Show();
        }
     
           

      

        private void exitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion,this.sensorChooserUi);
          
        }

        private void selectSupermarket(object sender, RoutedEventArgs e)
        {
            this.sensorChooser.Stop();
            this.Hide();
            int aux = Int32.Parse(((KinectTileButton)sender).Tag.ToString());
            SelecGameSuper selec = new SelecGameSuper(this.nameUser.Content.ToString());
            this.Hide();
            selec.Show();
        }

        }
    
}
