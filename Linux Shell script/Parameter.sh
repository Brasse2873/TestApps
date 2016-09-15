#
# parameter app
#

noPars=$#

echo "Number of parameters: $noPars"

echo "Par 0: $0"

if [ $noPars -gt 0 ] ; then	
	echo "Par1 :$1"; 
fi

if [ $noPars -gt 1 ] ; then	
	echo "Par2 :$2"; 
fi

if [ $noPars -gt 2 ] ; then	
	echo "Par3 :$3"; 
fi
