%include "io.inc"
section .data
    fmt db "%f", 10, 0
    num dq 0.0
    
    r dq 4.3
    
section .text
global main
main:
    mov ebp, esp; for correct debugging
    ; S = pi * r^2 pi - константа r - число (радиус, переменная))
    fld qword [r] ; STO = r = 4.3
    fmul st0 ; STO = STO * STO = r^2
    fldpi ; STO = pi = 3.1415... ST1 = r^2
    fmul st1
    
    ;write your code here
    xor eax, eax
    ret