%include "io.inc"
section .text
global main
main:

    mov ebp, esp; for correct debugging
    
    mov ecx, 10; ecx - кол-во повторений
    my_loop:
    ;тело цикла
    PRINT_STRING "HELLO"
    
    loop my_loop
    
    ;write your code here
    xor eax, eax
    ret