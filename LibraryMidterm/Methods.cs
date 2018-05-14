using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LibraryMidterm
{
    public class Methods
    {
        public static List<Book> ReadFile()
        {
            List<Book> Library = new List<Book>();

            StreamReader reader = new StreamReader("../../BookList.txt");
            string line = reader.ReadLine();


            while (line != null)
            {
                string[] words = line.Split(',');
                Library.Add(new Book(words[0], words[1], DateTime.Parse(words[2]), ((Status)Enum.Parse(typeof(Status), words[3]))));
                line = reader.ReadLine();
            }
            reader.Close();

            return Library;
        }
        public static void BookCheckOut(List<Book> Library, int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (Library[i].Stat == Status.OnShelf)
                {
                    Console.WriteLine($"{ i + 1 + ".       ",12}{ Library[i].Title,-28}");
                }
            }
            bool ChoooseABook = true;

            while (ChoooseABook)
            {
                //4. Select book to check out 
                int bookSelection = Validation.GetIndex("Which book would you like to check out?", number);

                //a. Book is not available
                if (Library[bookSelection].Stat == Status.CheckedOut)
                {
                    string BookUnavailable = Validation.UserContinue("I'm sorry.  That book is not available.  Would you like to choose another book? y/n");

                    if (BookUnavailable == "n")
                    {
                        Console.WriteLine("Okay!");
                        ChoooseABook = false;
                    }
                }
                else
                {
                    Library[bookSelection].Stat = (Status)0;
                    Library[bookSelection].DueDate = DateTime.Today.AddDays(14);
                    Console.WriteLine($"{Library[bookSelection].Title} is due {Library[bookSelection].DueDate}.");

                    string response = Validation.UserContinue("Would you like to check out another book? y/n");

                    if (response == "n")
                    {
                        Console.WriteLine("Okay!");
                        ChoooseABook = false;
                    }
                }
            }
        }

    }
 }
