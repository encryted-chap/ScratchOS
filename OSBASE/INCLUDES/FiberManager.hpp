#pragma once
#include "Collections.hpp"

using namespace ScratchKernel::Collections;

namespace ScratchKernel::Fibers {
    
    class Fiber {
    private:
        int INDEX = 0;
        static void StepRecursive(Fiber f) {
            if(f.NestedFibers.Length != 0) {
                for(int i = 0; i < f.NestedFibers.Length; i++) {
                    StepRecursive(f.NestedFibers[i]);
                }
            }
            f.Step();
        }
        static void StepAll() {
            for(int i = 0; i < FiberCollection.Length; i++) {
                StepRecursive(FiberCollection[i]);
            }
        }
        List<unsigned char> Binary = List<unsigned char>();
    public:
        static List<Fiber> FiberCollection;
        List<Fiber> NestedFibers;
        static void RegisterFiber(Fiber f) {
            Fiber::FiberCollection.Add(f);
        }
        void Step() {
            unsigned char instruction = Binary[INDEX++];
            switch(instruction) {
                case 0x0A:
                    int bytenum = Binary[INDEX++];
                    List<unsigned char> bytes = List<unsigned char>();
                    for(int i = 0; i < bytenum; i++, INDEX++) {
                        bytes.Add(Binary[INDEX]);
                    }
                    this->NestedFibers.Add(
                        Fiber(bytes.ToArray())
                    );
                    break;
            }
        }
        Fiber(unsigned char* Instructions) {
            Binary.AddRange(Instructions);
            RegisterFiber(*this);
        }
        static void StartExecuting() {
            while(true) {
                StepAll();
            }
        }
    };
}