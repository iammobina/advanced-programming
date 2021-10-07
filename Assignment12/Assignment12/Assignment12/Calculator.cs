using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Calculator
    {
        public Calculator()
        {
            this.State = new StartState(this);
        }
        /// <summary>
        /// عملگر های تعریف شده
        /// </summary>
        public static readonly Dictionary<char, Func<double, double, double>> Operators =
            new Dictionary<char, Func<double, double, double>>()
            {
                ['+'] = (x, y) => x + y,
                ['-'] = (x, y) => x - y,
                ['/'] = (x, y) => x / y,
                ['*'] = (x, y) => x * y
            };
        /// <summary>
        /// نمایش صفحه 
        /// </summary>
        public void PrintDisplay()
        {
            Console.Write(this.Display);
        }
        /// <summary>
        /// مقدار string عدد در حال نمایش
        /// </summary>
        public string Display { get; set; } = "0";
        /// <summary>
        /// مقدار عدد ذخیره شده برای انجام عملیات بر روی آن
        /// </summary>
        public double Accumulation { get; set; }
        /// <summary>
        /// عملگر
        /// </summary>
        public char? PendingOperator { get; set; } = null;
        /// <summary>
        /// حالت کنونی
        /// </summary>
        public IState State { get; protected set; }
        /// <summary>
        /// مقدار عددی وضعیت کنونی ماشین حساب
        /// </summary>
        public void Evalute()
        {
            Accumulation = PendingOperator.HasValue ?
                    Operators[PendingOperator.Value](Accumulation, double.Parse(Display)) :
                    double.Parse(Display);
        }
        /// <summary>
        /// اروری که میخواهد نمایش دهد را با رنگ قرمز نشان میدهد
        /// </summary>
        /// <param name="message"></param>
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
            Thread.Sleep(500);
        }
        public void UpdateDisplay() => Display = Accumulation.ToString();
        public void EnterPoint() => State = State.EnterPoint();

        public void EnterZeroDigit() => State = State.EnterZeroDigit();
        public void EnterNonZeroDigit(char c) => State = State.EnterNonZeroDigit(c);
        /// <summary>
        /// عملگر وارد شده را ذخیره میکند
        /// </summary>
        /// <param name="op"></param>
        public void EnterOperator(char op)
        {
            State = State.EnterOperator(op);
            PendingOperator = op;
        }

        public void EnterEqual() => State = State.EnterEqual();
        /// <summary>
        /// پاک کردن 
        /// </summary>
        public void Clear()
        {
            Accumulation = 0;
            State = new StartState(this);
            PendingOperator = null;
            Display = "0";
        }
    }
}
