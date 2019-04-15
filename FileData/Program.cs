using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var jobMap = new Dictionary<CmdLineOptions, IFileJob>();
            PopulateJobMap(jobMap, Console.Out);
            var cmdLineParameterOptions = (ConfigurationManager.GetSection("CmdLineParameterOptions") as System.Collections.Hashtable)
                .Cast<System.Collections.DictionaryEntry>().ToDictionary(n => n.Key.ToString(), n => n.Value.ToString());
            ICmdLineParser cmdLineParser = new CmdLineParser(cmdLineParameterOptions);

            try
            {
                var fileArgs = cmdLineParser.Parse(args);

                if(!jobMap.ContainsKey(fileArgs.CmdLineOption))
                {
                    throw new Exception($"Could not file FileJob to execture for CmdLineOption {fileArgs.CmdLineOption}");
                }

                IFileJob fileJob = jobMap[fileArgs.CmdLineOption];
                fileJob.Execute(fileArgs.FilePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(Environment.NewLine + "Press Enter to continue.");
            Console.ReadKey();
        }

        public static void PopulateJobMap(IDictionary<CmdLineOptions, IFileJob> jobMap, TextWriter tWriter)
        {
            jobMap.Add(CmdLineOptions.size, new FileSizeJob(tWriter));
            jobMap.Add(CmdLineOptions.version, new FileVersionJob(tWriter));
        }
    }
}
