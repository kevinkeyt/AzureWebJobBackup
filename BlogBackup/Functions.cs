using System.IO;
using Microsoft.Azure.WebJobs;

namespace BlogBackup
{
    public class Functions
    {

        public static void CheckForFileUpdates([FileTrigger(@"wwwroot\data\posts\{name}", "*.json", WatcherChangeTypes.Created | WatcherChangeTypes.Changed, autoDelete: false)] TextReader file, 
            [Blob(@"postbackup/{name}")] TextWriter output, string name, TextWriter log)
        {
            output.Write(file.ReadToEnd());
            log.WriteLine($"Processed input file {name}");
        }

        public static void BlogDataBackup([FileTrigger(@"wwwroot\data\{name}", "*.json", WatcherChangeTypes.Created | WatcherChangeTypes.Changed, autoDelete: false)] TextReader file,
            [Blob(@"blogbackup/{name}")] TextWriter output, string name, TextWriter log)
        {
            output.Write(file.ReadToEnd());
            log.WriteLine($"Processed input file {name}");
        }
    }
}
