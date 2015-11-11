namespace Repair_Windows_Updates
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusLable = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.completedList = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLable
            // 
            this.statusLable.AutoSize = true;
            this.statusLable.Location = new System.Drawing.Point(14, 78);
            this.statusLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLable.Name = "statusLable";
            this.statusLable.Size = new System.Drawing.Size(64, 20);
            this.statusLable.TabIndex = 0;
            this.statusLable.Text = "Status: ";
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(88, 78);
            this.statusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(44, 20);
            this.statusText.TabIndex = 1;
            this.statusText.Text = "Start";
            // 
            // completedList
            // 
            this.completedList.FormattingEnabled = true;
            this.completedList.HorizontalScrollbar = true;
            this.completedList.ItemHeight = 20;
            this.completedList.Location = new System.Drawing.Point(13, 203);
            this.completedList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.completedList.Name = "completedList";
            this.completedList.Size = new System.Drawing.Size(451, 324);
            this.completedList.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 158);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(112, 35);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start Fix";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(477, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(477, 545);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.completedList);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.statusLable);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repair Windows Updates";
            this.Load += new System.EventHandler(this.Form1_load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLable;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.ListBox completedList;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

