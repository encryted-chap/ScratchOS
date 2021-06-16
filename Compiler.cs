using Scratch2cpu.ProjectFile;
using Scratch2cpu.Base;
using System.Collections.Generic;
using System.IO;

namespace Scratch2cpu.Compilation {
    public class ScratchCompiler {
        List<byte> bytecode = new List<byte>();
        public ScratchFile FILE {get; private set;}
        List<Sprite> sprites {get; set;}
        public ScratchCompiler(ScratchFile file) {
            FILE = file;
            sprites = FILE.SProject.GetSprites();
        }
        public void Compile() {
            
        }
        public void Write() {
            string cppcode = "#pragma once\n\nchar SCRATCH[] {\n0x00, ";
            if(File.Exists(Directory.GetCurrentDirectory()+"/OSBASE/INCLUDES/SCRATCHBIN.hpp")) {
                foreach (var by in bytecode) {
                    cppcode += "0x"+by.ToString("X") + ", ";
                }
                cppcode += "\n};";
                File.WriteAllText(Directory.GetCurrentDirectory()+"/OSBASE/INCLUDES/SCRATCHBIN.hpp", cppcode); 
            }

        }
    }
    
}