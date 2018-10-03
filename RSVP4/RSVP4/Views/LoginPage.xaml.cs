using RSVP4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSVP4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent();
            BindingContext = new ViewModels.Login();

		}

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {

            string user = EntUserName.Text;
            string pass = EntPassword.Text;
            bool userCheck = false;
            bool passcheck = false;

            DAL dal = new DAL();
            List<Login> log = new List<Login>(dal.GetLogins());

            // check username
            foreach (Login login in log)
            {
                if (login.UserName == user)
                    userCheck = true;
            }

            foreach (Login login in log)
            {
                if (login.Password == pass)
                    passcheck = true;
            }

            if (userCheck && passcheck)
                App.Current.MainPage = new Views.ViewAllEventsPage();

            else
                App.Current.MainPage.DisplayAlert("Invalid Login", "User name or password are invalid," +
                    "try signing up", "OK");

        }

        private void BtnLoginClear_Clicked(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clear fields
        private void ClearFields()
        {
            EntUserName.Text = "";
            EntPassword.Text = "";
        }

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            Login l = new Login(EntUserName.Text, EntPassword.Text);

            dal.InsertLoginToDB(l);

            // Display message
            App.Current.MainPage.DisplayAlert("Success", "Profile created! Try signing in.", "OK");

            // Go to next page
            App.Current.MainPage = new LoginPage();

        }
    }
}