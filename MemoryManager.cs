using System;
using System.Collections.Generic;

namespace ChatBot
{
    internal class MemoryManager
    {
        private Dictionary<string, string> userMemory;

        private List<string> favouriteTopics;

        public MemoryManager()
        {
            userMemory =
                new Dictionary<string, string>();

            favouriteTopics =
                new List<string>();
        }

        public void StoreUserInfo(
            string key,
            string value)
        {
            userMemory[key] = value;
        }

        public string RetrieveUserInfo(
            string key)
        {
            if (userMemory.ContainsKey(key))
            {
                return userMemory[key];
            }

            return null;
        }

        public void AddFavourite(
            string topic)
        {
            if (!favouriteTopics.Contains(topic))
            {
                favouriteTopics.Add(topic);
            }
        }

        public List<string> GetFavourites()
        {
            return favouriteTopics;
        }
    }
}