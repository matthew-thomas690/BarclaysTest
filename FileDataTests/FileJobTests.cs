using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataTests
{
    [TestClass]
    public class FileJobTests
    {
        [TestMethod]
        public void FileSizeJobTest()
        {
            var path = @"C:\Test\Test.txt";

            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms) { AutoFlush = true };
                IFileJob job = new FileSizeJob(tw);
                job.Execute(path);
                ms.Position = 0;
                using (TextReader tr = new StreamReader(ms))
                {
                    var result = tr.ReadToEnd();
                    Assert.IsTrue(result.StartsWith("File Size: "));
                }
            }
        }

        [TestMethod]
        public void FileVersionJobTest()
        {
            var path = @"C:\Test\Test.txt";

            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms) { AutoFlush = true };
                IFileJob job = new FileVersionJob(tw);
                job.Execute(path);
                ms.Position = 0;
                using (TextReader tr = new StreamReader(ms))
                {
                    var result = tr.ReadToEnd();
                    Assert.IsTrue(result.StartsWith("File Version: "));
                }
            }
        }
    }
}
