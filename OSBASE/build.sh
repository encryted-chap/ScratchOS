nasm -fbin bootloader/ENTRY.asm -o OS.bin
cd resources

for res in $( ls && ls ../binfiles ) 
do 
    cat $res >> ../OS.bin && echo "appended: $res"
done

cd ..
qemu-system-x86_64 -hda OS.bin
mv OS.bin ../BUILT_OS
genisoimage -o ../BUILT_OS/OS.iso binfiles
rm *.bin