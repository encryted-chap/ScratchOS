using System.Collections.Generic;

namespace Scratch2cpu.Types {
    public class ScratchApp {
        public Dictionary<string, object> MainList {get; set;}
        public ScratchApp() {
            MainList = new Dictionary<string, object>();
        }
    }
}