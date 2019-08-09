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
            this.comboBoxFriends = new System.Windows.Forms.ComboBox();
            this.labelFriends = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxFriends
            // 
            this.comboBoxFriends.FormattingEnabled = true;
            this.comboBoxFriends.Items.AddRange(new object[] {
            "Zack",
            "Zoe",
            "Barnaby"});
            this.comboBoxFriends.Location = new System.Drawing.Point(65, 6);
            this.comboBoxFriends.Name = "comboBoxFriends";
            this.comboBoxFriends.Size = new System.Drawing.Size(208, 21);
            this.comboBoxFriends.TabIndex = 0;
            this.comboBoxFriends.Text = "Something";
            this.comboBoxFriends.SelectedIndexChanged += new System.EventHandler(this.comboBoxFriends_SelectedIndexChanged);
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Location = new System.Drawing.Point(12, 9);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(47, 13);
            this.labelFriends.TabIndex = 1;
            this.labelFriends.Text = "Friends: ";
            // 
            // JasonAndFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelFriends);
            this.Controls.Add(this.comboBoxFriends);
            this.Name = "JasonAndFriends";
            this.Text = "Jason and his friends";
            this.Load += new System.EventHandler(this.JasonAndFriends_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFriends;
        private System.Windows.Forms.Label labelFriends;
    }
}

