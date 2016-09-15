$ verify = 'f$verify(p1)
$ period = P2
$ yyyy = f$extract(0,4,period)
$ mm   = f$extract(4,2,period)
$ bb   = f$extract(6,2,period)
$ monthList       	= "/jan/feb/mar/apr/may/jun/jul/aug/sep/oct/nov/dec"
$ mmm           	= f$element(mm,"/",monthList)
$ superseedDate    	= f$cvtime("''bb'-''mmm'-''yyyy'","absolute","date")
$ firstOfSuperseedDate = "01-''f$cvt(superseedDate,"ABSOLUTE","MONTH")'-''f$cvt(superseedDate,"ABSOLUTE","YEAR")'"
$ PrevMonthOfSuperseedDate = f$cvt( firstOfsuperseedDate + "-1-","ABSOLUTE","DATE" )
$ write sys$output "''PrevMonthOfSuperseedDate'"
$ iqcTableDate = f$cvt(PrevMonthOfSuperseedDate,,"YEAR") + f$cvt(PrevMonthOfSuperseedDate,,"MONTH") + "''bb'"
$ write sys$output "''iqcTableDate'"