
//[[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"tel:**61*+46252708759681#"]];
[[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"tel:%2A%2A61%2A+46252708759681%23"]];


/*
telephone-url         = telephone-scheme ":"
                        telephone-subscriber
telephone-scheme      = "tel"
telephone-subscriber  = global-phone-number / local-phone-number
global-phone-number   = "+" base-phone-number [isdn-subaddress]
                        [post-dial] *(area-specifier /
                        service-provider / future-extension)
base-phone-number     = 1*phonedigit
local-phone-number    = 1*(phonedigit / dtmf-digit /
                        pause-character) [isdn-subaddress]
                        [post-dial] area-specifier
                        *(area-specifier / service-provider /
                        future-extension)
isdn-subaddress       = ";isub=" 1*phonedigit
post-dial             = ";postd=" 1*(phonedigit /
                        dtmf-digit / pause-character)
area-specifier        = ";" phone-context-tag "=" phone-context-ident
phone-context-tag     = "phone-context"
phone-context-ident   = network-prefix / private-prefix
network-prefix        = global-network-prefix / local-network-prefix
global-network-prefix = "+" 1*phonedigit
local-network-prefix  = 1*(phonedigit / dtmf-digit / pause-character)
private-prefix        = (%x21-22 / %x24-27 / %x2C / %x2F / %x3A /
                        %x3C-40 / %x45-4F / %x51-56 / %x58-60 /
                        %x65-6F / %x71-76 / %x78-7E)
                        *(%x21-3A / %x3C-7E)
*/