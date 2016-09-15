$ cc c_staticlib.c
$ library /create c_staticlib.olb c_staticlib.obj