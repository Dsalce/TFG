using Supermarket.Controller;
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
    /// Interaction logic for BasketProduct.xaml
    /// </summary>
    public partial class BasketProduct : UserControl
    {
        public int N
        {
            get { return num; }
            set {N=num;}
        }
        public ControllerBookStand controller
        {
            get;
            set;
        }
        private int num ;
        private int numPiece;
        private Producto ant;
        public BasketProduct()
        {
            
            InitializeComponent();
            
        }
        public void createBasket(int n)
        {
            this.num = n;
            Producto.bP = this;
            for (int i = 0; i < this.num; i++)
            {
                Producto p = new Producto();

                p.Width =200;
                p.Height = double.NaN;
                p.TagProduct = "";

                this.cesta.Children.Add(p);
            }
        }
        public void addProduct(Producto pro)
        {
            if (numPiece == 0)
            {



                ant = pro;
                numPiece++;
            }
            else if (numPiece == 1)
            {

                var p = pro.prod.Content;
                String tag = pro.TagProduct;
                int numProducto = pro.numProduc;

                pro.prod.Content = ant.prod.Content;
                pro.TagProduct = ant.TagProduct;
                pro.numProduc = ant.numProduc;

                ant.prod.Content = p;
                ant.TagProduct = tag;
                ant.numProduc = numProducto;

                pro.marked();
                ant.marked();
                numPiece = 0;

               
                

            }

        }

      public Boolean isFinish(){
          Boolean finish=true;
          foreach (Producto p in Producto.bP.cesta.Children)
          {

              Console.WriteLine(p.TagProduct + "\n");
             if( !this.controller.finishSuper(p.numProduc)){
                 finish=false;
             }
          }

          return finish;
      }



    }
}
