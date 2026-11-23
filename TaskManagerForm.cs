using System;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class TaskManagerForm : Form
    {
        private readonly TaskAssistant taskAssistant;

        public TaskManagerForm(TaskAssistant taskAssistant)
        {
            InitializeComponent();

            this.taskAssistant = taskAssistant;

            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                var tasks = taskAssistant.GetAllTasks();

                tasksGridView.DataSource = null;
                tasksGridView.DataSource = tasks;

                if (tasksGridView.Columns["Id"] != null)
                {
                    tasksGridView.Columns["Id"].Width = 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load tasks from the database. Please check your MySQL " +
                    "connection settings in App.config.\n\nDetails: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string description = descriptionTextBox.Text.Trim();

            DateTime? reminderDate = null;

            if (reminderCheckBox.Checked)
            {
                reminderDate = DateTime.Today.AddDays((double)reminderDaysUpDown.Value);
            }

            try
            {
                taskAssistant.AddTask(title, description, reminderDate);

                titleTextBox.Clear();
                descriptionTextBox.Clear();
                reminderCheckBox.Checked = false;

                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not save the task to the database.\n\nDetails: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CompleteTaskButton_Click(object sender, EventArgs e)
        {
            CyberTask selected = GetSelectedTask();

            if (selected == null)
            {
                MessageBox.Show("Please select a task first.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            taskAssistant.CompleteTask(selected.Id, selected.Title);

            LoadTasks();
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            CyberTask selected = GetSelectedTask();

            if (selected == null)
            {
                MessageBox.Show("Please select a task first.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Delete '" + selected.Title + "'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                taskAssistant.DeleteTask(selected.Id, selected.Title);
                LoadTasks();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private CyberTask GetSelectedTask()
        {
            if (tasksGridView.CurrentRow == null)
            {
                return null;
            }

            return tasksGridView.CurrentRow.DataBoundItem as CyberTask;
        }

        private void TaskManagerForm_Load(object sender, EventArgs e)
        {

        }
    }
}