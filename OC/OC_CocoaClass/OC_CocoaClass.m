
#import "OC_CocoaClass.h"


@implementation OC_CocoaClass

@syntersize numberVar, intVal;

- (Id)Init
{
	if( self = [super init] )
	{
		numberVar = [NSNumber numberWithInteger:0];
		intVal = 0;
	}
	return self;
}

@end
