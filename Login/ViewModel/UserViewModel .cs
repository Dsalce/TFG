using Login.DAO;
using Login.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security;
using System.Windows.Input;

namespace Login.ViewModel
{
    public class UserViewModel : ObservableCollection<UserModel>, INotifyPropertyChanged
    {
         private int selectedIndex;

        private DaoUser dao;
        private string user;
        private string name;
        private string lastName1;
        private string lastName2;
        private SecureString password;

        private ICommand addClientCommand;
        private ICommand clearCommand;

 

        public int SelectedIndexOfCollection {
            get {
                return selectedIndex;
            }//Fin de get.
            set{
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");
 
                //Activa el evento OnPropertyChanged de los atributos para refrescar las propiedades segun el indice seleccionado.
                OnPropertyChanged("User");
                OnPropertyChanged("Name");
                OnPropertyChanged("LastName");
                 OnPropertyChanged("LastName2");
                 OnPropertyChanged("PassWord");
            }//Fin de set.
        }//Fin de propiedad Name.
 
       public String User {
            get {
                if (this.SelectedIndexOfCollection > -1){
                    return this.Items[this.SelectedIndexOfCollection].User;
                }//Fin de if.
                else {
                    return user;
                }//Fin de else.
            }//Fin de get.
            set{
                if (this.SelectedIndexOfCollection > -1){
                    this.Items[this.SelectedIndexOfCollection].User = value;
                }//Fin de if.
                else {
                    user = value;
                }//Fin de else.
                OnPropertyChanged("User");
            }//Fin de set.
        }//Fin de propiedad Id.
 
        public string Name {
            get {
                if (this.SelectedIndexOfCollection > -1){
                    return this.Items[this.SelectedIndexOfCollection].Name;
                }//Fin de if.
                else {
                    return name;
                }//Fin de else.
            }//Fin de get.
            set{
                if (this.SelectedIndexOfCollection > -1){
                    this.Items[this.SelectedIndexOfCollection].Name = value;
                }//Fin de if.
                else {
                    name = value;
                }//Fin de else.
                OnPropertyChanged("Name");
            }//Fin de set.
        }//Fin de propiedad Name.
 
        public string LastName1 {
            get {
                if (this.SelectedIndexOfCollection > -1){
                    return this.Items[this.SelectedIndexOfCollection].LastName1;
                }//Fin de if.
                else {
                    return lastName1;
                }//Fin de else.
            }//Fin de get.
            set{
                if (this.SelectedIndexOfCollection > -1){
                    this.Items[this.SelectedIndexOfCollection].LastName1 = value;
                }//Fin de if.
                else {
                    lastName1 = value;
                }//Fin de else.
                OnPropertyChanged("LastName1");
            }//Fin de set.
        }//Fin de propiedad LastName.
 

         public string LastName2 {
            get {
                if (this.SelectedIndexOfCollection > -1){
                    return this.Items[this.SelectedIndexOfCollection].LastName2;
                }//Fin de if.
                else {
                    return lastName2;
                }//Fin de else.
            }//Fin de get.
            set{
                if (this.SelectedIndexOfCollection > -1){
                    this.Items[this.SelectedIndexOfCollection].LastName2 = value;
                }//Fin de if.
                else {
                    lastName2 = value;
                }//Fin de else.
                OnPropertyChanged("LastName2");
            }//Fin de set.
        }//Fin de propiedad LastName.

         public SecureString PassWord
         {
            get {
                if (this.SelectedIndexOfCollection > -1){
                    return this.Items[this.SelectedIndexOfCollection].PassWord;
                }//Fin de if.
                else {
                    return password;
                }//Fin de else.
            }//Fin de get.
            set{
                if (this.SelectedIndexOfCollection > -1){
                    this.Items[this.SelectedIndexOfCollection].PassWord = value;
                }//Fin de if.
                else {
                    password = value;
                }//Fin de else.
                OnPropertyChanged("PassWord");
            }//Fin de set.
        }//Fin de propiedad LastName.
        

        public ICommand AddClientCommand {
            get {
                return addClientCommand;
            }//Fin de get.
            set{
                addClientCommand = value;
            }//Fin de set.
        }//Fin de propiedad LastName.
 
        public ICommand ClearCommand {
            get {
                return clearCommand;
            }//Fin de get.
            set{
                clearCommand = value;
            }//Fin de set.
        }//Fin de propiedad LastName.



        public UserViewModel()
        {



            this.SelectedIndexOfCollection = -1;
            AddClientCommand = new CommandBase(param => this.AddClient());
            ClearCommand = new CommandBase(new Action<Object>(ClearClient));
      
           
        }//Fin de constructor.
     /*   public void inserta()
        {
            UserModel usr = new UserModel();
            usr.User = User;
            usr.Name = Name;
            usr.LastName1 = LastName1;
            usr.LastName2 = LastName2;
            usr.PassWord = PassWord;
            if (AddClientCommand.CanExecute(usr))
            {
                AddClientCommand.Execute(usr);
                this.dao = new DaoUser();
            this.dao.insert(usr);
            }
            
        }*/
        public void inserta(string user, string name, string lastname1, string lastname2, SecureString password)
        {
           
            User = user;
            Name = name;
            LastName1 = lastname1;
            LastName2 = lastName2;
            PassWord = password;


            if (AddClientCommand.CanExecute(null))
            {
                AddClientCommand.Execute(null);
                this.dao = new DaoUser();
                this.dao.insert(this.Items[SelectedIndexOfCollection]);
            }

        }
        public int login(string user,SecureString password)
        {
            User = user;
            Name = "";
            LastName1 = "";
            LastName2 = "";
            PassWord = password;


            if (AddClientCommand.CanExecute(null))
            {
                AddClientCommand.Execute(null);
                this.dao = new DaoUser();

              return  this.dao.login(this.Items[SelectedIndexOfCollection]);
            }
            return 0;
        }

        public  event PropertyChangedEventHandler PropertyChanged;

        protected  virtual void OnPropertyChanged(string propertyName)
       {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }//Fin de if.
        }//Fin de OnPropertyChanged.

   

       


        private void AddClient(){
            UserModel usr = new UserModel();
            usr.User = User;
            usr.Name = Name;
            usr.LastName1 = LastName1;
            usr.LastName2 = LastName2;
            usr.PassWord = PassWord;
            this.Add(usr);
            SelectedIndexOfCollection++;
         
        }//Fin de AddClient.
 
        private void ClearClient(object obj){
            SelectedIndexOfCollection = -1;
            User = "";
            Name = "";
            LastName1 = "";
            LastName2 = "";
            PassWord.Clear();
        }//Fin de AddClient.
 
    }
}
