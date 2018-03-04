using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("Please Enter 8 numbers:");
            string userInput = Console.ReadLine();
            string[] inputTokens = userInput.Split();
            int[] userInputNumbers = new int[8];
            userInputNumbers = new int[inputTokens.Length];

            int AnotherNumber;// عددی است که از کاربر به غیر از آن آرایه ی هشت تایی میگیرد

            do
            {
                for (int i = 0; i < inputTokens.Length; i++)
                {
                    userInputNumbers[i] = int.Parse(inputTokens[i]);
                }
                Console.WriteLine("Please Enter Another number:");
                AnotherNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(Ehtemal(userInputNumbers, AnotherNumber));
            } while (AnotherNumber != -1);
          }
        //این تابع برای محاسبه ی احتمال عدد وارد شده می باشد
        public static double Ehtemal(int[] userInputNumbers, int AnotherNumber)
        {
            double s = 0;
            double k = 0;
            for (int j = 0; j < userInputNumbers.Length; j++)
            {
                if (userInputNumbers[j] == AnotherNumber)
                    k++;
                s = k / 8;
            }
            k = 0;
            return s;
       }
    }
}
