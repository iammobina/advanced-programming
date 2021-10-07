using System;

namespace SimpleCalculator
{
    /// <summary>
    /// .نقطه ی شروع ماشین حساب 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        /// <summary>
        /// زدن اینتر یا مساوی
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        /// <summary>
        /// هرچقدر صفر وارد شود بی تاثیر است
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        /// <summary>
        /// صفر پاک می شود و عدد وارد شده نمایش داده می شود
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);
        /// <summary>
        /// در اینجا اگر نقطه وارد کنیم دیگر تغییری نمیکند
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}