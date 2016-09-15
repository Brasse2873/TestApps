#!/bin/bash
#
# String app
#

#Declare and initialize
str1="Hej"

#String length
str1Len=${#str1}

printf "str1=%s, len=%d\n" $str1 $str1Len


#Concatenate strings
str2="hopp"
message="$str1 $str2"
printf "$message\n"

message+="."
printf "$message\n"



#Print string with fixed length
printf "%-20s Col2\n" $str1
printf "%-20s Col2\n" $message