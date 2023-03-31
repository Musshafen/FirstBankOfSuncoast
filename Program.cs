using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            var isThisGoodInput = false;
            do
            {
                var stringInput = PromptForString(prompt);

                int numberInput;
                isThisGoodInput = Int32.TryParse(stringInput, out numberInput);

                if (isThisGoodInput)
                {
                    return numberInput;
                }
                else
                {
                    Console.WriteLine("Sorry, that isn't a valid input");
                }
            } while (!isThisGoodInput);

            // We shouldn't get here, but this makes C# happy
            return 0;
        }

        static void Main(string[] args)
        {
            var keepGoing = true;

            var transactions = new List<Transaction>();

            var tenDollarSavingsDeposit = new Transaction()
           {
            Amount = 10,
            Account = "Savings",
            Type = "Deposit"
           };
           transactions.Add(tenDollarSavingsDeposit);

           var eightDollarSavingsWithdraw = new Transaction()
           {
            Amount = 8,
            Account = "Savings",
            Type = "Withdraw"
           };
           transactions.Add(eightDollarSavingsWithdraw);

           var twentyFiveDollarCheckingDeposit = new Transaction()
           {
            Amount = 25,
            Account = "Checking",
            Type = "Deposit"
           };
           transactions.Add(twentyFiveDollarCheckingDeposit);




            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Choose an option from this menu:");
                Console.WriteLine();
                Console.WriteLine("[W]ithdraw");
                Console.WriteLine("[D]eposit");
                Console.WriteLine("[S]how Transactions");
                Console.WriteLine("[B]alances");
                Console.WriteLine("[Q]uit");
                Console.WriteLine();
                Console.Write("> ");
                var menuOption = Console.ReadLine().ToUpper();

                if (menuOption == "W")
                {
                }
                else
                if (menuOption == "D")
                {
                }
                else
                if (menuOption == "S")
                {
                }
                else
                if (menuOption == "B")
                {
                }
                else
                if (menuOption == "Q")
                {
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("Unknown menu option");
                }
            }
        }
    }
}