using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace assignment5
{
    
    class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {
            Console.WriteLine("\n\tTransaction Error: Insufficient Balance!");
        }
    }

    class Accounts
    {
        int accNumber { get; }
        public string holderName { get; set; }
        public string typeOfAccount { get; set; }
        int currentBalance { get; set; }

        public Accounts(int accNumber, string holderName, string typeOfAccount, int initialBalance)
        {
            this.accNumber = accNumber;
            this.holderName = holderName;
            this.typeOfAccount = typeOfAccount;
            this.currentBalance = initialBalance;
        }

        public void Credit(int amountToDeposit)
        {
            currentBalance += amountToDeposit;
            Console.WriteLine($"Deposited: Rs {amountToDeposit}. Current Balance: {currentBalance} /-");
            Console.WriteLine("*********************************************");
        }

        public void Debit(int amountToWithdraw)
        {
            if (amountToWithdraw > currentBalance)
                throw new InsufficientBalanceException($"Insufficient funds. Current Balance: {currentBalance} /-");

            currentBalance -= amountToWithdraw;
            Console.WriteLine($"Withdrawn: Rs {amountToWithdraw}. Current Balance: {currentBalance} /-");
            Console.WriteLine("*********************************************");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current Balance: {currentBalance} /-");
            Console.WriteLine("*********************************************");
        }

        public void ShowAccountDetails()
        {
            Console.WriteLine("*************** Account Details ***************");
            Console.WriteLine($"Account Number: {accNumber}");
            Console.WriteLine($"Holder Name: {holderName}");
            Console.WriteLine($"Account Type: {typeOfAccount}");
            Console.WriteLine($"Balance: Rs {currentBalance}");
            Console.WriteLine("*********************************************");
        }
    }

    class Question1
    {
        static void Main(string[] args)
        {
            Accounts userAccount = null;
            Console.WriteLine("Welcome to the Banking System");

            while (userAccount == null)
            {
                try
                {
                    Console.Write("Enter Account Number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Account Holder Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Account Type: ");
                    string type = Console.ReadLine();

                    userAccount = new Accounts(number, name, type, 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input Error: " + e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter 'b' for Balance, 'c' for Credit, 'd' for Debit, 's' for Account Details, any other key to Exit");
                    char action = char.Parse(Console.ReadLine());

                    if (action == 'd')
                    {
                        Console.Write("Enter Amount to Withdraw: ");
                        int withdrawAmount = Convert.ToInt32(Console.ReadLine());
                        userAccount.Debit(withdrawAmount);
                    }
                    else if (action == 'c')
                    {
                        Console.Write("Enter Amount to Deposit: ");
                        int depositAmount = Convert.ToInt32(Console.ReadLine());
                        userAccount.Credit(depositAmount);
                    }
                    else if (action == 's')
                    {
                        userAccount.ShowAccountDetails();
                    }
                    else if (action == 'b')
                    {
                        userAccount.ShowBalance();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Transaction Error: " + e.Message);
                }
            }

            Console.WriteLine("******************** END OF TRANSACTION *************************");
            Console.Read();
        }
    }
}
