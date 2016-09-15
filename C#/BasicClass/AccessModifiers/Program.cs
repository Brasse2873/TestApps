using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Public class member access
            //--------------------------
            publicClass publicCls = new publicClass();
            int var;
            var = publicCls.publicVar;
            var = publicCls.internalVar;
            // var = publicCls.privateVar;      Går ej
            // var = publicCls.protectedVar;    Går ej
            var = publicCls.protectedInternalVar;





            //Internal class member access
            //----------------------------
            var = publicCls.publicVar;
            var = publicCls.internalVar;
            // var = publicCls.privateVar;      Går ej
            // var = publicCls.protectedVar;    Går ej
            var = publicCls.protectedInternalVar;





            //private/protected class member access
            //-------------------------------------
            nestedClass nestedCls = new nestedClass();
            //var = nestedCls.privateCls.publicVar; Går ej
            nestedCls.touchPrivateClass();
            nestedCls.touchProtectedClass();
            nestedCls.touchProtectedInternalClass();




            //Inheritance
            //----------
            derivedPublicClass derivedPublicCls = new derivedPublicClass();
            var = derivedPublicCls.publicVar;
            var = derivedPublicCls.internalVar;
            // var = derivedPublicCls.privateVar;      Går ej
            // var = derivedPublicCls.protectedVar;    Går ej
            var = derivedPublicCls.protectedInternalVar;
            var = derivedPublicCls.getBaseProtectedVar();

        }
    }

    public class publicClass
    {
        public publicClass()
        { 
            publicVar = 1;
            privateVar = 2;
            internalVar = 3;
            protectedVar = 4;
            protectedInternalVar = 5;
        }

        public int publicVar;
        private int privateVar;
        internal int internalVar;
        protected int protectedVar;
        protected internal int protectedInternalVar;
    }

    internal class internalClass
    {
        public internalClass()
        { 
            publicVar = 1;
            privateVar = 2;
            internalVar = 3;
            protectedVar = 4;
            protectedInternalVar = 5;
        }

        public int publicVar;
        private int privateVar;
        internal int internalVar;
        protected int protectedVar;
        protected internal int protectedInternalVar;
    }


    /*Följande är inte OK eftersom ingen kan skapa objectet
    private class privateClass 
    {
    }
    protected class protectedClass
    { 
    }
    protected internal class protectedInternalClass
    {
    }
    */

    public class nestedClass
    {
        private privateClass privateCls;
        protected protectedClass protectedCls;
        protected internal protectedInternalClass protectedInternalCls;

        public nestedClass()
        {
            privateCls = new privateClass();
            protectedCls = new protectedClass();
            protectedInternalCls = new protectedInternalClass();
        }

        public void touchPrivateClass()
        {
            privateCls.publicVar = 11;
            privateCls.internalVar = 12;
            //privateCls.privateVar = 13;        Går ej
            //privateCls.protectedVar = 14;      Går ej
            privateCls.protectedInternalVar = 15;
        }

        public void touchProtectedClass()
        {
            protectedCls.publicVar = 21;
            protectedCls.internalVar = 22;
            //protectedCls.privateVar = 23;        Går ej
            //protectedCls.protectedVar = 24;      Går ej
            protectedCls.protectedInternalVar = 25;
        }

        public void touchProtectedInternalClass()
        {
            protectedInternalCls.publicVar = 31;
            protectedInternalCls.internalVar = 32;
            //protectedInternalCls.privateVar = 33;        Går ej
            //protectedInternalCls.protectedVar = 34;      Går ej
            protectedInternalCls.protectedInternalVar = 35;
        }

        private class privateClass
        {
            public int publicVar;
            private int privateVar;
            internal int internalVar;
            protected int protectedVar;
            protected internal int protectedInternalVar;
        }

        protected class protectedClass
        {
            public int publicVar;
            private int privateVar;
            internal int internalVar;
            protected int protectedVar;
            protected internal int protectedInternalVar;
        }

        protected internal class protectedInternalClass
        {
            public int publicVar;
            private int privateVar;
            internal int internalVar;
            protected int protectedVar;
            protected internal int protectedInternalVar;
        }
    }


    public class derivedPublicClass : publicClass
    { 
        public int getBaseProtectedVar() 
        {
            return protectedVar;
        }
    }
}
