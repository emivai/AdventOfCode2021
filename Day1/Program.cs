using System;
using System.IO;

namespace Day1
{
    //The input data is contained in a .txt file
    class Program
    {
        /// <summary>
        /// This is the first challenge of Day 1.
        /// The methods reads data from the file input.txt, 
        /// where each line has a number and determines how
        /// many of these numbers have a value bigger than the previous.
        /// The first one is an exception.
        /// </summary>
        /// <returns>Amount of numbers bigger than their previous</returns>
        public static int BiggerThanPreviousCount1()
        {
            int count = 0;
            int previous = 0;
            int current = 0;
            string[] lines = File.ReadAllLines(@"input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                current = int.Parse(lines[i]);
                if (i != 0 && current > previous)
                    count++;
                previous = int.Parse(lines[i]);
            }
            return count;
        }

        /// <summary>
        /// This is the second challenge of Day 1.
        /// The methods reads data from the file input.txt, 
        /// where each line has a number. This time
        /// each number is summed with two others than come after it.
        /// This sum of 3 is compared to the previous.
        /// The first one is an exception. If there are not enough
        /// numbers left to make a sum of 3, the method ends without considering those.
        /// </summary>
        /// <returns>Amount of sums of 3 than are bigger than the previous sum of 3</returns>
        public static int BiggerThanPreviousCount2()
        {
            int count = 0;
            int previous = 0;
            int current = 0;
            string[] lines = File.ReadAllLines(@"input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (i + 2 >= lines.Length)
                    return count;
                current = int.Parse(lines[i]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
                if (i != 0 && current > previous)
                    count++;
                previous = current;

            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(BiggerThanPreviousCount1());
            Console.WriteLine(BiggerThanPreviousCount2());
        }
    }
}
