using System;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class ChatbotForm : Form
    {
        private CyberGuardBot chatbot;
        private SentimentAnalyzer sentimentAnalyzer;
        private MemoryManager memoryManager;

        private NlpProcessor nlpProcessor;
        private TaskAssistant taskAssistant;
        private ActivityLogger activityLogger;

        private bool nameCaptured = false;
        private string currentUserName = "";

        private bool awaitingReminderResponse = false;

        public ChatbotForm()
        {
            InitializeComponent();

            chatbot = new CyberBot();
            sentimentAnalyzer = new SentimentAnalyzer();
            memoryManager = new MemoryManager();
            nlpProcessor = new NlpProcessor();
            activityLogger = new ActivityLogger();
            try
            {
                taskAssistant = new TaskAssistant(activityLogger);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to the database. Task features will be unavailable.\n\n" +
                    "Details: " + ex.Message,
                    "Database Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            sendButton.Click += sendButton_Click;
            inputTextBox.KeyDown += InputTextBox_KeyDown;

            this.BackColor = Color.MistyRose;
            this.Text = "Cybersecurity Awareness Bot";
            titlelabel.Text = "Cybersecurity Awareness Assistant";
            titlelabel.ForeColor = Color.DarkMagenta;
            titlelabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chatDisplayBox.BackColor = Color.White;
            chatDisplayBox.Font = new Font("Consolas", 10);
            chatDisplayBox.ReadOnly = true;
            sendButton.BackColor = Color.HotPink;
            sendButton.ForeColor = Color.White;
            sendButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            sendButton.FlatStyle = FlatStyle.Flat;
            topicListBox.BackColor = Color.Pink;
            topicListBox.ForeColor = Color.Black;
            topicListBox.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            sidebarpanel.Dock = DockStyle.Right;
            sidebarpanel.BackColor = Color.HotPink;

            LoadSidebarTopics();
            AddNavigationButtons();
            PlayGreetingAudio();
            AskForUserName();
        }


        private void ChatbotForm_Load(object sender, EventArgs e) { }

        private void LoadSidebarTopics()
        {
            topicListBox.Items.Add("What is phishing?");
            topicListBox.Items.Add("How malware infects devices");
            topicListBox.Items.Add("Understanding ransomware attacks");
            topicListBox.Items.Add("Creating strong passwords");
            topicListBox.Items.Add("Benefits of VPN protection");
            topicListBox.Items.Add("What firewalls do");
            topicListBox.Items.Add("Importance of 2FA");
            topicListBox.Items.Add("Safe browsing techniques");
            topicListBox.Items.Add("Protecting social media accounts");
            topicListBox.Items.Add("Recognising online scams");
            topicListBox.Items.Add("── Actions ──");
            topicListBox.Items.Add("View My Tasks");
            topicListBox.Items.Add("Start Quiz");
            topicListBox.Items.Add("Activity Log");

            topicListBox.SelectedIndexChanged += TopicListBox_SelectedIndexChanged;
        }

        private void AddNavigationButtons()
        {
            Button tasksButton = new Button();
            tasksButton.Name = "tasksNavButton";
            tasksButton.Text = "Tasks";
            tasksButton.Dock = DockStyle.Top;
            tasksButton.Height = 40;
            tasksButton.BackColor = Color.DeepPink;
            tasksButton.ForeColor = Color.White;
            tasksButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            tasksButton.FlatStyle = FlatStyle.Flat;
            tasksButton.Cursor = Cursors.Hand;
            tasksButton.Click += (s, e) => ShowTasks();

            Button quizButton = new Button();
            quizButton.Name = "quizNavButton";
            quizButton.Text = "Quiz";
            quizButton.Dock = DockStyle.Top;
            quizButton.Height = 40;
            quizButton.BackColor = Color.DeepPink;
            quizButton.ForeColor = Color.White;
            quizButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            quizButton.FlatStyle = FlatStyle.Flat;
            quizButton.Cursor = Cursors.Hand;
            quizButton.Click += (s, e) => LaunchQuiz();

            Button logButton = new Button();
            logButton.Name = "logNavButton";
            logButton.Text = "Activity Log";
            logButton.Dock = DockStyle.Top;
            logButton.Height = 40;
            logButton.BackColor = Color.DeepPink;
            logButton.ForeColor = Color.White;
            logButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            logButton.FlatStyle = FlatStyle.Flat;
            logButton.Cursor = Cursors.Hand;
            logButton.Click += (s, e) => ShowActivityLog();

            sidebarpanel.Controls.Add(logButton);
            sidebarpanel.Controls.Add(quizButton);
            sidebarpanel.Controls.Add(tasksButton);
        }

        private void TopicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (topicListBox.SelectedItem == null) return;
            string topic = topicListBox.SelectedItem.ToString();
            if (topic.StartsWith("──")) return;

            if (topic == "View My Tasks") { ShowTasks(); return; }
            if (topic == "Start Quiz") { LaunchQuiz(); return; }
            if (topic == "Activity Log") { ShowActivityLog(); return; }

            string response = chatbot.GetResponse(topic);
            AppendUser("Topic Selected: " + topic);
            AppendBot(response);
        }

        private void AskForUserName()
        {
            chatDisplayBox.SelectionColor = Color.DarkMagenta;
            chatDisplayBox.AppendText(
@"
============================================================
         ***  CYBERSECURITY AWARENESS BOT  ***
============================================================
      ___  _   _ ____  _____ ____      ____   ___ _____
     / __|| | | | __ )| ____|  _ \    | __ ) / _ \_   _|
    | |   | | | |  _ \|  _| | |_) |   |  _ \| | | || |
    | |__ | |_| | |_) | |___|  _ <    | |_) | |_| || |
     \___| \___/|____/|_____|_| \_\   |____/ \___/ |_|

