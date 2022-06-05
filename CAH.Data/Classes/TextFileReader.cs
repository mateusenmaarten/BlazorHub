using CAH.Data.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CAH.Data.Classes
{
    public class TextFileReader : IReader
    {
        private static string _answerFile = "TextFiles/Answers.txt";
        private static string _questionFile = "TextFiles/Questions.txt";

        public List<string> GetAllAnswers()
        {
            return File.ReadAllLines(_answerFile).Distinct().ToList();
        }

        public List<string> GetAllQuestions()
        {
            return File.ReadAllLines(_questionFile).Distinct().ToList();
        }
    }   


}
