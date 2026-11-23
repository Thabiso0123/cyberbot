using System;
using System.Collections.Generic;

namespace ChatBot
{
    public class ActivityLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "[" + Timestamp.ToString("dd MMM yyyy HH:mm") + "] " + Description;
        }
    }

    public class ActivityLogger
    {
        private readonly List<ActivityLogEntry> log;

        public ActivityLogger()
        {
            log = new List<ActivityLogEntry>();
        }

        public void AddEntry(string description)
        {
            log.Add(new ActivityLogEntry
            {
                Timestamp = DateTime.Now,
                Description = description
            });
        }

        public List<ActivityLogEntry> GetRecentEntries(int count = 5)
        {
            int startIndex = Math.Max(0, log.Count - count);

            return log.GetRange(startIndex, log.Count - startIndex);
        }

        public List<ActivityLogEntry> GetAllEntries()
        {
            return new List<ActivityLogEntry>(log);
        }

        public bool HasEntries
        {
            get
            {
                return log.Count > 0;
            }
        }

        public void Clear()
        {
            log.Clear();
        }
    }
}