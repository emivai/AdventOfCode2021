using System;
using System.IO;

namespace Day2
{
    //The input data is contained in a .txt file
    class Program
    {
        /// <summary>
        /// This is the first challenge of day 2.
        /// The method gets its input from a file called input.txt.
        /// Every line contains a command and an integer value:
        /// The command "up" means that the submarine's depth decreases (submarine goes upwards);
        /// The command "down" means that the submarine's depth increases (submarine goes downwards);
        /// The command "forward" means that the submarine's horizontal position increases;
        /// The integer value tells by how much the submarine moves in the specified direction.
        /// </summary>
        /// <returns>Value of depth multipled by horizontal position</returns>
        public static int getMultipliedPosition1()
        {
            int depth = 0;
            int horizontalPos = 0;
            string[] lines = File.ReadAllLines(@"input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(' ');
                switch (items[0])
                {
                    case "up":
                        depth -= int.Parse(items[1]);
                        break;
                    case "down":
                        depth += int.Parse(items[1]);
                        break;
                    case "forward":
                        horizontalPos += int.Parse(items[1]);
                        break;
                }
            }
            return depth * horizontalPos;
        }

        /// <summary>
        /// This is the first challenge of day 2.
        /// The method gets its input from a file called input.txt.
        /// Every line contains a command and an integer value:
        /// The command "up" means that the submarine's aim decreases (submarine goes upwards);
        /// The command "down" means that the submarine's aim increases (submarine goes downwards);
        /// The command "forward" means that the submarine's horizontal position increases and
        /// if aim is more than zero, depth increases by aim multiplied by horizontal position;
        /// The integer value tells by how much the submarine moves in the specified direction.
        /// </summary>
        /// <returns>Value of depth multipled by horizontal position</returns>
        public static int getMultipliedPosition2()
        {
            int depth = 0;
            int horizontalPos = 0;
            int aim = 0;
            string[] lines = File.ReadAllLines(@"input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split(' ');
                switch (items[0])
                {
                    case "up":
                        aim -= int.Parse(items[1]);
                        break;
                    case "down":
                        aim += int.Parse(items[1]);
                        break;
                    case "forward":
                        horizontalPos += int.Parse(items[1]);
                        if (aim != 0)
                            depth += (int.Parse(items[1]) * aim);
                        break;
                }
            }
            return depth * horizontalPos;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(getMultipliedPosition1());
            Console.WriteLine(getMultipliedPosition2());
        }
    }
}
