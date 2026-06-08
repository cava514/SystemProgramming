%include "io.inc"
section .data
    str1 db "Hello", 0
    str2 db "world", 0
    
section .text
global main
main:

    mov esi, str1 ; esi = str1
    mov edi, str2 ; edi = str2
    
    ; mov eax, 4 eax = 4
    mov ecx, 5
    
    rep movsb  ; из esi (источник) взять ecx символов и скопировать в str2
    
    PRINT_STRING str2
    
    
    ;write your code here
    xor eax, eax
    ret