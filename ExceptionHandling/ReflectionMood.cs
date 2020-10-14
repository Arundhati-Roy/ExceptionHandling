using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ExceptionHandling
{
    class ReflectionCust
    {
        public static void Test()
        {
            Type type = Type.GetType("ExceptionHandling.MoodAnalyzer");
            Console.WriteLine("Full Name:{0}", type.FullName);
            Console.WriteLine("Class Name:{0}", type.Name);
            Console.WriteLine("Methods in Customer class");
            MemberInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }

            Console.WriteLine("Properties in Customer class");
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name);
            }

            Console.WriteLine("Constructors in Customer class");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo cons in constructors)
            {
                Console.WriteLine(cons.ToString());
            }
        }
    }

}
