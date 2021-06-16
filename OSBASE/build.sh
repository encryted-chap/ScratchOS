# assemble/build
nasm -f elf boot.asm -o bootloader.o
g++ -w -fpermissive -m32 -fno-stack-protector -c kernel.cpp -o kernel.o

# link
ld -m elf_i386 -T link.ld -o kernel.bin bootloader.o kernel.o

# os booting
grub-mkrescue -o SCRATCH.iso
qemu-system-i386 -kernel ./kernel.bin

# cleanup
rm -r *.o
rm -r *.bin