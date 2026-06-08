%include "io.inc"
section .text
global main
main:
    ;write your code here
    xor eax, eax
    mov eax, 0
    
    for_loop:
        cmp eax, 10
        jge for_end
        
        PRINT_DEC 4, eax
        NEWLINE
        
        inc eax
        jmp for_loop
        
    for_end:
    xor eax, eax
    ret