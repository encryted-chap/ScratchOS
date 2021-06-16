using System.Collections.Generic;
using System.Text.Json;
using System;

namespace Scratch2cpu.Base {
    public class Sprite {
        public bool isStage {get; set;}
        public string name {get; set;}
        public Dictionary<string, List<object>> variables {get; set;}
        public Dictionary<string, List<object>> lists {get; set;}
        public Dictionary<string, List<object>> broadcasts {get; set;}
        public Dictionary<string, Block> blocks {get; set;} 
        public Dictionary<string, List<object>> comments {get; set;}
        public int costume {get; set;}
        public List<object> costumes {get; set;}
        public List<object> sounds {get; set;}
        public int volume {get; set;}
        public int layerOrder {get; set;}
        public int tempo {get; set;}
        public int videoTransparency {get; set;}
        public string videoState {get; set;}
        public object textToSpeechLanguage {get; set;}
    }

    public class Block {
        public string opcode {get; set;}
        public string next {get; set;}
        public string parent {get; set;}
        public object inputs {get; set;}
        public object fields {get; set;}
        public bool shadow {get; set;}
        public bool topLevel {get; set;}
        
        public static Block FromJSON(string JSON) {
            return JsonSerializer.Deserialize<Block>(JSON);
        }
        public string ToJSON() {
            return JsonSerializer.Serialize(this);
        }
    }
    public class HeadBlock : Block {
        public int x {get; set;}
        public int y {get; set;}
        
        new public static HeadBlock FromJSON(string JSON) {
            return JsonSerializer.Deserialize<HeadBlock>(JSON);
        }
    }
}