namespace Jarvis
{
    partial class Jarvis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.commandsListBox = new System.Windows.Forms.ListBox();
            this.speakingTimer = new System.Windows.Forms.Timer(this.components);
            this.speechOutputTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // commandsListBox
            // 
            this.commandsListBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.commandsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsListBox.ForeColor = System.Drawing.Color.White;
            this.commandsListBox.FormattingEnabled = true;
            this.commandsListBox.ItemHeight = 16;
            this.commandsListBox.Location = new System.Drawing.Point(0, 0);
            this.commandsListBox.Margin = new System.Windows.Forms.Padding(4);
            this.commandsListBox.Name = "commandsListBox";
            this.commandsListBox.Size = new System.Drawing.Size(839, 527);
            this.commandsListBox.TabIndex = 0;
            this.commandsListBox.Visible = false;
            // 
            // speakingTimer
            // 
            this.speakingTimer.Interval = 1000;
            this.speakingTimer.Tick += new System.EventHandler(this.speakingTimer_Tick);
            // 
            // speechOutputTimer
            // 
            this.speechOutputTimer.Enabled = true;
            this.speechOutputTimer.Tick += new System.EventHandler(this.speechOutputTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(839, 527);
            this.Controls.Add(this.commandsListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Jarvis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox commandsListBox;
        private System.Windows.Forms.Timer speakingTimer;
        private System.Windows.Forms.Timer speechOutputTimer;
    }
}

