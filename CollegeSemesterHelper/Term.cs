using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace C971_Tracker
{
    public class Term
    {
        //this will be the sqlLite ID
        [PrimaryKey, AutoIncrement] public int sql_ID { get; set; }
        [NotNull] public string termName { get; set; }
        public DateTime termStart { get; set; }
        public DateTime termEnd { get; set; }
        public Term()
        {

        }

    }
}
