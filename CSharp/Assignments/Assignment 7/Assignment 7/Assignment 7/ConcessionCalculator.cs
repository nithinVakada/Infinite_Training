using System;

namespace TravelConcessionLib
{
    public class ConcessionCalculator
    {
        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concessionFare = totalFare * 0.7; 
                return $"Senior Citizen - Fare after concession: {concessionFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {totalFare}";
            }
        }
    }
}
