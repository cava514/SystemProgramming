MB_DEFBUTTON2 EQU 100h
IDNO          EQU 7
MB_YESNO      EQU 4
section .data
    Height db 1
    Width db 1
    Format db "%lf", 0
    Square db "Square: %.lf", 0
    MessageBoxText    db "Do you want to exit?", 0
    MessageBoxCaption db "MessageBox 64", 0
section .text
extern scanf
extern printf
extern MessageBoxA
extern ExitProcess
global main
main:
    mov rbp, rsp; for correct debugging
    sub rsp, 40
    
    lea rcx, [Format]
    mov r8, [Height]
    call scanf
    
    lea rdx, [Format]
    mov r9, [Width]
    call scanf
    
    imul r8, r9
    
    lea rdx, [Square]
    mov r10, r8
    call printf
    
    add rsp, 40
    
    sub RSP, 40

    .DisplayMessageBox:
    xor   ECX, ECX
    lea   RDX, [REL MessageBoxText]
    lea   R8, [REL MessageBoxCaption]
    mov   R9D, MB_YESNO | MB_DEFBUTTON2
    call  MessageBoxA

    cmp   RAX, IDNO
    je    .DisplayMessageBox

    add   RSP, 32

    xor   ECX, ECX
    call  ExitProcess
    
    
    ;write your code here
    xor rax, rax
    ret