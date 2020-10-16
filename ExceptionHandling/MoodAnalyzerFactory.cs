using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ExceptionHandling
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class");
                }
                catch(MissingMethodException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor");
                }
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method");
            }

        }
        public static object CreateMoodAnalyseWithoutAssembly(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    //Assembly executing = Assembly.GetExecutingAssembly();
                    //MoodAnalyzerFactory mf = new MoodAnalyzerFactory();
                    Type moodAnalyseType = typeof(MoodAnalyzerFactory);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class");
                }
                /*catch (MissingMethodException)
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such constructor");
                }*/
            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method");
            }

        }
        public static object CreateMoodAnalyseUsingParameter(string className, string constructorName,string message)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_CLASS, "No such class");
                }

            }
            else
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "No such method");
            }
        }
        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("ExceptionHandling.MoodAnalyzer");
                object moodAnalyseObject = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameter("ExceptionHandling.MoodAnalyzer","MoodAnalyzer",message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString().ToUpper();
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }
        public static object SetField(string message,string fieldName)
        {
            try
            {
                // Get the type of the class
                Type type = typeof(MoodAnalyzer);

                // Create an object of class
                object mood = Activator.CreateInstance(type);

                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName);

                // set the field value of a particular field in particular object
                fieldInfo.SetValue(mood, message);

                // Get the method using reflection
                MethodInfo method = type.GetMethod("AnalyseMood");

                // Invoke the method using reflection
                object methodReturn = method.Invoke(mood, null);
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NO_SUCH_FIELD, "Field is not found");
            }
            catch
            {
                throw new MoodAnalyzerCustomException(MoodAnalyzerCustomException.ExceptionType.NULL_MESSAGE, "Mood should not be NULL");
            }
        }

    }
}

