using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileSizeJob : IFileJob
    {
        TextWriter textWriter;

        public FileSizeJob(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Execute(string filePath)
        {
            textWriter.WriteLine($"File Size: {new FileDetails().Size(filePath)}");
        }
    }
}
