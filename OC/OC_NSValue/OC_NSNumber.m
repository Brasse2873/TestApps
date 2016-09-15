
#import <foundation/foundation.h>

void printValue( NSNumber *number )
{
	NSLog(@"%@: Value = %@, type = %s", number, [number stringValue], [number objCType] );
}

void testCreateNSNumber()
{
	NSNumber *number;

	number = [NSNumber numberWithBool:NO];

	number = [NSNumber numberWithChar:'A'];

	number = [NSNumber numberWithDouble:MAXDOUBLE];

	number = [NSNumber numberWithFloat:2.0];

	number = [NSNumber numberWithInt:NSIntegerMax];

	number = [NSNumber numberWithInteger:NSIntegerMax];

	number = [NSNumber numberWithLong:-3];

	number = [NSNumber numberWithLongLong:-4];

	number = [NSNumber numberWithShort:0];

	number = [NSNumber numberWithUnsignedChar:0x0];

	number = [NSNumber numberWithUnsignedInt:NSUIntegerMax];

	number = [NSNumber numberWithUnsignedInteger:NSUIntegerMax];

	number = [NSNumber numberWithUnsignedLong:0];

	number = [NSNumber numberWithUnsignedLongLong:0];
}

void testNSNumberAddition()
{
	NSNumber *num1;
	NSNumber *num2;

}

void testNSSubraction()
{
}

void testNSNumber()
{
	testCreateNSNumber();
	testNSNumberAddition();
	testNSNumberSubtaction();
}

int main( int argc, char *argv[] )
{
	Test_NSNumber();
}

