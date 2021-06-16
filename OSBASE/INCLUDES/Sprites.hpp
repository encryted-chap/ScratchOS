#pragma once
#include "VirtualReg.hpp"

using namespace ScratchKernel::Registers;
namespace ScratchKernel::Sprites {
    class Sprite {
    private:
        
    public:
        Register_32 Accumulator;
        Register_32 X, Y, Di, Si;
        Sprite() {
            Si=Di=Y=X = Register_32();
        }
    };
}