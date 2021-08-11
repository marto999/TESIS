using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                postListView.ItemsSource = posts;
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {


            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Post>();
                int rowsAffected = conn.Delete(tappeddata.Id);

                if (rowsAffected > 0)
                    DisplayAlert("Success", "Post saved", "Ok");
                else
                    DisplayAlert("Failure", "Post was not saved, please try again", "Ok");
            }
        }

    }
}
