namespace WindowsFormsClient
{
    partial class MainWindow
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
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MessagesListBox = new System.Windows.Forms.ListBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.UpdateMessagesTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendMessageButton.Location = new System.Drawing.Point(908, 504);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(151, 39);
            this.SendMessageButton.TabIndex = 0;
            this.SendMessageButton.Text = "Send";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // MessagesListBox
            // 
            this.MessagesListBox.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessagesListBox.FormattingEnabled = true;
            this.MessagesListBox.ItemHeight = 27;
            this.MessagesListBox.Location = new System.Drawing.Point(13, 45);
            this.MessagesListBox.Name = "MessagesListBox";
            this.MessagesListBox.ScrollAlwaysVisible = true;
            this.MessagesListBox.Size = new System.Drawing.Size(1046, 436);
            this.MessagesListBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(117, 30);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "NickName";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageTextBox.Location = new System.Drawing.Point(12, 504);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(890, 39);
            this.messageTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(126, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(208, 34);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_TextChanged);
            // 
            // UpdateMessagesTimer
            // 
            this.UpdateMessagesTimer.Tick += new System.EventHandler(this.UpdateMessagesTimer_Tick);
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1071, 555);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.MessagesListBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SendMessageButton);
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox MessagesListBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Timer UpdateMessagesTimer;
    }
}

