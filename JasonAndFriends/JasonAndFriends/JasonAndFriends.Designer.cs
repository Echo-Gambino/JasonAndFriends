namespace JasonAndFriends
{
    partial class JasonAndFriends
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
            this.comboBoxSelFriends = new System.Windows.Forms.ComboBox();
            this.labelFriends = new System.Windows.Forms.Label();
            this.buttonAddFriend = new System.Windows.Forms.Button();
            this.buttonDelFriend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSelFriends
            // 
            this.comboBoxSelFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelFriends.FormattingEnabled = true;
            this.comboBoxSelFriends.Items.AddRange(new object[] {
            "Zack",
            "Zoe",
            "Barnaby"});
            this.comboBoxSelFriends.Location = new System.Drawing.Point(56, 7);
            this.comboBoxSelFriends.MinimumSize = new System.Drawing.Size(100, 0);
            this.comboBoxSelFriends.Name = "comboBoxSelFriends";
            this.comboBoxSelFriends.Size = new System.Drawing.Size(195, 21);
            this.comboBoxSelFriends.TabIndex = 0;
            this.comboBoxSelFriends.Text = "Something";
            this.comboBoxSelFriends.SelectedIndexChanged += new System.EventHandler(this.comboBoxFriends_SelectedIndexChanged);
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Location = new System.Drawing.Point(3, 10);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(47, 13);
            this.labelFriends.TabIndex = 1;
            this.labelFriends.Text = "Friends: ";
            // 
            // buttonAddFriend
            // 
            this.buttonAddFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFriend.Location = new System.Drawing.Point(257, 7);
            this.buttonAddFriend.MaximumSize = new System.Drawing.Size(1000, 21);
            this.buttonAddFriend.Name = "buttonAddFriend";
            this.buttonAddFriend.Size = new System.Drawing.Size(75, 21);
            this.buttonAddFriend.TabIndex = 2;
            this.buttonAddFriend.Text = "Add";
            this.buttonAddFriend.UseVisualStyleBackColor = true;
            // 
            // buttonDelFriend
            // 
            this.buttonDelFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelFriend.Location = new System.Drawing.Point(338, 7);
            this.buttonDelFriend.MaximumSize = new System.Drawing.Size(1000, 21);
            this.buttonDelFriend.Name = "buttonDelFriend";
            this.buttonDelFriend.Size = new System.Drawing.Size(75, 21);
            this.buttonDelFriend.TabIndex = 3;
            this.buttonDelFriend.Text = "Remove";
            this.buttonDelFriend.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.comboBoxSelFriends);
            this.panel1.Controls.Add(this.buttonDelFriend);
            this.panel1.Controls.Add(this.labelFriends);
            this.panel1.Controls.Add(this.buttonAddFriend);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 390);
            this.panel1.TabIndex = 4;
            // 
            // JasonAndFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 394);
            this.Controls.Add(this.panel1);
            this.Name = "JasonAndFriends";
            this.Text = "Jason and his friends";
            this.Load += new System.EventHandler(this.JasonAndFriends_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelFriends;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.Button buttonAddFriend;
        private System.Windows.Forms.Button buttonDelFriend;
        private System.Windows.Forms.Panel panel1;
    }
}

