using System.IO;

namespace Logger
{
    public abstract class LogFileNamePolicy : ILogFileNamePolicy
    {
        //نوع فایل
        public string LogExt { get; set; }
        //Directory = ادرس 
        public string LogDir { get; }
        //پیشوند فایل
        public string LogPrefix { get; }
        
        /// <summary>
        /// با توجه به ارث بری از آی لاگ فایل نیم اطلاعات را دیافت و شی مربوطه را می سازد
        /// </summary>
        /// <param name="logDir"></param>
        /// <param name="logPrefix"></param>
        /// <param name="logExt"></param>
        public LogFileNamePolicy(string logDir, string logPrefix, string logExt)
        {
            this.LogDir = logDir;
            this.LogPrefix = logPrefix;
            this.LogExt = logExt;
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }
        /// <summary>
        /// برای اسامی فایل های بعدی استفاده میشود و ابسترکت است و نمیتوان از آن شی ساخت
        /// </summary>
        /// <returns></returns>
        public abstract string NextFileName();
    }
}