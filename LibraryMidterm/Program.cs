﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LibraryMidterm
{
    //Tim
    class Program
    {
        static void Main(string[] args)
        {
            //Text file to list

            List<Book> Library = Methods.ReadFile();
            int number = Library.Count();

            bool KeepGoing = true;
            while (KeepGoing)
            {
                Console.WriteLine($"{"1.",5} {"List books"}\n{"2.",5} {"Search by Author"}\n" +
                    $"{"3.",5} {"Search by title keyword"} \n{"4.",5} {"Select book to check out"}\n" +
                    $"{"5.",5} {"Return book"}\n{"6.",5} {"Add Book"}");


                Console.ForegroundColor = ConsoleColor.Green;

                int UserTask = Validation.GetIndex("What would you like to do? (Please Select Option 1-6)", 6) + 1;

                Console.ForegroundColor = ConsoleColor.White;

                //methods are called under each of these selections
                if (UserTask == 1)
                {
                    //1. List Books - Tim & Anna
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{"Book No.",-12}{"Title",-28}{"Author",-28}{"Duedate",-15}{"Status",-10}");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine($"{i + 1 + ".       ",12}{Library[i].Title,-28}{Library[i].Author,-28}{Library[i].DueDate.ToShortDateString(),-15}{Library[i].Stat,-10}");
                    }

                }
                else if (UserTask == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    SearchBy.AuthorSearch(Library, "\tPlease Enter an Authors Name");
                    Console.ForegroundColor = ConsoleColor.White;
                    //2. Search for author - Toni & Jason
                }
                else if (UserTask == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    SearchBy.TitleSearch(Library, "\tPlease Enter a Book Title or Title Key Word");
                    Console.ForegroundColor = ConsoleColor.White;
                    //3. Search by the title keyword - Toni & Jason
                }
                else if (UserTask == 4)
                {
                    Methods.BookCheckOut(Library, number);
                }

                else if (UserTask == 5)
                {
                    ////indexing number user puts in
                    for (int i = 0; i < number; i++)
                    {
                        if (Library[i].Stat == Status.CheckedOut)
                        {
                            Console.WriteLine($"{ i + 1 + ".       ",12}{ Library[i].Title,-28}");
                        }
                    }
                    bool returnABook = true;
                    while (returnABook)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        int bookSelection = Validation.GetIndex("\tWhich book do you want to return?", number);
                        
                        if (Library[bookSelection].Stat == Status.OnShelf)
                        {
                            string BookUnavailable = Validation.UserContinue("I'm sorry.  That book is already checked in.  Would you like to choose another book? y/n");
                            if (BookUnavailable == "n")
                            {
                                Console.WriteLine("\n\tOk");
                                returnABook = false;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{bookSelection + 1 + ".       ",12}{Library[bookSelection].Title,-28}");
                            string returnResponse = Validation.UserContinue("\tWould you like to return this book? y/n");
                            ////changes status
                            if (returnResponse == "y")
                            {
                                Library[bookSelection].Stat = (Status)1;
                            }
                            string response = Validation.UserContinue("\tWould You Like to Return Another Book? y/n");

                            if (response == "n")
                            {
                                Console.WriteLine("\n\tOkay!");
                                returnABook = false;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }
                }
                else if (UserTask == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Library.Add(new Book(Validation.ValidateNewBook("\tPlease Enter the Book Title: "), Validation.ValidateNewBook("Enter the Book Author: "), DateTime.Today, Status.OnShelf));
                    Console.ForegroundColor = ConsoleColor.White;
                }

                //Loop for continuing
                Console.ForegroundColor = ConsoleColor.Green;
                string Response = Validation.UserContinue("\n\tWould you like to keep browsing the Library? y/n");
                Console.ForegroundColor = ConsoleColor.White;
                if (Response == "n")
                {
                    Console.WriteLine("\n\tOkay!  See you next time!");
                    KeepGoing = false;
                    StreamWriter edit = new StreamWriter("../../BookList.txt", false);
                    
                    foreach (Book elements in Library)
                    {
                        edit.WriteLine($"{elements.Title},{elements.Author},{elements.DueDate.Date.ToString("d")},{elements.Stat}");
                    }

                    edit.Close();
                }
            }
        }
    }
}
