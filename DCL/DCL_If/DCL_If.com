$! compare integers 
$! ----------------
$  intVal = 5
$  if (intVal .eq. 5)
$  then
$  	write sys$output "intVal:''intVal', = 5"
$  else
$  	write sys$output "intVal:''intVal', != 5"
$  endif
$!
$! compare strings (add a s to above operators)
$! ---------------
$  strVal = "string"
$  if (strVal .eqs. "string" )
$  then
$       write sys$output "strVal:''strVal', = string"
$  else
$       write sys$output "strVal:'strVal', != string"
$  endif
$!
$! one line statement
$  if intVal .eq. 5 then write sys$output "intVal equal to 5
!
$  write sys$output "== !=     .eq. .ne. .eqs. .nes."
$  write sys$output "< <=      .lt. .le. .lts. .les."
$  write sys$output "> >=      .gt. .ge. .gts. .ges."
$  write sys$output "AND OR    .and. .or."
$  write sys$output ".not."