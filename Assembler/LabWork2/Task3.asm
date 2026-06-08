%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
    
    ; Task №1
    mov esp, 1
    
    mov ecx, 0 ; Инициализация параметра: i = 0
    mov edx, 0 ; Инициализация параметра: j = 0
    
    loop_start:
    GET_DEC 4, eax
    cmp esp, eax 
    jl loop_less; Если rcx >= 10, выходим из цикла
    jg loop_more
    je loop_end
    
    loop_less:
    PRINT_STRING "требуется ввести меньшее число"
    NEWLINE
    jmp loop_start
    loop_more:
    PRINT_STRING "требуется ввести большее число"
    NEWLINE
    jmp loop_start
    
    loop_end:
    PRINT_STRING "Вы угадали!"
    ; Код после завершения цикла
    ;write your code here
    xor eax, eax
    ret