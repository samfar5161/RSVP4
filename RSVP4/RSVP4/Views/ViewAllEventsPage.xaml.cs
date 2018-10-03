using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using RSVP4.ViewModels;
using System.Collections.ObjectModel;

namespace RSVP4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


	public partial class ViewAllEventsPage : ContentPage
	{
        public Event selectedEvent = new Event();

        public ViewAllEventsPage ()
		{
            InitializeComponent();
            BindingContext = new ViewModels.Event();
            
            DAL dal = new DAL();
            List<Event> events = new List<Event>();
            events = new List<Event>(dal.GetEvents());
            
            LstVwEventList.ItemsSource = events;
        }


        private void BtnCreateNewEvent_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Views.CreateNewEventPage();
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Event ev = new Event();
        //    App.Current.MainPage = new Views.EventDetailPage();
        //}

        private void LstVwEventList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            selectedEvent = (Event)e.SelectedItem;  
        }

        private void BtnViewEventDetail_Clicked(object sender, EventArgs e)
        {
            if (selectedEvent != null)
                App.Current.MainPage = new Views.EventDetailPage(selectedEvent);

            else
                App.Current.MainPage.DisplayAlert
                    ("No Event Selected", "You have to select the event you want to view", "OK");
        }
    }
}