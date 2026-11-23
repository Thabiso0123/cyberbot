using System;

namespace ChatBot
{
    internal abstract class CyberGuardBot
    {
        public string UserName { get; set; }

        public abstract string GetResponse(string input);
    }
}