using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot
{
    public class TaskAssistant
    {
        private readonly DatabaseHelper databaseHelper;
        private readonly ActivityLogger activityLogger;

        public CyberTask LastAddedTask { get; private set; }

        public TaskAssistant(ActivityLogger logger)
        {
            databaseHelper = new DatabaseHelper();
            activityLogger = logger;

            databaseHelper.InitializeDatabase();
        }

        public CyberTask AddTask(string title, string description, DateTime? reminderDate)
        {
            int newId = databaseHelper.AddTask(title, description, reminderDate);

            CyberTask task = new CyberTask
            {
                Id = newId,
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            };

            LastAddedTask = task;

            string log = "Task added: " + title;

            if (reminderDate.HasValue)
                log += " (Reminder: " + reminderDate.Value.ToString("dd MMM yyyy") + ")";

            activityLogger.AddEntry(log);

            return task;
        }

        public List<CyberTask> GetAllTasks()
        {
            return databaseHelper.GetAllTasks();
        }

        public CyberTask FindTaskByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return null;

            return GetAllTasks().FirstOrDefault(t =>
                t.Title.ToLower().Contains(title.ToLower()));
        }

        public void CompleteTask(int id, string title)
        {
            databaseHelper.MarkCompleted(id);
            activityLogger.AddEntry("Completed task: " + title);
        }

        public void DeleteTask(int id, string title)
        {
            databaseHelper.DeleteTask(id);
            activityLogger.AddEntry("Deleted task: " + title);
        }

        public bool SetReminderOnLastTask(DateTime reminder)
        {
            if (LastAddedTask == null)
                return false;

            databaseHelper.SetReminder(LastAddedTask.Id, reminder);
            LastAddedTask.ReminderDate = reminder;

            activityLogger.AddEntry(
                "Reminder set for '" +
                LastAddedTask.Title +
                "' on " +
                reminder.ToString("dd MMM yyyy"));

            return true;
        }
    }
}