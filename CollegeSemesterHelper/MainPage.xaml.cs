using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace C971_Tracker{
    
    public partial class MainPage : ContentPage
    {
        public static Term currentSelectTerm;
        public static object index;        
        public MainPage()
        {
            InitializeComponent();
           
        private void addTermBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addTerm());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Term>();
                var terms = connection.Table<Term>().ToList();

                termsListView.ItemsSource = terms;              
            }
        }
        
        private async void deleteTermBTN_Clicked(object sender, EventArgs e)
        {                                   
            bool answer = await DisplayAlert("DELETE TERM?", "Are you sure you want to Delete?", "Delete", "Cancel");
            if (!answer) { return; }

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Term>();
                /*var terms = connection.Table<Term>().ToList();*/

                connection.Delete<Term>(currentSelectTerm.sql_ID);

                /*termsListView.ItemsSource = terms;*/

                await Navigation.PushAsync(new MainPage());
            }

        }

        private void termsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            currentSelectTerm = e.SelectedItem as Term;
            index = (termsListView.ItemsSource as List<Term>).IndexOf(e.SelectedItem as Term);

            Navigation.PushAsync(new TermsView());
        }
    }
}
