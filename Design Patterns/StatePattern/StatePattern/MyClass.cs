namespace StatePattern
{

    #region MyClass, Class with states
    public class MyClass
    {
        #region MyClass (Context) Implementation


        private MyStateBase state; //ToDo 2: Keep an instance of state base class
        private int modelData;

        public MyClass()
        {
            this.state = MyState1.Instance;
        }
        
        private void ChangeState( MyStateBase state ) //ToDo 3: Create a private method used by State objects to change state
        {
            this.state = state;
        }

        public int ModelData //Todo 9a: Make properties that can be used by State object to change context data
        {
            get {return modelData;}
            set {modelData = value;}
        }

        public string StateName
        {
            get{ return state.StateName;}
        }

        public string StateIndependentMethod()
        {
            modelData = 0;
            return "MyClass" + ": ModelData=" + ModelData;
        }

        public string StateDependentMethod() //ToDo 4a: Create state dependent method, State base class duplicate this
        {
            return state.StateDependentMethod(this); //Todo 5: Forward the call to the state object
        }

        public void StateChangingEvent()
        {
            state.StateChangingEvent(this);
        }
        #endregion

        #region MyStateBase, Base class for states

        
        public abstract class MyStateBase                                   //ToDo 1: Create an abstract base class for states, Must be a nested class to reach ChangeState method of context class
        {
            protected string stateName;

            protected void ChangeState(MyClass context, MyStateBase state)
            {
                context.ChangeState(state);
            }

            public string StateName { get { return stateName; } }
            abstract public string StateDependentMethod(MyClass context);   //ToDo 4b: Duplicate context class method and make it abstract
            abstract public void StateChangingEvent(MyClass context);
        }
        #endregion

        #region MyState1, Concrete class for state1
        
        class MyState1 : MyStateBase                                        //ToDo 6: Create a State class that inherit from State base
        {
            private static volatile MyState1 instance = new MyState1();     //ToDo 7a: Keep an instance of the state. Use Singleton pattern
            private MyState1() { stateName = "State1"; }                    //ToDo 7b: privet constructor (singleton pattern)

            public static MyStateBase Instance                              //ToDo 7c: Only way to create the class (singleton pattern)
            {
                get { return instance; }
            }

            public override string StateDependentMethod(MyClass context)    //ToDo 8: Implement state dependent method
            {
                context.ModelData += 10;                                    //ToDo 9b: Change context data
                return StateName + ": ModelData=" + context.ModelData;
            }

            public override void StateChangingEvent(MyClass context)
            {
                ChangeState(context, MyState2.Instance);                    //ToDo 10: Change state. State knows when to change state, and to which state.
            }
        }
        #endregion

        #region MyState2, Concreate class for state 2
        class MyState2 : MyStateBase
        {
            private static volatile MyState2 instance = new MyState2();
            private MyState2() { stateName = "State2"; }

            public static MyStateBase Instance
            {
                get { return instance; }
            }


            public override void StateChangingEvent(MyClass context)
            {
                ChangeState(context, MyState1.Instance);
            }

            public override string StateDependentMethod(MyClass context)
            {
                context.ModelData -= 10;
                return StateName + ": ModelData=" + context.ModelData;
            }
        }
        #endregion
    }
    #endregion
}
