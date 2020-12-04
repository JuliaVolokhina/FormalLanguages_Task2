using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task2
{
    class Lexer
    {
        List<Automaton> automatons;
        Dictionary<Automaton, string> tokens;

        public Lexer(List<Automaton> automatons)
        {
            this.automatons = automatons;
            tokens = new Dictionary<Automaton, string>();
            tokens.Add(automatons[0], "integer");
            tokens.Add(automatons[1], "float");
            tokens.Add(automatons[2], "id");
            tokens.Add(automatons[3], "bool");
            tokens.Add(automatons[4], "whitespaces");
            tokens.Add(automatons[5], "operations");
            tokens.Add(automatons[6], "keywords");
        }

        public HashSet<KeyValuePair<string, string>> GetTokens(string message, ref int offset)
        {
            HashSet<KeyValuePair<string, string>> result = new HashSet<KeyValuePair<string, string>>();
            Automaton automaton;
            string substring;
            int max;
            bool isIntValue;
            while (offset < message.Length)
            {
                automaton = null;
                substring = "";
                max = -1;
                isIntValue = false;
                foreach (var a in automatons)
                {
                    KeyValuePair<bool, int> new_message = a.GetValues(message, offset);
                    if (new_message.Key == true)
                    {
                        isIntValue = true;
                        if (new_message.Value == max)
                        {
                            if (a.order > automaton.order)
                            {
                                automaton = a;
                                substring = message.Substring(offset, new_message.Value);
                            }
                        }

                        if (new_message.Value > max)
                        {
                            max = new_message.Value;
                            automaton = a;
                            substring = message.Substring(offset, new_message.Value);
                        }
                    }
                }

                if (isIntValue)
                {
                    result.Add(new KeyValuePair<string, string>(substring, tokens[automaton]));
                    offset += max;
                }
                else
                {
                    offset++;
                }
            }

            return result;
        }
    }
}
