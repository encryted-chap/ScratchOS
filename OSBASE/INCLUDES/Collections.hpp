#pragma once

namespace ScratchKernel::Collections {
    template<class T> class List {
    public:
        int Length;
        List() {
            Length = 0;
        }
        void Add(T object) {
            array[aindex++] = object;
            UpdateLength();
        }
        void AddRange(T* objects) {
            for(int i = 0; objects[i] != '\0'; i++) 
                this->Add(objects[i]);
        }
        T operator[](int index) {
            return array[index];
        }

    private:
        void UpdateLength() {
            for(Length = 0; Length < sizeof(array) / sizeof(T); Length++);
            Length++;
        }
        int aindex = 0;
        T* array;
    };
}