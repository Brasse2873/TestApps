<?php


echo 'Include a file in root: ';
include($_SERVER['DOCUMENT_ROOT'].'/SampleInclude.php');
echo '<br>';

echo 'Include a file from one dir above current: ';
include('../SampleInclude.php');
echo '<br>';

echo 'Include a file in same directory as current: ';
include('./SampleInclude.php');
echo '<br>';

echo 'Include a file from a subdir of current file: ';
include('./SamplesSub/SampleInclude.php');
echo '<br>';

include('test.txt')

?>