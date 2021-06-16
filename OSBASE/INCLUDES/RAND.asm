bits    32

section .text
    global RAND
RAND:
    ; check that rdrand is available
    mov         eax, 1
    mov         ecx, 9
    cpuid
    shr         ecx, 30
    and         ecx, 1

    ; if unavailable, go to failed
    cmp         ecx, 1
    jne         onfail

    ; attempt to get random number
    mov         ecx, 100
retry:
    rdrand      eax
    jc          ondone
    loop        retry
onfail:
    mov         eax, 0
    ret
ondone:
    ret
