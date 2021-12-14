using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
{
    class Program
    {

        public static Dictionary<string, string> getRules (string[] input)
        {
            Dictionary <string, string> rules = new Dictionary<string, string>();

            for (int i = 2; i < input.Length; i++)
            {
                string rule = input[i];
                rules.Add(rule.Substring(0, 2), rule[6].ToString());
            }

            return rules;
        }

        public static string AlterPolymer(string polymer, Dictionary<string, string> rules)
        {           
            for (int count = 0; count < 10; count++)
            {
                    for (int j = 0; j < polymer.Length - 1; j++)
                    {
                        string key = polymer[j].ToString() + polymer[j + 1].ToString();
                        if (rules.ContainsKey(key))
                        {
                            polymer = polymer.Insert(j + 1, rules[key]);
                            j++;
                        }
                    }
            }
            return polymer;
        }

        public static int findValue (string polymer)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (char c in polymer)
            {
                if (chars.ContainsKey(c)) chars[c]++;
                else chars.Add(c, 1);
            }

            int max = chars.Values.Max();
            int min = chars.Values.Min();
            return max - min;
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            string initialPolymer = input[0];
            Dictionary<string, string> rules = getRules(input);
            string newPolymer = AlterPolymer(initialPolymer, rules);
            Console.WriteLine(findValue(newPolymer));
        }
    }
}
