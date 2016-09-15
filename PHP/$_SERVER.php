<?php
//$_SERVER — Server and execution environment information
echo '$_SERVER[]' . "<br>";
while ($item = current($_SERVER) )
{
	echo key($_SERVER)."     , Value:$item<br>";
	next($_SERVER);
}

?>