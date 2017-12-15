using System;
using System.Reflection;
using System.Linq.Expressions;



namespace Cactoos.Reflection
{
    /// <summary>
    /// Allows to create objects without direct constructor invocation,  
    /// only knowing its type and constructor arguments.
    /// Significantly faster than Activator.CreateInstance()
    /// Warning! To use <see cref="NewInstance{T}"/> you have to know 
    /// exact position of required type constructor in Type.GetConstructors() array.
    /// For example, <see cref="String"/> has 8 constructors:
    /// 
    ///   Void .ctor(Char*)
    ///   Void .ctor(Char*, Int32, Int32)
    ///   Void .ctor(SByte*)
    ///   Void .ctor(SByte*, Int32, Int32)
    ///   Void .ctor(SByte*, Int32, Int32, System.Text.Encoding)
    ///   Void .ctor(Char[], Int32, Int32)
    ///   Void .ctor(Char[])
    ///   Void .ctor(Char, Int32)
    ///   
    /// And you want to create a <see cref="String"/> from char array,
    /// so the ctorPosition will be 6 (in zero-based index).
    /// Example usage:
    ///
    ///     var ctor = new NewInstance(typeof(string), 6, new char[2]{'1', '2'}); 
    ///     var str = ctor.Value(); 
    ///     
    /// str is equal to "12" now.
    /// </summary>
    public struct NewInstance<T> : IScalar<T>
    {
        private int _constructorNumber;
        private Type _type;
        private object[] _args;

        /// <summary>
        /// Intializes a new instance of <see cref="NewInstance{T}"/>
        /// </summary>
        /// <parameters name="type">Type of object to create</parameters>
        /// <parameters name="ctorPosition">Position of constructor in Type.GetConstructors() array</parameters>
        /// <parameters name="args">Constructor arguments</parameters>
        public NewInstance(Type type, int ctorPosition, params object[] args)
        {
            _type = type;
            _constructorNumber = ctorPosition;
            _args = args;
        }

        /// <summary>
        /// Intializes a new instance of <see cref="NewInstance{T}"/> running a default constructor.
        /// </summary>
        /// <parameters name="type">Type of object to create</parameters>
        /// <parameters name="ctorPosition">Position of constructor in Type.GetConstructors() array</parameters>
        public NewInstance(Type type, int ctorPosition = 0) : this(type, ctorPosition, new object[0])
        {

        }

        delegate T ObjectActivator(params object[] args);

        /// <summary>
        /// Initializes a new instance of required type.
        /// </summary>
        /// <returns>New instance of required type</returns>
        public T Value()
        {
            ConstructorInfo constructor = _type.GetConstructors()[_constructorNumber];
            ParameterInfo[] parametersInfo = constructor.GetParameters();

            //create a single parameters of type object[]
            ParameterExpression parameters =
                Expression.Parameter(new TypeOf<object[]>().Value(), "args");

            Expression[] arguments =
                new Expression[parametersInfo.Length];

            //pick each arg from the parameters array 
            //and create a typed expression of them
            for (int i = 0; i < parametersInfo.Length; i++)
            {
                arguments[i] =
                    Expression.Convert(
                        Expression.ArrayIndex(parameters, Expression.Constant(i)),
                        parametersInfo[i].ParameterType
                    );
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(constructor, arguments);

            //create a lambda with the New
            //Expression as body and our parameters object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(new TypeOf<ObjectActivator>().Value(), newExp, parameters);

            //compile it
            ObjectActivator compiled = (ObjectActivator)lambda.Compile();
            return compiled(_args);
        }
    }
}
