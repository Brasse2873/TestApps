$ set NOON
$ write sys$output "main"
$!
$ call subroutin1
$ write sys$output "Return value subroutin1: ''$Status'"
$!
$ call subroutin2 1 "par2"
$ write sys$output "Return value subroutin2: ''$Status'"
$!
$ intVal = 1
$ stringVal = "Hej hopp 1"
$ call subroutine3 intVal stringVal
$ write sys$output "Return value subroutin3: ''$Status'"
$!
$ intVal = 2
$ stringVal = "Hej hopp 2"
$ call subroutine3 'intVal' 'stringVal'
$ write sys$output "Return value subroutin3: ''$Status'"
$!
$ intVal = 3
$ call subroutine4 intVal 
$ write sys$output "Return value subroutin4: ''$Status' , intVal = ''intVal'"
$ goto exit
$!
$!
$!
$!
$!
$ subroutin1: subroutine
$     write sys$output ""
$     write sys$output "subroutin1"
$ endsubroutine
$!
$ subroutin2: subroutine
$     write sys$output ""
$     write sys$output "subroutin2: parameter 1=''P1', parameter 2=''P2'"
$     exit 2
$ endsubroutines
$!
$ subroutine3: subroutine
$     write sys$output ""
$     write sys$output "subroutine3: parameter 1=''P1', parameter 2=''P2'"
$     write sys$output "subroutine3: parameter 1=" + P1 + ", parameter 2=" + P2
$     write sys$output "subroutine3: parameter 1=" + 'P1' + ", parameter 2=" + 'P2'
$     exit 2
$ endsubroutines
$!
$ subroutine4: subroutine
$     write sys$output ""
$     write sys$output "subroutine4: parameter 1" 
$     write sys$output P1
$     write sys$output 'P1'
$     'P1' = 33
$ endsubroutines
$ exit:
$ write sys$output "finish"