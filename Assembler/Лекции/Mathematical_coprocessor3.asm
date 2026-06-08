%include "io.inc"
section .data
    fmt db "%f", 10, 0
    num dq 0.0
   
    r dq 4.3
    a dq 16.0
    b dq 3.4

section .text
    global main
    main:
    mov ebp, esp; for correct debugging
       
    ; S = pi * r^2 pi - контанта r - число (радиус, переменная)
    
    fld qword [r] ; 
    fmul st0
    fldpi
    fmul st1
    
                     
    ; 1. Сохраняем st0 в память как 64-битное double
    fstp qword [num]

    ; 2. Вызываем printf (передаем параметры по стандарту cdecl)
    push dword [num+4]        ; Старшие 32 бита double
    push dword [num]          ; Младшие 32 бита double
    push fmt                  ; Адрес строки формата
    call printf
    add esp, 12               ; Очистка стека после вызова
                
        ret                 ; Выход из функции

