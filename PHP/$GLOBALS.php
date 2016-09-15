<?php
//$GLOBALS — References all variables available in global scope
echo '$GLOBALS' . "<br>";
print_r($GLOBALS);
echo "<br><br>";

while ($item = current($GLOBALS) )
{
	echo key($GLOBALS)."     , Value:$item<br>";
	next($GLOBALS);
}
