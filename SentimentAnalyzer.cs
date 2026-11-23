using System;

namespace ChatBot
{
    internal class SentimentAnalyzer
    {
        public string DetectMood(string input)
        {
            input =
                input.ToLower();

            if (input.Contains("worried") ||
                input.Contains("scared") ||
                input.Contains("anxious"))
            {
                return "worried";
            }

            else if (input.Contains("frustrated") ||
                     input.Contains("angry") ||
                     input.Contains("annoyed"))
            {
                return "frustrated";
            }

            else if (input.Contains("confused") ||
                     input.Contains("lost") ||
                     input.Contains("don't understand"))
            {
                return "confused";
            }

            else if (input.Contains("happy") ||
                     input.Contains("great") ||
                     input.Contains("good"))
            {
                return "positive";
            }

            else if (input.Contains("sad") ||
                     input.Contains("bad"))
            {
                return "negative";
            }

            return "neutral";
        }
    }
}