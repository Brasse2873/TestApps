$ write sys$output "''F$extract(0,4,"123456789")'"
$ string1 = "text_id"
$ string2 = "text_"
$ string3 = f$extract( f$length(string2), f$length(string1)-f$length(string2), string1)
$ write sys$output "''string3'"