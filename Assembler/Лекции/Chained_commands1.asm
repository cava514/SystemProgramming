%include "io.inc"
section .data
    str1 db "Hello", 0
    str2 db "world", 0
    
    char db 'l'
    
section .text
global main
main:
    mov ebp, esp; for correct debugging

    mov esi, str1 ; edi = str1
    mov ecx, 5 ; ecx - количество символов в строке
    mov al, [char] ; al - искомый символ
    
    repne scasb ; сканирование ecx символов
    
    je found ; если найден, символ прыгаем в found
    PRINT_STRING "Not Found" ; сообщение
    jmp endl
    
    found:
    PRINT_STRING "Found" ; сообщение
    NEWLINE
    PRINT_DEC ecx
    
    endl:
    
    ;write your code here
    xor eax, eax
    ret