using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public class CmdLineParser : ICmdLineParser
    {
        public IDictionary<string, string> CmdLineOptions;

        public CmdLineParser(IDictionary<string, string> CmdLineOptions)
        {
            this.CmdLineOptions = CmdLineOptions;
        }
        public CmdLineArgs Parse(string[] args)
        {
           if(args.Count() != 2 || !CmdLineOptions.ContainsKey(args.First()))
            {
                throw new Exception("Invalid arguments.");
            }

            CmdLineOptions cmdLineOption;

            if(!Enum.TryParse(CmdLineOptions[args.First()], out cmdLineOption))
            {
                throw new Exception($"could not parse the string value '{CmdLineOptions[args.First()]}' to a CmdLineOptions enum value");
            }

            return new CmdLineArgs(cmdLineOption, args.Last());
        }
    }
}
