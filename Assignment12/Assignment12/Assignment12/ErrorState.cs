namespace SimpleCalculator
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual()
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }
        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }
        public override IState EnterZeroDigit()
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }
        public override IState EnterOperator(char c)
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }
        public override IState EnterPoint()
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }
    }
}