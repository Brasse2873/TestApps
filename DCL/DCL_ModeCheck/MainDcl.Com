$   SAY         = "write sys$output"
$   verifyBefore = f$verify(1)
$   say "MainDcl Start: Mode=''f$mode()'"
$   gosub GOSUB_SUB
$   call CALL_SUB
$   gosub SUBDCL_SUB
$   goto EXIT
$!
$   GOSUB_SUB:
$       say "GOSUB_SUB: Mode=''f$mode()'"
$       return 
$!
$   CALL_SUB: subroutine
$       say "CALL_SUB: Mode=''f$mode()'"
$       endsubroutine 
$!
$   SUBDCL_SUB:
$       @[.tmp]SubDcl
$       return 
$!
$   EXIT:
$   dummy = f$verify(verifyBefore)
