<?php
$myString = 'This is my string';
echo "myString=$myString<br>";

//Length of string
echo 'Length of myString is' . strlen($myString) . "<br>";

//Find character or substring
$posSubString = strpos($myString,'my');
echo "my can be found on pos $posSubString<br>";

?>