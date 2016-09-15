$    verifyCurrent = p1
$    verifyBefore = f$verify(verifyCurrent)
$    SAY         = "write sys$output"
$    @test_def
$    say "TESTDEFINE_GROUP=''F$TRNLNM("TESTDEFINE_GROUP")'"
$    say "TESTDEFINE_PROCESS=''F$TRNLNM("TESTDEFINE_PROCESS")'"
$    say "TESTDEFINE_EMPTY=''F$TRNLNM("TESTDEFINE_EMPTY")'"
$    exit f$verify(verifyBefore)
