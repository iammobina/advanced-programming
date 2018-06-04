using System;

namespace SimpleCalculator
{
    public class Program
    {

        static void Main(string[] args)
        {
            RunCalculator(() => Console.ReadKey().KeyChar, Console.Clear);
        }
       
        /// <summary>
        /// با توجه  به ورودی حالت مایشن حساب را تعیین میکند
        /// </summary>
        /// <param name="GetKey">دریافت کلید ورودی</param>
        /// <param name="ClearConsole">پاک کردن صفحه نمایش</param>
        /// <returns>نمایش وضعیت نهایی</returns>
        public static Calculator RunCalculator(Func<char> GetKey, Action ClearConsole)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                ClearConsole();
                calc.PrintDisplay();
                char key = GetKey();
                switch (key)
                {
                    case '.':
                        calc.EnterPoint();
                        break;
                    case '0':
                        calc.EnterZeroDigit();
                        break;
                    case '=':
                    case (char)ConsoleKey.Enter:
                        calc.EnterEqual();
                        break;
                    case (char)ConsoleKey.Escape:
                        calc.Clear();
                        break;
                    case var c when c != '0' && char.IsDigit(c):
                        calc.EnterNonZeroDigit(c);
                        break;
                    case var c when Calculator.Operators.ContainsKey(c):
                        calc.EnterOperator(c);
                        break;
                    case 'q':
                        return calc;
                }
            }
        }
    }
}
