using System.Collections.Generic;

namespace ChatBot
{
    internal enum QuestionType
    {
        MultipleChoice,
        TrueFalse
    }
    internal class QuizQuestion
    {
        public string Question { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
        public string Explanation { get; set; }
    }
}