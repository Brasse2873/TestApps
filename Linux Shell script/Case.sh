#
# Echo case app
#

clear
while true
do
	echo -e "\nSkriv en siffra mellan 1-9 och tryck ENTER (q to quit)"

	read CHOICE
	case $CHOICE in
		1) 	echo "Number one pressed";; 

		2) 
			echo "Number two pressed" ;;

		3) 
			echo "Number three pressed" 
			;;

		4|5) 
			echo "Fore or fiver pressed"
			;;

		#Must be ended with ;; following is not valid. Syntax error 6) 	echo "Six-"
		# 															7)  echo "Seven-";;
		q|Q) break;;
		*) 	echo "Not a number between 1-9";;
	esac
done
