$ esqlc esqltest.sc
$ cc /FLOAT=IEEE_FLOAT esqltest.c
$ link esqltest.obj,ingsys:<ingres.files>esql.opt/opt
