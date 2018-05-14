using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMidterm
{
    public class Book
    {
        private string title;
        private string author;
        private DateTime dueDate;
        private Status stat;

        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        public string Author
        {
            set { author = value; }
            get { return author; }
        }
        public DateTime DueDate
        {
            set { dueDate = value; }
            get { return dueDate; }
        }
        ////changed status to enum
        public Status Stat
        {
            set { stat = value; }
            get { return stat; }
        }

        public Book()
        {
            
            DueDate = new DateTime(01 / 01 / 2000);

        }
        public Book(string t, string a, DateTime d, Status s)
        {
            Title = t;
            Author = a;
            DueDate = d;
            Stat = s;
        }


    }
}
