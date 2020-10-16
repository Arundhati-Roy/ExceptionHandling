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
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        [TestMethod]
        public void TestMethod6()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyzer(message);
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
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
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseWithoutAssembly("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer");
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
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameter("ExceptionHandling.MoodAnalyzer", "MoodAnalyzer","HAPPY");
            expected.GetType().Equals(obj.GetType());
        }

        [TestMethod]
        public void GivenHappyMoodReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyzerFactory.InvokeAnalyseMood("HAPPY", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// TC 7.1 When given proper fieldName and a mood message for happy mood then should return HAPPY
        /// </summary>
        [TestMethod]
        public void Given_HappyMessage_withReflector_ReturnHappy()
        {
            object mood = MoodAnalyzerFactory.SetField("HAPPY mood", "message");
            Assert.AreEqual("HAPPY", mood);
        }
        [TestMethod]
        public void ChangeMoodDynamicallyForValidFieldName()
        {
            // ACT
            object actual = MoodAnalyzerFactory.SetField("I am happy today", "message");

            // Assert
            Assert.AreEqual("HAPPY", actual);
        }

        /// <summary>
        ///  TC 7.2 When given wrong fieldName and a happy mood message then should throw exception
        /// </summary>
        [TestMethod]
        public void ChangeMoodDynamicallyInValid()
        {
            try
            {
                // ACT
                object actual = MoodAnalyzerFactory.SetField("I am in happy mood today", "InvalidField");
            }
            catch (MoodAnalyzerCustomException exception)
            {
                // Assert
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// TC 7.3 When given correct fieldName and passing a null mood message then throw error that Mood should not be NULL
        /// </summary>
        [TestMethod]
        public void ChangeMoodDynamicallySetNull()
        {
            try
            {
                // ACT
                object actual = MoodAnalyzerFactory.SetField(null, "message");
            }
            catch (MoodAnalyzerCustomException exception)
            {
                // Assert
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }
    }
}
