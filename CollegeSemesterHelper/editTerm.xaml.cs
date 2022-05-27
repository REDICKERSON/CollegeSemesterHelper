using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Tracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editTerm : ContentPage
    {
        public editTerm()
        {
            InitializeComponent();
            editTermNameEntry.Text = MainPage.currentSelectTerm.termName;
            editTermStartDate.Date = MainPage.currentSelectTerm.termStart;
            editTermEndDate.Date = MainPage.currentSelectTerm.termEnd;
        }

        private void editTermSaveBTN_Clicked(object sender, EventArgs e)
        {
            Term editTerm = new Term()
            {
                sql_ID = MainPage.currentSelectTerm.sql_ID,
                termName = editTermNameEntry.Text,
                termStart = editTermStartDate.Date,
                termEnd = editTermEndDate.Date
            };

            if (MainPage.currentSelectTerm.sql_ID != 0)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
                {
                    connection.CreateTable<Term>();

                    connection.InsertOrReplace(editTerm);

                    MainPage.currentSelectTerm.termName = editTerm.termName;
                    MainPage.currentSelectTerm.termStart = editTermStartDate.Date;
                    MainPage.currentSelectTerm.termEnd = editTermEndDate.Date;

                    Navigation.PushAsync(new TermsView());

                    DisplayAlert("Edit Term Successful", "You have edited the term", "OK");
                }
            }
        }

        private void editTermCancelBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsView());
        }
    }
}