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
    public partial class CoursesView : ContentPage
    {
        public CoursesView()
        {
            InitializeComponent();
            coursesViewLabel.Text = TermsView.currentSelectCourse.courseName;
            courseStartLabel.Text = TermsView.currentSelectCourse.courseStart.ToString("MMM dd, yyyy");
            courseEndLabel.Text = TermsView.currentSelectCourse.courseEnd.ToString("MMM dd, yyyy");
        }

        private void deleteCourseBTN_Clicked(object sender, EventArgs e)
        {

        }

        private void editCourseBTN_Clicked(object sender, EventArgs e)
        {

        }

        private void editCourseBTN_Clicked_1(object sender, EventArgs e)
        {

        }

        private void assessmentListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void addAssessmentBTN_Clicked(object sender, EventArgs e)
        {

        }
    }
}