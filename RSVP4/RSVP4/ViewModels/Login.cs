using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace RSVP4.ViewModels
{
    [Table("Login")]
    public class Login : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Private fields.
        string userName, password;

        // Primary Key for SQLite
        [PrimaryKey, AutoIncrement, Indexed]
        public int LoginID { get; set; } = 1;

        [Column("UserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        [Column("Password")]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public Login() { }

        public Login(string u, string p)
        {
            this.UserName = u;
            this.Password = p;
        }


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
