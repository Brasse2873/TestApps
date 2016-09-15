$ verify = 'f$verify(1)
$ say = "write sys$output"
$ tmpFile = "Stat.txt"
$ define sys$output 'tmpFile'
$ sear /stat/exact/noout 'P1' "''P2'"
$ deassign sys$output
$ verify = 'f$verify(0)

