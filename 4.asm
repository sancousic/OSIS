.model small 
.stack 1000 
.data 
old dd 0 
sss db 256 dup('$') 
vOldInt LABEL WORD 
.code 
.486 
count dw 0 ;Счетчик гласных букв 
flag dw 0 

new_handle proc 
push ds si es di dx cx bx ax 


xor ax, ax 
in al, 60h ;Получаем скан-код символа 

cmp al, 2Ah 
je ti 
cmp al, 0AAh 
je to 

cmp al, 10h ;Сравниваем код с кодом буквы q
mov dl, 'r' 
je new_handler 
cmp al, 11h ;Сравниваем код с кодом буквы w
mov dl, 'x' 
je new_handler 
cmp al, 13h ;Сравниваем код с кодом буквы r 
mov dl, 's' 
je new_handler 
cmp al, 14h ;Сравниваем код с кодом буквы t
mov dl, 'u' 
je new_handler 
cmp al, 19h ;Сравниваем код с кодом буквы p
mov dl, 'q' 
je new_handler 
cmp al, 1Fh ;Сравниваем код с кодом буквы s 
mov dl, 't' 
je new_handler 
cmp al, 20h ;Сравниваем код с кодом буквы d
mov dl, 'e' 
je new_handler 
cmp al, 21h ;Сравниваем код с кодом буквы f 
mov dl, 'g' 
je new_handler 
cmp al, 22h ;Сравниваем код с кодом буквы g
mov dl, 'h' 
je new_handler 
cmp al, 23h ;Сравниваем код с кодом буквы h
mov dl, 'i' 
je new_handler 

cmp al, 24h ;Сравниваем код с кодом буквы j
mov dl, 'k' 
je new_handler 
cmp al, 25h ;Сравниваем код с кодом буквы k
mov dl, 'l' 
je new_handler 
cmp al, 26h ;Сравниваем код с кодом буквы l
mov dl, 'm' 
je new_handler 
cmp al, 2Ch ;Сравниваем код с кодом буквы z
mov dl, 'a' 
je new_handler 
cmp al, 2Dh ;Сравниваем код с кодом буквы x
mov dl, 'y' 
je new_handler 
cmp al, 2Eh ;Сравниваем код с кодом буквы c
mov dl, 'd' 
je new_handler 
cmp al, 2Fh ;Сравниваем код с кодом буквы v
mov dl, 'w' 
je new_handler 
cmp al, 30h ;Сравниваем код с кодом буквы b
mov dl, 'c' 
je new_handler 
cmp al, 31h ;Сравниваем код с кодом буквы n
mov dl, 'o' 
je new_handler 
cmp al, 32h ;Сравниваем код с кодом буквы m
mov dl, 'n' 
je new_handler 
jmp old_handler 
ti: 


;mov ah, 02h 
;MOV dl,'-' 
;int 21h 
mov flag, 1 
;je exit 
jmp old_handler 

to: 

; mov ah, 02h 
; MOV dl,'+' 
; int 21h 
mov flag, 0 
;je exit 
jmp old_handler 

new_handler: 

;inc count ;инкремент счетчика с каждой гласной буквой 

cmp flag, 1 
jne lb 

sub dl, 32 

lb: 

mov ah, 02h 
int 21h 

;mov ax, count 
mov BX, 1 
xor DX, DX 
div BX 
cmp DX, 0 


mov al, 20h 
out 20h, al 
je exit 

old_handler: 
pop ax bx cx dx di es si ds 
jmp dword ptr cs:old ;вызов стандартного обработчика прерывания 
xor ax, ax 
mov al, 20h 
out 20h, al 
jmp exit 

exit: 
xor ax, ax 
mov al, 20h 
out 20h, al 
pop ax bx cx dx di es si ds ;восстановление регистров перед выходом из нашего обработчика прерываний 
iret
new_handle endp 


new_end: 

start: 
mov ax, @data 
mov ds, ax 

cli ;сброс флага IF 
pushf 
push 0 ;перебрасываем значение 0 в DS 
pop ds 
mov eax, ds:[09h*4] 
mov cs:[old], eax ;сохранение системного обработчика 


;;;;;;; 
;; mov [vOldInt], bx 
;; mov [vOldInt+2], es 
;;;;;;; 

mov ax, cs 
shl eax, 16 
mov ax, offset new_handle 
mov ds:[09h*4], eax ;запись нового обработчика 
sti ;Установка флага IF 

; mov ah, 10 
; mov dx, offset sss 
; int 21h 

xor ax, ax 
mov ah, 31h 
MOV DX, (New_end - @code + 10FH) / 16 ;вычисление размера резидентной части в параграфах(16 байт) 
INT 21H 



end start