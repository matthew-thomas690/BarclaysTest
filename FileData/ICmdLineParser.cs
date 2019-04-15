using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public interface ICmdLineParser
    {
        CmdLineArgs Parse(string[] args);
    }

    public enum CmdLineOptions { version, size }


}
