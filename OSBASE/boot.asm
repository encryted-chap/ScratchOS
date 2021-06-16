bits    32
section .text
    align 4
    dd 0x1BADB002
    dd 0
    dd - (0x1BADB002+0)
    
    global start
start:
    extern kmain
    call kmain
    hlt
