$   gosub INITIALIZE_SUB
$ MENU_CLEAR:
$   say ClearScreen
$   say   "1: Menu choice 1 desciption"
$   say   "2: Menu choice 2 desciption"
$   say   "X: Tillbaka till föregående meny  		[ctrl+Z]"
$   read/end=EXIT/prompt="Välj alternativ :" sys$command menu_choice
$   menu_choice = F$edit("''menu_choice'","upcase")
$   if menu_choice .eqs. "" 	then goto MENU_CLEAR
$   if menu_choice .eqs. "X" 	then goto EXIT
$   say ClearScreen
$   say "Selected menu choice=''menu_choice'"
$   pause
$   goto MENU_CLEAR
$
$ EXIT:
$   exit
$!
$!
$!
$!
$!
$ INITIALIZE_SUB:
$   say 	                = "write sys$output"
$   ESC 		            = ""
$   CSI 		            = "''ESC'["
$   ClearScreen             = "''CSI'2J"
$   pause		            = "if f$mode() .eqs. ""INTERACTIVE"" then read/end=EXIT /prompt=""Press return to continue "" sys$command dummy"
$   begin_normal_rendition  = "''CSI'0m"
$   double_high_top         = "''ESC'#3"
$   double_high_bottom      = "''ESC'#4"
$   return
