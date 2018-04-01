using System;


namespace Helloworld
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
        public static bool issorted(int[] grades, bool asc)
        {
            int lastgrade = grades[0];
            foreach (int grade in grades)
            {
                if (asc)
                {
                    if (grade < lastgrade)
                        return false;
                    else
                        lastgrade = grade;
                }
                else
                {
                    if (grade > lastgrade)
                        return false;
                    else
                        lastgrade = grade;

                }
            }
            return true;
        }
    }
}
