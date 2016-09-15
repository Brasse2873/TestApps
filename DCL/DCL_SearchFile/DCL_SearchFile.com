$ dummy = f$verify(1)
$ say = "write sys$output"
$ startFileLoop:
$     filePathName = f$search("*.*",1)
$     if ("''filePathName'" .EQS. "") then goto endFileLoop
$     say "File name: ''filePathName' "
$     fileNoVersion=f$element(0,";",filePathName)
$     say "File no version: ''fileNoVersion' "
$     goto startFileLoop
$ endFileLoop:
$!
$ say "Test how ' works with search" 
$ fileName = "DCL_SearchFile.com"
$ filePath = "te_usr:[schererm.tmp]"
$ filePathName = ""
$ filePathName = f$search(fileName)
$ say "Test1: Returned value ''filePathName'"
$ filePathName = ""
$ filePathName = f$search('fileName')
$ say "Test2: Returned value ''filePathName'"
$ filePathName = ""
$ filePathName = f$search("''fileName'")
$ say "Test3: Returned value ''filePathName'"
$ dummy = f$verify(0)


