using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ExceptionHandling
{
    public class MoodAnalyzer
    {
        private string message;
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            //nullcase
            //if (this.message == (null))
            //    return null;
            if (this.message.Contains("Sad"))
                return "Sad";
            else
                return "Happy";
        }    
        public string AnalyseMood_WithException(string message)
        {
            //nullcase
            //if (this.message == (null))
            //    return null;
            try
            {
                if (this.message.Contains("Sad"))
                    return "Sad";
                else
                    return "Happy";
            }
            catch
            {
                return "Happy";
            }
        }

    }
}
