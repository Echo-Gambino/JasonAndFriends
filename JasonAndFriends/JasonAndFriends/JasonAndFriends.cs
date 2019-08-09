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

    public partial class JasonAndFriends : Form
    {
        public JasonAndFriends()
        {
            InitializeComponent();
        }

        private void JasonAndFriends_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb == null) throw new ArgumentNullException();

            MessageBox.Show(cb.SelectedIndex.ToString());

            cb.SelectedIndex = -1;

        }
    }
}
