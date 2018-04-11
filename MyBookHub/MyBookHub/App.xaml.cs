using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyBookHub.Data;
using MyBookHub.Model;
using MyBookHub.View;
using Xamarin.Forms;

namespace MyBookHub
{
    public partial class App : Application
    {
		Database database;

        public App()
        {
            InitializeComponent();

			// Database = new Database();

            //MainPage = new MyBookHub.MainPage();
			MainPage = new NavigationPage(new LoginPage());
        }

		public Database Database { 
			set
			{
				database = value; 
			}
			get {
				if (database == null)
				{
					database = new Database();
				}
				return database;
			} 
		}

		public User User { set; get; }
    }
}
