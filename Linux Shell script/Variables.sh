#
# User varialbles
#


# Integer
# ======= 
intVar=1
echo "intVar =$intVar"

intVar2=10
echo "intVar2 =$intVar2"

sumVar=`expr $intVar + $intVar2`
echo "intVar + intVar2 = $sumVar"


# String
# ======
stringVar1="This is stringVar1 content"
echo "stringVar1 =$stringVar1"

stringVar2='This is stringVar2 content'
echo "stringVar2 =$stringVar2"

stringCat="$stringVar1 $stringVar2"
echo "stringCat =$stringCat"

# Local variables
#================
func1()
{
	local localVar="Local Var"
	globalVar="Global Var"
}

func1
echo "localVar :$localVar"
echo "globalVar :$globalVar"
