<?php

//Global scoop
$stringVar = 'This is a global string';
$intVar = 1964;
$globalString = 'This is another global string';

echo "stringVar: $stringVar, intVar:$intVar<br>";


//All global variables
print_r($GLOBALS);


function func()
{
	//Local scoop
	$stringVar = 'This is a local string';
	echo "stringVar:$stringVar<br>";
	
	//Global string
	echo "globalString in func():$globalString<br>"; //Give an error
	global $globalString;
	echo "globalString in func():$globalString<br>";
	echo 'globalString in func() without global keyword:' . $GLOBALS["globalString"] . "<br>";
}

function funcWithStaticVar()
{
	static $staticVar = 0;
	$staticVar++;
	echo 'staticVar in funcWithStaticVar():' . $staticVar . "<br>";
}

func();
echo "stringVar after func(): $stringVar<br>";

funcWithStaticVar();
funcWithStaticVar();





?>