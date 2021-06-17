using Scratch2cpu.ProjectFile;
using Scratch2cpu.Base;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Scratch2cpu.Compilation {
    
    public class ScratchCompiler {
        List<byte> bytecode = new List<byte>();
        public ScratchFile FILE {get; private set;}
        List<Sprite> sprites {get; set;}
        public ScratchCompiler(ScratchFile file) {
            FILE = file;
            sprites = FILE.SProject.GetSprites();
            Compile();
        }
        public void Compile() {
            Dictionary<string, Sprite> searchspr = new Dictionary<string, Sprite>();
            foreach(Sprite s in sprites)
                searchspr.Add(s.name, s);
            var headblocks = GetChains();
            // attach all sprites
            foreach(var hb in headblocks) {
                hb.Value.SetAttached (
                    searchspr[hb.Key]
                );
            }
        }
        public Dictionary<string, HeadBlock> GetChains() {
            Dictionary<string, HeadBlock> blocks = new Dictionary<string, HeadBlock>();
            foreach(var sp in sprites) {
                foreach(var bl in sp.blocks) {
                    if(bl.Value.parent == null) {
                        // start of thread
                        blocks.Add(sp.name, bl.Value as HeadBlock);
                    }
                }
            }
            return blocks;
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