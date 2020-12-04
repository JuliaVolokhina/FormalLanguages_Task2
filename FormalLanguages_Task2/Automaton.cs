using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormalLanguages_Task2
{
    class Automaton
    {
        private Dictionary<KeyValuePair<int, string>, int> transitions;
        public int currentState { get; set; }
        public int start { get; set; }
        public HashSet<int> stop { get; set; }
        public int order { get; set; }

        public Automaton()
        {
            this.transitions = new Dictionary<KeyValuePair<int, string>, int>();
            this.start = 1;
        }
        public Automaton(Dictionary<KeyValuePair<int, string>, int> transitions, int start, HashSet<int> stop)
        {
            this.transitions = transitions;
            this.start = start;
            this.stop = stop;
        }

        public KeyValuePair<KeyValuePair<int, string>, int>[] Transitions
        {
            get
            {
                return this.transitions.ToArray();
            }
            set
            {
                this.transitions = value.ToDictionary(x => x.Key, y => y.Value);
            }
        }

        public KeyValuePair<bool, int> GetValues(string message, int offset)
        {
            currentState = start;
            bool isIntValue = false;
            int symbols = 0;
            int index = offset;
            while (index < message.Length)
            {
                string substring = message[index].ToString();
                if (transitions.ContainsKey(new KeyValuePair<int, string>(currentState, substring)))
                {
                    isIntValue = true;
                    symbols++;
                    currentState = transitions[new KeyValuePair<int, string>(currentState, substring)];
                    index++;
                }
                else
                {
                    break;
                }
            }
            if (!stop.Contains(currentState))
            {
                isIntValue = false;
                symbols = 0;
            }

            return new KeyValuePair<bool, int>(isIntValue, symbols);
        }
    }
}
