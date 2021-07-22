%define sectnum 1
section .text
    mov     [_driveid], dl              ; drive id is placed in dl by BIOS

    ; get drive info
    mov     ah, 8                       ; drive info interrupt
    int     0x13
    and     cl, 0x3f
    mov     [_sectptrack], cl           ; sectors per track
    mov     [_numofheads], dl           ; number of heads

    ; clear screen
    mov     ah, 0
    mov     al, 0x03
    int     0x10
    
; makes the operating system bootable
bootable:
    times   510-($-$$) db 0
    dw      0xaa55
section .data
_driveid db 0
_sectptrack db 0
_numofheads db 0

    