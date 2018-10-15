using System;

using Xamarin.Forms;
using SQLite;
using System.IO;
using SQLiteXDocs2.Models;
using System.Collections.ObjectModel;

namespace SQLiteXDocs2.Views
{
    public class HomePage : ContentPage
    {

        public ObservableCollection<Stock> Customers { get; set; }

        public HomePage()
        {
            this.Title = "SQLite Stock";
            StackLayout stackLayout = new StackLayout();


            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "ormdemo.db3");

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<Stock>();

            if (db.Table<Stock>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Stock();
                newStock.Symbol = "AAPL";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Symbol = "GOOG";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Symbol = "MSFT";
                db.Insert(newStock);
            }

            this.Customers =
              new ObservableCollection<Stock>(db.Table<Stock>());


            /*var listView = new ListView();

            stackLayout.Children.Add(listView);
            listView.ItemsSource = db.Table<Stock>().ToList();
            Content = stackLayout;*/

            //DoSomeDataAccess();
        }
        /*public static void DoSomeDataAccess()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Stock>();
            if (db.Table<Stock>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Stock();
                newStock.Symbol = "AAPL";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Symbol = "GOOG";
                db.Insert(newStock);
                newStock = new Stock();
                newStock.Symbol = "MSFT";
                db.Insert(newStock);
            }


            var listView = new ListView();

            stackLayout.Children.Add(listView);
            //listView.ItemsSource = db.Table<Stock>();
            listView.ItemsSource = db.Table<Stock>();/*new string[]
            {
                "Gualter",
                "Dos",
                "Santos"
            };*/

            /*Console.WriteLine("Reading data");
            var table = db.Table<Stock>();
            foreach (var s in table)
            {
                Console.WriteLine(s.Id + " " + s.Symbol);
            }
        }*/


    }
}

