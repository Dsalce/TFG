using Supermarket.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Controller
{
    
   public  class ControllerBookStand
    {
       private ShoppingListModel sL;

       public ControllerBookStand(int num)
       {
           sL = new ShoppingListModel(num);


       }
       public ArrayList generateListShopping()
       {
           return this.sL.generateList();
       }

       public Boolean finishSuper( int n)
       {
           return this.sL.isFinish(n);

            
       }
    }
}
