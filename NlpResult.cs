using System;

namespace ChatBot
{
    internal enum NlpIntent
    {
        AddTask,
        ReminderFollowUp,
        ShowTasks,
        CompleteTask,
        DeleteTask,
        StartQuiz,
        ShowActivityLog,
        ShowMoreLog,
        Unknown
    }

    internal class NlpResult
    {
        public NlpIntent Intent { get; set; }
        public string TaskTitle { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool ReminderRequested { get; set; }
    }
}