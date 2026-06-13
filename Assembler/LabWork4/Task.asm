MB_DEFBUTTON2 EQU 100h
IDNO          EQU 7
MB_YESNO      EQU 4
section .data
    Height dq 2
    Width dq 3
    SquareChislo dq 0
    Format db "%d", 0
    SquareFormat db "Square: %.lf", 0
    MessageBoxText    db "Square: %.lf", 0
    MessageBoxCaption db "MessageBox 64", 0
section .text
extern scanf
extern printf
extern MessageBoxA
extern ExitProcess
global main
main:
    mov rbp, rsp; for correct debugging
    
    sub rsp, 48
    lea rcx, [Format]
    mov rdx, [Height]
    call scanf
    add rsp, 48
    
    sub rsp, 48
    lea rcx, [Format]
    mov rdx, [Width]
    call scanf
    mov r14, rbx
    add rsp, 48
    
    imul r13, r14
    
    sub rsp, 40
    lea rcx, [SquareFormat]
    mov rdx, r13
    call printf
    add rsp, 40
    
    sub   RSP, 8

    sub   RSP, 32

    .DisplayMessageBox:
    xor   RCX, RCX
    lea   RDX, [REL SquareFormat]
    lea   R8, [REL MessageBoxCaption]
    mov   R9D, MB_YESNO | MB_DEFBUTTON2
    call  MessageBoxA

    cmp   RAX, IDNO
    je    .DisplayMessageBox

    add   RSP, 32

    xor   RCX, RCX
    call  ExitProcess
    
    ;write your code here
    xor rax, rax
    ret