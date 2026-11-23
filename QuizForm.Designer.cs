namespace ChatBot
{
    partial class QuizForm
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
            this.progressLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.optionButton1 = new System.Windows.Forms.Button();
            this.optionButton2 = new System.Windows.Forms.Button();
            this.optionButton3 = new System.Windows.Forms.Button();
            this.optionButton4 = new System.Windows.Forms.Button();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressLabel
            // 
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.progressLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.progressLabel.Location = new System.Drawing.Point(15, 15);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(200, 22);
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "Question 1 of 12";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.Color.DarkMagenta;
            this.scoreLabel.Location = new System.Drawing.Point(330, 15);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(150, 22);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // questionLabel
            // 
            this.questionLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.questionLabel.Location = new System.Drawing.Point(15, 50);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(465, 60);
            this.questionLabel.TabIndex = 2;
            this.questionLabel.Text = "Question text goes here.";
            // 
            // optionButton1
            // 
            this.optionButton1.BackColor = System.Drawing.Color.Pink;
            this.optionButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionButton1.Location = new System.Drawing.Point(15, 120);
            this.optionButton1.Name = "optionButton1";
            this.optionButton1.Size = new System.Drawing.Size(465, 35);
            this.optionButton1.TabIndex = 3;
            this.optionButton1.Tag = 0;
            this.optionButton1.Text = "Option A";
            this.optionButton1.UseVisualStyleBackColor = false;
            this.optionButton1.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // optionButton2
            // 
            this.optionButton2.BackColor = System.Drawing.Color.Pink;
            this.optionButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionButton2.Location = new System.Drawing.Point(15, 162);
            this.optionButton2.Name = "optionButton2";
            this.optionButton2.Size = new System.Drawing.Size(465, 35);
            this.optionButton2.TabIndex = 4;
            this.optionButton2.Tag = 1;
            this.optionButton2.Text = "Option B";
            this.optionButton2.UseVisualStyleBackColor = false;
            this.optionButton2.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // optionButton3
            // 
            this.optionButton3.BackColor = System.Drawing.Color.Pink;
            this.optionButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionButton3.Location = new System.Drawing.Point(15, 204);
            this.optionButton3.Name = "optionButton3";
            this.optionButton3.Size = new System.Drawing.Size(465, 35);
            this.optionButton3.TabIndex = 5;
            this.optionButton3.Tag = 2;
            this.optionButton3.Text = "Option C";
            this.optionButton3.UseVisualStyleBackColor = false;
            this.optionButton3.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // optionButton4
            // 
            this.optionButton4.BackColor = System.Drawing.Color.Pink;
            this.optionButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionButton4.Location = new System.Drawing.Point(15, 246);
            this.optionButton4.Name = "optionButton4";
            this.optionButton4.Size = new System.Drawing.Size(465, 35);
            this.optionButton4.TabIndex = 6;
            this.optionButton4.Tag = 3;
            this.optionButton4.Text = "Option D";
            this.optionButton4.UseVisualStyleBackColor = false;
            this.optionButton4.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.feedbackLabel.Location = new System.Drawing.Point(15, 295);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(465, 60);
            this.feedbackLabel.TabIndex = 7;
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.HotPink;
            this.nextButton.Enabled = false;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(15, 360);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(150, 32);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "Next Question";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(330, 360);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(150, 32);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // QuizForm
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(495, 410);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.optionButton1);
            this.Controls.Add(this.optionButton2);
            this.Controls.Add(this.optionButton3);
            this.Controls.Add(this.optionButton4);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cybersecurity Mini-Game";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button optionButton1;
        private System.Windows.Forms.Button optionButton2;
        private System.Windows.Forms.Button optionButton3;
        private System.Windows.Forms.Button optionButton4;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button closeButton;
    }
}