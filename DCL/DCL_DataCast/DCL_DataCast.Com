$ verify = f$verify(1)
$ say = "write sys$output"
$ X = F$Integer( "12" )
$ Y = F$Integer( "10" )
$ Z = X + Y
$ say "''X' + ''Y' = ''Z'"
$ verify = f$verify(0)