using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace FormalLanguages_Task2
{
    class FileStream
    {
        public Automaton GetAutomaton(string fileName)
        {
            Automaton automaton = null;
            string content;
            using (StreamReader sr = new StreamReader(fileName))
            {
                content = sr.ReadToEnd();
                automaton = JsonConvert.DeserializeObject<Automaton>(content);
            }
            return automaton;
        }

        public Lexer GetAutomatons()
        {
            List<Automaton> automatons = new List<Automaton>();

            string[] types = new string[7] { "integer.txt", "float.txt", "id.txt", "bool.txt", "whitespaces.txt", "operations.txt", "keywords.txt" };
            Automaton automaton;
            for (int i = 0; i < types.Length; i++)
            {
                automaton = GetAutomaton(types[i]);
                automatons.Add(automaton);
            }

            return new Lexer(automatons);
        }
    }
}