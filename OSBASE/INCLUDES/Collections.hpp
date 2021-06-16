#pragma once

namespace ScratchKernel::Collections {
    template<class T> class List {
    public:
        List() {
            
        }
        void Add(T object) {
            array[aindex++] = object;
        }
        void AddRange(T* objects) {
            for(int i = 0; objects[i] != '\0'; i++) 
                this->Add(objects[i]);
        }
        T operator[](int index) {
            return array[index];
        }

    private:
        int aindex = 0;
        T* array;
    };
}