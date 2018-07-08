using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class CsvLogFormatter : XsvFormatter
    {
        /// <summary>
        /// از 
        /// XsvFormatter
        /// ارث بری میکند و کاراکتر ویرگول را استفاده میکند
        /// </summary>
        private CsvLogFormatter()
            : base(',')
        { }

    }
}

