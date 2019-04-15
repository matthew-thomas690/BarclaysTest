using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public class CmdLineArgs
    {
        public CmdLineArgs(CmdLineOptions cmdLineOption, string filePath)
        {
            CmdLineOption = cmdLineOption;
            FilePath = filePath;
        }

        public CmdLineOptions CmdLineOption { get; private set; }
        public string FilePath { get; private set; }
    }
}
