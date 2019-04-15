using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataTests
{
    [TestClass]
    public class CmdLineParserTests
    {
        private ICmdLineParser parser;

        public CmdLineParserTests()
        {
            var cmdLineParameterOptions = new Dictionary<string, string>();
            cmdLineParameterOptions.Add("-v", "version");
            cmdLineParameterOptions.Add("--v", "version");
            cmdLineParameterOptions.Add("/v", "version");
            cmdLineParameterOptions.Add("--version", "version");
            cmdLineParameterOptions.Add("-s", "size");
            cmdLineParameterOptions.Add("--s", "size");
            cmdLineParameterOptions.Add("/s", "size");
            cmdLineParameterOptions.Add("--size", "size");

            parser = new CmdLineParser(cmdLineParameterOptions);
        }

        [TestMethod]
        public void VersionOptions()
        {
            var path = @"C:\Test\Test.txt";

            var result = parser.Parse(new string[] { "-v", path });
            Assert.AreEqual(path, result.FilePath);
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.version);

            result = parser.Parse(new string[] { "--v", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.version);

            result = parser.Parse(new string[] { "/v", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.version);

            result = parser.Parse(new string[] { "--version", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.version);
        }

        [TestMethod]
        public void SizeOptions()
        {
            var path = @"C:\Test\Test.txt";

            var result = parser.Parse(new string[] { "-s", path });
            Assert.AreEqual(path, result.FilePath);
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.size);

            result = parser.Parse(new string[] { "--s", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.size);

            result = parser.Parse(new string[] { "/s", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.size);

            result = parser.Parse(new string[] { "--size", path });
            Assert.AreEqual(result.CmdLineOption, CmdLineOptions.size);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid arguments.")]
        public void ExtraParamFailure()
        {
            var path = @"C:\Test\Test.txt";
            var result = parser.Parse(new string[] { "-s", path, "extraParam" });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid arguments.")]
        public void MissingParamFailure()
        {
            var result = parser.Parse(new string[] { "-s" });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid arguments.")]
        public void WrongParamFailure()
        {
            var path = @"C:\Test\Test.txt";
            var result = parser.Parse(new string[] { "wrongParam", path });
        }

    }
}
