using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FizzBuzz
{
    /// <summary>
    /// Author: Kyle Rowe
    /// Date: 2020-08-14
    /// Purpose: Simple program to play FizzBuzz with dynamic beginning and ending points, as well as a dynamic number of multiples to check.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0; // The starting number for the game
            int max = 0; // The ending number for the game

            Dictionary<string, int> multiples = new Dictionary<string, int>(); // The collection of multiples and their corresponding exclamations
            /*
             * First input block: Prompt user for starting number
             */
            do
            {
                Console.Clear();
                Console.Write("Please enter a starting number: ");
                string input = Console.ReadLine();

                if (ValidateInteger(input))
                {
                    min = int.Parse(input);
                }
            }
            while (min == 0);

            /*
             * Second input block: Prompt user for ending number
             */
            do
            {
                Console.Clear();
                Console.Write("Please enter an ending number: ");
                string input = Console.ReadLine();

                if (ValidateInteger(input))
                {
                    int temp = int.Parse(input);
                    if (temp > min)
                    {
                        max = temp;
                    }
                }
            }
            while (max == 0);

            string repeat; // The variable determining if the third input block should repeat

            /*
             * Third input block: Contains fourth, fifth, and sixth input blocks
             */
            do
            {
                Console.Clear();

                string key = ""; // The exclamation of the multiple/exclamation pair
                int value = 0; // The multiple of the multiple/exclamation pair

                /*
                 * Fourth input block: Prompt the user for multiple
                 */
                do
                {
                    Console.Clear();
                    Console.Write("Please enter a multiple: ");
                    string input = Console.ReadLine();

                    if (ValidateInteger(input))
                    {
                        value = int.Parse(input);
                    }
                }
                while (value == 0);

                /*
                 * Fifth input block: Prompt the user for exclamation for prior multiple
                 */
                do
                {
                    Console.Clear();
                    Console.Write(string.Format("Please enter an exclamation for multiple '{0}': ", value));
                    string input = Console.ReadLine();

                    if (input != "")
                    {
                        key = input;
                    }
                }
                while (key == "");

                multiples.Add(key, value); // Add the multiple to the dictionary

                /*
                 * Sixth input block: Prompt the user if they would like to add another multiple
                 */
                do
                {
                    Console.Clear();
                    Console.Write("Would you like to add another multiple to the game? (Y/N): ");
                    repeat = Console.ReadLine().ToLower();
                }
                while (repeat != "y" && repeat != "n");


            }
            while (repeat == "y");

            Console.Clear();

            StringBuilder output = new StringBuilder(); // Output string

            for (int i = min; i <= max; i++)
            {
                output.Clear();

                foreach (KeyValuePair<string, int> kvp in multiples)
                {
                    // If index is divisible by the current multiple
                    if (i % kvp.Value == 0)
                    {
                        output.Append(kvp.Key); // Append the exclamation to the output builder
                    }
                }

                // If the index was not divisible by any of the multiples
                if (output.ToString() == "")
                {
                    output.Append(i); // Append the index itself to the output builder
                }

                Console.WriteLine(output.ToString()); // Output the string
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Validates a string input to see if it can be resolved to an integer
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>bool</returns>
        static private bool ValidateInteger(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
