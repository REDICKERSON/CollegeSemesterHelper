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
    public partial class TermsView : ContentPage
    {
        public static Course currentSelectCourse;
        public TermsView()
        {
            InitializeComponent();
            termViewLabel.Text = MainPage.currentSelectTerm.termName;
            /*termNameLabel.Text = MainPage.currentSelectTerm.termName;*/
            termStartLabel.Text = MainPage.currentSelectTerm.termStart.ToString("MMMM dd, yyyy");
            termEndLabel.Text = MainPage.currentSelectTerm.termEnd.ToString("MMMM dd, yyyy");


        }
        /// <summary>
        /// This populates the current view's listview and updates its itemsource
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Course>();
                var course = connection.Table<Course>().ToList();

                courseListView.ItemsSource = course;
            }
        }

        private void addCourseBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addCourse());
        }

        private void editTermBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new editTerm());
        }
        private async void deleteTermBTN_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("DELETE THIS TERM?", "Are you sure you want to Delete?", "Delete", "Cancel");
            if (!answer) { return; }

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Term>();
                /*var terms = connection.Table<Term>().ToList();*/

                connection.Delete<Term>(MainPage.currentSelectTerm.sql_ID);

                /*termsListView.ItemsSource = terms;*/

                await Navigation.PushAsync(new MainPage());
            }

        }
        private void courseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            currentSelectCourse = e.SelectedItem as Course;            

            Navigation.PushAsync(new CoursesView());
        }
    }
}