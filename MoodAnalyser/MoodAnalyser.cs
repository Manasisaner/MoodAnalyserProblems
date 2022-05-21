using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblems
{
    public class MoodAnalyser
    {
        //instance variable
        string message;

        //parameterized constructor for initializing instance member
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        //Analyser method to find mood
        public string Analyser() //check msg passing into the constructor is contain(sad) then written sad else sad
        {
            if (this.message.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "no sad";
            }
        }
        //Analyser method to find mood
        public string Analyser() //check msg passing into the constructor is contain(sad) then written sad else sad
        {
            if (this.message.ToLower().Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }

        public string Analyser() //check msg passing into the constructor 
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                }
                if (this.message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException)
            {
                //return ex.Message;
                throw new MoodAnalyser.MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Mood should not be null");
            }
        }
    }

}
}
