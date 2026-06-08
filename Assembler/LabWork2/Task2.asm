%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
    
    ; Task №1
    GET_DEC 4, eax
    
    mov ecx, 1 ; Инициализация параметра: i = 0
    mov edx, 1 ; Инициализация параметра: j = 0
    
    loop_start:
    cmp ecx, eax ; Сравнение параметра: проверить, достиг ли ebx 10
    jge loop_end; Если rcx >= 10, выходим из цикла
    
    ;Тело цикла
    loop_start1:
    mov edx, ecx
    imul edx, edx
    cmp edx, eax
    jge loop_end
    PRINT_DEC 4, edx
    cmp edx, ecx
    jl loop_start1
    NEWLINE
    
    inc ecx ; Изменение параметра: i++ (или add ecx, 1)
    jmp loop_start ; Возврат в начало цикла
    
    loop_end:
    ; Код после завершения цикла
    
    ;write your code here
    xor eax, eax
    ret