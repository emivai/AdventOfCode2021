using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    //The input data is contained in a .txt file
    class Program
    {
        /// <summary>
        /// The method determines which bit (0 or 1)
        /// is most common and least common in each position
        /// of the binary number and keeps this data in a
        /// frequency array, where the first half is the frequencies
        /// of 0 and second half are frequencies of 1.
        /// </summary>
        /// <returns>Array of bit frequencies</returns>
        private static int[] calculateFrequencies1()
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            int[] frequencies = new int[lines[0].Length * 2];
            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for(int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '0')
                        frequencies[j] += 1;
                    else
                        frequencies[j + line.Length] += 1;
                }
            }
            return frequencies;
        }

        /// <summary>
        /// This is the first challenge of day 3.
        /// This method takes an array of bit frequencies made
        /// by the method calculateFrequencies() and forms two values:
        /// gamma rate consists of the most frequent bits of each position;
        /// epsilon rate consists of the least frequent bits of each position;
        /// then these values are multipled to calculate power consumption.
        /// </summary>
        /// <returns>Value of power consumption</returns>
        public static int calculatePowerConsumption()
        {
            int powerConsumption = 0;
            int[] frequencies = calculateFrequencies1();
            string gammaRate = "";
            string epsilonRate = "";
            for (int i = 0; i < (frequencies.Length/2); i++)
            {
                if (frequencies[i] > frequencies[i + (frequencies.Length / 2)])
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                else
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
            }
            powerConsumption = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
            return powerConsumption;
        }

        /// <summary>
        /// The method determines which bit (0 or 1)
        /// is most common and least common in the specified position
        /// of the binary number and keeps this data in a
        /// frequency array, where the first member is the frequency of 0
        /// and the second member is the frequency of 1.
        /// </summary>
        /// <returns>Array of bit frequencies</returns>
        private static int[] calculateFrequencies2(List<string> numbers, int position)
        {
            int[] frequencies = new int[2];
            for (int i = 0; i < numbers.Count; i++)
            {
                string line = numbers[i];

                if (line[position] == '0')
                    frequencies[0] += 1;
                else
                    frequencies[1] += 1;
            }
            return frequencies;
        }

        /// <summary>
        /// This method finds the Oxygen Level Rating binary value
        /// by filtering all of the values. It takes only
        /// the values which have the binary digit with
        /// more frequency at the given position. If frequencies are
        /// equal then 1 is considered as the filtering criterion.
        /// The search continues by going one position forward at 
        /// a time until only one value remains.
        /// </summary>
        /// <param name="currentPosition">Current position to use for filtering</param>
        /// <param name="numbers">All of the numbers to be filtered</param>
        /// <param name="answer">The last value left which is the Oxygen Level Rating</param>
        private static void findOxygenRating(int currentPosition, List<string> numbers, ref string answer)
        {
            List<string> newNumbers = new List<string>();
            int[] frequencies = calculateFrequencies2(numbers, currentPosition);
            for (int i = 0 ; i < numbers.Count; i++)
            {
                string number = numbers[i];
                if (frequencies[0] > frequencies[1])
                {
                    if (number[currentPosition] == '0')
                        newNumbers.Add(number);
                }
                else
                {
                    if (number[currentPosition] == '1')
                        newNumbers.Add(number);
                }
            }
            if (newNumbers.Count == 1)
            {
                answer = newNumbers[0];
                return;
            }
            findOxygenRating(currentPosition+1, newNumbers, ref answer);
        }

        /// <summary>
        /// This method finds the CO2 Scrubber Rating binary value
        /// by filtering all of the values. It takes only
        /// the values which have the binary digit with
        /// less frequency at the given position. If frequencies are
        /// equal then 0 is considered as the filtering criterion.
        /// The search continues by going one position forward at a
        /// time until only one value remains.
        /// </summary>
        /// <param name="currentPosition">Current position to use for filtering</param>
        /// <param name="numbers">All of the numbers to be filtered</param>
        /// <param name="answer">The last value left which is the CO2 Scrubber Rating</param>
        private static void findCO2ScrubberRating(int currentPosition, List<string> numbers, ref string answer)
        {
            List<string> newNumbers = new List<string>();
            int[] frequencies = calculateFrequencies2(numbers, currentPosition);
            for (int i = 0; i < numbers.Count; i++)
            {
                string number = numbers[i];
                if (frequencies[0] > frequencies[1])
                {
                    if (number[currentPosition] == '1')
                        newNumbers.Add(number);
                }
                else
                {
                    if (number[currentPosition] == '0')
                        newNumbers.Add(number);
                }
            }
            if (newNumbers.Count == 1)
            {
                answer = newNumbers[0];
                return;
            }
            findCO2ScrubberRating(currentPosition + 1, newNumbers, ref answer);
        }

        /// <summary>
        /// This is the second challenge of day 3.
        /// This method calculates the value of the Life Support Rating
        /// by multiplying Oxygen Level Rating and CO2 Scrubber Rating.
        /// </summary>
        /// <returns>Value of Life Support Rating</returns>
        public static int calculateLifeSupportRating()
        {
            string oxygen = "";
            string CO2 = "";
            List<string> numbers = new List<string>(File.ReadAllLines(@"input.txt"));
            findOxygenRating(0,numbers, ref oxygen);
            findCO2ScrubberRating(0, numbers, ref CO2);
            int lifeSupportRating = Convert.ToInt32(oxygen, 2) * Convert.ToInt32(CO2, 2);
            return lifeSupportRating;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(calculatePowerConsumption());
            Console.WriteLine(calculateLifeSupportRating());
        }
    }
}
