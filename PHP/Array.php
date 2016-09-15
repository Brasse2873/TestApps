<?php
$indexArrayInt = array(10,20,30);
print_r($indexArrayInt);
echo "<br>";

$indexArrayString = array('hej','hopp');
print_r($indexArrayString);
echo "<br>";



$associativeArray = array(1=>'Monday',2=>'Tuesday');
print_r($associativeArray);
echo "<br>";

$arr2 = array('Key1'=>'01234679','Key2'=>'987654321');
print_r($arr2);
echo "<br>";


// Loop array
$arr = array( 'KEY1'=>'VALUE1', 'KEY2'=>'VALUE2','KEY3'=>'VALUE3' );  
while ($item = current($arr)) 
{
	echo key($arr).", Value:$item<br>";
    next($arr);
}

?>