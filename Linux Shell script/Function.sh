#!/bin/bash
#
# Funcion app
#

echo "Start of script"

echo -e "\nApplication arguments"
echo "No args :$#"
echo "arg 0: $0"
echo "args: $@"

Main()
{
	echo "main()"
	
	SimpleFunc
	
	FuncWith3Argumets 1 2 3
	
	FuncWithResult
	result = $?
	echo "result = $result"
}

SimpleFunc()
{
	echo "SimpleFunc()"
}


FuncWith3Argumets()
{
	par1=$0
	par2=$1
	par3=$2
	
	echo "FuncWith3Argumets()"
	echo "args: $@"
	printf "\tNo args:%d\n" $#
	printf "\targ: 0=%s, 1=%s, 2=%s\n" $par1 $par2 $par3
}


FuncWithResult()
{
	echo "funcWithReturnValue"
	return 1
}

Main

