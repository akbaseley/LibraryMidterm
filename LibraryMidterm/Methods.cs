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

            while (String.IsNullOrEmpty(line))
            {
                string[] words = line.Split(',');
                Library.Add(new Book(words[0], words[1], DateTime.Parse(words[2]), words[3]));
                line = reader.ReadLine();
            }
            reader.Close();

            return Library;
        }
    }
}
