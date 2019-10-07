using System;

namespace NamuDarbaiNr1CS
{
    class Program
    {
        static void Main(string[] args)
        {
            //default condition check values are set
            bool isInputNumber = true;
            bool isInputInRange = true;
            do
            {
                //program starts, initial input is initiated
                string input = HelpMethods.AskForAndReadInput();
                //input is checked to verify that all symbols are numbers or '-'
                isInputNumber = HelpMethods.CheckIsInputNumber(input);
                //if all symbols of input are numbers or '-' we can continue
                if (isInputNumber)
                {
                    //input is parsed (no extra checks, as it has been verified previously)
                    int number = int.Parse(input);
                    //verification of input being in range
                    isInputInRange = HelpMethods.CheckIsInputInRange(number);
                    //if input is in range, words are assigned to numbers with function PrintAnyNumberUptoBillionInWords
                    if (isInputInRange)
                    {
                        //function takes 3 arrays of words and input converted as int
                        HelpMethods.PrintAnyNumberUptoBillionInWords(number);
                    }
                    //if input is not in range input is incorrect --> user is asked to enter new input
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Input was incorrect");
                    }

                }
                /*if input contains something that is not a number or '-' input is incorrect
                --> user is asked to enter new input*/
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input was incorrect");
                }
                /*program is looped while user manages to enter a number that is a number 
                only and is within range*/
            } while (!isInputNumber || !isInputInRange);
        }
    }
}
