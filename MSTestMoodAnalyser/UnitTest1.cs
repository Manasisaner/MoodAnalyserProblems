using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestMoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
     
        public void Given_Sadmood_Expecting_Sad_Results()
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in sad mood");
            string expected = "sad";

            //Act
            string actual = mood.Analyser();

            //Asert
            Assert.AreEqual(expected, actual);
        }
        public void Given_Sadmood_Should_Return_Happy(object Asert)
        {
            //Arrange;
            MoodAnalyser mood = new MoodAnalyser("I am in Happy mood");
            string expected = "sad";
            //Act
            string actual = mood.Analyser();
            //Asert
            object p = Asert.AreEqual(excepted, actual);
        }
        public void Given_Nullmood_Using_CustomException_Return_Null()
        {
            //Arrange;
            MoodAnalyser mood = new MoodAnalyser(null);
            string expected = "Mood should not be null";
            try
            {
                //Act
                string actual = mood.Analyser();
            }
            catch (MoodAnalyserException exception)
            {
                //Asert
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}
 