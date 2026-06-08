%include "io.inc";
section .text
global main
main:
    mov ebp, esp; for correct debugging
        
    ; Task №1
    GET_DEC 4, eax
    
    mov ecx, 0 ; Инициализация параметра: i = 0
    mov edx, 0 ; Инициализация параметра: j = 0
    
    loop_start:
    cmp ecx, eax ; Сравнение параметра: проверить, достиг ли ebx 10
    jg loop_end; Если ecx >= 10, выходим из цикла
    
    ;Тело цикла
    loop_start1:
    PRINT_STRING "# "
    inc edx
    cmp ecx, edx
    jge loop_start1
    mov edx, 0
    NEWLINE
    
    inc ecx ; Изменение параметра: i++ (или add ecx, 1)
    jmp loop_start ; Возврат в начало цикла
    
    loop_end:
    ; Код после завершения цикла
    
    xor eax, eax
    ret