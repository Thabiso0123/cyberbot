namespace ChatBot
{
    partial class ActivityLogForm
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
            this.logListBox = new System.Windows.Forms.ListBox();
            this.showFullHistoryButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.headerLabel.Location = new System.Drawing.Point(15, 15);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(420, 28);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Bot Activity Log";
            // 
            // logListBox
            // 
            this.logListBox.BackColor = System.Drawing.Color.White;
            this.logListBox.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.logListBox.HorizontalScrollbar = true;
            this.logListBox.ItemHeight = 15;
            this.logListBox.Location = new System.Drawing.Point(15, 55);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(450, 274);
            this.logListBox.TabIndex = 1;
            // 
            // showFullHistoryButton
            // 
            this.showFullHistoryButton.BackColor = System.Drawing.Color.HotPink;
            this.showFullHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showFullHistoryButton.ForeColor = System.Drawing.Color.White;
            this.showFullHistoryButton.Location = new System.Drawing.Point(15, 345);
            this.showFullHistoryButton.Name = "showFullHistoryButton";
            this.showFullHistoryButton.Size = new System.Drawing.Size(180, 32);
            this.showFullHistoryButton.TabIndex = 2;
            this.showFullHistoryButton.Text = "Show Full History";
            this.showFullHistoryButton.UseVisualStyleBackColor = false;
            this.showFullHistoryButton.Click += new System.EventHandler(this.ShowFullHistoryButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(285, 345);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(180, 32);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ActivityLogForm
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(480, 395);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.showFullHistoryButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivityLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Activity Log - Cybersecurity Assistant";
            this.Load += new System.EventHandler(this.ActivityLogForm_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button showFullHistoryButton;
        private System.Windows.Forms.Button closeButton;
    }
}