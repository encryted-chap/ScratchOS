#pragma once
#include "Collections.hpp"

using namespace ScratchKernel::Collections;

namespace ScratchKernel::Fibers {
    class FiberManager {
    public:
        FiberManager() {

        }
    };
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
    public:
        static List<Fiber> FiberCollection;
        List<Fiber> NestedFibers;
        static void RegisterFiber(Fiber f) {
            Fiber::FiberCollection.Add(f);
        }
        void Step() {
            
        }
        static void StepAll() {
            for(int i = 0; i < FiberCollection.Length; i++) {
                StepRecursive(FiberCollection[i]);
            }
        }

    };
}