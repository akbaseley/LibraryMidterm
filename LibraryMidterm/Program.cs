using System;
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

            bool KeepGoing = true;
            while (KeepGoing)
            {
                Console.WriteLine($"{"1.",5} {"List books"}\n{"2.",5} {"Search by Author"}\n" +
                    $"{"3.",5} {"Search by title keyword"} \n{"4.",5} {"Select book to check out"}\n" +
                    $"{"/5.",5} {"Return book"}");

                int UserTask = Validation.UserSelection("What would you like to do?", 1, 5);

                //methods are called under each of these selections
                if (UserTask == 1)
                {
                    //1. List Books - Tim & Anna
                    Console.WriteLine(String.Format($"{ "Title",-30}, {"Author",-20}, {"Duedate",-10}, {"Status",-12}"));

                    for (int i = 0; i < Library.Count; i++)
                    {
                        Console.WriteLine($"{Library[i].Title,-30}, {Library[i].Author,-20}, {Library[i].DueDate,-10}, {Library[i].Status,-12}");
                    }
                }
                else if (UserTask == 2)
                {
                    SearchBy.AuthorSearch(Library,"Enter an author name");  
                    //2. Search for author - Toni & Jason
                }
                else if (UserTask == 3)
                {
                    //3. Search by the title keyword - Toni & Jason
                }
                else if (UserTask == 4)
                {
                    //4. Select book to check out - ????
                    //a. Book is not available
                    //b. change status & set due-date
                }
                else if (UserTask == 5)
                {
                    //5. Return book  - ????
                    //change status

                }

                //Loop for continuing
                string Response = Validation.UserContinue("Would you like to keep browsing the Library? y/n");
                if (Response == "n")
                {
                    Console.WriteLine("Okay!  See you next time!");
                    KeepGoing = false;
                }
            }
        }
    }
}
