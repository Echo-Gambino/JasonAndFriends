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
            this.buttonNewFriend = new System.Windows.Forms.Button();
            this.buttonDelFriend = new System.Windows.Forms.Button();
            this.panelFriendInfo = new System.Windows.Forms.Panel();
            this.buttonResetFriend = new System.Windows.Forms.Button();
            this.buttonSaveFriend = new System.Windows.Forms.Button();
            this.textBoxFriendName = new System.Windows.Forms.TextBox();
            this.labelFriendName = new System.Windows.Forms.Label();
            this.radioButtonDietaryYes = new System.Windows.Forms.RadioButton();
            this.radioButtonDietaryNo = new System.Windows.Forms.RadioButton();
            this.labelDietary = new System.Windows.Forms.Label();
            this.labelCanDrink = new System.Windows.Forms.Label();
            this.radioButtonCanDrinkYes = new System.Windows.Forms.RadioButton();
            this.radioButtonCanDrinkNo = new System.Windows.Forms.RadioButton();
            this.panelDietary = new System.Windows.Forms.Panel();
            this.panelCanDrink = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFriendInfo.SuspendLayout();
            this.panelDietary.SuspendLayout();
            this.panelCanDrink.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSelFriends
            // 
            this.comboBoxSelFriends.AllowDrop = true;
            this.comboBoxSelFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelFriends.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelFriends.FormattingEnabled = true;
            this.comboBoxSelFriends.Location = new System.Drawing.Point(48, 7);
            this.comboBoxSelFriends.MinimumSize = new System.Drawing.Size(100, 0);
            this.comboBoxSelFriends.Name = "comboBoxSelFriends";
            this.comboBoxSelFriends.Size = new System.Drawing.Size(439, 21);
            this.comboBoxSelFriends.TabIndex = 0;
            this.comboBoxSelFriends.SelectedIndexChanged += new System.EventHandler(this.comboBoxFriends_SelectedIndexChanged);
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Location = new System.Drawing.Point(4, 11);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(44, 13);
            this.labelFriends.TabIndex = 1;
            this.labelFriends.Text = "Friends:";
            // 
            // buttonNewFriend
            // 
            this.buttonNewFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewFriend.Location = new System.Drawing.Point(493, 7);
            this.buttonNewFriend.MaximumSize = new System.Drawing.Size(1000, 21);
            this.buttonNewFriend.Name = "buttonNewFriend";
            this.buttonNewFriend.Size = new System.Drawing.Size(75, 21);
            this.buttonNewFriend.TabIndex = 2;
            this.buttonNewFriend.Text = "New";
            this.buttonNewFriend.UseVisualStyleBackColor = true;
            this.buttonNewFriend.Click += new System.EventHandler(this.buttonNewFriend_Click);
            // 
            // buttonDelFriend
            // 
            this.buttonDelFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelFriend.Location = new System.Drawing.Point(574, 7);
            this.buttonDelFriend.MaximumSize = new System.Drawing.Size(1000, 21);
            this.buttonDelFriend.Name = "buttonDelFriend";
            this.buttonDelFriend.Size = new System.Drawing.Size(75, 21);
            this.buttonDelFriend.TabIndex = 3;
            this.buttonDelFriend.Text = "Remove";
            this.buttonDelFriend.UseVisualStyleBackColor = true;
            this.buttonDelFriend.Click += new System.EventHandler(this.buttonDelFriend_Click);
            // 
            // panelFriendInfo
            // 
            this.panelFriendInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFriendInfo.Controls.Add(this.tableLayoutPanel1);
            this.panelFriendInfo.Controls.Add(this.buttonResetFriend);
            this.panelFriendInfo.Controls.Add(this.buttonSaveFriend);
            this.panelFriendInfo.Controls.Add(this.textBoxFriendName);
            this.panelFriendInfo.Controls.Add(this.labelFriendName);
            this.panelFriendInfo.Controls.Add(this.comboBoxSelFriends);
            this.panelFriendInfo.Controls.Add(this.buttonDelFriend);
            this.panelFriendInfo.Controls.Add(this.labelFriends);
            this.panelFriendInfo.Controls.Add(this.buttonNewFriend);
            this.panelFriendInfo.Location = new System.Drawing.Point(2, 2);
            this.panelFriendInfo.Name = "panelFriendInfo";
            this.panelFriendInfo.Size = new System.Drawing.Size(656, 504);
            this.panelFriendInfo.TabIndex = 4;
            // 
            // buttonResetFriend
            // 
            this.buttonResetFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetFriend.Location = new System.Drawing.Point(493, 478);
            this.buttonResetFriend.Name = "buttonResetFriend";
            this.buttonResetFriend.Size = new System.Drawing.Size(75, 23);
            this.buttonResetFriend.TabIndex = 7;
            this.buttonResetFriend.Text = "Reset";
            this.buttonResetFriend.UseVisualStyleBackColor = true;
            this.buttonResetFriend.Click += new System.EventHandler(this.buttonResetFriend_Click);
            // 
            // buttonSaveFriend
            // 
            this.buttonSaveFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveFriend.Location = new System.Drawing.Point(574, 478);
            this.buttonSaveFriend.Name = "buttonSaveFriend";
            this.buttonSaveFriend.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFriend.TabIndex = 6;
            this.buttonSaveFriend.Text = "Save";
            this.buttonSaveFriend.UseVisualStyleBackColor = true;
            this.buttonSaveFriend.Click += new System.EventHandler(this.buttonSaveFriend_Click);
            // 
            // textBoxFriendName
            // 
            this.textBoxFriendName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFriendName.Location = new System.Drawing.Point(48, 36);
            this.textBoxFriendName.Name = "textBoxFriendName";
            this.textBoxFriendName.Size = new System.Drawing.Size(601, 20);
            this.textBoxFriendName.TabIndex = 5;
            // 
            // labelFriendName
            // 
            this.labelFriendName.AutoSize = true;
            this.labelFriendName.Location = new System.Drawing.Point(10, 39);
            this.labelFriendName.Name = "labelFriendName";
            this.labelFriendName.Size = new System.Drawing.Size(38, 13);
            this.labelFriendName.TabIndex = 4;
            this.labelFriendName.Text = "Name:";
            // 
            // radioButtonDietaryYes
            // 
            this.radioButtonDietaryYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonDietaryYes.AutoSize = true;
            this.radioButtonDietaryYes.Location = new System.Drawing.Point(214, 19);
            this.radioButtonDietaryYes.Name = "radioButtonDietaryYes";
            this.radioButtonDietaryYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonDietaryYes.TabIndex = 8;
            this.radioButtonDietaryYes.Text = "Yes";
            this.radioButtonDietaryYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonDietaryNo
            // 
            this.radioButtonDietaryNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonDietaryNo.AutoSize = true;
            this.radioButtonDietaryNo.Checked = true;
            this.radioButtonDietaryNo.Location = new System.Drawing.Point(271, 19);
            this.radioButtonDietaryNo.Name = "radioButtonDietaryNo";
            this.radioButtonDietaryNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonDietaryNo.TabIndex = 9;
            this.radioButtonDietaryNo.TabStop = true;
            this.radioButtonDietaryNo.Text = "No";
            this.radioButtonDietaryNo.UseVisualStyleBackColor = true;
            // 
            // labelDietary
            // 
            this.labelDietary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDietary.AutoSize = true;
            this.labelDietary.Location = new System.Drawing.Point(211, 0);
            this.labelDietary.Name = "labelDietary";
            this.labelDietary.Size = new System.Drawing.Size(98, 13);
            this.labelDietary.TabIndex = 10;
            this.labelDietary.Text = "Dietary Restrictions";
            // 
            // labelCanDrink
            // 
            this.labelCanDrink.AutoSize = true;
            this.labelCanDrink.Location = new System.Drawing.Point(3, 0);
            this.labelCanDrink.Name = "labelCanDrink";
            this.labelCanDrink.Size = new System.Drawing.Size(101, 13);
            this.labelCanDrink.TabIndex = 11;
            this.labelCanDrink.Text = "Over 18 (Can Drink)";
            // 
            // radioButtonCanDrinkYes
            // 
            this.radioButtonCanDrinkYes.AutoSize = true;
            this.radioButtonCanDrinkYes.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCanDrinkYes.Name = "radioButtonCanDrinkYes";
            this.radioButtonCanDrinkYes.Size = new System.Drawing.Size(43, 17);
            this.radioButtonCanDrinkYes.TabIndex = 12;
            this.radioButtonCanDrinkYes.Text = "Yes";
            this.radioButtonCanDrinkYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonCanDrinkNo
            // 
            this.radioButtonCanDrinkNo.AutoSize = true;
            this.radioButtonCanDrinkNo.Checked = true;
            this.radioButtonCanDrinkNo.Location = new System.Drawing.Point(65, 19);
            this.radioButtonCanDrinkNo.Name = "radioButtonCanDrinkNo";
            this.radioButtonCanDrinkNo.Size = new System.Drawing.Size(39, 17);
            this.radioButtonCanDrinkNo.TabIndex = 13;
            this.radioButtonCanDrinkNo.TabStop = true;
            this.radioButtonCanDrinkNo.Text = "No";
            this.radioButtonCanDrinkNo.UseVisualStyleBackColor = true;
            // 
            // panelDietary
            // 
            this.panelDietary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDietary.Controls.Add(this.labelDietary);
            this.panelDietary.Controls.Add(this.radioButtonDietaryYes);
            this.panelDietary.Controls.Add(this.radioButtonDietaryNo);
            this.panelDietary.Location = new System.Drawing.Point(3, 3);
            this.panelDietary.Name = "panelDietary";
            this.panelDietary.Size = new System.Drawing.Size(313, 39);
            this.panelDietary.TabIndex = 14;
            // 
            // panelCanDrink
            // 
            this.panelCanDrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanDrink.Controls.Add(this.labelCanDrink);
            this.panelCanDrink.Controls.Add(this.radioButtonCanDrinkYes);
            this.panelCanDrink.Controls.Add(this.radioButtonCanDrinkNo);
            this.panelCanDrink.Location = new System.Drawing.Point(322, 3);
            this.panelCanDrink.Name = "panelCanDrink";
            this.panelCanDrink.Size = new System.Drawing.Size(317, 39);
            this.panelCanDrink.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.77778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.22222F));
            this.tableLayoutPanel1.Controls.Add(this.panelDietary, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCanDrink);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 410);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // JasonAndFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 508);
            this.Controls.Add(this.panelFriendInfo);
            this.MinimumSize = new System.Drawing.Size(525, 0);
            this.Name = "JasonAndFriends";
            this.Text = "Jason and his friends";
            this.Load += new System.EventHandler(this.JasonAndFriends_Load);
            this.panelFriendInfo.ResumeLayout(false);
            this.panelFriendInfo.PerformLayout();
            this.panelDietary.ResumeLayout(false);
            this.panelDietary.PerformLayout();
            this.panelCanDrink.ResumeLayout(false);
            this.panelCanDrink.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.Button buttonNewFriend;
        private System.Windows.Forms.Button buttonDelFriend;
        private System.Windows.Forms.Panel panelFriendInfo;
        private System.Windows.Forms.TextBox textBoxFriendName;
        private System.Windows.Forms.Label labelFriendName;
        private System.Windows.Forms.ComboBox comboBoxSelFriends;
        private System.Windows.Forms.Button buttonResetFriend;
        private System.Windows.Forms.Button buttonSaveFriend;
        private System.Windows.Forms.RadioButton radioButtonCanDrinkNo;
        private System.Windows.Forms.RadioButton radioButtonCanDrinkYes;
        private System.Windows.Forms.Label labelCanDrink;
        private System.Windows.Forms.Label labelDietary;
        private System.Windows.Forms.RadioButton radioButtonDietaryNo;
        private System.Windows.Forms.RadioButton radioButtonDietaryYes;
        private System.Windows.Forms.Panel panelCanDrink;
        private System.Windows.Forms.Panel panelDietary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

