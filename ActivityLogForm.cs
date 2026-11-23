using System.Windows.Forms;

namespace ChatBot
{

    public partial class ActivityLogForm : Form
    {
        private readonly ActivityLogger activityLogger;
        private bool showingFullHistory = false;

        public ActivityLogForm(ActivityLogger activityLogger)
        {
            InitializeComponent();

            this.activityLogger = activityLogger;

            DisplayRecentEntries();
        }

        private void DisplayRecentEntries()
        {
            logListBox.Items.Clear();

            if (!activityLogger.HasEntries)
            {
                logListBox.Items.Add("No activity has been recorded yet.");
                return;
            }

            foreach (var entry in activityLogger.GetRecentEntries(10))
            {
                logListBox.Items.Add(entry.ToString());
            }

            showingFullHistory = false;
            showFullHistoryButton.Text = "Show Full History";
        }

        private void ShowFullHistoryButton_Click(object sender, System.EventArgs e)
        {
            logListBox.Items.Clear();

            if (showingFullHistory)
            {
                DisplayRecentEntries();
                return;
            }

            foreach (var entry in activityLogger.GetAllEntries())
            {
                logListBox.Items.Add(entry.ToString());
            }

            showingFullHistory = true;
            showFullHistoryButton.Text = "Show Recent Only";
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ActivityLogForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}