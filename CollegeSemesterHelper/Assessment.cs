using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C971_Tracker
{
    internal class Assessment
    {
        //this will be the sqlLite ID
        public int assessment_Sql_ID = MainPage.currentSelectTerm.sql_ID; /*{ get; set; }*/
        [NotNull] public string assessmentName { get; set; }
        public DateTime assessmentStart { get; set; }
        public DateTime assessmentEnd { get; set; }
        [NotNull] public string assessmentType { get; set; }
        public Assessment()
        {

        }
    }
}
