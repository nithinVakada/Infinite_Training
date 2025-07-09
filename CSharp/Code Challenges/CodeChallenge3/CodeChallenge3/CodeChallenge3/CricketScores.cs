using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to find the Sum and the Average points scored by the teams in the IPL.

//Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches)
//that takes no.of matches as input and accepts that many scores from the user.

//The function should then return the Count of Matches, Average and Sum of the scores.


namespace CodeChallenge3
{
    class CricketTeam
    {
        public (int matchCount, int totalPoints, double averagePoints) Pointscalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            Console.WriteLine($"Enter the scores for {no_of_matches} matches:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Score of match {i + 1} : ");
                int score=int.Parse(Console.ReadLine());
                scores.Add(score);
            }

            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }

            double average = no_of_matches > 0 ? (double)total / no_of_matches : 0;

            return (no_of_matches, total, average);
        }
    }

    class  CricketScores
    {
        static void Main()
        {
            Console.Write("Enter the number of matches played: ");
            int matches=int.Parse(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            var result = team.Pointscalculation(matches);

            Console.WriteLine("\n--- Performance Summary ---");
            Console.WriteLine($"Matches Played: {result.matchCount}");
            Console.WriteLine($"Total Points: {result.totalPoints}");
            Console.WriteLine($"Average Points: {result.averagePoints:F2}");

            Console.ReadKey();
        }
    }

}


