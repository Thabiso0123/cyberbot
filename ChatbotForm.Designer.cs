namespace ChatBot
{
    partial class ChatbotForm
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
            this.titlelabel = new System.Windows.Forms.Label();
            this.chatDisplayBox = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sidebarpanel = new System.Windows.Forms.Panel();
            this.topicListBox = new System.Windows.Forms.ListBox();
            this.quickActionsLabel = new System.Windows.Forms.Label();
            this.taskManagerButton = new System.Windows.Forms.Button();
            this.quizButton = new System.Windows.Forms.Button();
            this.activityLogButton = new System.Windows.Forms.Button();
            this.sidebarpanel.SuspendLayout();
            this.SuspendLayout();
    
            this.titlelabel.BackColor = System.Drawing.Color.Transparent;
            this.titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.titlelabel.Location = new System.Drawing.Point(10, 10);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(760, 45);
            this.titlelabel.TabIndex = 0;
            this.titlelabel.Text = "CYBERSECURITY AWARENESS ASSISANT BOT ";
            this.titlelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titlelabel.Click += new System.EventHandler(this.titlelabel_Click);
     
            this.chatDisplayBox.BackColor = System.Drawing.Color.White;
            this.chatDisplayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatDisplayBox.ForeColor = System.Drawing.Color.Black;
            this.chatDisplayBox.Location = new System.Drawing.Point(20, 70);
            this.chatDisplayBox.Name = "chatDisplayBox";
            this.chatDisplayBox.ReadOnly = true;
            this.chatDisplayBox.Size = new System.Drawing.Size(740, 468);
            this.chatDisplayBox.TabIndex = 1;
            this.chatDisplayBox.Text = "";
            this.chatDisplayBox.TextChanged += new System.EventHandler(this.chatDisplayBox_TextChanged);
 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(20, 571);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(560, 22);
            this.inputTextBox.TabIndex = 2;
   
            this.sendButton.BackColor = System.Drawing.Color.LightPink;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.Location = new System.Drawing.Point(620, 561);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(140, 32);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
   
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1060, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "System Protected";
      
            this.sidebarpanel.BackColor = System.Drawing.Color.HotPink;
            this.sidebarpanel.Controls.Add(this.activityLogButton);
            this.sidebarpanel.Controls.Add(this.quizButton);
            this.sidebarpanel.Controls.Add(this.taskManagerButton);
            this.sidebarpanel.Controls.Add(this.quickActionsLabel);
            this.sidebarpanel.Controls.Add(this.topicListBox);
            this.sidebarpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidebarpanel.Location = new System.Drawing.Point(860, 0);
            this.sidebarpanel.Name = "sidebarpanel";
            this.sidebarpanel.Size = new System.Drawing.Size(200, 666);
            this.sidebarpanel.TabIndex = 5;

            this.topicListBox.BackColor = System.Drawing.Color.Pink;
            this.topicListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.topicListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicListBox.FormattingEnabled = true;
            this.topicListBox.ItemHeight = 17;
            this.topicListBox.Location = new System.Drawing.Point(0, 0);
            this.topicListBox.Name = "topicListBox";
            this.topicListBox.Size = new System.Drawing.Size(200, 430);
            this.topicListBox.TabIndex = 0;
 
            this.quickActionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.quickActionsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.quickActionsLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.quickActionsLabel.Location = new System.Drawing.Point(10, 440);
            this.quickActionsLabel.Size = new System.Drawing.Size(180, 20);
            this.quickActionsLabel.Text = "Quick Actions";
            this.quickActionsLabel.TabIndex = 1;

            this.taskManagerButton.BackColor = System.Drawing.Color.White;
            this.taskManagerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskManagerButton.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.taskManagerButton.Location = new System.Drawing.Point(10, 465);
            this.taskManagerButton.Name = "taskManagerButton";
            this.taskManagerButton.Size = new System.Drawing.Size(180, 36);
            this.taskManagerButton.TabIndex = 2;
            this.taskManagerButton.Text = "Task Manager";
            this.taskManagerButton.UseVisualStyleBackColor = false;
            this.taskManagerButton.Click += new System.EventHandler(this.TaskManagerButton_Click);

            this.quizButton.BackColor = System.Drawing.Color.White;
            this.quizButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quizButton.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.quizButton.Location = new System.Drawing.Point(10, 507);
            this.quizButton.Name = "quizButton";
            this.quizButton.Size = new System.Drawing.Size(180, 36);
            this.quizButton.TabIndex = 3;
            this.quizButton.Text = "Cybersecurity Quiz";
            this.quizButton.UseVisualStyleBackColor = false;
            this.quizButton.Click += new System.EventHandler(this.QuizButton_Click);
 
            this.activityLogButton.BackColor = System.Drawing.Color.White;
            this.activityLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activityLogButton.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.activityLogButton.Location = new System.Drawing.Point(10, 549);
            this.activityLogButton.Name = "activityLogButton";
            this.activityLogButton.Size = new System.Drawing.Size(180, 36);
            this.activityLogButton.TabIndex = 4;
            this.activityLogButton.Text = "Activity Log";
            this.activityLogButton.UseVisualStyleBackColor = false;
            this.activityLogButton.Click += new System.EventHandler(this.ActivityLogButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1060, 688);
            this.Controls.Add(this.sidebarpanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.chatDisplayBox);
            this.Controls.Add(this.titlelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ChatbotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cybersecurity Awareness Bot";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            this.sidebarpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label titlelabel;
        private System.Windows.Forms.RichTextBox chatDisplayBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel sidebarpanel;
        private System.Windows.Forms.ListBox topicListBox;
        private System.Windows.Forms.Label quickActionsLabel;
        private System.Windows.Forms.Button taskManagerButton;
        private System.Windows.Forms.Button quizButton;
        private System.Windows.Forms.Button activityLogButton;
    }
}