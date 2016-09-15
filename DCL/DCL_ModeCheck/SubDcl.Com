$   SAY         = "write sys$output"
$   verifyBefore = f$verify(1)
$   say "SubDcl Start: Mode=''f$mode()'"
$   dummy = f$verify(verifyBefore)