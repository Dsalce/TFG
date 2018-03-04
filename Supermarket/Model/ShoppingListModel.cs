using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    public class ShoppingListModel
    {
        private int num;
        private ArrayList shopping;
        public ShoppingListModel(int num)
        {
            this.num = num;
            shopping = new ArrayList();
        }

        public ArrayList generateList()
        {
             
            Random r = new Random();

            int auxiliar = 0;
           
            int i=0;
            while(  i < num)
            {
                auxiliar = r.Next(1, 27);
                
                if (!shopping.Contains(auxiliar))
                {
                   this.shopping.Add(auxiliar);
                    i++;
                }
              
            }

            return shopping;
        }

        public Boolean isFinish(int n)
        {
            return shopping.Contains(n);
        }



    }
}
