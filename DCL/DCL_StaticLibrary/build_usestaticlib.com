$ cc c_usestaticlib.c
$ link c_usestaticlib.obj ,c_staticlib.olb/library