using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMidterm
{
    class Validation
    {
        public static int UserSelection(string message, int min, int max)
        {
            Console.WriteLine(message);
            int select = int.Parse(Console.ReadLine());

            while (select < min || select > max)
            {
                Console.WriteLine("I'm' sorry." + "Please enter the number.");
                select = int.Parse(Console.ReadLine());
            }
            return select;
        }

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
    }
}
