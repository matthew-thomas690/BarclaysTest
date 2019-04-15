using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileVersionJob : IFileJob
    {

        TextWriter textWriter;

        public FileVersionJob(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }


        public void Execute(string filePath)
        {
            textWriter.WriteLine($"File Version: {new FileDetails().Version(filePath)}");
        }
    }
}
