<?php

/* Skeleton
**********************************/
class classSkeleton
{
}


/* ctor/dtor
**********************************/
class classCtorDtor
{
	function __construct()
	{
		echo "classCtorDtor:__construct()<br>";
		echo 'this='; 
		var_dump($this);
		echo "<br>";
	}
	
	function __destruct()
	{
		echo "classCtorDtor:__destruct()<br>";
		echo 'this='; 
		var_dump($this);
		echo "<br>";
	}
}

/* Create object
**********************************/
$obj1 = new classCtorDtor;
$obj2 = new classCtorDtor;
unset($obj1);
unset($obj2);

/* Properties
**********************************/
class classProp
{
	private $privField;
	protected $protField;
	public $publField;
	function __construct()
	{
		$this->privField = 'Value privField';
		$this->protField = 'Value protField';
		$this->publField = 'Value publField';
	}
}
$obj1 = new classProp;
//Error echo "obj1->privField=$obj1->privField<br>";
//Error echo "obj1->protField=$obj1->protField<br>";
echo "obj1->publField=$obj1->publField<br>";



/* Method
**********************************/
class classMeth
{
	private function privMeth()
	{
		echo 'classMeth::privMeth()' . "<br>";
	}
	
	protected function protMeth()
	{
		echo 'classMeth::protMeth()' . "<br>";
	}
	
	public function publMeth()
	{
		echo 'classMeth::publMeth()' . "<br>";
	}
}
$obj1 = new classMeth;
//Error $obj1->privMeth();
//Error $obj1->protMeth();
$obj1->publMeth();

/* Inheritance
**********************************/
class classBase
{
	public function baseClassMethod()
	{	
		echo "baseClassMethod<br>";
	}
}

class classChild extends classBase
{
	public function childClassMethod()
	{	
		echo "childClassMethod<br>";
	}
}
$obj1 = new classChild;
$obj1->baseClassMethod();
$obj1->childClassMethod();
?>