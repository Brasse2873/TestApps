#!/bin/bash
#
# array app
#

TestCase=0


Main()
{

	echo "Declare and Initialize"
	#====================================

	# Declare
	#------------------------------------
	declare -a arr1

	# Initialize
	#------------------------------------
	arr1=( a b c d e )

	# Declare and Initialize 
	#------------------------------------
	arr2=( zero one two three )
	arr3=( [0]=1 [1]=2 [2]=3 )





	echo "Get values from array"
	#====================================

	# Get value
	#------------------------------------
	NextTestCase
	itemValue=${arr1[0]}		#{curly brackets} needed
	echo "$TestCase: arr1[0]=$itemValue"

	# Get all items
	#------------------------------------
	NextTestCase
	itemsArr1=${arr1[@]}
	echo "$TestCase: itemsArr1=$itemsArr1"
	NextTestCase
	itemsArr2=${arr2[*]}
	echo "$TestCase: itemsArr2=$itemsArr2"


	echo "Set items to array"
	#====================================
	# Update item
	arr1[0]=A				#zero-based indexing 
	echo "$TestCase: itemsArr1=${arr1[@]}"

	# Add item
	#------------------------------------
	NextTestCase
	arr1[5]=f
	echo "$TestCase: itemsArr1=${arr1[@]}"
	NextTestCase
	arr1[${#arr1[@]}]="new"	#Add element to the end of array
	echo "$TestCase: itemsArr1=${arr1[@]}"
	NextTestCase
	arr2[7]=seven				#Array members need not be consecutive or contiguous
	echo "$TestCase: itemsArr2=${arr2[@]}"




	echo "Get size/length"
	#====================================
	NextTestCase
	arrSize=${#arr1[@]}	
	echo "$TestCase: Number of elements in arr1=$arrSize"
	NextTestCase
	lenItem=${#arr2[0]}			#Length of first element
	echo "$TestCase: Length of first element in arr2=$lenItem"



	echo "Iterate array"
	#====================================
	NextTestCase
	for item in "${arr1[@]}"
	do
		echo "$TestCase: arr1[$index]=$item"
	done
	NextTestCase
	for (( ix=0 ; ix<${#arr1[@]} ; ix++ ))
	do
		echo "$TestCase: arr1[$ix]=${arr1[$ix]}"
	done


	echo "Remove item"
	#====================================
	NextTestCase
	unset arr1[1]
	echo "$TestCase: itemsArr1=${arr1[@]}"

	NextTestCase
	unset arr1[${#arr1[@]}-1]	#Remove last item
	echo "$TestCase: itemsArr1=${arr1[@]}"
	
}

NextTestCase()
{
	((TestCase++))	#same as: TestCase=`expr $TestCase + 1`
}


Main
