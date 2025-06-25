using System;

namespace Inheritance
{
    class Accounts
    {
        private int accountNo;
        private string customerName;
        private string accountType;
        private char transactionType;
        private int amount;
        private int balance;

        public Accounts(int accNo, string custName, string accType, char transType, int amt, int initialBalance)
        {
            accountNo = accNo;
            customerName = custName;
            accountType = accType;
            transactionType = Char.ToUpper(transType);
            amount = amt;
            balance = initialBalance;

            if (transactionType == 'D')
            {
                Credit(amount);
            }
            else if (transactionType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }

        public void Credit(int amt)
        {
            balance += amt;
            Console.WriteLine($"Deposited ₹{amt}. New balance: ₹{balance}");
        }

        public void Debit(int amt)
        {
            if (amt > balance)
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
            }
            else
            {
                balance -= amt;
                Console.WriteLine($"Withdrew ₹{amt}. New balance: ₹{balance}");
            }
        }

        public void ShowData()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account No     : {accountNo}");
            Console.WriteLine($"Customer Name  : {customerName}");
            Console.WriteLine($"Account Type   : {accountType}");
            Console.WriteLine($"Transaction    : {(transactionType == 'D' ? "Deposit" : "Withdrawal")}");
            Console.WriteLine($"Amount         : ₹{amount}");
            Console.WriteLine($"Balance        : ₹{balance}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string custName = Console.ReadLine();

            Console.Write("Enter Account Type (Savings/Current): ");
            string accType = Console.ReadLine();

            Console.Write("Enter Transaction Type (D for Deposit / W for Withdrawal): ");
            char transType = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Initial Balance: ");
            int balance = Convert.ToInt32(Console.ReadLine());

            Accounts acc = new Accounts(accNo, custName, accType, transType, amount, balance);
            acc.ShowData();

            Console.Read();
        }
    }
}
