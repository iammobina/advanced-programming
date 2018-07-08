using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's SSN is  432-12-3232";
            string expectedString = "Ali's SSN is  XXX-XX-XXXX";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void IranIDTest()
        {
            string testString = "Hassan's SSN is  002-3065894";
            string expectedString = "Hassan's SSN is  XXX-XXXXXX4";
            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }

        /*[TestMethod]
        public void EmailTest()
        {
            string testString = "Mr. Salehi email is Salehi@yahoo.com.";
            string expectedString = "Mr. Salehi email is xxxxxx@xxxxx.xxx.";

            string maskedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }*/

        [TestMethod]
        public void CCTest()
        {
            string testString = "Mrs. Maryam Afshari's CC is 6362-1410-8793-1730";
            string expectedString = "Mrs. Maryam Afshari's CC is XXXX-XXXX-XXXX-XXXX";

            string maskedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);

            testString = "Mrs. Maryam Afshari's CC is 6362 1410 8793 1730";
            expectedString = "Mrs. Maryam Afshari's CC is XXXX XXXX XXXX XXXX";

            maskedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);


            testString = "Mrs. Maryam Afshari's CC is 6362141087931730";
            expectedString = "Mrs. Maryam Afshari's CC is XXXXXXXXXXXXXXXX";

            maskedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }

    }

}
