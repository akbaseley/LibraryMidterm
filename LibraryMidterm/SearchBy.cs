using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMidterm
{
    class SearchBy
    {
        public static void AuthorSearch(List<Book> Library, string prompt)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine(prompt);

                string LibraryAuthor = Console.ReadLine().ToLower();
                if (!String.IsNullOrEmpty(LibraryAuthor))
                {
                    List<Book> LibraryResult = Library.Where(s => s.Author.ToLower().Contains(LibraryAuthor)).ToList();
                    int number = LibraryResult.Count;

                    if (LibraryResult.Count > 0)
                        foreach (Book s in LibraryResult)
                        {
                            Console.WriteLine(s.Title);
                        }
                    else if (LibraryResult.Count == 0)
                        Console.WriteLine("No Author by that name found");
                    for (int i = 0; i < LibraryResult.Count; i++)
                    {
                        if (LibraryResult[i].Stat == Status.OnShelf)
                        {
                            Console.WriteLine($"{ i + 1 + ".       ",12}{ LibraryResult[i].Title,-28}");
                        }
                    }
                    string response = Validation.UserContinue("Would you like to check out a book? y/n");
                    if (response == "n")
                    {
                        
                        repeat = false;
                    }
                    else if (response == "y")
                    {
                        Methods.BookCheckOut(Library, number);
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
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine(prompt);

                string LibraryAuthor = Console.ReadLine().ToLower();
                if (!String.IsNullOrEmpty(LibraryAuthor))
                {
                    List<Book> LibraryResult = Library.Where(s => s.Title.ToLower().Contains(LibraryAuthor)).ToList();
                    int number = LibraryResult.Count;

                    if (LibraryResult.Count > 0)
                        foreach (Book s in LibraryResult)
                        {
                            Console.WriteLine(s.Title);
                        }
                    else if (LibraryResult.Count == 0)
                        Console.WriteLine("No Author by that name found");
                    for (int i = 0; i < LibraryResult.Count; i++)
                    {
                            if (LibraryResult[i].Stat == Status.OnShelf)
                        {
                            Console.WriteLine($"{ i + 1 + ".       ",12}{ LibraryResult[i].Title,-28}");
                        }
                    }
                    int Usertask = 0;
                    string response = Validation.UserContinue("Would you like to check out a book? y/n");
                    if (response == "n")
                    {
                    repeat = false;
                    }
                    else if (response == "y")
                    {
                        Methods.BookCheckOut(Library, number);
                    }
                    break;
                }

                else
                {
                    Console.WriteLine("You must enter Title or Keyword to search for a Title");
                }
            }
        }
    }
}
