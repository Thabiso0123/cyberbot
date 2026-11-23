using System;

namespace ChatBot
{
    public class CyberTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReminderDate { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string reminderText = ReminderDate.HasValue
                ? " | Reminder: " + ReminderDate.Value.ToString("dd MMM yyyy")
                : " | No reminder set";

            string status = IsCompleted
                ? " | Status: Completed"
                : " | Status: Pending";

            return Title + reminderText + status;
        }
    }
}