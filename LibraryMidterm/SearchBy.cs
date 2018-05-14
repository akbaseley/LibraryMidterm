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
        public static void AuthorSearch(List<Book> Library,string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);

                string LibraryAuthor = Console.ReadLine().ToLower();
                if (!String.IsNullOrEmpty(LibraryAuthor))
                {
                    List<Book> LibraryResult = Library.Where(s => s.Author.ToLower().Contains(LibraryAuthor)).ToList();
                    if (Library.Count > 0)
                        foreach (Book s in LibraryResult)
                        {
                            Console.WriteLine(s.Title);
                            
                        }
                    else if(LibraryResult.Count == 0)
                        Console.WriteLine("No Author by that name found");
                    break;
                    {

                    }
                }
                else
                {
                    Console.WriteLine("You must enter an Author to search for a Title");
                }
            }
        }
        public static void TitleSearch(List<Book> Library, string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);

                string LibraryAuthor = Console.ReadLine().ToLower();
                if (!String.IsNullOrEmpty(LibraryAuthor))
                {
                    List<Book> LibraryResult = Library.Where(s => s.Title.ToLower().Contains(LibraryAuthor)).ToList();
                    if (LibraryResult.Count > 0)
                        foreach (Book s in LibraryResult)
                        {
                            Console.WriteLine(s.Title);
                            
                        }
                    else if (LibraryResult.Count == 0)
                        Console.WriteLine("No Author by that name found");
                    break;
                    {

                    }
                }
                else
                {
                    Console.WriteLine("You must enter an Author to search for a Title");
                }
            }
        }

    }
}
