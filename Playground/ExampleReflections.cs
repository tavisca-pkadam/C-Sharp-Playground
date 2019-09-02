using System;
using System.Reflection;

namespace Playground
{
    public class ExampleClass
    {
        private static string classObjective = "For Reflections";

        public int AddNumber(int number1, int number2)
        {
            int result = number1 + number2;
            return result;
        }
        //public int AddNumber(int number1, int number2, int number3)
        //{
        //    int result = number1 + number2 + number3;
        //    return result;
        //}

        public int SubtractNumber(int number1, int number2)
        {
            int result = number1 - number2;
            return result;
        }

    }

    class ReflectionsX
    {
        internal static void CallAllFunction()
        {
            Console.WriteLine("Running All Functions for Reflections");
            //CreateMethod();
            //CreateMethodFromMethodList();
            //CreateMethodFromUsingCreateInstance();
            CreateMethodFromUsingField();
        }

        public static void CreateMethod()
        {
            ExampleClass exampleObject = new ExampleClass();
            Type exampleObjectType = exampleObject.GetType();
            MethodInfo myMethodInfo = exampleObjectType.GetMethod("AddNumber");

            object[] mParam = new object[] { 5, 10 };


            Console.WriteLine($"Class Name Is {exampleObjectType.FullName} and its method {myMethodInfo.Name} returns -> {myMethodInfo.Invoke(exampleObject, mParam)}");
            //object[] mParam2 = new object[] { 5, 10,11 };


            //Console.WriteLine($"Class Name Is {exampleObjectType.FullName} and its method {myMethodInfo.Name} returns -> {myMethodInfo.Invoke(exampleObject, mParam2)}");

        }

        public static void CreateMethodFromMethodList()
        {
            ExampleClass exampleObject = new ExampleClass();
            Type exampleObjectType = exampleObject.GetType();
            MethodInfo[] exampleClassMethods = exampleObjectType.GetMethods();
            
            object[] mParam = new object[] { 5, 10 };
            Console.WriteLine(exampleClassMethods[0].Attributes);
            Console.WriteLine($"Class Name Is {exampleObjectType.FullName} and its method {exampleClassMethods[0].Name} returns -> {exampleClassMethods[0].Invoke(exampleObject, mParam)}");

        }

        public static void CreateMethodFromUsingCreateInstance()
        {
            var currentExecutingAssembly = Assembly.GetExecutingAssembly();
            Type exampleObjectType = currentExecutingAssembly.GetType("Playground.ExampleClass");
            ExampleClass exampleObject = (ExampleClass)Activator.CreateInstance(exampleObjectType);

            MethodInfo[] exampleClassMethods = exampleObjectType.GetMethods();

            object[] mParam = new object[] { 5, 10 };

            Console.WriteLine($"Class Name Is {exampleObjectType.FullName} and its method {exampleClassMethods[0].Name} returns -> {exampleClassMethods[0].Invoke(exampleObject, mParam)}");

        }

        public static void CreateMethodFromUsingField()
        {
            var currentExecutingAssembly = Assembly.GetExecutingAssembly();
            Type exampleObjectType = currentExecutingAssembly.GetType("Playground.ExampleClass");

            FieldInfo fieldInfo = exampleObjectType.GetField("classObjective",  BindingFlags.Static);
            fieldInfo.SetValue("classObjective", "For FieldInfo in Relfections");
            var fieldValue = (String)fieldInfo.GetValue("classObjective");
           
            Console.WriteLine($"Class Name Is {exampleObjectType.FullName} and its fieldInfo classObjective has value ->  {fieldValue}");

        }

        //Assembly testAssembly = Assembly.LoadFile(@"c:\YourData.dll");
        //// get info about property: public double Number
        //PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");

        //// get value of property: public double Number
        //double value = (double)numberPropertyInfo.GetValue(calcInstance, null);

        //// set value of property: public double Number
        //numberPropertyInfo.SetValue(calcInstance, 10.0, null);

    }
}

