using System;

//2. Create a class called Scholarship which has a function Public void Merit()
//that takes marks and fees as an input.
//If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
//If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
//If the given mark is >90, then calculate scholarship amount as 50% of the fees.
//In all the cases return the Scholarship amount, else throw an user exception
namespace Assignment_5
{
    
    class NoScholarshipException : ApplicationException
    {
        public NoScholarshipException(string message) : base(message)
        {
            Console.WriteLine("\n\tError \nScholarship is not Applicable!!");
        }
    }

    class Scholarship
    {
        public double Merit(int score, double tuitionFee)
        {
            double eligibleAmount = 0;

            if (score > 90)
            {
                eligibleAmount = tuitionFee * 0.5;
            }
            else if (score > 80 && score <= 90)
            {
                eligibleAmount = tuitionFee * 0.3;
            }
            else if (score >= 70 && score <= 80)
            {
                eligibleAmount = tuitionFee * 0.2;
            }
            else
            {
                throw new NoScholarshipException("Score is below the eligibility threshold.");
            }

            return eligibleAmount;
        }
    }

    class Question_2
    {
        static void Main()
        {
            int studentScore = 0;
            Console.Write("Enter Marks: ");
            try
            {
                studentScore = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input for marks: " + e.Message);
            }

            double courseFee = 0;
            Console.Write("Enter Fees: ");
            try
            {
                courseFee = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input for fees: " + e.Message);
            }

            Scholarship scholarship = new Scholarship();
            double awardedAmount = 0;

            try
            {
                awardedAmount = scholarship.Merit(studentScore, courseFee);
            }
            catch (NoScholarshipException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("The Scholarship Amount = " + awardedAmount+" /-");
            Console.ReadKey();
        }
    }
}
