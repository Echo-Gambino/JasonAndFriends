namespace JasonAndFriends
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Newtonsoft.Json;

    using Classes;

    public partial class ItemForm : Form
    {
        private const string EMPTY_NAME_PROMPT = "<Item Name>";

        private Item item;

        private string data;

        private string lastItemName;

        public Item Item
        {
            get { return this.item; }
        }

        public string Data
        {
            get { return this.data; }
        }

        public ItemForm(Item item = null)
        {
            InitializeComponent();

            this.lastItemName = string.Empty;

            if (item == null)
            {
                item = new Item();
            }

            this.data = SerializeItem(item);

            this.item = DeserializeItem(this.data);

            DisplayItemParams(this.item);

        }

        #region Private Methods

        private void DisplayItemParams(Item item)
        {
            string text = EMPTY_NAME_PROMPT;

            if (item.Name != "")
                text = item.Name;

            this.comboBoxItemName.Text = text;

            this.numericUpDownItemQuantity.Value = item.Quantity;
        }

        private void ResetFields()
        {
            this.item = DeserializeItem(this.data);

            DisplayItemParams(this.item);
        }

        private string SerializeItem(Item item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }

        private Item DeserializeItem(string data)
        {
            return JsonConvert.DeserializeObject<Item>(data);
        }

        #endregion Private Methods

        #region Event Handler

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // Check for invalid user inputs 
            string itemName = this.comboBoxItemName.Text;
            if ((itemName == EMPTY_NAME_PROMPT) || string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show(
                    "Item name is not valid, please specify an item name", 
                    "Cannot Confirm Changes",
                    MessageBoxButtons.OK);

                ResetFields();

                return;
            }

            // Finalize confirmation
            this.data = SerializeItem(this.item);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //string curData = JsonConvert.SerializeObject(this.item, Formatting.Indented);
            //if (curData != this.data)
            //{
            //    // MessageBox.Show(string.Format("{0}\n\n{1}", curData, this.data));

            //    string mainMsg = "You have made some changes in the item that are still unsaved.\n";
            //    mainMsg += "Continue to exit?";
            //    DialogResult result = MessageBox.Show(mainMsg, "Unsaved Changes Detected", MessageBoxButtons.YesNo);

            //    if (result == DialogResult.No) return;
            //}

            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void numericUpDownItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nup = (sender as NumericUpDown) ?? throw new ArgumentNullException();

            if (nup.Value <= 0)
            {
                nup.Value = 1;
            }
            else
            {
                this.item.Quantity = (int)nup.Value;
            }
        }

        private void comboBoxItemName_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox) ?? throw new ArgumentNullException();

            if ((cb.Text == "") || (cb.Text == string.Empty))
            {
                cb.Text = EMPTY_NAME_PROMPT;
            }

            this.lastItemName = cb.Text;
        }

        private void comboBoxItemName_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox) ?? throw new ArgumentNullException();

            string committedText = cb.Text;

            if (committedText == EMPTY_NAME_PROMPT) committedText = "";

            this.item.Name = committedText;
        }

        private void comboBoxItemName_KeyPressed(object sender, KeyEventArgs e)
        {
            ComboBox cb = (sender as ComboBox) ?? throw new ArgumentNullException();

            if (e.KeyCode == Keys.Enter)
            {
                string committedText = cb.Text;

                if (committedText == EMPTY_NAME_PROMPT) committedText = "";

                this.item.Name = committedText;
            }

            if (this.lastItemName == EMPTY_NAME_PROMPT)
            {
                if ((e.KeyCode.ToString().Length == 1)
                    || (e.KeyCode == Keys.Back))
                {
                    this.comboBoxItemName.Text = "";
                }
            }

        }


        #endregion Event Handler

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }

        private void ItemForm_Closing(object sender, FormClosingEventArgs e)
        {
            string name = this.comboBoxItemName.Text;
            int quantity = (int)this.numericUpDownItemQuantity.Value;

            this.item.Name = name;
            this.item.Quantity = quantity;

            string curData = JsonConvert.SerializeObject(this.item, Formatting.Indented);
            if (curData != this.data)
            {
                string mainMsg = "You have made some changes in the item that are still unsaved.\n";
                mainMsg += "Continue to exit?";
                DialogResult result = MessageBox.Show(mainMsg, "Unsaved Changes Detected", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

        }
    }
}
