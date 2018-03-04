using Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model
{
    public class UserModel : NotifyBase
    {

         private string  user;
        private string name;
        private string lastname1;
        private string lastName2;
        private SecureString password;

        public string User
        {
            get{
                return user;
            }//Fin de get.
            set{
                user = value;
                OnPropertyChanged("User");
                OnPropertyChanged("DisplayName");
            }//Fin de set.
        }//Fin de propiedad Id.
 
        public string Name {
            get{
                return name;
            }//Fin de get.
            set{
                name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("DisplayName");
            }//Fin de set.
        }//Fin de propiedad Name.
 
        public string LastName1 {
            get{
                return lastname1;
            }//Fin de get.
            set{
                lastname1 = value;
                OnPropertyChanged("LastName1");
                OnPropertyChanged("DisplayName");
            }//Fin de set.
        }//Fin de propiedad LastName.

        public string LastName2
        {
            get
            {
                return lastName2;
            }//Fin de get.
            set
            {
                lastName2 = value;
                OnPropertyChanged("LastName2");
                OnPropertyChanged("DisplayName");
            }//Fin de set.
        }//Fin de propiedad LastNam
        public SecureString PassWord
        {
            get
            {
                return password;
            }//Fin de get.
            set
            {
                password = value;
                OnPropertyChanged("Password");
                OnPropertyChanged("DisplayName");
            }//Fin de set.
        }//Fin de propiedad LastNam


        public string DisplayName {
            get {
                return User + "-" + Name + " " + LastName1 + " "  + LastName2;
            }//Fin de get.
        }//Fin de la propiedad readonly DisplayName.



    }
}
