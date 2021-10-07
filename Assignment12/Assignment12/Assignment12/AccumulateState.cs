using static System.Console;

namespace SimpleCalculator
{
    /// <summary>
    /// اعدادی را که دریافت یا میخواهد دریافت کند را نمایش می دهد
    /// </summary>
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        /// <summary>
        /// پس از زدن دکمه = یا اینتر به این تابع وارد شده  عملیات را محاسبه و نمایش میدهد
        /// </summary>
        /// <returns>حالت بعدی  را برمیگرداند</returns>
        public override IState EnterEqual()
        {
            return base.ProcessOperator(new ComputeState(Calc));
        }
        /// <summary>
        /// به حالت غیر صفر باز گردانده میشود
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');

        /// <summary>
        /// رقم وارد شده را ب انتهای string شامل عدد اضافه میکند
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c;
            return this;
        }
        /// <summary>
        ///عملگر جدید را دریافت میکند
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c)
        {
            return base.ProcessOperator(new ComputeState(Calc), c);
        }
        /// <summary>
        ///حالتی که هر چقدر هم نقطه وارد کنیم بی تاثیر خواهد بود
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            this.Calc.Display += ".";
            return new PointState(Calc);
        }
    }
}