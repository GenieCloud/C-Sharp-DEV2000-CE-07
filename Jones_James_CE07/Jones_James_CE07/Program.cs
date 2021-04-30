using System;

namespace Jones_James_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * James M. Jones
             * 04/23/2021
             * DEV2000-O 02: Introduction to Development II
             * 3.2 Code Exercise 07: Methods
             */

            //Problem #1: Currency Converter

            //First, greet the user and explain the program.
            Console.WriteLine("Hello, today we will convert euros to dollars.\r\nHow many euros do you have?");

            //Prompt the user for input - this MUST be a decimal since we are working with money.
            string eurosString = Console.ReadLine();

            //Convert the input to a decimal.
            decimal euros;

            //I also need to create a variable for the American dollar's value compared to a single euro.
            decimal usdDollar = 1.16m;

            //Validate the user's input using a while loop.
            while (!decimal.TryParse(eurosString, out euros) || euros < 0)
            {
                //Tell the user the error.
                Console.WriteLine("Please only input positive decimal values.\r\nHow many euros do you have?");

                //Re-prompt and listen for the user's input.
                eurosString = Console.ReadLine();
            }
            //Create a function to convert the euros to American dollars.

            //Function call and save the return value in a new variable.
            decimal conversion = ConvertEuros(euros, usdDollar);

            //Report to the user the final output.
            Console.WriteLine("\r\n{0} euros converted to dollars is {1}", euros, conversion.ToString("c"));

            /*
            * Test Values for Currency Converter:
            * euros = 5.50 (Should calculate out to $6.38 American dollars)
            * euros = -15.32 (Re-prompt, you cannot have a negative amount of money.
            * euros = 15.32 (Should calculate out to $17.77 American dollars)
            * 
            */

            //Problem #2: Astronomical

            //First, I want to create an array variable to store the % of weight as compared to Earth's.
            //I want to put these in order with the another string array that will hold the planet names.
            //We will use the to allow the user to make a choice to determine their weight on another planet.
            int[] planetWeightPercentages = {38, 91, 100, 38, 234, 93, 92, 112};

            //String array for storing the planet names and getting them when the user makes a selection from a list.
            string[] planetNames = {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};

            //Prompt the user for their weight. 
            Console.WriteLine("\r\nHello, today we will calculate your weight on a planet of your choice.\r\nHow much do you weigh?");

            //We also need a variable to hold the user's weight.
            string userWeightString = Console.ReadLine();

            //Convert the user's input to double datatype. Since this can return a whole number or decimal in the final output.
            double userWeight;

            //Validate the user's input using a while loop.
            while (!double.TryParse(userWeightString, out userWeight) || userWeight < 0)
            {
                //Tell the user error and restate the question.
                Console.WriteLine("Please only enter postive whole number or decimal values.\r\nHow much do you weigh?");

                //Re-prompt and listen for the user's input again.
                userWeightString = Console.ReadLine();
            }

            //Prompt the user for which planet they would like to see their weight on.
            Console.WriteLine("\r\nWhich planet would you like to see your weight on?");

            //I can use an if statement and for loop to display the list of planets and numbers available for the user to select from the menu.
            if (planetWeightPercentages.Length == planetNames.Length)
            {   //Loop through each planet index number and planet name to display a list of planets to choose from.
                for (int i = 0; i < planetWeightPercentages.Length; i++)
                {   //Output the planet number and the planet to the console.
                    Console.WriteLine("\r\nYou can choose {0} for {1}.", i + 1, planetNames[i]);
                }
            }

            //Listen for the user's response for the number of the planet they want to choose.
            string planetSelectionString = Console.ReadLine();

            //Convert to the whole number
            int planetSelection;

            //Validate the user's input using a while loop nested in an if statement.
            //The if statement only allows the users to chose a number between 1 and 8.
            while (!int.TryParse(planetSelectionString, out planetSelection) || planetSelection < 1 || planetSelection > 8)
            {
                //Tell the user the error and re-state the question.
                Console.WriteLine("Please only enter a number between 1 and 8.\r\nWhich planet would you like to see your weight on ? ");

                //Re-prompt the user and listen for the input again.
                planetSelectionString = Console.ReadLine();
            }
            //We need to grab the planet weight percentages from our array.
            //Remember array indexes are numbered one less than the total number of elements in the array.
            int weightPercentage = planetWeightPercentages[planetSelection - 1];

            //We can also grab the planet names from our array of planet names with a new variable.
            //Again, array indexes are numbered one less than the total number of elements in the array.
            string planet = planetNames[planetSelection - 1];

            //Now we can create a function to calculate the user's weight on the other planet.

            //Function call CalcWeight and save the value to a new variable to be used in the main method.
            //I prefer to stick with the same variableName that is used in the function.
            double weightOnOtherPlanet = CalcWeight(userWeight, weightPercentage);

            //Now we are ready to output the final results to the console.
            Console.WriteLine("\r\nOn Earth, you weight {0} lbs, but on {1}, you would weigh {2} lbs.", userWeight, planet, Math.Round(weightOnOtherPlanet, 2, MidpointRounding.ToEven));
        }

        //this function is called in the Main Method for the Astronomical program.
        public static double CalcWeight(double weight, double weightPercentage)
        {
            //Create a variable and do the math.
            double weightOnOtherPlanet = weight / 100 * weightPercentage;

            //Return the weight on the other planet's value
            return weightOnOtherPlanet;
        }

        //This function is called in in the Main method for the Currency Converter program. 
        public static decimal ConvertEuros(decimal eu, decimal usd)
        {
            //create a variable for the conversion and do the math.
            decimal conversion = eu * usd;

            //return the conversion value
            return conversion;
        }
        /*
         * Test Values for Astronomical program:
         * Astronaut's Weight = -160 Re-prompt, you can weight a negative amount.
         * Astronaut's Weight = 160 Planet Choice = 6
         * Results = "On Earth, you weigh 160 lbs, but on Saturn, you would weigh 148.8 lbs."
         * Astronaut's Weight = 210 Planet Choice - 9 Re-prompt because not a valid choice in our list.
         * New Choice = 5
         * Results = "On Earth, you weigh 210 lbs, but on Jupiter, you would weigh 491.4 lbs."
         */
    }
}
