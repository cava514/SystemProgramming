%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
    ;write your code here
    xor eax, eax
    ;Task №1
    mov eax, 1
    mov ebx, 2
    
    cmp eax, ebx
    je equal
    jne not_equal
    
    equal:
    PRINT_STRING "equal"
    jmp exit
    
    not_equal:
    PRINT_STRING "not equal"
    jmp exit
    
    exit:
    ret