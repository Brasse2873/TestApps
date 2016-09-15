@implementation PortraitViewController

- (id)init
{
   self = [super initWithNibName:@"PortraitView" bundle:nil];
   if (self)
   {
       isShowingLandscapeView = NO;
       self.landscapeViewController = [[[LandscapeViewController alloc]
                            initWithNibName:@"LandscapeView" bundle:nil] autorelease];
 
       [[UIDevice currentDevice] beginGeneratingDeviceOrientationNotifications];
       [[NSNotificationCenter defaultCenter] addObserver:self
                                 selector:@selector(orientationChanged:)
                                 name:UIDeviceOrientationDidChangeNotification
                                 object:nil];
   }
   return self;
}
 
- (void)orientationChanged:(NSNotification *)notification
{
    UIDeviceOrientation deviceOrientation = [UIDevice currentDevice].orientation;
    if (UIDeviceOrientationIsLandscape(deviceOrientation) &&
        !isShowingLandscapeView)
    {
        [self presentModalViewController:self.landscapeViewController
                                animated:YES];
        isShowingLandscapeView = YES;
    }
    else if (deviceOrientation == UIDeviceOrientationPortrait &&
             isShowingLandscapeView)
    {
        [self dismissModalViewControllerAnimated:YES];
        isShowingLandscapeView = NO;
    }
}


- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)orientation
{
   if ((orientation == UIInterfaceOrientationPortrait) ||
       (orientation == UIInterfaceOrientationLandscapeLeft))
      return YES;
 
   return NO;
}