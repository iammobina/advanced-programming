using System;
using System.IO;

namespace Logger
{
    public class TimeBasedLogFileName : LogFileNamePolicy
    {
        /// <summary>
        /// base 
        /// بر اساس لاگ فایل نیم پالیسی نوشته شده که با توجه به کلاس پدر شی سازی انجام میشه
        /// </summary>
        /// <param name="logDir">ادرس</param>
        /// <param name="logPrefix">پیشوند</param>
        /// <param name="logExt">نوع </param>
        public TimeBasedLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt)
        {}
        /// <summary>
        /// نام فایل بعدی با توجه به زمان ساخته میشود
        /// </summary>
        /// <returns></returns>
        public override string NextFileName() =>
            Path.Combine(LogDir, 
                $"{LogPrefix}_{DateTime.Now.ToString("yy-MM-dd_HH-mm-ss")}.{LogExt}");
    }
}