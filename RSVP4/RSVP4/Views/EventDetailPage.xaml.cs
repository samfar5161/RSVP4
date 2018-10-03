using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSVP4.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSVP4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailPage : ContentPage
	{
        public Event SelectedEvent = new Event();
		public EventDetailPage ()
		{
			InitializeComponent ();
		}

        public EventDetailPage(Event ev)
        {
            InitializeComponent();
            SelectedEvent = ev;
            BindingContext = SelectedEvent;

            
        }

        private void BtnReturnToList_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Views.ViewAllEventsPage();
        }

        private void BtnRSVP_Clicked(object sender, EventArgs e)
        {
            if (DateTime.Today > SelectedEvent.RSVP_Deadline.Date)
            {
                App.Current.MainPage.DisplayAlert
                    ("Past Deadline", "Sorry, but you missed the deadline", "OK");

                BtnRSVP.IsVisible = false;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("RSVP Successful", "You have sent an RSVP", "OK");
                App.Current.MainPage = new Views.ViewAllEventsPage();
            }

        }

        private void BtnEditEvent_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnDeleteEvent_Clicked(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            dal.DeleteEventFromDB(SelectedEvent.EventID);

            App.Current.MainPage.DisplayAlert("Delete Event", "Event Deleted", "OK");

            App.Current.MainPage = new Views.ViewAllEventsPage();
        }
    }
}