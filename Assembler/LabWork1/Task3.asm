%include "io.inc";
section .text
global main
main:
    ;write your code here
    xor eax, eax
    ;Task №3
    mov eax, 1
    mov ebx, 2
    mov ecx, 3
    
    cmp eax, ebx
    jg one_is_bigger_than_the_other
    je equalab
    cmp ebx, ecx
    jg two_is_bigger_than_the_other
    je equalbc
    cmp eax, ecx
    jg two_is_bigger_than_the_other
    je equalbc
    
    cmp eax, ecx
    jg one_is_bigger_than_the_other
    je equal12
    jg
    
    one_is_bigger_than_the_other:
    cmp eax, ecx
    jg one
    jl 
    PRINT_UDEC 4, ebx
    jmp exit
    
    one:
    PRINT_UDEC 4, eax
    
    two:
    PRINT_UDEC 4, ebx
    
    three:
    PRINT_UDEC 4, ecx
    
    equal12:
    PRINT_UDEC 4, eax
    
    equal_two:
    PRINT_UDEC 4, ebx
    
    equal_three:
    PRINT_UDEC 4, ecx
    
    exit:
    ret