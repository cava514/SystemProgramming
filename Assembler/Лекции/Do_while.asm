%include "io.inc"
section .text
global main
main:
    ;write your code here
    mov ebp, esp
    
    mov ecx, 0
    do_while:
    
    PRINT_STRING "ITERACIA CIKLA"
    NEWLINE
    ;dec ecx
    
    cmp ecx, 0
    jg do_while
    
    xor eax, eax
    ret