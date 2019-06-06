using NUnit.Framework;
using Whois.Models;
using Whois.Parsers;

namespace Whois.Parsing.Whois.Tcinet.Ru.Ru
{
    [TestFixture]
    public class RuParsingTests : ParsingTests
    {
        private WhoisParser parser;

        [SetUp]
        public void SetUp()
        {
            SerilogConfig.Init();

            parser = new WhoisParser();
        }

        [Test]
        public void Test_found()
        {
            var sample = SampleReader.Read("whois.tcinet.ru", "ru", "found.txt");
            var response = parser.Parse("whois.tcinet.ru", "ru", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.Found, response.Status);
        }

        [Test]
        public void Test_not_found()
        {
            var sample = SampleReader.Read("whois.tcinet.ru", "ru", "not_found.txt");
            var response = parser.Parse("whois.tcinet.ru", "ru", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.NotFound, response.Status);
        }

        [Test]
        public void Test_found_status_registered()
        {
            var sample = SampleReader.Read("whois.tcinet.ru", "ru", "found_status_registered.txt");
            var response = parser.Parse("whois.tcinet.ru", "ru", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.Found, response.Status);
        }
    }
}