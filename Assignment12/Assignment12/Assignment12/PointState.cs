namespace SimpleCalculator
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        
        public PointState(Calculator calc) : base(calc) { }
        /// <summary>
        /// در این حالت نباید پس از صفر و ممیز با زدن نقطه ی جدید نقطه ای اضافه شود.
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            return this;
        }

    }
}