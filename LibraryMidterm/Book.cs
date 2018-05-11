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
        private string status;

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
        public string Status
        {
            set { status = value; }
            get { return status; }
        }

        public Book()
        {
            Title = "";
            Author = "";
            Status = "";
            DueDate = new DateTime(01/01/2000);
        }
        public Book(string t, string a, DateTime d, string s)
        {
            Title = t;
            Author = a;
            DueDate = d;
            Status = s;
        }


    }
}
