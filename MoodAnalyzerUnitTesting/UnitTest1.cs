using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionHandling;
using System.Data;
using System;

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
        [TestMethod]
        //[DataRow("I am in Happy mood")]
        //[DataRow(null)]
        //[DataRow("")]
        public void TestMethod3()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood_withCustomException(message);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                string message = null;
                MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);
                string mood = moodAnalyse.AnalyseMood_withCustomException(message);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerReflection.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        [TestMethod]
        public void TestMethod6()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyzer(message);
                object obj = MoodAnalyzerReflection.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such constructor", e.Message);
            }
        }
        [TestMethod]
        public void TestMethod7()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyzer(message);
                object obj = MoodAnalyzerReflection.CreateMoodAnalyseWithoutAssembly("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalyzerCustomException e)
            {
                Assert.AreEqual("No such constructor", e.Message);
            }
        }
        [TestMethod]
        public void TestMethod8()
        {
            string message = "HAPPY";
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerReflection.CreateMoodAnalyseUsingParameter("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        /*[TestMethod]
        public void TestMethod9_UC6()
        {
            object actual = null;
            object expected = null;
            try
            {
                expected = "Happy";
                actual = MoodAnalyzerReflection.InvokeAnalyseMethod("Analyse");
            }
            catch(MoodAnalyzerCustomException e)
            {
                expected.Equals(actual);
            }
            
        }*/

    }
}
