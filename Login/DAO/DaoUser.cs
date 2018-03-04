using Login.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login.DAO
{
    public class DaoUser
    {
        private static SqlConnection con;
  
        public void connection()
        {

            con = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=DatabaseUserGames;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();



        }


        public int login(UserModel usr)
        {
            int result;
            this.connection();

            using (SqlCommand cmd = new SqlCommand("SELECT count(*)  FROM [User] WHERE userId=@user  And password=@pass", con))
            {
                cmd.Parameters.Add("@user",SqlDbType.VarChar,10).Value=usr.User;
                String aux = SecureStringToString(usr.PassWord);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 10).Value = aux;

             
                
                    result = (Int32)cmd.ExecuteScalar();
                

            }
            con.Close();

            return result;
        }
        String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public void insert(UserModel usr)
        {
          this.connection();
          SqlCommand cmd = new SqlCommand("INSERT into [User] (userId,name,lastName1,lastName2,password) VALUES(@userId,@name,@lastName1,@lastName2,@password)", con);
            {

            cmd.Parameters.Add("@userId",SqlDbType.VarChar,10).Value=usr.User;
           cmd.Parameters.Add("@name",SqlDbType.VarChar,10).Value=usr.Name;
           cmd.Parameters.Add("@lastName1",SqlDbType.VarChar,10).Value=usr.LastName1;
           cmd.Parameters.Add("@lastName2",SqlDbType.VarChar,10).Value=usr.LastName2;
           String aux = SecureStringToString(usr.PassWord);
           cmd.Parameters.Add("@password", SqlDbType.VarChar, 10).Value = aux;
           cmd.ExecuteNonQuery();
       }
        con.Close();
     }
        


    }
}
