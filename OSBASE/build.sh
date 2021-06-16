# assemble/build
nasm -f elf boot.asm -o bootloader.o
nasm -f elf ./INCLUDES/RAND.asm -o rand.o
g++ -w -static -fpermissive -m32 -fno-stack-protector -c kernel.cpp -o kernel.o

# link
ld -m elf_i386 -T link.ld -o kernel.bin bootloader.o kernel.o rand.o

# os booting
grub-mkrescue -o SCRATCH.iso
qemu-system-i386 -kernel ./kernel.bin

# cleanup
rm -r *.o
rm -r *.bin