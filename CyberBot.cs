using System;
using System.Collections.Generic;

namespace ChatBot
{
    internal class CyberBot : CyberGuardBot
    {
        private Dictionary<string, string> responses;

        public CyberBot()
        {
            responses =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase)
            {
                {
                    "hello",
                    "Hello. It is great to chat with you today. How can I help you stay safe online?"
                },

                {
                    "hi",
                    "Hi there. What cybersecurity topic would you like to learn about today?"
                },

                {
                    "how are you",
                    "I am functioning perfectly and ready to help you with cybersecurity awareness."
                },

                {
                    "phishing",
                    "Phishing is a scam where attackers pretend to be trusted companies or people to steal passwords or personal information. Have you ever received a suspicious email before?"
                },

                {
                    "malware",
                    "Malware is dangerous software designed to harm your computer or steal information. It is important to avoid downloading files from unknown websites."
                },

                {
                    "ransomware",
                    "Ransomware locks your files and demands payment to unlock them. Backing up your files regularly is one of the best protections."
                },

                {
                    "password",
                    "Strong passwords should include uppercase letters, lowercase letters, numbers, and symbols. Do you currently use different passwords for different accounts?"
                },

                {
                    "vpn",
                    "A VPN protects your privacy online by encrypting your internet connection, especially useful on public Wi-Fi."
                },

                {
                    "firewall",
                    "A firewall acts like a security guard between your computer and the internet, blocking suspicious traffic."
                },

                {
                    "2fa",
                    "Two-factor authentication adds extra security to your account by requiring a second verification step."
                },

                {
                    "safe browsing",
                    "Safe browsing means avoiding suspicious links, checking website security, and being careful with downloads."
                },

                {
                    "thank you",
                    "You are welcome. I am always here to help you stay safe online."
                },

                {
                    "bye",
                    "Goodbye. Stay safe online and remember to protect your personal information."
                }
            };
        }

        public override string GetResponse(string input)
        {
            string lowerInput =
                input.ToLower();

            foreach (var item in responses)
            {
                if (lowerInput.Contains(item.Key))
                {
                    return item.Value;
                }
            }

            return
                "That is interesting. Could you ask me something related to cybersecurity such as phishing, malware, passwords, ransomware, or online scams?";
        }
    }
}