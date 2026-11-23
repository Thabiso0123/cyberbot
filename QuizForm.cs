using System;
using System.Windows.Forms;

namespace ChatBot
{

    public partial class QuizForm : Form
    {
        private readonly QuizEngine quizEngine;
        private readonly ActivityLogger activityLogger;
        private readonly Button[] optionButtons;

        public QuizForm(ActivityLogger activityLogger)
        {
            InitializeComponent();

            this.activityLogger = activityLogger;
            quizEngine = new QuizEngine();

            optionButtons = new[] { optionButton1, optionButton2, optionButton3, optionButton4 };

            activityLogger.AddEntry("Quiz started.");

            DisplayCurrentQuestion();
        }

        private void DisplayCurrentQuestion()
        {
            QuizQuestion question = quizEngine.GetCurrentQuestion();

            progressLabel.Text = "Question " + quizEngine.QuestionNumber + " of " + quizEngine.TotalQuestions;
            scoreLabel.Text = "Score: " + quizEngine.Score;
            questionLabel.Text = question.Question;
            feedbackLabel.Text = "";
            nextButton.Enabled = false;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i < question.Options.Count)
                {
                    optionButtons[i].Visible = true;
                    optionButtons[i].Text = question.Options[i];
                    optionButtons[i].Enabled = true;
                    optionButtons[i].BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    optionButtons[i].Visible = false;
                }
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int chosenIndex = (int)clickedButton.Tag;

            QuizQuestion question = quizEngine.GetCurrentQuestion();
            bool isCorrect = quizEngine.SubmitAnswer(chosenIndex);

            foreach (Button button in optionButtons)
            {
                if (!button.Visible)
                {
                    continue;
                }

                button.Enabled = false;

                int buttonIndex = (int)button.Tag;

                if (buttonIndex == question.CorrectOptionIndex)
                {
                    button.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (buttonIndex == chosenIndex)
                {
                    button.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            feedbackLabel.ForeColor = isCorrect ? System.Drawing.Color.Green : System.Drawing.Color.DarkRed;
            feedbackLabel.Text = (isCorrect ? "Correct! " : "Not quite. ") + question.Explanation;
            scoreLabel.Text = "Score: " + quizEngine.Score;

            nextButton.Enabled = true;
            nextButton.Text = quizEngine.IsFinished ? "Finish" : "Next Question";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (quizEngine.IsFinished)
            {
                ShowFinalScore();
                return;
            }

            DisplayCurrentQuestion();
        }

        private void ShowFinalScore()
        {
            string message =
                "You scored " + quizEngine.Score + " out of " + quizEngine.TotalQuestions + ".\n\n" +
                quizEngine.GetScoreFeedback();

            activityLogger.AddEntry(
                "Quiz completed - scored " + quizEngine.Score + "/" + quizEngine.TotalQuestions + ".");

            MessageBox.Show(message, "Quiz Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {

        }
    }
}