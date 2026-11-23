using System.Collections.Generic;

namespace ChatBot
{
    internal class QuizEngine
    {
        private readonly List<QuizQuestion> questions;
        private int currentIndex;

        public int Score { get; private set; }
        public int TotalQuestions { get { return questions.Count; } }
        public int QuestionNumber { get { return currentIndex + 1; } }
        public bool IsFinished { get { return currentIndex >= questions.Count; } }

        public QuizEngine()
        {
            questions = BuildQuestionBank();
            currentIndex = 0;
            Score = 0;
        }

        public void Restart()
        {
            currentIndex = 0;
            Score = 0;
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (IsFinished)
            {
                return null;
            }

            return questions[currentIndex];
        }
        public bool SubmitAnswer(int chosenOptionIndex)
        {
            QuizQuestion question = GetCurrentQuestion();

            bool isCorrect = chosenOptionIndex == question.CorrectOptionIndex;

            if (isCorrect)
            {
                Score++;
            }

            currentIndex++;

            return isCorrect;
        }

        public string GetScoreFeedback()
        {
            double percentage = (double)Score / TotalQuestions * 100;

            if (percentage >= 80)
            {
                return "Great job! You're a cybersecurity pro!";
            }
            else if (percentage >= 50)
            {
                return "Good effort! A little more practice and you'll be a pro.";
            }
            else
            {
                return "Keep learning to stay safe online!";
            }
        }

        private List<QuizQuestion> BuildQuestionBank()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" },
                    CorrectOptionIndex = 2,
                    Explanation = "Correct! Reporting phishing emails helps prevent scams."
                },
                new QuizQuestion
                {
                    Question = "A strong password should include uppercase, lowercase, numbers and symbols.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "Correct! Mixing character types makes passwords much harder to guess or crack."
                },
                new QuizQuestion
                {
                    Question = "Which of these is the safest way to connect on public Wi-Fi?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "Use a VPN", "Disable your antivirus", "Share files with everyone nearby", "Use the same password everywhere" },
                    CorrectOptionIndex = 0,
                    Explanation = "Correct! A VPN encrypts your connection, protecting your data on untrusted networks."
                },
                new QuizQuestion
                {
                    Question = "It is safe to click links in unexpected text messages from unknown numbers.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Correct! Unexpected links are a common way attackers deliver malware or steal information."
                },
                new QuizQuestion
                {
                    Question = "What is the main purpose of two-factor authentication (2FA)?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "To speed up logins", "To add a second layer of security beyond your password", "To remove the need for passwords", "To share your account with others" },
                    CorrectOptionIndex = 1,
                    Explanation = "Correct! 2FA requires a second proof of identity, making accounts much harder to break into."
                },
                new QuizQuestion
                {
                    Question = "Social engineering attacks rely on tricking people rather than exploiting software bugs.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "Correct! Social engineering manipulates human trust and behaviour, not just technical weaknesses."
                },
                new QuizQuestion
                {
                    Question = "Which of these is a common sign of a phishing email?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "A personalised greeting with no spelling errors", "Urgent language demanding immediate action", "An email from a known, verified colleague", "A message with no links or attachments" },
                    CorrectOptionIndex = 1,
                    Explanation = "Correct! Urgency and pressure are classic phishing tactics designed to stop you from thinking carefully."
                },
                new QuizQuestion
                {
                    Question = "Ransomware encrypts your files and demands payment to unlock them.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "Correct! Regular backups are one of the best defences against ransomware."
                },
                new QuizQuestion
                {
                    Question = "What does a firewall primarily do?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "Speeds up your internet connection", "Stores your passwords securely", "Monitors and blocks suspicious network traffic", "Backs up your files automatically" },
                    CorrectOptionIndex = 2,
                    Explanation = "Correct! A firewall acts as a barrier between trusted and untrusted networks."
                },
                new QuizQuestion
                {
                    Question = "Using the same password across multiple accounts is a safe practice.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Correct! Reusing passwords means one breach can expose all of your accounts."
                },
                new QuizQuestion
                {
                    Question = "Which of these is the best practice for browsing safely online?",
                    Type = QuestionType.MultipleChoice,
                    Options = new List<string> { "Checking for HTTPS before entering personal details", "Downloading software from any pop-up advert", "Disabling browser security warnings", "Saving passwords on shared computers" },
                    CorrectOptionIndex = 0,
                    Explanation = "Correct! HTTPS confirms your connection to a site is encrypted."
                },
                new QuizQuestion
                {
                    Question = "Malware can only infect computers, never smartphones.",
                    Type = QuestionType.TrueFalse,
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Correct! Smartphones can be infected too, especially through malicious apps and links."
                }
            };
        }
    }
}