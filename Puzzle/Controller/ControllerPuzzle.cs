using Puzzle.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Controller
{
    class ControllerPuzzle
    {


        private DaoPuzzle daoPuz;
        public ControllerPuzzle()
        {
            this.daoPuz = new DaoPuzzle();
        }
        public void insertTime(DateTime date,String user,String time,int n)
        {

            this.daoPuz.insert(date,user,time, n);
        }
    }
}
