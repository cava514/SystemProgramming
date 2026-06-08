%include "io.inc"
section .text
global main
main:
    mov ebp, esp; for correct debugging
    mov eax, 6
    xor ebx, ebx
    mov bh, 2
    idiv bx
    PRINT_DEC 4, eax
    ;write your code here
    xor eax, eax
    ret