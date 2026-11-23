using System;
using System.Linq;

namespace ChatBot
{
    internal class NlpProcessor
    {
        private readonly string[] addTaskTriggers =
        {
            "add task", "add a task", "create task", "create a task",
            "new task", "remind me to", "can you remind me to", "i need to"
        };

        private readonly string[] showTasksTriggers =
        {
            "show tasks", "show my tasks", "view tasks", "view my tasks", "my tasks", "tasks",
            "list tasks", "list my tasks", "what are my tasks", "my task list"
        };

        private readonly string[] completeTaskTriggers =
        {
            "complete task", "mark task", "mark as done", "finish task", "i finished"
        };

        private readonly string[] deleteTaskTriggers =
        {
            "delete task", "remove task", "cancel task"
        };

        private readonly string[] quizTriggers =
        {
            "start quiz", "play quiz", "begin quiz", "test me", "quiz me", "take the quiz", "quiz", "start the quiz", "open quiz"
        };

        private readonly string[] activityLogTriggers =
        {
            "show activity log", "activity log", "what have you done for me", "log",
            "what have you done", "show my activity", "show log"
        };

        private readonly string[] showMoreTriggers =
        {
            "show more", "show full history", "show all activity", "full log"
        };

        private readonly string[] affirmativeWords =
        {
            "yes", "yeah", "yep", "sure", "please"
        };

        public NlpResult Process(string rawInput)
        {
            string input = rawInput.ToLower().Trim();

            NlpResult result = new NlpResult { Intent = NlpIntent.Unknown };

            if (ContainsAny(input, activityLogTriggers))
            {
                result.Intent = NlpIntent.ShowActivityLog;
                return result;
            }

            if (ContainsAny(input, showMoreTriggers))
            {
                result.Intent = NlpIntent.ShowMoreLog;
                return result;
            }

            if (ContainsAny(input, quizTriggers))
            {
                result.Intent = NlpIntent.StartQuiz;
                return result;
            }

            if (ContainsAny(input, completeTaskTriggers))
            {
                result.Intent = NlpIntent.CompleteTask;
                result.TaskTitle = ExtractTitleAfterTrigger(input, completeTaskTriggers);
                return result;
            }

            if (ContainsAny(input, deleteTaskTriggers))
            {
                result.Intent = NlpIntent.DeleteTask;
                result.TaskTitle = ExtractTitleAfterTrigger(input, deleteTaskTriggers);
                return result;
            }

            if (ContainsAny(input, showTasksTriggers))
            {
                result.Intent = NlpIntent.ShowTasks;
                return result;
            }

            if (ContainsAny(input, addTaskTriggers))
            {
                result.Intent = NlpIntent.AddTask;
                result.TaskTitle = ExtractTitleAfterTrigger(input, addTaskTriggers);

                DateTime? reminder = ExtractReminderDate(input);

                if (reminder.HasValue)
                {
                    result.ReminderRequested = true;
                    result.ReminderDate = reminder;
                }

                return result;
            }

            if (ContainsAny(input, affirmativeWords) || input.Contains("remind me in") || input.Contains("no reminder") || input.StartsWith("no"))
            {
                result.Intent = NlpIntent.ReminderFollowUp;
                result.ReminderDate = ExtractReminderDate(input);
                result.ReminderRequested = result.ReminderDate.HasValue;
                return result;
            }

            return result;
        }

        private bool ContainsAny(string input, string[] triggers)
        {
            return triggers.Any(trigger => input.Contains(trigger));
        }

        private string ExtractTitleAfterTrigger(string input, string[] triggers)
        {
            string matchedTrigger =
                triggers.OrderByDescending(t => t.Length)
                        .FirstOrDefault(t => input.Contains(t));

            if (matchedTrigger == null)
            {
                return string.Empty;
            }

            int triggerIndex = input.IndexOf(matchedTrigger);
            string remainder = input.Substring(triggerIndex + matchedTrigger.Length);

            remainder = remainder.Trim(' ', '-', ':', '.');

            if (remainder.StartsWith("to "))
            {
                remainder = remainder.Substring(3);
            }

            int reminderClauseIndex = remainder.IndexOf(" remind");
            if (reminderClauseIndex > 0)
            {
                remainder = remainder.Substring(0, reminderClauseIndex);
            }

            return CapitaliseFirstLetter(remainder.Trim());
        }

        private DateTime? ExtractReminderDate(string input)
        {
            if (input.Contains("tomorrow"))
            {
                return DateTime.Today.AddDays(1);
            }

            if (input.Contains("next week"))
            {
                return DateTime.Today.AddDays(7);
            }

            if (input.Contains("today"))
            {
                return DateTime.Today;
            }

            int inIndex = input.IndexOf("in ");

            if (inIndex >= 0)
            {
                string afterIn = input.Substring(inIndex + 3);
                string[] words = afterIn.Split(' ');

                if (words.Length > 0 && int.TryParse(words[0], out int days))
                {
                    return DateTime.Today.AddDays(days);
                }
            }

            return null;
        }

        private string CapitaliseFirstLetter(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}