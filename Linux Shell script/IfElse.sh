#
# if else app
#

noPars=$#

echo "Test simple IF with test"
if test $noPars -eq 0
then
	echo "No arguments given"
fi


echo -e "\nTest simple IF with []"
if [ $noPars -eq 0 ]
then
	echo "No arguments given"
fi


echo -e "\nTest simple nested IF"
if [ $noPars -eq 0 ]; then
	echo "Zero arguments"
else
	if [ $noPars -eq 1 ]; then
		echo "One argument"
	else
		echo "$noPars number of arguments"
	fi
fi

echo -e "\nTest simple IF/ELIF"
if [ $noPars -eq 0 ]; then
	echo "Zero arguments"
elif [ $noPars -eq 1 ]; then
	echo "One argument"
elif [ $noPars -eq 2 ]; then
	echo "Two argument"
else
	echo "$noPars number of arguments"
fi
