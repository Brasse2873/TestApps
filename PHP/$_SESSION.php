<?php
//$_SESSION -— Session variables
echo '$_SESSION' . "<br>";

session_start();
print_r($_SESSION);
echo "<br><br>";

while ($item = current($_SESSION) )
{
	echo key($_SESSION)."     , Value:$item<br>";
	next($_SESSION);
}
