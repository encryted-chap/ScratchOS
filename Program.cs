using System.IO;
using Scratch2cpu.ProjectFile;
using Scratch2cpu.Compilation;

namespace Scratch2cpu
{
    class Program
    {
        static void Main(string[] args)
        {
            if(Directory.Exists(Directory.GetCurrentDirectory() + "\\TEMP")) {
                foreach(var f in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\TEMP"))
                    File.Delete(f);
                Directory.Delete(Directory.GetCurrentDirectory() + "\\TEMP");
            }
            string FilePath = args[0];
            ScratchFile file = new ScratchFile(FilePath);
            ScratchCompiler compiler = new ScratchCompiler(file);
            compiler.Write();
        }
    }
}
