using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RSVP4.ViewModels;
using RSVP4.Views;

namespace RSVP4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNewEventPage : ContentPage
	{
		public CreateNewEventPage ()
		{
			InitializeComponent();
            BindingContext = new ViewModels.Event();
            ClearFields();
		}

        private void BtnCreateNewEvent_Clicked(object sender, EventArgs e)
        {

            if (EntName.Text == "" || EntAddress.Text == "" || EntPeople.Text == "" || EntHostName.Text == "")
            {
                Application.Current.MainPage.DisplayAlert("Create New Event", "Missing required information", "OK");
                ClearFields();
            }
            else
            {
                DAL dal = new DAL();

                // Create New Event
                Event ev = new Event();
                ev.Name = EntName.Text;
                ev.Address = EntAddress.Text;

                if (Convert.ToInt32(EntPeople.Text) > 0)
                    ev.People = Convert.ToInt32(EntPeople.Text);
                else
                    ClearFields();

                ev.HostName = EntHostName.Text;

                ev.EventDateTime = new DateTime(EntEventDate.Date.Year, EntEventDate.Date.Month,
                    EntEventDate.Date.Day, EntEventTime.Time.Hours, EntEventTime.Time.Minutes,
                    EntEventTime.Time.Seconds);

                ev.EventTime = EntEventTime.Time;

                ev.RSVP_Deadline = EntRSVP_Deadline.Date;

                // Put Event in SQLite DB using data bindings.
                //bool eventInserted = dal.InsertEventToDB((Event)this.BindingContext);
                bool eventInserted = dal.InsertEventToDB(ev);

                if (eventInserted)
                {
                    // Show an alert with details
                    App.Current.MainPage.DisplayAlert("Success", "New Event Created", "OK");

                    // Go to ViewAllEventsPage
                    App.Current.MainPage = new ViewAllEventsPage();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Failed", "Event failed to save to database.", "Word");
                    App.Current.MainPage = new ViewAllEventsPage();
                }
            }           
        }

        private void BtnCreateNewEventClear_Clicked(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clears fields on page.
        private void ClearFields()
        {
            EntName.Text = "";
            EntAddress.Text = "";
            EntPeople.Text = "";
            EntHostName.Text = "";
            EntEventDate.Date = DateTime.Today;
            EntRSVP_Deadline.Date = DateTime.Today;
        }
    }
}