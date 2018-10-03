using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RSVP4.ViewModels;
using RSVP4.Views;
using System.ComponentModel;

namespace RSVP4
{
    public class DAL 
    {
        public SQLite.SQLiteConnection db;

        public DAL()
        {
            // set database path
            var dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.MyDocuments), "Events.sqlite");

            // create new connection
            db = new SQLiteConnection(dbPath);

            if (db.GetTableInfo("Event").Count == 0)
                db.CreateTable<Event>();

            if (db.GetTableInfo("Login").Count == 0)
                db.CreateTable<Login>();

            // debug
            //db.DropTable<Event>();
            //db.DropTable<Login>();
        }

        // Inserts an event into the Event table
        public bool InsertEventToDB(Event ev)
        {
            if (db.GetTableInfo("Event").Count == 0)
                db.CreateTable<Event>();

            int numberOfRows = db.Insert(ev);
            if (numberOfRows > 0)
                return true;
            else
                return false;
        }

        // returns a list of events
        public List<Event> GetEvents()
        {
            if (db.GetTableInfo("Event").Count != 0)
            {
                List<Event> events = db.Table<Event>().ToList();
                return events;
            }
            else
                return new List<Event>();
        }

        // Deletes a record from the Events table
        public bool DeleteEventFromDB(int id)
        {
            int numberOfRows = db.GetTableInfo("Event").Count;

            if (numberOfRows > 0)
                db.CreateTable<Event>();

            db.Delete<Event>(id);

            int numberOfRows2 = db.GetTableInfo("Event").Count;

            if (numberOfRows2 == numberOfRows - 1)
                return true;

            else
                return false;
        }

        // gets a single event
        public Event GetEvent(int id)
        {
            if (db.GetTableInfo("Event").Count != 0)
            {
                return db.Table<Event>().Where(x => x.EventID == id).SingleOrDefault();
            }

            return null;
        }

        //inserts a user to the login table
        public bool InsertLoginToDB(Login l)
        {
            if (db.GetTableInfo("Login").Count == 0)
                db.CreateTable<Login>();

            int numberOfRows = db.Insert(l);
            if (numberOfRows > 0)
                return true;
            else
                return false;
        }

        // retrns a list of logins
        public List<Login> GetLogins()
        {
            if (db.GetTableInfo("Login").Count != 0)
            {
                List<Login> logins = db.Table<Login>().ToList();
                return logins;
            }
            else
                return new List<Login>();
        }
    }
}
