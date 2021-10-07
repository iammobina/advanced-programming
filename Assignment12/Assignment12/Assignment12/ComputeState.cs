namespace SimpleCalculator
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }
        /// <summary>
        /// نشان دهنده ی ارور
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }
        /// <summary>
        /// برای نمایش عدد غیر صفر به کار می رود
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display = c.ToString();
            return new AccumulateState(Calc);
        }
        /// <summary>
        /// تکرار صفر بی اثر است
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit()
        {
            Calc.Display = "0";
            return this;
        }

        /// <summary>
        /// مقدار ذخیره شده و عملگر تغییر میکند
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c)
        {
            Calc.Accumulation = double.Parse(Calc.Display);
            Calc.PendingOperator = c;
            return new ComputeState(Calc);
        }
        /// <summary>
        /// حالت به ممیزدار تغییر میکند
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}