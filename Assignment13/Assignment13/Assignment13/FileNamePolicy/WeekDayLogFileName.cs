using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logger
{ 
    class WeekDayLogFileName : LogFileNamePolicy
    {
        /// <summary>
        /// base 
        /// بر اساس لاگ فایل نیم پالیسی نوشته شده که با توجه به کلاس پدر شی سازی انجام میشه
        /// </summary>
        /// <param name="logDir">ادرس</param>
        /// <param name="logPrefix">پیشوند</param>
        /// <param name="logExt">نوع </param>
        public WeekDayLogFileName(string logDir, string logPrefix, string logExt)
            : base(logDir, logPrefix, logExt)
        {}

        /// <summary>
        /// نام فایل اساس روز هفته 
        /// </summary>
        /// <returns>نام کامل فایل</returns>
        public override string NextFileName() =>
            Path.Combine(LogDir,
                $"{LogPrefix}_{DateTime.Today.DayOfWeek.ToString()}.{LogExt}");
    }
}