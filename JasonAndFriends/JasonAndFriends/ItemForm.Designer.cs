namespace JasonAndFriends
{
    partial class ItemForm
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
            this.labelItemQuantity = new System.Windows.Forms.Label();
            this.numericUpDownItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.comboBoxItemType = new System.Windows.Forms.ComboBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanelItems = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemQuantity)).BeginInit();
            this.tableLayoutPanelItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelItemQuantity
            // 
            this.labelItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemQuantity.AutoSize = true;
            this.labelItemQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemQuantity.Location = new System.Drawing.Point(216, 9);
            this.labelItemQuantity.Name = "labelItemQuantity";
            this.labelItemQuantity.Size = new System.Drawing.Size(15, 15);
            this.labelItemQuantity.TabIndex = 2;
            this.labelItemQuantity.Text = "X";
            // 
            // numericUpDownItemQuantity
            // 
            this.numericUpDownItemQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownItemQuantity.Location = new System.Drawing.Point(235, 9);
            this.numericUpDownItemQuantity.Name = "numericUpDownItemQuantity";
            this.numericUpDownItemQuantity.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownItemQuantity.TabIndex = 3;
            this.numericUpDownItemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownItemQuantity.ValueChanged += new System.EventHandler(this.numericUpDownItemQuantity_ValueChanged);
            // 
            // comboBoxItemName
            // 
            this.comboBoxItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItemName.FormattingEnabled = true;
            this.comboBoxItemName.Location = new System.Drawing.Point(12, 8);
            this.comboBoxItemName.Name = "comboBoxItemName";
            this.comboBoxItemName.Size = new System.Drawing.Size(198, 21);
            this.comboBoxItemName.TabIndex = 4;
            this.comboBoxItemName.Text = "<Item Name>";
            this.comboBoxItemName.TextUpdate += new System.EventHandler(this.comboBoxItemName_TextChanged);
            this.comboBoxItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxItemName_KeyPressed);
            this.comboBoxItemName.Leave += new System.EventHandler(this.comboBoxItemName_Leave);
            // 
            // comboBoxItemType
            // 
            this.comboBoxItemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItemType.FormattingEnabled = true;
            this.comboBoxItemType.Location = new System.Drawing.Point(12, 36);
            this.comboBoxItemType.Name = "comboBoxItemType";
            this.comboBoxItemType.Size = new System.Drawing.Size(260, 21);
            this.comboBoxItemType.TabIndex = 5;
            this.comboBoxItemType.Text = "Item Type";
            this.comboBoxItemType.Visible = false;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(3, 3);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(80, 23);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(89, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(80, 23);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(175, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tableLayoutPanelItems
            // 
            this.tableLayoutPanelItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelItems.ColumnCount = 3;
            this.tableLayoutPanelItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelItems.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanelItems.Controls.Add(this.buttonConfirm, 0, 0);
            this.tableLayoutPanelItems.Controls.Add(this.buttonReset, 1, 0);
            this.tableLayoutPanelItems.Location = new System.Drawing.Point(12, 119);
            this.tableLayoutPanelItems.Name = "tableLayoutPanelItems";
            this.tableLayoutPanelItems.RowCount = 1;
            this.tableLayoutPanelItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelItems.Size = new System.Drawing.Size(260, 30);
            this.tableLayoutPanelItems.TabIndex = 9;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tableLayoutPanelItems);
            this.Controls.Add(this.comboBoxItemType);
            this.Controls.Add(this.comboBoxItemName);
            this.Controls.Add(this.numericUpDownItemQuantity);
            this.Controls.Add(this.labelItemQuantity);
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "ItemForm";
            this.Text = "ItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemQuantity)).EndInit();
            this.tableLayoutPanelItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelItemQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownItemQuantity;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.ComboBox comboBoxItemType;
        private System.Windows.Forms.Button buttonConfirm;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItems;
    }
}