using System;
using System.Collections.Generic;
using System.Text;

namespace NamuDarbaiNr1CS
{
    class HelpMethods
    {
        //user input is requested and saved
        public static string AskForAndReadInput()
        {
            Console.WriteLine("Input number up to 9 digits");
            return Console.ReadLine();
        }
        //input is checked for any symbols that are not numbers or '-'
        public static bool CheckIsInputNumber(string input)
        {
            //list of symbols that input is checked against. 
            List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-' };
            for (int i = 0; i < input.Length; i++)
            {
                char symbolCheck = input[i];
                //if every char of input is number or '-' 
                if (!numbers.Contains(symbolCheck))
                {
                    return false;
                }
                //if '-' is present, and its not in the front return false
                if (symbolCheck == '-' && i != 0)
                {
                    return false;
                }
            }
            return true;
        }
        //input is checked if its in desired range
        public static bool CheckIsInputInRange(int number)
        {
            return number > -999999999 && number < 999999999;
        }
        //this is the main function, initialised after checks
        public static void PrintAnyNumberUptoBillionInWords(int input)
        {
            string[] thousands = { "hundred", "thousand", "million" };
            string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] twenties = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            //empty return string created
            string word = "";
            //if input is zero --> no further checks
            if (input == 0)
            {
                word += twenties[input];
            }
            /*if input is negative, "negative" is added to return string, 
            and its converted to positive for further processing*/
            if (input < 0)
            {
                word += "negative ";
                input *= -1;
            }
            /*input is divided in three separate sections xxx xxx xxx and processed 
            with ReturnStringThreeDigitNum. This allows future expansion (array in
            ReturnArrayStringsHundredtoMillion should be appended with needed strings
            in case of expansion)*/
            if (input / 1000000 != 0)
            {
                int firstThreeSymbols = input / 1000000;
                word += ReturnStringThreeDigitNum(twenties, tens, thousands, firstThreeSymbols) + " " + thousands[2] + " ";
            }
            if (input % 1000000 / 1000 != 0)
            {
                int secondThreeSymbols = input % 1000000 / 1000;
                word += ReturnStringThreeDigitNum(twenties, tens, thousands, secondThreeSymbols) + " " + thousands[1] + " ";
            }
            if (input % 1000 != 0)
            {
                int thirdThreeSymbols = input % 1000;
                word += ReturnStringThreeDigitNum(twenties, tens, thousands, thirdThreeSymbols);
            }
            //assembled string is returned
            Console.WriteLine($"\nYou have entered \n{word}");

        }
        //this function converts a 3 digit number to words
        public static string ReturnStringThreeDigitNum(string[] twenties, string[] tens, string[] thousands, int input)
        {
            //initial return string - empty
            string word = "";
            //checking if the first symbol is not zero
            if (input / 100 != 0)
            {
                int hundred = input / 100;
                word += twenties[hundred] + " " + thousands[0];
            }
            //checking if second two numbers fall in 'teens' or not and converted accordingly
            if ((input % 100) / 10 != 0 && (input % 100) > 19)
            {
                int deca = (input % 100) / 10;
                word += " " + tens[deca - 2];
            }
            else if ((input % 100) / 10 != 0 && (input % 100) <= 19)
            {
                int deca = input % 100;
                word += " " + twenties[deca];
                return word;
            }
            //checking if last number is not zero and converting it
            if (input % 10 != 0)
            {
                int singles = input % 10;
                word += " " + twenties[singles];
            }
            //assembled string of 3digits converted to words is returned
            return word;
        }

        #region FunctionsUsedPreviousSolutions
        /*
        public static void PrintNumberConvertedToText(string[] words, int number)
        {
            if (number < 0 && number > -999999999)
            {
                number *= -1;
                Console.WriteLine($"Your number is negative {words[number]}");
            }
            else if (number >= 0 && number < 999999999)
            {
                Console.WriteLine($"Your number is {words[number]}");
            }
        }
        public static void PrintNumberConvertedToTextNegNineteenToNineteen(string[] intStrings, int number)
        {
            if (number > -20 && number < 0)
            {
                number *= -1;
                Console.WriteLine($"Your number is negative {intStrings[number]}");
            }
            else if (number >= 0 && number < 20)
            {
                Console.WriteLine($"Your number is {intStrings[number]}");
            }
        }
        */
        #endregion
        #region ArraysWithStringsOfNumbers
        /*  //first three functions only return arrays of number names, for easier use in program
          public static string[] ReturnArrayStringsZeroToNineteen()
          {
              string[] twenties = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
              return twenties;
          }
          public static string[] ReturnArrayStringsTwentytoNinety()
          {
              string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
              return tens;
          }
          public static string[] ReturnArrayStringsHundredtoMillion()
          {
              string[] thousands = { "hundred", "thousand", "million" };
              return thousands;
          }*/
        #endregion

    }
}
