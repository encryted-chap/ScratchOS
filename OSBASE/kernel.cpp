#include "INCLUDES/Exec.hpp"
#include "INCLUDES/FiberManager.hpp"
#include "INCLUDES/Collections.hpp"

extern "C" void kmain();
using namespace ScratchKernel;
using namespace Collections;
using namespace Fibers;

void kmain() {
    FiberManager fman = FiberManager();
    
}