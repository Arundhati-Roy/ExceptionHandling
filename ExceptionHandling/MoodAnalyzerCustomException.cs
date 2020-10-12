using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace ExceptionHandling
{
    public class MoodAnalyzerCustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE
        }
        public readonly ExceptionType type;
        public MoodAnalyzerCustomException(ExceptionType Type, string message):base(message)
        {
            this.type = Type;
        }
        
    }
}
