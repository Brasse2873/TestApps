$ verify = 'f$verify(p1)
$ say = "write sys$output"
$ tempFile	= "sys$scratch:tmp.txt"
$ dummy = f$verify(0)
$ define sys$output 'tempFile'
$ dir 'P2' /col=1/noheading/notrailing
$ DEASSIGN SYS$OUTPUT
$ dummy = f$verify(p1)
$ type 'tempFile'
$ if f$search(tempFile)	.nes. "" then delete/NOlog 'tempFile';*
$ dummy = f$verify(verify)
$ say " "
$ say " "
$ say "Finish"
$ EXIT: