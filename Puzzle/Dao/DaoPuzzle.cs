using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Dao
{
    public class DaoPuzzle
    {


        public DaoPuzzle()
        {


        }
         private static SqlConnection con;
  
        public void connection()
        {

            con = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=DatabaseUserGames;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();



        }


       
       

        public void insert(DateTime date,String user,string time,int n)
        {
            SqlCommand cmd=null;
          this.connection();
            switch(n){
                case 2:
                       cmd = new SqlCommand("INSERT into [PuzzleDe4] (date,userPuz,time) VALUES(@date,@user,@time)", con);
                break;
                case 3:
                     cmd = new SqlCommand("INSERT into [PuzzleDe9] (date,userPuz,time) VALUES(@date,@user,@time)", con);
                   

                    break;

                case 4:
                    cmd = new SqlCommand("INSERT into [PuzzleDe16] (date,userPuz,time) VALUES(@date,@user,@time)", con);
                  
                break;
            }

            
          
            

           cmd.Parameters.Add("@date",SqlDbType.DateTime).Value=date;
           cmd.Parameters.Add("@user",SqlDbType.VarChar,10).Value=user;
           cmd.Parameters.Add("@time",SqlDbType.VarChar,8).Value=time;
           
           cmd.ExecuteNonQuery();
       
        con.Close();
     }
        


    }
    
}
