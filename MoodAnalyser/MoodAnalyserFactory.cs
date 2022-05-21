using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyser
{
 public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructorName)
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
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }
        //UC5-Reflection using parameterized constructor
        public static object CreatedMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserProblems);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");

            }
        }
        ///UC6 Use Reflection to Invoke the method

        public static string InvokeMethod(string className, string methodName, string message)
        {
            Type type1 = typeof(MoodAnalyserFactory);
            try
            {
                ConstructorInfo constructor = type1.GetConstructor(new[] { typeof(string) });
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor(className, methodName, message);
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                MethodInfo getMoodMethod = type.GetMethod(methodName);
                string msg = (string)getMoodMethod.Invoke(obj, null);
                return msg;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "No Such Method");
            }
        }

        public static dynamic ChangeMoodDynamically(string v, object p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// UC7 Use Reflection to change mood dynamically
        /// </summary>
        /// <param name="className"></param>
        /// <param name="mood"></param>
        /// <returns></returns>
        public static dynamic ChangeMoodDynamically(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("GetMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, e.Message);
            }
        }
    }
}
