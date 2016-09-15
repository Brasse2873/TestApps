#
# Check Status app
#


echo "Current status value  :$?" 
rm blablafile.bla
rmStatus=$?
echo "rmStatus  :$rmStatus"

exit $rmStatus