using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
{
    //https://adventofcode.com/2021/day/14
    //The input data is contained in a .txt file
    class Program
    {
        /// <summary>
        /// This method creates a dictionary where the key of each pair
        /// is a two character combination and the value is the character
        /// to be inserted when that combination is found.
        /// </summary>
        /// <param name="input">All lines from the input file</param>
        /// <returns>Dictionary containing polymerization rules</returns>
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

        /// <summary>
        /// This method iterates through characters of the polymer
        /// and if any two neighboring characters exist as a key in
        /// the dictionary of rules, that rule is applied (value is inserted
        /// between the two characters). Newly inserted values are not considered
        /// in the same repetition. 
        /// </summary>
        /// <param name="polymer">line of characters</param>
        /// <param name="rules">dictionary of rules that determine when to insert new characters</param>
        /// <param name="repetitions">amount of times the process should be done</param>
        /// <returns>polymer value altered according to rules</returns>
        public static string AlterPolymer(string polymer, Dictionary<string, string> rules, int repetitions)
        {           
            for (int count = 0; count < repetitions; count++)
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

        /// <summary>
        /// Calculates difference between amount of most common and
        /// least common character in polymer.
        /// </summary>
        /// <param name="polymer">line of characters</param>
        /// <returns>amount difference between most common and least common values</returns>
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
            string newPolymer = AlterPolymer(initialPolymer, rules, 10);
            Console.WriteLine(findValue(newPolymer));
        }
    }
}
