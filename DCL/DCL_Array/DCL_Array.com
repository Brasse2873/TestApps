$  ix = 0
$  array_0 = "Index 0"
$  array_1 = "Index 1"
$  array_2 = "Index 2"
$  array_3 = "Index 3"
$  array_4 = "Index 4"
$startLoop:
$  if 'ix' .eq. 5 then goto endLoop
$  currString = array_'ix'
$  write sys$output "Value at array index ''ix': ''currString'"
$  ix = ix + 1
$  goto startLoop
$endLoop: