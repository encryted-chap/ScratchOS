#pragma once

namespace ScratchKernel::Registers {
    class Register_32 {
    private:
        int REG = 0;
    public:
        enum ShiftDirection {
            Left = 0,
            Right = 1,
        };
        Register_32() {
            REG = 0;
        }
        void Shift(int b, ShiftDirection direction){
            if((int)direction)
                REG >>= b;
            else REG <<= b;
        }
        void Set(int* i) {
            REG = *i;
        }
        void Set(int i) {Set(&i);}
    };

}