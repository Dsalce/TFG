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

namespace Supermarket.View
{
    /// <summary>
    /// Interaction logic for Producto.xaml
    /// </summary>
    public partial class Producto : UserControl
    {
        public static BasketProduct bP;
     
        public int numProduc
        {
            get;
            set;
        }
        public ImageSource Source
        {
            get
            {
                return this.img.Source;
            }
            set
            {
                img.Source = value;
          

            }
        }
        public String TagProduct
        {
            get
            {
                return this.img.Tag.ToString();
            }
            set
            {
                img.Tag = value;

                this.prod.Label = value;
            }
        }

         private Boolean marcada;
        public Boolean mark
        {
            get
            {
                return this.marcada;

            }
            set
            {

                marcada = value;
            }
        }

        
        

      
        public void marked()
        {
            if (this.marcada)
            {
                this.marcada = false;

                this.Opacity = 100.0;

            }
            else
            {
                this.marcada = true;
                this.Opacity = 0.5;
            }
        }

     
    
        public Producto()
        {
            InitializeComponent();
           
        }

      

        public void addProduct(object sender, RoutedEventArgs e)
        {
            this.marked();

            bP.addProduct(this);
               // this.Source = null;
            
        }
     
    }
}
