using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alias
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if(args[0] == "--help" || args[0] == "--HELP")
                    Console.WriteLine("Use: alias {name} = command");
                else if (args.Length > 2 && args[1] ==  "=")
                {
                    var name = args[0];
                    Console.WriteLine(name);
                    var commandArray = args.Skip(2).Take(args.Length - 1).ToArray();
                    var command = ConactinateCommand(commandArray);
                    Console.WriteLine(command);
                    CreateFile(name, command);
                }
            }
        }

        public static string ConactinateCommand(string[] commandArray)
        {
            var command = string.Empty;
            foreach (var cmnd in commandArray)
                command += cmnd + " ";
            return command;
        }
        public static void CreateFile(string name, string command)
        {
            var path = @"C:\aliases\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                var value = Environment.GetEnvironmentVariable("Path");
                Console.WriteLine(value);
                Console.WriteLine();
                value = path + ";" + value;
                Console.WriteLine(value);
                Environment.SetEnvironmentVariable("Path",value, EnvironmentVariableTarget.Machine);   
            }
            var fullPath = path + name + ".bat";
            Console.WriteLine(fullPath);
            var filestream = File.Create(fullPath);
            var streamWriter = new StreamWriter(filestream);
            streamWriter.WriteLine(command);
            streamWriter.Close();
            filestream.Close();
            
        }
    }
}
