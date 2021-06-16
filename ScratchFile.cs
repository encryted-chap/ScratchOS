using System.IO.Compression;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Scratch2cpu.Base;
using System;

namespace Scratch2cpu.ProjectFile {
    public class ScratchFile {
        string JSON {get; set;}
        public Project SProject {get; set;}

        public ScratchFile(string Path) {
            FileStream stream = new FileStream(Path, FileMode.Open);
            ZipArchive archive = new ZipArchive(stream);
            
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\TEMP");
            archive.ExtractToDirectory(Directory.GetCurrentDirectory() + "\\TEMP");

            JSON = File.ReadAllText(
                Directory.GetCurrentDirectory() + "\\Temp" +
                    "\\project.json"
            );
            SProject = Project.FromJSON(this.JSON);
            Console.Write(JsonSerializer.Serialize(SProject.GetSprites()[0]));
        }
    }
    public class Project {
        public List<Sprite> targets {get; set;}
        public List<object> monitors {get; set;}
        public List<object> extensions {get; set;}
        public object meta {get; set;}

        public static Project FromJSON(string json) {
            return JsonSerializer.Deserialize<Project>(json);
        }
        public string ToJSON() {
            return JsonSerializer.Serialize<Project>(this);
        }
        public Project(){}
        public List<Sprite> GetSprites() {
            List<Sprite> ret = new List<Sprite>();
            foreach(var s in targets) {
                ret.Add(s);
            }
                
            return ret;
        }
    }
}