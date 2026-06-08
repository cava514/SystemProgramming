%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
    ;write your code here
    xor eax, eax
    ;Task №4
    mov eax, 11 ; x
    mov ebx, 10 ; a
    cmp eax, -10
    jl square
    je module
    jg minus
    
    square: ; а*х2
    imul eax, eax
    imul eax, ebx
    PRINT_UDEC 4, eax
    jmp exit
    
    module: ; а*|х|
    cmp eax, 10
    jg minus
    je minus
    cdq
    xor eax, edx
    sub eax, edx
    imul eax, ebx
    PRINT_UDEC 4, eax
    jmp exit
    
    minus: ; а-х
    cmp eax, 10
    jl module
    sub ebx, eax
    PRINT_DEC 4, ebx
    jmp exit
    
    exit:
    ret