using System;
using System.Collections.Generic;
using System.Linq;

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

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Amount = 10,
                    Account = "Savings",
                    Type = "Deposit"
                },
              new Transaction()
              {
                  Amount = 8,
                  Account = "Savings",
                  Type = "Withdraw"
              },
              new Transaction()
              {
                  Amount = 25,
                  Account = "Checking",
                  Type = "Deposit"
              }

            };



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

                    foreach (var transaction in transactions)
                    {
                        var descriptionOfTransaction = transaction.Description();

                        Console.WriteLine(descriptionOfTransaction);

                    }



                }
                else
                if (menuOption == "B")
                {


                    var totalCheckingDeposits = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);

                    var totalCheckingWithdraw = transactions.Where(transaction => transaction.Account == "Checking" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

                    var totalChecking = totalCheckingDeposits - totalCheckingWithdraw;




                    var totalSavingsDeposits = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Deposit").Sum(transaction => transaction.Amount);

                    var totalSavingsWithdraw = transactions.Where(transaction => transaction.Account == "Savings" && transaction.Type == "Withdraw").Sum(transaction => transaction.Amount);

                    var totalSavings = totalSavingsDeposits - totalSavingsWithdraw;

                    Console.WriteLine($"Your checking account has ${totalChecking} and your savings has ${totalSavings}");
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