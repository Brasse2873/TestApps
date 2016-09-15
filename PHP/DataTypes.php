<?php


/* String data type
==========================*/
$strVar1 = "This is a string";
$strVar2 = 'This is also a string';
echo 'strVar1 =' . $strVar1 . "<br>";
echo 'strVar2 =' . $strVar2 . "<br>";

/* Integer data type
==========================*/
$intVar = 1234;
var_dump($intVar);
echo "<br>";

$intVar = -1234;
var_dump($intVar);
echo "<br>";

$intVar = 0xABCD; //Hex value
var_dump($intVar);
echo "<br>";

$intVar = 0b0111; //Binary
var_dump($intVar);
echo "<br>";

//Max int
echo 'Integer size:' . PHP_INT_SIZE . "<br>";
echo 'Integer max:' . PHP_INT_MAX . "<br>";


/* Floating point data type
==========================*/

/* Boolean data type
==========================*/
$x=true;
$y=false;
var_dump($x);
echo "<br>";
var_dump($y);
echo "<br>";

/* Arrays
==========================*/
$cars=array("Volvo","BMW","Toyota");
var_dump($cars);
echo "<br>";
print_r($cars);
echo "<br>";


/* Class data type
==========================*/
class class1
{
	private $field1;
	function __construct()
	{
		$this->field1 = 'This is field1 in class class1';
	}
	
	public function method1()
	{
	
		echo "class1::method1():field1=$this->field1<br>";
		var_dump($this);
		echo "<br>";
	}
}
$obj1 = new class1();
$obj1->method1();

?>