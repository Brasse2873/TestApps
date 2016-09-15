$ verify = 'f$verify(p1)
$ say = "write sys$output"
$ say "open file ''P2'"
$ open/read file 'P2'
$ say "file open"
$ startReadFileLoop:
$	read/end=endReadFileLoop  file   line
$	say "''line'"
$	goto startReadFileLoop
$ endReadFileLoop:
$ say "finish reading"
$ close file
$ EXIT: