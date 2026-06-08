%include "io.inc"
section .text
global main
main:
    ;write your code here
    xor eax, eax
    GET_DEC 4, eax
    while_loop:
        cmp eax, 0
        je while_end
        ;тело цикла
        GET_DEC 4, eax
        PRINT_STRING "EAX = "
        PRINT_DEC 4, eax
        ; что-то меняем в eax
        jmp while_loop ;ghjff
    
    while_end:
    xor eax, eax
    ret