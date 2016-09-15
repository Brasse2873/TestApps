$ gosub INITIALIZE_SUB
$ say ClearScreen
$ say   "''csi'1;16H" + begin_normal_rendition + double_high_top -
        + "Menu title" -
        + begin_normal_rendition
$ say   "''csi'2;16H" + begin_normal_rendition + double_high_bottom -
        + "Menu title" -
        + begin_normal_rendition
$ say   "''csi'5;24H1: Menu choice 1"
$ say   "''csi'6;24H2: Menu choice 2"
$ say   "''csi'22;24HX: Tillbaka till föregående meny  		[ctrl+Z]"
$!
$ INITIALIZE_SUB:
$ say 	                    = "write sys$output"
$ ESC 		                = ""
$ CSI 		                = "''ESC'["
$ ClearScreen               = "''CSI'2J"
$ begin_normal_rendition    = "''CSI'0m"
$ double_high_top           = "''ESC'#3"
$ double_high_bottom        = "''ESC'#4"
$ return
