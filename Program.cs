using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

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


            var transactions = new List<Transaction>();

            if (File.Exists("transactions.csv"))
            {
                var fileReader = new StreamReader("transactions.csv");
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                transactions = csvReader.GetRecords<Transaction>().ToList();
                fileReader.Close();
            }




            var keepGoing = true;
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
                    var transaction = new Transaction();
                    Console.WriteLine();
                    Console.WriteLine("Which account would you like to withdraw from:");
                    Console.WriteLine("[C]hecking");
                    Console.WriteLine("[S]avings");
                    var userInput = Console.ReadLine().ToUpper();
                    if (userInput == "C")
                    {
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to withdraw from your checking? $");
                        var accountTotal = transactions.Where(transaction => transaction.Type == "Checking").Sum(transaction => transaction.Amount);
                        if (transaction.Amount > accountTotal)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.WriteLine();

                        }
                        else
                        {
                            transaction.Account = "Checking";
                            transaction.Type = "Withdraw";
                            transactions.Add(transaction);

                        }


                    }
                    else
                    if (userInput == "S")
                    {
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to withdraw from your savings? $");
                        var accountTotal = transactions.Where(transaction => transaction.Type == "Savings").Sum(transaction => transaction.Amount);
                        if (transaction.Amount > accountTotal)
                        {
                            Console.WriteLine("Insufficient Funds");
                            Console.WriteLine();
                        }
                        else
                        {
                            transaction.Account = "Savings";
                            transaction.Type = "Withdraw";
                            transactions.Add(transaction);


                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection");
                    }

                }
                else
                if (menuOption == "D")
                {
                    var transaction = new Transaction();
                    Console.WriteLine();
                    Console.WriteLine("Which account would you like to deposit to:");
                    Console.WriteLine("[C]hecking");
                    Console.WriteLine("[S]avings");
                    var userInput = Console.ReadLine().ToUpper();
                    if (userInput == "C")
                    {
                        transaction.Account = "Checking";
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to deposit to your checking? $");
                        transaction.Type = "Deposit";
                        transactions.Add(transaction);
                    }
                    else
                    if (userInput == "S")
                    {
                        transaction.Account = "Savings";
                        Console.WriteLine();
                        transaction.Amount = PromptForInteger("How much would you like to deposit to your savings? $");
                        transaction.Type = "Deposit";
                        transactions.Add(transaction);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection");
                    }


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
                // Create a stream for writing information into a file
                var fileWriter = new StreamWriter("transactions.csv");
                // Create an object that can write CSV to the fileWriter
                var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                // Ask our csvWriter to write out our list of numbers
                csvWriter.WriteRecords(transactions);
                // Tell the file we are done
                fileWriter.Close();




            }
        }
    }
}