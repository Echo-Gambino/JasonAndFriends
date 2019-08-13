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

        public ItemForm(Item item)
        {
            InitializeComponent();

            this.lastItemName = string.Empty;

            this.data = SerializeItem(item);

            this.item = DeserializeItem(this.data);

            DisplayItemParams(this.item);

        }

        #region Private Methods

        private void DisplayItemParams(Item item)
        {
            this.comboBoxItemName.Text = this.item.Name;

            this.numericUpDownItemQuantity.Value = this.item.Quantity;
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
            this.item = DeserializeItem(this.data);

            DisplayItemParams(this.item);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.data = SerializeItem(this.item);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void numericUpDownItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nup = (sender as NumericUpDown) ?? throw new ArgumentNullException();

            if (nup.Value < 0)
            {
                nup.Value = 0;
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
                cb.Text = "<Item Name>";
            }

            this.lastItemName = cb.Text;
        }

        private void comboBoxItemName_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox) ?? throw new ArgumentNullException();

            this.item.Name = cb.Text;
        }

        private void comboBoxItemName_KeyPressed(object sender, KeyEventArgs e)
        {
            ComboBox cb = (sender as ComboBox) ?? throw new ArgumentNullException();

            if (e.KeyCode == Keys.Enter)
            {
                this.item.Name = cb.Text;
            }

            if (this.lastItemName == "<Item Name>")
            {
                if ((e.KeyCode.ToString().Length == 1)
                    || (e.KeyCode == Keys.Back))
                {
                    this.comboBoxItemName.Text = "";
                }
            }

        }


        #endregion Event Handler

    }
}
