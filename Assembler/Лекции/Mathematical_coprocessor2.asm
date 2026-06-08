%include "io.inc"
section .data
    fmt db "%f", 10, 0
    num dq 0.0
    
    r dq 4.3
    a dq 16.45689
    b dq 3.4
    
section .text
global main
main:
    mov ebp, esp; for correct debugging
    
    ; S = pi * r^2 pi - константа r - число (радиус, переменная))
    
    fld qword [a] ;
    fld qword [b] ;
    fabs
    fchs
    fldpi
    fldz
    fld1 ; st0=1, st1=0, st2=3,14, st3=b; st4=a
    ;sqrt(a)
    fxch st4; st0 = a, st4 = 1
    ;write your code here
    xor eax, eax
    ret