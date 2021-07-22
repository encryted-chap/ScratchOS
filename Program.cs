using System;
using System.IO;
using System.IO.Compression;

namespace Scratch2cpu
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <= 0 || args.Length > 1)
                Console.WriteLine("./scratch2cpu [scratch project path]");
            else {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/TEMP");
                ZipFile.ExtractToDirectory(args[0], Directory.GetCurrentDirectory() + "/TEMP");

                foreach(var f in Directory.GetFiles(Directory.GetCurrentDirectory() + "/TEMP")) {
                    string name = f.Remove(0, f.LastIndexOf("\\")).Trim('/').Trim('\\');
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "/OSbase/resources/" + name, File.ReadAllBytes(f));
                    Console.WriteLine($"Extracted {name}");
                    File.Delete(f);
                } Directory.Delete(Directory.GetCurrentDirectory() + "/TEMP");

                Console.WriteLine("Attempting to convert your project into assembly...");
                string JSON = File.ReadAllText(Directory.GetCurrentDirectory() + "/OSbase/resources/project.json");
                File.Delete(Directory.GetCurrentDirectory() + "/OSbase/resources/project.json");
                Console.WriteLine("Read and removed project.json (since it isn't a resource)");

                
            }
        }
    }
}
