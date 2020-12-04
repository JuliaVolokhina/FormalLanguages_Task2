using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream();
            Lexer lexer = fs.GetAutomatons();
            string new_message = "";

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                new_message = sr.ReadToEnd();
            }

            int offset = 0;
            HashSet<KeyValuePair<string, string>> output = lexer.GetTokens(new_message, ref offset);
            foreach (var i in output)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}