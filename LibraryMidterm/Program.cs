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
                    Console.WriteLine($"{"Title",-50}, {"Author",-15}, {"Duedate",-12}, {"Status",-10}");

                    for (int i = 0; i < Library.Count; i++)
                    {
 
                        Console.WriteLine($"{Library[i].Title,50}, {Library[i].Author,15}, {Library[i].DueDate,12}, {Library[i].Stat,10}");
                    }
                }
                else if (UserTask == 2)
                {
                    SearchBy.AuthorSearch(Library);  
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
                    int number = Library.Count();
                    ////indexing number user puts in
                    int bookSelection = Validation.GetIndex("What book do you want to return?", number);
                    Console.WriteLine($"{bookSelection + 1,-50}{Library[bookSelection].Stat,-15}");
                    string response = Validation.UserContinue("Would you like to return a book?");
                    ////changes status
                    if(response == "y")
                    {
                        Library[bookSelection].Stat = (Status)1;
                    }
                    else
                    {
                        Library[bookSelection].Stat = (Status)0;
                    }

                    StreamWriter edit = new StreamWriter("../../BookList.txt");
                    edit.WriteLine(Library[bookSelection].Stat);
                    edit.Close();

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
