using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMidterm
{
    class SearchBy
    {
        private string input;
        public static void AuthorSearch(List<Book> Library)
        {
            while (true)
            {
                Console.WriteLine("Enter the author's name:");

                string LibraryAuthor = Console.ReadLine();
                if (!String.IsNullOrEmpty(LibraryAuthor))
                {
                    Library = Library.Where(s => s.Author.Contains(LibraryAuthor)).ToList();

                    foreach (Book s in Library)
                    {
                        Console.WriteLine(s.Title);
                    }
                    break;

                }
                else
                {
                    Console.WriteLine("You must enter an Author to search for a Title");
                }
            }
        }
    }
}
