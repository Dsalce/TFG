using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ViewCommon
{
    
        public static class Refresh
        {

            private static Action EmptyDelegate = delegate() { };


            public static void RefreshWindow(this UIElement uiElement)
            {
                uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            }
        }

    
}
