%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
    ;write your code here
    xor eax, eax
    ;Task №2
    mov eax, 15
    cmp eax, 4
    jg within_range
    jl out_of_range
    
    within_range:
    cmp eax, 14
    jg out_of_range
    
    PRINT_STRING "within range (4..14)"
    
    jmp exit
    
    out_of_range:
    PRINT_STRING "out of range"
    
    jmp exit
    exit:
    ret