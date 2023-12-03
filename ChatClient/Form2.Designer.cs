namespace ChatClient
{
    partial class Form2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtServerIP = new TextBox();
            txtServerPort = new TextBox();
            txtMessage = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            txtChat = new TextBox();
            lblStatus = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(71, 35);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(100, 23);
            txtServerIP.TabIndex = 0;
            txtServerIP.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(71, 79);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(100, 23);
            txtServerPort.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(218, 79);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(162, 208);
            txtMessage.TabIndex = 2;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(83, 137);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(255, 302);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtChat
            // 
            txtChat.Location = new Point(427, 24);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(348, 403);
            txtChat.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(32, 412);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(218, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(162, 23);
            txtName.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtName);
            Controls.Add(lblStatus);
            Controls.Add(txtChat);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtMessage);
            Controls.Add(txtServerPort);
            Controls.Add(txtServerIP);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServerIP;
        private TextBox txtServerPort;
        private TextBox txtMessage;
        private Button btnConnect;
        private Button btnSend;
        private TextBox txtChat;
        private Label lblStatus;
        private TextBox txtName;
    }
}