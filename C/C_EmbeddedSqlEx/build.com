$ esqlc createtable.sc
$ cc /FLOAT=IEEE_FLOAT createtable.c
$ link createtable.obj,ingsys:<ingres.files>esql.opt/opt
