namespace ChatBot
{
    partial class TaskManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.reminderCheckBox = new System.Windows.Forms.CheckBox();
            this.reminderDaysUpDown = new System.Windows.Forms.NumericUpDown();
            this.reminderDaysLabel = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.completeTaskButton = new System.Windows.Forms.Button();
            this.deleteTaskButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reminderDaysUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.headerLabel.Location = new System.Drawing.Point(15, 15);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(500, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Cybersecurity Task Assistant";
            // 
            // tasksGridView
            // 
            this.tasksGridView.AllowUserToAddRows = false;
            this.tasksGridView.AllowUserToDeleteRows = false;
            this.tasksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tasksGridView.BackgroundColor = System.Drawing.Color.White;
            this.tasksGridView.Location = new System.Drawing.Point(15, 55);
            this.tasksGridView.MultiSelect = false;
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.ReadOnly = true;
            this.tasksGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksGridView.Size = new System.Drawing.Size(660, 220);
            this.tasksGridView.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(15, 290);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 20);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Task title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(120, 287);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(300, 20);
            this.titleTextBox.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(15, 320);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(100, 20);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(120, 317);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(300, 20);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // reminderCheckBox
            // 
            this.reminderCheckBox.Location = new System.Drawing.Point(15, 352);
            this.reminderCheckBox.Name = "reminderCheckBox";
            this.reminderCheckBox.Size = new System.Drawing.Size(110, 24);
            this.reminderCheckBox.TabIndex = 6;
            this.reminderCheckBox.Text = "Set reminder";
            // 
            // reminderDaysUpDown
            // 
            this.reminderDaysUpDown.Location = new System.Drawing.Point(140, 352);
            this.reminderDaysUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.reminderDaysUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reminderDaysUpDown.Name = "reminderDaysUpDown";
            this.reminderDaysUpDown.Size = new System.Drawing.Size(60, 20);
            this.reminderDaysUpDown.TabIndex = 7;
            this.reminderDaysUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // reminderDaysLabel
            // 
            this.reminderDaysLabel.Location = new System.Drawing.Point(205, 355);
            this.reminderDaysLabel.Name = "reminderDaysLabel";
            this.reminderDaysLabel.Size = new System.Drawing.Size(140, 20);
            this.reminderDaysLabel.TabIndex = 8;
            this.reminderDaysLabel.Text = "day(s) from now";
            // 
            // addTaskButton
            // 
            this.addTaskButton.BackColor = System.Drawing.Color.HotPink;
            this.addTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskButton.ForeColor = System.Drawing.Color.White;
            this.addTaskButton.Location = new System.Drawing.Point(450, 287);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(110, 30);
            this.addTaskButton.TabIndex = 9;
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.UseVisualStyleBackColor = false;
            this.addTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // completeTaskButton
            // 
            this.completeTaskButton.BackColor = System.Drawing.Color.LightGreen;
            this.completeTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeTaskButton.Location = new System.Drawing.Point(15, 390);
            this.completeTaskButton.Name = "completeTaskButton";
            this.completeTaskButton.Size = new System.Drawing.Size(150, 30);
            this.completeTaskButton.TabIndex = 10;
            this.completeTaskButton.Text = "Mark Completed";
            this.completeTaskButton.UseVisualStyleBackColor = false;
            this.completeTaskButton.Click += new System.EventHandler(this.CompleteTaskButton_Click);
            // 
            // deleteTaskButton
            // 
            this.deleteTaskButton.BackColor = System.Drawing.Color.LightCoral;
            this.deleteTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTaskButton.Location = new System.Drawing.Point(180, 390);
            this.deleteTaskButton.Name = "deleteTaskButton";
            this.deleteTaskButton.Size = new System.Drawing.Size(150, 30);
            this.deleteTaskButton.TabIndex = 11;
            this.deleteTaskButton.Text = "Delete Task";
            this.deleteTaskButton.UseVisualStyleBackColor = false;
            this.deleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(345, 390);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(110, 30);
            this.refreshButton.TabIndex = 12;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(565, 390);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(110, 30);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TaskManagerForm
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(692, 440);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.tasksGridView);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.reminderCheckBox);
            this.Controls.Add(this.reminderDaysUpDown);
            this.Controls.Add(this.reminderDaysLabel);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.completeTaskButton);
            this.Controls.Add(this.deleteTaskButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Manager - Cybersecurity Assistant";
            this.Load += new System.EventHandler(this.TaskManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reminderDaysUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.CheckBox reminderCheckBox;
        private System.Windows.Forms.NumericUpDown reminderDaysUpDown;
        private System.Windows.Forms.Label reminderDaysLabel;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button completeTaskButton;
        private System.Windows.Forms.Button deleteTaskButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button closeButton;
    }
}