using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMidterm
{

    class Validation
    {
        

        public static string UserContinue(string message)
        {
            Console.WriteLine(message);
            string Response = Console.ReadLine().ToLower();

            while (Response != "n" && Response != "y")
            {
                Console.WriteLine("What was that?" + message);
                Response = Console.ReadLine().ToLower();
            }
            return Response;
        }
        public static int GetIndex(string message, int number)
        {
            Console.WriteLine(message);
            int bookReturn = int.Parse(Console.ReadLine());

            while (bookReturn < 1 || bookReturn > number)
            {
                Console.WriteLine("Invalid Input, " + message);
            }
            return bookReturn - 1;
        }
        public static string ValidateNewBook(string message)
        {
            Console.Write(message);
            string newBook = Console.ReadLine();
            return newBook;
        }
    }
}
