using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Titanic.csv")
                .Skip(1)
                .Select(line => new TitanicData(line));

            Console.WriteLine($"Paid the highest fare: {data.GetMostExpensiveFare().Name}");

            // If necessary, you can use more than one extension method to calculate these answers.
            Console.WriteLine($"Oldest person's name: {data.GetOldestPersonName()}");
            Console.WriteLine($"Oldest female's name: {data.GetOldestFemaleName()}");
            Console.WriteLine($"Total passengers: {data.TotalPassengers()}");
            Console.WriteLine($"Total Female passengers: {data.TotalFemalePassengers()}");
            Console.WriteLine($"Total number of survivors: {data.TotalSurvival()}");
            Console.WriteLine($"Percent of passengers who survived: {data.SurvivalPerecent()}");
            Console.WriteLine($"Number of female Survivors: {data.FemaleSurvival()}");
            Console.WriteLine($"Percent of females who survived: {data.FemaleSurvivalPerecent()}");
            Console.WriteLine($"Percent of survivors who were female: {data.FemaleSurvivalPerecentinFemales()}");
            Console.WriteLine($"Percent of kids under 10 who survived: {data.GetUnder10SurvivalPercent()}");
            Console.WriteLine($"Port of boarding with most survivors: {data.Boardingsurvivors()}");
            Console.WriteLine($"Port of boarding with most survivors percent: {data.PartofBoardingsurvivorsPerecent()}");
            Console.WriteLine($"The age group (age/10) with most passengers: {data.AgeGroupeWithMostPassengers()}");
            Console.WriteLine($"The age group (age/10) with most survivors: {data.AgeGroupeWithMostSurvival()}");

        }
    }


    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;

        public static Nullable<double> ParseDoubleOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? double.Parse(str) as Nullable<double> : null;

        public static TitanicData GetMostExpensiveFare(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Fare).First();

        /// <summary>
        /// from this we will Get The Oldest Person Name
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>OldestPersonName</returns>
        public static TitanicData GetOldestPersonName(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Age).First();

        /// <summary>
        /// from this we will Get The Oldest Female Name
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>OldestFemaleName</returns>
        public static TitanicData GetOldestFemaleName(this IEnumerable<TitanicData> data)
            => data.Where(p => p.IsFemale).OrderByDescending(p => p.Age).First();

        /// <summary>
        /// from this we will Get The Number of TotalPassengers
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Number of TotalPassengers</returns>
        public static int TotalPassengers (this IEnumerable<TitanicData> data)
            =>  data.Select(p => p.Name).Count();

        /// <summary>
        /// from this we will Get The Number of TotalFemalePassengers
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Number of TotalFemalePassengers</returns>
        public static int TotalFemalePassengers(this IEnumerable<TitanicData> data)
            => data.Select(p => p.IsFemale).Count();

        /// <summary>
        /// from this we will Get The Number of TotalSurvival
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Number of TotalSurvival</returns>
        public static int TotalSurvival(this IEnumerable<TitanicData> data)
           => data.Where(p => p.Survived).Count();

        /// <summary>
        /// from this we will Get The Perecent of Survivors
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Perecent of Survivors</returns>
        public static double SurvivalPerecent(this IEnumerable<TitanicData> data)
           => (double)data.Where(p => p.Survived).Count()/
              data.TotalPassengers();


        /// <summary>
        /// from this we will Get The Number of Female Survivors
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Number of Female Survivors</returns>
        public static int FemaleSurvival(this IEnumerable<TitanicData> data)
           => data.Where(p => p.IsFemale && p.Survived).Count();

        /// <summary>
        /// from this we will Get The Perecent of FemaleSurvivors in All Passengers
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Perecent of FemaleSurvivors in All Passengers</returns>
        public static double FemaleSurvivalPerecent(this IEnumerable<TitanicData> data)
           => (double)data.Where(p => p.IsFemale && p.Survived).Count()/data.TotalPassengers();

        /// <summary>
        /// from this we will Get The Perecent of FemaleSurvivors in Females
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>The Perecent of FemaleSurvivors in Females</returns>
        public static int FemaleSurvivalPerecentinFemales(this IEnumerable<TitanicData> data)
           => data.Select(p => p.IsFemale && p.Survived).Count()/ data.TotalFemalePassengers();

        /// <summary>
        /// from this we will Get The Perecent of Kids under 10 that has been survived
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>Under10SurvivalPercent</returns>
        public static double GetUnder10SurvivalPercent(this IEnumerable<TitanicData> data)
            => data.Where(p => p.Age < 10 && p.Survived).Count() /
               data.Where(p => p.Age < 10).Count();

        /// <summary>
        /// from this we will Get Port of boarding with most survivors 
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>Port of boarding with most survivors </returns>
        public static string Boardingsurvivors(this IEnumerable<TitanicData> data)
            => data.Where(p => p.BoardingPort != null).GroupBy(x => x.BoardingPort).OrderByDescending(x => x.Count(g => g.Survived)).First().Key;


        /// <summary>
        /// from this we will Get Port of boarding with most survivors Perecent
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>Port of boarding with most survivors Perecent</returns>
        public static string PartofBoardingsurvivorsPerecent(this IEnumerable<TitanicData> data)
        {
            double S=(double)data.Where(p => p.Survived && p.BoardingPort.ToString()=="S").Count() / data.Select(x => x.PassengerId).Count();
            double C = (double)data.Where(p => p.Survived && p.BoardingPort.ToString() == "C").Count() / data.Select(x => x.PassengerId).Count();
            double Q = (double)data.Where(p => p.Survived && p.BoardingPort.ToString() == "Q").Count() / data.Select(x => x.PassengerId).Count();
            if (S > Q && S > C)
                return "S";
            else if (Q > S && Q > S)
                return "Q";
            else return "C";
        }


        /// <summary>
        /// from this we will Get The Age Groupe With Most Survival
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>AgeGroupeWithMostSurvival</returns>
        public static int AgeGroupeWithMostSurvival(this IEnumerable<TitanicData> data)
        =>data.Where(p => p.Age !=null && p.Survived).GroupBy(p=>(int) p.Age/10)
            .OrderByDescending(x => x.Count()).First().Key;

        /// <summary>
        /// from this we will Get The Age Groupe With Most Passengers
        /// </summary>
        /// <param name="data">titanic data</param>
        /// <returns>AgeGroupeWithMostPassengers</returns>
        public static int AgeGroupeWithMostPassengers(this IEnumerable<TitanicData> data)
          => data.Where(p => p.Age != null).GroupBy(p => (int)p.Age / 10)
            .OrderByDescending(x => x.Count()).First().Key;



        
      
    }

    public class TitanicData
    {
        public TitanicData(string line)
        {
            var toks = line.Split(',');
            PassengerId = toks[0];
            Survived = toks[1] == "1";
            PClass = toks[2];
            Name = toks[3];
            IsFemale = toks[4] == "female";
            Age = toks[5].ParseDoubleOrNull();
            SibilingsOnBoard = toks[6].ParseIntOrNull();
            ParentsOnBoard = toks[7].ParseIntOrNull();
            Ticket = toks[8];
            Fare = double.Parse(toks[9]);
            Cabin = toks[10];
            BoardingPort = toks[11];
        }
        public string PassengerId;
        public bool Survived;
        public string PClass;
        public string Name;
        public bool IsFemale;
        public Nullable<double> Age;
        public Nullable<int> SibilingsOnBoard;
        public Nullable<int> ParentsOnBoard;
        public string Ticket;
        public double Fare;
        public string Cabin;
        public string BoardingPort;
    }
}
