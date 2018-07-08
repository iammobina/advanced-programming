using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        private EmailScrubber() { }

        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());

        protected override Regex PIIRegEx
            => new Regex(@"\b[\w\d!#$%&'*+-/=?_`{|}~]*\.?[\w\d\s^ ]*\b\@[\d\w\s^ ]*\.[\w]*");

        public override string Scrub(string content) => MaskPII(content, this.MaskLetters);
    }
}
