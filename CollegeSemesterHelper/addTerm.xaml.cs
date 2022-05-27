using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace C971_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addTerm : ContentPage
    {
        public addTerm()
        {
            InitializeComponent();
        }

        /*private void saveBTN_Clicked(object sender, EventArgs e)
        {

        }*/

        private void addTermSaveBTN_Clicked(object sender, EventArgs e)
        {
            Term term = new Term()
            {
                termName = addTermNameEntry.Text,
                termStart = termStartDate.Date,
                termEnd = termEndDate.Date
            };

            Navigation.PushAsync(new MainPage());

            DisplayAlert("Add Term Successful", "You have added a new term", "OK");

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Term>();
                int rowsAdded = connection.Insert(term);
            }
        }

        private void addTermCancelBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}