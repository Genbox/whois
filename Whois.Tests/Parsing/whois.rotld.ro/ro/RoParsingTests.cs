using NUnit.Framework;
using Whois.Models;
using Whois.Parsers;

namespace Whois.Parsing.Whois.Rotld.Ro.Ro
{
    [TestFixture]
    public class RoParsingTests : ParsingTests
    {
        private WhoisParser parser;

        [SetUp]
        public void SetUp()
        {
            SerilogConfig.Init();

            parser = new WhoisParser();
        }

        [Test]
        public void Test_other_status_updateprohibited()
        {
            var sample = SampleReader.Read("whois.rotld.ro", "ro", "other_status_updateprohibited.txt");
            var response = parser.Parse("whois.rotld.ro", "ro", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.Other, response.Status);
        }

        [Test]
        public void Test_not_found()
        {
            var sample = SampleReader.Read("whois.rotld.ro", "ro", "not_found.txt");
            var response = parser.Parse("whois.rotld.ro", "ro", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.NotFound, response.Status);
        }

        [Test]
        public void Test_found()
        {
            var sample = SampleReader.Read("whois.rotld.ro", "ro", "found.txt");
            var response = parser.Parse("whois.rotld.ro", "ro", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.Found, response.Status);
        }
    }
}