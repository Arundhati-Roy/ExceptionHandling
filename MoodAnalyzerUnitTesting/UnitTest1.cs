using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionHandling;
using System.Data;

namespace MoodAnalyzerUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert
            string expected = "Sad";
            string message = "I am in a Sad mood";
            //string message = "I am in a Happy mood";
            //string message = null;

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow(null)]
        public void TestMethod2(string message)
        {
            //string expected = "Sad";
            string expected = "Happy";
            //string message = "I am in a Sad mood";
            //string message = "I am in a Happy mood";
            //string message = null;

            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            //Act
            string mood = moodAnalyse.AnalyseMood_WithException(message);

            //Assert
            Assert.AreEqual(expected, mood);
            //Assert.IsNull(mood);

        }
    }
}
