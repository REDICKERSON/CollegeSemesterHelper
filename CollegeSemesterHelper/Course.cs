using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C971_Tracker
{
    public class Course
    {
        //this will be the sqlLite ID
        public int course_Term_Sql_ID = MainPage.currentSelectTerm.sql_ID; /*{ get; set; }*/
        [NotNull] public string courseName { get; set; }
        public DateTime courseStart { get; set; }
        public DateTime courseEnd { get; set; }
        [NotNull] public string courseStatus { get; set; }
        [NotNull] public string courseInstructorName { get; set; }
        [NotNull] public string courseInstructorPhone { get; set; }
        [NotNull] public string courseInstructorEmail { get; set; }
        public string courseOptionalNotes { get; set; }

        public Course()
        {

        }
    }
}
