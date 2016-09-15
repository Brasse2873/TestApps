$ verify = f$verify(p1)
$ say = "write sys$output"
$ tempFile	= "sys$scratch:tmp.txt"
$ dummy = f$verify(0)
$ define sys$output 'tempFile'
$ search 'P2' "''P3'"
$ DEASSIGN SYS$OUTPUT
$ dummy = f$verify(p1)
$ say "type ''tempFile':"
$ type 'tempFile'
$ if f$search(tempFile)	.nes. "" then delete/NOlog 'tempFile';*
$ if ( .not. $status ) then say "Line not found"
$ dummy = f$verify(verify)
$ say " "
$ say " "
$ say "Finish"
$ EXIT: