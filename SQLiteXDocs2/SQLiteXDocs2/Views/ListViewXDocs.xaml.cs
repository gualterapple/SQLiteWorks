using System;
using System.Collections.Generic;
using SQLiteXDocs2.Models;
using Xamarin.Forms;

namespace SQLiteXDocs2.Views
{
    public partial class ListViewXDocs : ContentPage
    {
        private HomePage dataAccess;
        Stock stock = new Stock();

        public ListViewXDocs()
        {
            this.stock.Id = 4;
            this.stock.Symbol = "GUA";
            this.dataAccess = new HomePage();
            this.BindingContext = this.dataAccess.Customers;
            //this.BindingContext = this.stock;
            InitializeComponent();
        }
    }
}
