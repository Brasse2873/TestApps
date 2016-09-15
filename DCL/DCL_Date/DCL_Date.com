$ verify = f$verify(1)
$ say = "write sys$output"
$ say "F$time()                      return: ''F$time()'"
$ say "F$cvtime()                    return: ''F$cvtime()'"
$ say "F$cvtime(,,YEAR)              return: ''F$cvtime(,,"YEAR")'"
$ say "F$cvtime(,,MONTH)             return: ''F$cvtime(,,"MONTH")'"
$ say "F$cvtime(,,DAY)               return: ''F$cvtime(,,"DAY")'"
$ say "F$cvtime(,,TIME)              return: ''F$cvtime(,,"TIME")'"
$ say "F$cvtime(,ABSOLUT)            return: ''F$cvtime(,"ABSOLUTE")'"
$ say "F$cvtime(,ABSOLUT,YEAR)       return: ''F$cvtime(,"ABSOLUTE","YEAR")'"
$ say "F$cvtime(,ABSOLUT,MONTH)      return: ''F$cvtime(,"ABSOLUTE","MONTH")'"
$ say "F$cvtime(,ABSOLUT,DAY)        return: ''F$cvtime(,"ABSOLUTE","DAY")'"
$ say "F$cvtime(,ABSOLUT,TIME)       return: ''F$cvtime(,"ABSOLUTE","TIME")'"
$!
$! Convert absolute - delta
$ deltaTime = f$cvt()
$ say "To absolute: ''deltaTime' -> ''f$cvt( 00 + deltaTime,"ABSOLUTE")'"
$ absoluteTime = f$cvt(,"ABSOLUTE")
$ say "To delta: ''absoluteTime' -> ''f$cvt( absoluteTime )' "
$!
$! Current month
$ say "Current month: ''f$cvt( f$cvt(,"ABSOLUTE"),"ABSOLUTE","MONTH" )'"
$!
$! Current Year
$ say "Current year: ''f$cvt( f$cvt(,"ABSOLUTE"),"ABSOLUTE","YEAR" )'"
$!
$! Next month
$ firstOfThisMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ say "next month: ''f$cvt( firstOfThisMonth + "+31-","ABSOLUTE","MONTH" )'"
$!
$! Year of next month
$ firstOfThisMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ say "Year of next month: ''f$cvt( firstOfThisMonth + "+31-","ABSOLUTE","YEAR" )'"
$!
$! Previous month
$ firstOfThisMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ say "Prev month: ''f$cvt( firstOfThisMonth + "-1-","ABSOLUTE","MONTH" )'"
$!
$! Year of prevous month
$ firstOfThisMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ say "Year of prev month: ''f$cvt( firstOfThisMonth + "-1-","ABSOLUTE","YEAR" )'"
$!
$! Time and date aritmetics
$! ------------------------
$ now = f$cvt(,"ABSOLUTE")
$ say "+1 day: ''f$cvt( now + "+1-","ABSOLUTE")'"
$ say "+7 days: ''f$cvt( now + "+7-","ABSOLUTE")'"
$ say "+1 hour: ''f$cvt( now + "+1:","ABSOLUTE")'"
$ say "+1 minute: ''f$cvt( now + "+:1","ABSOLUTE")'"
$ say "-1 day: ''f$cvt( now + "-1-","ABSOLUTE")'"
$ say "-7 days: ''f$cvt( now + "-7-","ABSOLUTE")'"
$ say "-1 hour: ''f$cvt( now + "-1:","ABSOLUTE")'"
$ say "-1 minute: ''f$cvt( now + "-:1","ABSOLUTE")'"
$!
$! Specific hour and minutes
$! ------------------------
$ say "01:30:00 today: ''f$cvt( "TODAY" + "+1:30","ABSOLUTE")'"
$ say "01:30:00 yesterday: ''f$cvt( "YESTERDAY" + "+1:30","ABSOLUTE")'"
$ say "01:30:00 tomorrow: ''f$cvt( "TOMORROW" + "+1:30","ABSOLUTE")'"
$ say "01:30:00 +3 days: ''f$cvt( "TODAY" + "+3-1:30","ABSOLUTE")'"
$!
$! Last day current month
$! -----------------------
$ firstOfCurrentMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ nextMonth = f$cvt( firstOfThisMonth + "+31-","ABSOLUTE")'"
$ lastDayCurrentMonth = f$cvt( nextMonth + "-''f$cvt(nextMonth,"ABSOLUTE","DAY")'-" ,"ABSOLUTE")'"
$ say "Last day current month: ''lastDayCurrentMonth'"
$!
$! Last day previous month
$! -----------------------
$ firstOfCurrentMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ say "Last day prev month: ''f$cvt(firstOfCurrentMonth + "-1-","ABSOLUTE")'"
$!
$! Last day 3 month ago
$! --------------------
$ firstOfCurrentMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$ someDayOfMonthTwoMonthAgo = "''f$cvt(firstOfCurrentMonth + "-84-","ABSOLUTE")'" !28*2
$ lastDayOfMonthThreeMonthAgo = f$cvt( someDayOfMonthTwoMonthAgo + "-''f$cvt(someDayOfMonthTwoMonthAgo,"ABSOLUTE","DAY")'-" ,"ABSOLUTE")
$ say "Last day3 month ago: ''lastDayOfMonthThreeMonthAgo'"
$!
$! Day of week
$! -----------------------
$ say "Day of week: ''f$cvt("today","ABSOLUTE","WEEKDAY")'"
$!
$! Misc
$! -----------------------
$ say "f$cvtime(,,date)- - - -       return: ''f$cvtime(,,"date")-"-"-"-"' "
$ say "yyyymmdd format: ''f$cvtime(,,"YEAR")'''f$cvtime(,,"MONTH")'''f$cvtime(,,"DAY")' "
$ say "previous day: f$cvtime(YESTERDAY,ABSOLUTE,DATE)      return: ''F$cvtime("YESTERDAY","ABSOLUTE","DATE")' "
$ say "previous day: Format:dd_MMM_yyyy  return: ''F$cvtime("YESTERDAY","ABSOLUTE","DAY")'_''F$cvtime("YESTERDAY","ABSOLUTE","MONTH")'_''F$cvtime("YESTERDAY","ABSOLUTE","YEAR")'"

$!
$       firstOfThisMonth = "01-''f$cvt("today","ABSOLUTE","MONTH")'-''f$cvt("today","ABSOLUTE","YEAR")'"
$       dayInMonthToKeepUncompressed = "''f$cvt(firstOfCurrentMonth + "-84-","ABSOLUTE")'" !28*3
$       dayInMonthToKeepUnbackuped = "''f$cvt(firstOfCurrentMonth + "-168-","ABSOLUTE")'" !28*6
$       firstDayToKeepUncompressed = "01-''f$cvt(dayInMonthToKeepUncompressed,"ABSOLUTE","MONTH")'-''f$cvt(dayInMonthToKeepUncompressed,"ABSOLUTE","YEAR")'"
$       firstDayToKeepUnbackuped = "01-''f$cvt(dayInMonthToKeepUnbackuped,"ABSOLUTE","MONTH")'-''f$cvt(dayInMonthToKeepUnbackuped,"ABSOLUTE","YEAR")'"
$!


$ verify = f$verify(0)