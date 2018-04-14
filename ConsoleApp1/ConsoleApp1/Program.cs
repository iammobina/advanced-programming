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
            //لطفا هشت عدد را در یک خط وارد کنید.
            Console.WriteLine("Reminder: This program designed for 8 Numbers if you want to Enter more numbers //Comment line 27-28");
            Console.WriteLine("Please Enter 8 numbers in one line: ");
            string userInput = Console.ReadLine();
            string[] inputTokens = userInput.Split();
            int[] userInputNumbers = new int[inputTokens.Length];

            // عددی است که از کاربر به غیر از آن آرایه ی هشت تایی میگیرد
            int AnotherNumber;
            do
            {
                if (inputTokens.Length > 8)
                {
                    break;
                }
                for (int i = 0; i < inputTokens.Length; i++)
                {
                        userInputNumbers[i] = int.Parse(inputTokens[i]);
                }
                Console.WriteLine("Please Enter Another number:");
                AnotherNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(Ehtemal(userInputNumbers, AnotherNumber));
            } while (AnotherNumber != -1);
          }
        
        /// <summary>
        /// این تابع برای محاسبه ی احتمال عدد وارد شده می باشد
        /// با توجه به صورت سوال که آرایه ی 8 تایی درنظر گرفته شده بود من در کد قبلی تقسیم بر 8 کردم ولی این بار بر سایز آرایه تقسیم کردم با این تفاوت که دستوری برای کنترل 8 تایی بودن ایجاد کردم.
        /// </summary>
        /// <param name="userInputNumbers"></param>
        /// <param name="AnotherNumber"></param>
        /// <returns>احتمال محاسبه شده</returns>
        public static double Ehtemal(int[] userInputNumbers, int AnotherNumber)
        {
            double k = 0;
            for (int j = 0; j < userInputNumbers.Length; j++)
                if (userInputNumbers[j] == AnotherNumber)
                    k++;
               return k / userInputNumbers.Length;
       }
    }
}
