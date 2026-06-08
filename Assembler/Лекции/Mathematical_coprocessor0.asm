%include "io.inc"
section .text
global main
main:
    mov ebp, esp; for correct debugging
    FINIT
    fld 10
    ;write your code here
    xor eax, eax
    ret