#pragma once
#include "Sprites.hpp"
#include "Collections.hpp"

using namespace ScratchKernel::Collections;
using namespace ScratchKernel::Sprites;

namespace ScratchKernel::Fibers {
    extern "C" class Fiber;
    static List<Fiber>* FiberCollection;
    static List<Sprite> AllSprites = List<Sprite>();
    class Fiber {
    private:
        Sprite* attached;
        int spriteID = 0;
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
            for(int i = 0; i < (*FiberCollection).Length; i++) {
                StepRecursive((*FiberCollection)[i]);
            }
        }
        List<unsigned char> Binary = List<unsigned char>();
        
    public:
        
        
        List<Fiber> NestedFibers;
        static void RegisterFiber(Fiber f) {
            (*FiberCollection).Add(f);
        }
        static void SetCollection() {
            (*FiberCollection) = List<Fiber>();
        }
        
       Fiber(unsigned char* Instructions, bool isNested=false) {
           Binary.AddRange(Instructions);
           
           SetSprite(Instructions[INDEX++]);
           if(!isNested)
               Fiber::RegisterFiber(*this);
       } 
        static void StartExecuting() {
            while(true) {
                StepAll();
            }
        }
        void SetSprite(int id) {
            this->spriteID = id;
            while(AllSprites.Length <= spriteID) 
                AllSprites.Add(Sprite());
            this->attached = &AllSprites[spriteID];
        }
        void Step() {
            unsigned char instruction = Binary[INDEX++];
            switch(instruction) {
                case 0x0A: {
                    int bytenum = Binary[INDEX++];
                    List<unsigned char> bytes = List<unsigned char>();
                    
                    SetSprite(Binary[INDEX++]);
                    for(int i = 0; i < bytenum; i++, INDEX++) {
                        bytes.Add(Binary[INDEX]);
                    }
                    this->NestedFibers.Add(
                        Fiber(bytes.ToArray(), true)
                    );
                    break;
                }
                case 0x0B: {
                    auto spriteid = Binary[INDEX];
                    attached = &AllSprites[spriteid];
                    spriteID = spriteid;
                    break;
                }
                case 0x00: {
                    (void)0; // nop
                    break;
                }
                case 0x01: {
                    int op1 = Binary[INDEX++];
                    int op2 = Binary[INDEX];
                    op1 += op2;
                    attached->Accumulator.Set(op1);
                    break;
                }
                case 0x02: {
                    
                    break;
                }
                
            }
        }
    };
}