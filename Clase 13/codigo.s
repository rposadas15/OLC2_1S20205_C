.section .data
mensaje: .asciz "Hola alumnos de Compi 2\n"

.section .text
.global_start

_start: 
    mov x10, #5

bucle: 
    mov x0, #1
    ldr x1, =mensaje
    mov x2, #20
    mov x8, #64
    svc #0

    subs x10, x10, #1
    bne bucle

mov x8, #93
mov x0, #0
svc #0
