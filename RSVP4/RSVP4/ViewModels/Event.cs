using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RSVP4.ViewModels
{
    [Table("Event")]
    public class Event : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // private event properties
        string name, address, hostName;
        int people;
        DateTime eventDateTime, rsvp_Deadline;
        TimeSpan eventTime;
     

        // OnPropertyChanged method
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            
        }

        // Event ID for SQLite
        [Column("EventID"), PrimaryKey, AutoIncrement, Indexed]
        public int EventID { get; set; } = 2;

        [Column("Name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        [Column("Address")]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        [Column("People")]
        public int People
        {
            get { return people; }
            set
            {
                people = value;
                OnPropertyChanged();
            }
        }

        [Column("HostName")]
        public string HostName
        {
            get { return hostName; }
            set
            {
                hostName = value;
                OnPropertyChanged();
            }
        }

        [Column("EventDateTime")]
        public DateTime EventDateTime
        {
            get { return eventDateTime; }
            set
            {
                eventDateTime = value;
                OnPropertyChanged();
            }
        }

        [Column("EventTime")]
        public TimeSpan EventTime
        {
            get { return eventTime; }
            set
            {
                eventTime = new TimeSpan(this.eventDateTime.Hour, this.eventDateTime.Minute, this.eventDateTime.Second);
                //eventTime = value;
                //OnPropertyChanged();
            }
        }

        [Column("RSVP_Deadline")]
        public DateTime RSVP_Deadline
        {
            get { return rsvp_Deadline; }
            set
            {
                rsvp_Deadline = value;
                OnPropertyChanged();
            }
        }     
    }
}
