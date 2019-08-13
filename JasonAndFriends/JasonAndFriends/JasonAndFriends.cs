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

    using FriendSheetMVC;
    using ItemListMVC;
    using Classes;

    public partial class JasonAndFriends : Form
    {
        private FriendSheetController friendSheet;

        private ItemListController itemList;

        private ComboBox ComboBoxFriends
        {
            get { return this.comboBoxSelFriends; }
            set { this.comboBoxSelFriends = value; }
        }

        #region Initializer

        public JasonAndFriends()
        {
            InitializeComponent();
        }

        private void JasonAndFriends_Load(object sender, EventArgs e)
        {
            this.friendSheet = GenFriendSheetController();



            List<Friend> friends = new List<Friend>();

            friends.Add(new Friend("Abba"));
            friends.Add(new Friend("Charles"));
            friends.Add(new Friend("Mike"));
            friends.Add(new Friend("Peter"));

            foreach (Friend fr in friends)
            {
                this.ComboBoxFriends.Items.Add(fr);
            }

            //List<Item> items = new List<Item>()
            //{
            //    new Item("Apple"),
            //    new Item("Dip"),
            //    new Item("Chips")
            //};

            this.itemList = GenItemListController();

            //this.itemList.SetItems(items);

        }

        private ItemListController GenItemListController()
        {
            ItemListController controller;
            ItemListView view;

            view = new ItemListView();

            view.ButtonNew = this.buttonWillBringNew;
            view.ButtonRem = this.buttonWillBringRem;
            view.ButtonEdt = this.buttonWillBringEdt;
            view.ListBoxItems = this.listBoxWillBring;

            controller = new ItemListController(view);

            return controller;
        }

        private FriendSheetController GenFriendSheetController()
        {
            FriendSheetController controller;
            FriendSheetView view;

            view = new FriendSheetView();

            view.TextBoxName = this.textBoxFriendName;
            view.RadioButtonDietary = new List<RadioButton>()
            {
                this.radioButtonDietaryYes,
                this.radioButtonDietaryNo
            };
            view.RadioButtonCanDrink = new List<RadioButton>()
            {
                this.radioButtonCanDrinkYes,
                this.radioButtonCanDrinkNo
            };

            controller = new FriendSheetController(view);

            return controller;
        }

        #endregion Initializer

        #region Private Methods


        #endregion Private Methods

        #region EventHandlers

        private void comboBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (sender as ComboBox) ?? throw new ArgumentNullException("sender is not ComboBox");

            Friend friend = (combo.SelectedItem as Friend) ?? new Friend();

            this.friendSheet.SetFriend(friend);

        }

        private void buttonDelFriend_Click(object sender, EventArgs e)
        {
            // Retrieve comboBox
            if (this.ComboBoxFriends == null) throw new NullReferenceException("ComboBox is null");

            // Prompt user (and not break) if comboBox's selection is invalid
            if (this.ComboBoxFriends.Items.Count == 0)
            {
                MessageBox.Show("Cannot Remove Friend: Friend list is already empty.");
                return;
            }
            else if (this.ComboBoxFriends.SelectedIndex == -1)
            {
                MessageBox.Show("Cannot Remove Friend: No valid entry is selected.");
                return;
            }

            // Get the index and the friend object of the comboBox
            int index = this.ComboBoxFriends.SelectedIndex;
            Friend friend = (this.ComboBoxFriends.SelectedItem as Friend);

            // Remove the comboBoxItem by the index
            this.ComboBoxFriends.Items.RemoveAt(index);

            // If the friend selected is the same as the friend currently within
            // the friendSheet, then set it to a blank sheet
            if (friend == this.friendSheet.Friend)
            {
                this.friendSheet.SetFriend(new Friend());
            }

            // Set the selected index to be one entry above position 
            // of the recently removed item
            this.ComboBoxFriends.SelectedIndex = index - 1;

        }

        private void buttonNewFriend_Click(object sender, EventArgs e)
        {
            // Retrieve comboBox
            if (this.ComboBoxFriends == null) throw new NullReferenceException("ComboBox is null");

            this.ComboBoxFriends.SelectedIndex = -1;
        }

        private void buttonResetFriend_Click(object sender, EventArgs e)
        {
            this.friendSheet.ResetFriend();
        }

        private void buttonSaveFriend_Click(object sender, EventArgs e)
        {
            this.friendSheet.SaveFriend();

            Friend friend = this.friendSheet.Friend;

            int index = this.ComboBoxFriends.SelectedIndex;

            ComboBox.ObjectCollection items = this.ComboBoxFriends.Items;

            if (index == -1)
            {
                index = 0;
            }
            else
            {
                items.RemoveAt(index);
            }

            items.Insert(index, friend);

            this.ComboBoxFriends.SelectedIndex = index;

        }

        private void textBoxFriendName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (sender as TextBox) ?? throw new ArgumentNullException();

            // Enables or disables the button to save the friend's parameters
            // if the string is null, empty, or whitespace.
            this.buttonSaveFriend.Enabled = !(string.IsNullOrWhiteSpace(textBox.Text));


        }

        #endregion EventHandlers

    }
}