============================================================

");
            chatDisplayBox.SelectionColor = Color.Black;
            chatDisplayBox.AppendText("Bot: Welcome to the Cybersecurity Awareness Assistant.\n");
            chatDisplayBox.AppendText("Bot: Please enter your name to continue.\n\n");
        }

        private void PlayGreetingAudio()
        {
            try
            {
                string audioPath = System.IO.Path.Combine(Application.StartupPath, "greeting.wav");
                if (System.IO.File.Exists(audioPath))
                    new SoundPlayer(audioPath).Play();
            }
            catch
            {
                MessageBox.Show("Greeting audio could not be played.", "Audio Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (input.ToLower() == "exit")
            {
                AppendBot("Goodbye " + currentUserName + ". Stay safe online and protect your personal information.");
                MessageBox.Show("Goodbye " + currentUserName + "!", "Session Ended",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            AppendUser(nameCaptured ? currentUserName + ": " + input : "User: " + input);

            if (!nameCaptured)
            {
                currentUserName = input;
                this.Text = "Cybersecurity Assistant - " + currentUserName;
                memoryManager.StoreUserInfo("name", currentUserName);
                nameCaptured = true;

                AppendBot("Welcome " + currentUserName + ".");
                AppendBot("I am your Cybersecurity Awareness Assistant.");
                AppendBot("You can ask me about phishing, malware, ransomware, passwords, VPNs, firewalls, " +
                          "scams, and safe browsing.\n" +
                          "You can also say things like:\n" +
                          "\"Add a task to enable 2FA\"\n" +
                          "\"Show my tasks\"\n" +
                          "\"Start quiz\"\n" +
                          "\"Show activity log\"");
                inputTextBox.Clear();
                return;
            }

            if (awaitingReminderResponse)
            {
                HandleReminderFollowUp(input);
                inputTextBox.Clear();
                return;
            }

            NlpResult nlp = nlpProcessor.Process(input);

            switch (nlp.Intent)
            {
                case NlpIntent.AddTask:
                    HandleAddTask(nlp);
                    break;

                case NlpIntent.ShowTasks:
                    ShowTasks();
                    break;

                case NlpIntent.CompleteTask:
                    HandleCompleteTask(nlp);
                    break;

                case NlpIntent.DeleteTask:
                    HandleDeleteTask(nlp);
                    break;

                case NlpIntent.StartQuiz:
                    LaunchQuiz();
                    break;

                case NlpIntent.ShowActivityLog:
                    ShowActivityLog();
                    break;

                case NlpIntent.ShowMoreLog:
                    ShowFullActivityLog();
                    break;

                default:
                    HandleGeneralChat(input);
                    break;
            }

            inputTextBox.Clear();
        }


        private void HandleAddTask(NlpResult nlp)
        {
            if (taskAssistant == null)
            {
                AppendBot("Sorry, the task feature is unavailable because the database could not be reached.");
                return;
            }

            string title = string.IsNullOrWhiteSpace(nlp.TaskTitle)
                ? "Cybersecurity task"
                : nlp.TaskTitle;

            string description = "Cybersecurity task: " + title + ". " +
                                 "Complete this to improve your online security.";

            if (nlp.ReminderRequested && nlp.ReminderDate.HasValue)
            {
                taskAssistant.AddTask(title, description, nlp.ReminderDate);
                AppendBot("Task added: '" + title + "'. Reminder set for " +
                          nlp.ReminderDate.Value.ToString("dd MMM yyyy") + ".");
                awaitingReminderResponse = false;
            }
            else
            {
                taskAssistant.AddTask(title, description, null);
                AppendBot("Task added: '" + title + "'. Would you like to set a reminder? " +
                          "(e.g. \"Yes, remind me in 3 days\" or \"No reminder\")");
                awaitingReminderResponse = true;
            }
        }

        private void HandleReminderFollowUp(string input)
        {
            if (taskAssistant == null) { awaitingReminderResponse = false; return; }

            NlpResult nlp = nlpProcessor.Process(input);

            if (input.ToLower().StartsWith("no") ||
                input.ToLower().Contains("no reminder") ||
                input.ToLower().Contains("skip"))
            {
                AppendBot("No reminder set. Your task has been saved without a reminder.");
                awaitingReminderResponse = false;
                return;
            }

            DateTime? date = nlp.ReminderDate;
            if (date == null)
            {
                string lower = input.ToLower();
                int idx = lower.IndexOf("in ");
                if (idx >= 0)
                {
                    string[] words = lower.Substring(idx + 3).Split(' ');
                    if (words.Length > 0 && int.TryParse(words[0], out int days))
                        date = DateTime.Today.AddDays(days);
                }
            }

            if (date.HasValue && taskAssistant.SetReminderOnLastTask(date.Value))
            {
                AppendBot("Got it! I'll remind you on " + date.Value.ToString("dd MMM yyyy") + ".");
            }
            else
            {
                AppendBot("I couldn't understand that date. Reminder not set. " +
                          "Try saying \"remind me in 3 days\" or \"remind me tomorrow\".");
            }

            awaitingReminderResponse = false;
        }

        private void ShowTasks()
        {
            if (taskAssistant == null)
            {
                AppendBot("Task feature is unavailable – no database connection.");
                return;
            }

            try
            {
                var tasks = taskAssistant.GetAllTasks();
                activityLogger.AddEntry("User viewed task list.");

                if (tasks.Count == 0)
                {
                    AppendBot("You have no tasks yet. Say \"Add a task to...\" to create one.");
                    return;
                }


                TaskManagerForm tmf = new TaskManagerForm(taskAssistant);
                tmf.ShowDialog(this);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Here is a quick summary of your " + tasks.Count + " task(s):");
                foreach (var t in tasks)
                    sb.AppendLine("  • " + t.ToString());
                AppendBot(sb.ToString());
            }
            catch (Exception ex)
            {
                AppendBot("Could not load tasks: " + ex.Message);
            }
        }

        private void HandleCompleteTask(NlpResult nlp)
        {
            if (taskAssistant == null) { AppendBot("Task feature unavailable."); return; }

            CyberTask task = taskAssistant.FindTaskByTitle(nlp.TaskTitle);
            if (task == null)
            {
                AppendBot("I could not find a task matching \"" + nlp.TaskTitle +
                          "\". Say \"Show my tasks\" to see all tasks.");
                return;
            }
            taskAssistant.CompleteTask(task.Id, task.Title);
            AppendBot("Task '" + task.Title + "' has been marked as completed. Well done!");
        }

        private void HandleDeleteTask(NlpResult nlp)
        {
            if (taskAssistant == null) { AppendBot("Task feature unavailable."); return; }

            CyberTask task = taskAssistant.FindTaskByTitle(nlp.TaskTitle);
            if (task == null)
            {
                AppendBot("I could not find a task matching \"" + nlp.TaskTitle +
                          "\". Say \"Show my tasks\" to see all tasks.");
                return;
            }
            taskAssistant.DeleteTask(task.Id, task.Title);
            AppendBot("Task '" + task.Title + "' has been deleted.");
        }



        private void LaunchQuiz()
        {
            activityLogger.AddEntry("User started the cybersecurity quiz.");
            AppendBot("Opening the Cybersecurity Quiz. Good luck!");
            QuizForm quiz = new QuizForm(activityLogger);
            quiz.ShowDialog(this);
        }


        private void ShowActivityLog()
        {
            if (!activityLogger.HasEntries)
            {
                AppendBot("No activity has been recorded yet. Start chatting, add tasks, or take the quiz!");
                return;
            }

            ActivityLogForm alf = new ActivityLogForm(activityLogger);
            alf.ShowDialog(this);

            var recent = activityLogger.GetRecentEntries(5);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Here is a summary of recent actions:");
            int n = 1;
            foreach (var entry in recent)
                sb.AppendLine("  " + n++ + ". " + entry.ToString());
            AppendBot(sb.ToString());
        }

        private void ShowFullActivityLog()
        {
            if (!activityLogger.HasEntries)
            {
                AppendBot("No activity recorded yet.");
                return;
            }
            ActivityLogForm alf = new ActivityLogForm(activityLogger);
            alf.ShowDialog(this);
        }

        private void HandleGeneralChat(string input)
        {
            activityLogger.AddEntry("Chat query received: \"" + input + "\"");

            string response = chatbot.GetResponse(input);
            string mood = sentimentAnalyzer.DetectMood(input);

            switch (mood)
            {
                case "worried":
                    response = "I understand why you may feel concerned about cybersecurity threats. " +
                               "Many online scams and attacks are designed to appear convincing, but " +
                               "learning how they work is one of the best ways to stay protected. " +
                               response +
                               " Remember to avoid clicking suspicious links and never share sensitive " +
                               "information unless you are certain the source is trustworthy.";
                    break;

                case "frustrated":
                    response = "Cybersecurity issues can definitely feel overwhelming and frustrating. " +
                               "Take things one step at a time and focus on basic safety practices first. " +
                               response +
                               " With consistent awareness and safe habits, protecting yourself online " +
                               "becomes much easier.";
                    break;

                case "confused":
                    response = "That is completely understandable – cybersecurity concepts can sometimes " +
                               "seem technical. Let me explain in a simpler way. " +
                               response +
                               " The most important thing is understanding how to recognise risks and " +
                               "respond safely online.";
                    break;

                case "positive":
                    response = "It is great to see your positive attitude toward cybersecurity awareness! " +
                               "Being proactive is one of the best defences against online threats. " +
                               response +
                               " Continue practising safe online habits to strengthen your digital security.";
                    break;

                case "negative":
                    response = "I am sorry you may be feeling uncertain or discouraged. " +
                               "Online safety challenges can affect anyone. " +
                               response +
                               " Understanding cybersecurity basics can greatly reduce online risks.";
                    break;

                default:
                    response = "Thank you for your question. " +
                               response +
                               " You can also say \"add a task\", \"start quiz\", or \"show activity log\" " +
                               "to use the other features.";
                    break;
            }

            AppendBot(response);
        }

        private void AppendUser(string text)
        {
            chatDisplayBox.SelectionColor = Color.DeepPink;
            chatDisplayBox.AppendText(text + "\n");
        }

        private void AppendBot(string text)
        {
            chatDisplayBox.SelectionColor = Color.Black;
            chatDisplayBox.AppendText("Bot: " + text + "\n\n");
            chatDisplayBox.ScrollToCaret();
        }


        private void titlelabel_Click(object sender, EventArgs e) { }
        private void chatDisplayBox_TextChanged(object sender, EventArgs e) { }
  
        private void TaskManagerButton_Click(object sender, EventArgs e)
        {
            ShowTasks();
        }

        private void QuizButton_Click(object sender, EventArgs e)
        {
            LaunchQuiz();
        }

        private void ActivityLogButton_Click(object sender, EventArgs e)
        {
            ShowActivityLog();
        }
    }
}