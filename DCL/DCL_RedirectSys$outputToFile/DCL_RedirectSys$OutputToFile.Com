$ verify = 'f$verify(1)
$ say = "write sys$output"
$ define sys$output Sys$OutputFile.txt
$ dir
$ deassign sys$output
$ verify = 'f$verify(0)
