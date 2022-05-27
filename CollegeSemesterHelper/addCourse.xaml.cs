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
    public partial class addCourse : ContentPage
    {
        public addCourse()
        {
            InitializeComponent();
        }

        private void addCourseSaveBTN_Clicked(object sender, EventArgs e)
        {
            Course course = new Course()
            {//tried adding an ID here to see if I can make unique courses with it because a course primary ID isnt working.
                course_Term_Sql_ID = MainPage.currentSelectTerm.sql_ID,
                courseName = addCourseNameEntry.Text,
                courseStart = courseStartDate.Date,
                courseEnd = courseEndDate.Date,
                courseStatus = courseStatusPicker.SelectedItem.ToString(),
                courseInstructorName = addCourseInstructorNameEntry.Text,
                courseInstructorPhone = addCourseInstructorPhoneEntry.Text,
                courseInstructorEmail = addCourseInstructorEmailEntry.Text,
                courseOptionalNotes = addCourseOptionalNotesEntry.Text
            };

            Navigation.PushAsync(new TermsView());

            DisplayAlert("Add Course Successful", "You have added a new course", "OK");

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                connection.CreateTable<Course>();
                int rowsAdded = connection.Insert(course);
            }
        }

        private void addCourseCancelBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsView());
        }
    }
}