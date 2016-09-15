#!/bin/bash
#
# Menu app
#
Main()
{
	PrintMenu
}

PrintMenu()
{
	declare -a MenuItems=( '' '' '' '' '' '' '' '' '' '' ) 
	
	printf "============================\n"
	printf "|    Header                |\n"
	printf "============================\n"
	printf "============================\n"
	printf "|    Footer                |\n"
	printf "============================\n"
}


Main
