$ dummy = f$verify(1)
$ SAY   = "write sys$output"
$ PathFile = "disk_1:[000000]#fil.txt"
$ Path = f$element(0,"#",PathFile)
$ File = f$element(1,"#",PathFile)
$ say "Path=''Path', File=''File'"
$ fileName = f$search("*.*")
$ fileNoVersion = f$element(0,";",fileName)
$ fileNoVerNoVer = f$element(0,";",fileNoVersion)
$ say "fileName=''fileName',  fileNoVersion=''fileNoVersion',  fileNoVerNoVer=''fileNoVerNoVer'"
$ dummy = f$verify(0)
