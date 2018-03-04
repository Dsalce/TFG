
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ViewCommon
{
    /// <summary>
    /// Interaction logic for Crono.xaml
    /// </summary>
    public partial class Crono : UserControl
    {
        private int second;
        private int min;
        private int hour;
        private DispatcherTimer dispatcherTimer;
      
        public String Time
        {
            get;
            set;
        }
        public Crono()
        {
            InitializeComponent();
            this.Loaded += timeLoad;
        }

        private void timeLoad(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            this.second = 0;
            this.min = 0;
            this.hour = 0;
        }
       public void startCrono(){
           this.second = 0;
           this.min = 0;
           this.hour = 0;
            dispatcherTimer.Start();
       }
       public void stopCrono()
       {
           
           dispatcherTimer.Stop();
       }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            if (this.second == 60)
            {
                this.second = 0;
                this.min++;
            }
            if (this.second == 60 && this.min == 60)
            {
                this.second = 0;
                this.min = 0;
                this.hour++;
            }
            Time = this.hour.ToString("00") + ":" + this.min.ToString("00") + ":" + this.second.ToString("00");
            this.time.Content = Time;
            this.second++;
        }
    }
}

    

