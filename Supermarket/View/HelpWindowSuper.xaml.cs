

using KinectToolsBox;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
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
using System.Windows.Shapes;

namespace Supermarket.View
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindowSuper : Window
    {
        private KinectChooser sensorChooser;
        private SelecGameSuper sG;
        public HelpWindowSuper(SelecGameSuper sG)
        {
            InitializeComponent();
            this.sG = sG;
            
          
        }
      
      
        private void BtPlayClick(object sender, RoutedEventArgs e)
        {
          //  VideoControl.Source = newUri(MediaPathTextBox.Text);

           
            
            videoControl.Visibility = Visibility.Visible;
            videoControl.Play();
        }

        private void BtStopClick(object sender, RoutedEventArgs e)
        {
          

            videoControl.Visibility = Visibility.Visible;
            videoControl.Stop();
        }

        private void BtPauseClick(object sender, RoutedEventArgs e)
        {
            

            videoControl.Visibility = Visibility.Visible;
          videoControl.Pause();
        }

        private void exitButton(object sender, RoutedEventArgs e)
        {
            videoControl.Stop();
            this.sensorChooser.Stop();
            this.sG.returnWindow();
            this.Close();
        }

        private void loadWindow(object sender, RoutedEventArgs e)
        {
            sensorChooser = new KinectChooser(this.kinectRegion, this.sensorChooserUi);

          // this.videoControl.Source = new Uri(@"VideoHelp/helpKinect.mp4", UriKind.Relative);
            videoControl.Visibility = Visibility.Visible;
            videoControl.Play();
        }

       
      
        private void maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }
    }
}
