#import <UIKit/UIKit.h>

@interface OU_CocoaClass : NSObject
{
	int			intVar;
	NSNumber	*numberVar;
}

property ( nonatomic, retain ) NSNumber *numberVar;
property int intVar;

- (Id)Init;

@end

