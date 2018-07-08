using System.IO;
using System.Linq;

namespace Logger
{
    public class IncrementalLogFileName : LogFileNamePolicy
    {
        /// <summary>
        /// base 
        /// بر اساس لاگ فایل نیم پالیسی نوشته شده که با توجه به کلاس پدر شی سازی انجام میشه
        /// </summary>
        /// <param name="logDir">ادرس</param>
        /// <param name="logPrefix">پیشوند</param>
        /// <param name="logExt">نوع </param>
        public IncrementalLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt)
        { }
        /// <summary>
        /// با توجه به path combine 
        ///  اسم فایل بعدی به صورت پیشوند خط فاصله یک شماره بیشتر از شماره ی آخرین فایل
        /// </summary>
        /// <returns></returns>
        public override string NextFileName() => 
            Path.Combine(LogDir, 
                $"{LogPrefix}_{(LastLogNumber+1).ToString("0000")}.{LogExt}");



        /// <summary>
        /// شماره ی آخرین فایل
        /// </summary>
        protected int LastLogNumber
        {
            get
            {
                string[] files = Directory.GetFiles(this.LogDir, $"{LogPrefix}_*.{LogExt}");
                return files.Length == 0 ? -1 :
                       files.Select(f => f.Substring(0, f.Length - LogExt.Length - 1)
                                          .Substring(f.LastIndexOf('_') + 1))
                            .Max(n => int.Parse(n));
            }
        }

    }
}