#
# Echo app
#


echo "Plain text examples"
echo "==================="
echo Hello
echo Multiple words without double quote
echo "Hello World, Double quote"
echo 'Hello World, Single quote'


echo "Text with variable examples"
echo "==========================="
intVar=10
echo "Variable intVar="
echo $intVar

echo "Variable name in double quote. intVar =$intVar"
echo 'Variable name in Single quote (variale not translated). intVar =$intVar'


echo "Variable in expression. intVar + 10 = `expr $intVar + 10`"


echo -e "Echo with 3 LF\n\n\n"


echo "Total args passed $#"
echo "All args (\$@) passed to me -\"$@\""
echo "All args (\$*) passed to me -\"$*\""

