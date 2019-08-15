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

    using System.IO;

    using Newtonsoft.Json;

    public partial class JasonAndFriends : Form
    {
        private FriendSheetController friendSheet;

        private ItemListController listBring;

        private ItemListController listWant;

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

            List<Friend> friends = LoadFriendsFromJsonFile() ?? new List<Friend>();

            foreach (Friend fr in friends)
            {
                this.ComboBoxFriends.Items.Add(fr);
            }

            this.listBring = GenWillBringListController();
            this.listWant = GenWillWantListController();

        }

        private void JasonAndFriends_Closing(object sender, FormClosingEventArgs e)
        {
            bool saved = CheckUnsavedData(this.friendSheet, this.listBring, this.listWant);
            if (!saved)
            {
                switch (DataNotSavedDialog())
                {
                    case DialogResult.Yes:
                        DialogResult saveStatus = PerformSaveOpWithDialog();

                        if (saveStatus == DialogResult.Abort)
                        {
                            e.Cancel = true;
                            return;
                        }

                        break;
                    case DialogResult.No:
                        break; // Does nothing and lets the process continue closing
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return; // Cancels the process and exits before the data is saved into the Json file
                    default:
                        throw new NotSupportedException();
                }

            }

            List<Friend> friends = GenFriendListFromComboBox(this.ComboBoxFriends);

            SaveToJsonFile(friends);
        }

        private ItemListController GenWillBringListController()
        {
            ItemListController controller;
            ItemListView view;

            view = new ItemListView();

            view.ButtonNew = this.buttonWillBringNew;
            view.ButtonRem = this.buttonWillBringRem;
            view.ButtonEdt = this.buttonWillBringEdt;

            view.ListBoxItems = this.listBoxWillBring;

            controller = new ItemListController(view);

            controller.ItemName = "Brought Item";

            return controller;
        }

        private ItemListController GenWillWantListController()
        {
            ItemListController controller;
            ItemListView view;

            view = new ItemListView();

            view.ButtonNew = this.buttonWillWantNew;
            view.ButtonRem = this.buttonWillWantRem;
            view.ButtonEdt = this.buttonWillWantEdt;

            view.ListBoxItems = this.listBoxWillWant;

            controller = new ItemListController(view);

            controller.ItemName = "Wanted Item";

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

        private List<Friend> LoadFriendsFromJsonFile()
        {
            string dataDir = "";
            string regJsonFile = "";

            while (true)
            {
                try
                {
                    dataDir = CheckAndGetDataDir(Directory.GetCurrentDirectory());

                    regJsonFile = dataDir + "\\data.json";
                }
                catch (UnauthorizedAccessException ex)
                {
                    string curDir = @"C:\ProgramData\JasonAndFriends";

                    Directory.CreateDirectory(curDir);

                    Directory.SetCurrentDirectory(curDir);

                    continue;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(ex.GetType().ToString());
                    sb.AppendLine();
                    sb.AppendLine(ex.Message);
                    sb.AppendLine();
                    sb.AppendLine(ex.StackTrace);

                    MessageBox.Show(sb.ToString(), ex.Source + " Error!");
                }

                break;
            }

            if (!File.Exists(regJsonFile))
            {
                return new List<Friend>();
            }

            string data = File.ReadAllText(regJsonFile);

            return JsonConvert.DeserializeObject<List<Friend>>(data);
        }

        private void SaveToJsonFile(List<Friend> friends)
        {
            string dataDir;
            string regJsonFile;

            while (true)
            {
                try
                {
                    dataDir = CheckAndGetDataDir(Directory.GetCurrentDirectory());

                    regJsonFile = dataDir + "\\data.json";
                }
                catch (UnauthorizedAccessException ex)
                {
                    string curDir = @"C:\ProgramData\JasonAndFriends";

                    Directory.CreateDirectory(curDir);

                    Directory.SetCurrentDirectory(curDir);

                    continue;
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(ex.GetType().ToString());
                    sb.AppendLine();
                    sb.AppendLine(ex.Message);
                    sb.AppendLine();
                    sb.AppendLine(ex.StackTrace);

                    MessageBox.Show(sb.ToString(), ex.Source + " Error!");

                    return;
                }

                break;
            }

            string data = JsonConvert.SerializeObject(friends, Formatting.Indented);

            File.WriteAllText(regJsonFile, data);
        }

        /// <summary>
        /// Creates a directory by the name of "Data" on top of the current directory
        /// </summary>
        /// <returns></returns>
        private string CheckAndGetDataDir(string workingDir)
        {
            string dataDir;

            dataDir = workingDir + "\\Data";

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            return dataDir;
        }

        private List<Friend> GenFriendListFromComboBox(ComboBox comboBox)
        {
            List<Friend> friends = new List<Friend>();

            foreach (Friend fr in comboBox.Items)
            {
                friends.Add(fr);
            }

            return friends;
        }

        private DialogResult PerformSaveOpWithDialog()
        {
            DialogResult latestResult = DialogResult.None;

            while (true)
            {
                bool success = PerformSaveOp();
                if (!success)
                {
                    latestResult = MessageBox.Show(
                        "Error: Save operation failed.\nTry Again?",
                        "Save Failure", 
                        MessageBoxButtons.AbortRetryIgnore);

                    if (latestResult == DialogResult.Retry) continue;
                }

                break;
            }

            return latestResult;
        }

        private bool PerformSaveOp()
        {
            // Check if saving is valid
            bool notValid = string.IsNullOrWhiteSpace(this.friendSheet.Friend.Name);
            if (notValid)
            {
                MessageBox.Show(
                    "Saving failed, name cannot be empty or only have whitespace", 
                    "Cannot save",
                    MessageBoxButtons.OK);
                return false;
            }

            // Save friend sheet
            this.friendSheet.SaveFriend();

            // Save lists 
            this.listBring.SaveItemList();
            this.listWant.SaveItemList();

            Friend friend = this.friendSheet.Friend;

            friend.ListBring = this.listBring.Items;
            friend.ListWant = this.listWant.Items;

            int index = this.ComboBoxFriends.SelectedIndex;

            ComboBox.ObjectCollection items = this.ComboBoxFriends.Items;

            if (index == -1)
            {
                // If index is -1 (new entry) then prepare the index to be 0 for later insertion
                index = 0;
            }
            else
            {
                // If index is something other than -1 (existing entry), remove the entry at that index 
                // (supposedly the friend object with "outdated" params) to have the new friend entry 
                // be added in as a replacement.
                items.RemoveAt(index);
            }

            // Insert the friend object at the designated index
            items.Insert(index, friend);

            // Have the combo box select the entry corresponding to that index
            this.ComboBoxFriends.SelectedIndex = index;

            return true;
        }

        /// <summary>
        /// Checks if there is any unsaved data.
        /// </summary>
        /// <returns>True if data has been saved, False if data has not been saved</returns>
        private bool CheckUnsavedData(
            FriendSheetController friendSheet,
            ItemListController broughtItemList,
            ItemListController wantedItemList
            )
        {
            if (friendSheet == null) throw new ArgumentNullException();

            string curData = friendSheet.FriendData;
            string savData = friendSheet.SavedData;

            if (curData != savData) return false;

            Friend friend = friendSheet.Friend;

            string cbi = JsonConvert.SerializeObject(broughtItemList.Items);
            string sbi = JsonConvert.SerializeObject(friend.ListBring);

            if (cbi != sbi) return false;

            string cwi = JsonConvert.SerializeObject(wantedItemList.Items);
            string swi = JsonConvert.SerializeObject(friend.ListWant);

            if (cwi != swi) return false;

            return true;
        }

        /// <summary>
        /// Shows a generic "unsaved changes" dialog box with an "Yes", "No", and "Cancel" button for the user to input
        /// </summary>
        /// <returns>The resulting button inputs from the user</returns>
        private DialogResult DataNotSavedDialog()
        {
            return MessageBox.Show(
                    "There are unsaved changes in the program!\nSave Changes?",
                    "Unsaved Changes Detected",
                    MessageBoxButtons.YesNoCancel);
        }

        #endregion Private Methods

        #region EventHandlers

        private void comboBoxSelFriends_Click(object sender, EventArgs e)
        {
            ComboBox combo = (sender as ComboBox) ?? throw new ArgumentNullException("sender is not ComboBox");

            // Unsaved changes check
            bool saved = CheckUnsavedData(this.friendSheet, this.listBring, this.listWant);
            if (!saved)
            {
                switch (DataNotSavedDialog())
                {
                    case DialogResult.Yes:
                        bool success = PerformSaveOp();
                        this.ComboBoxFriends.DroppedDown = success;
                        break;
                    case DialogResult.No:
                        this.ComboBoxFriends.DroppedDown = true;
                        break;
                    case DialogResult.Cancel:
                        this.ComboBoxFriends.DroppedDown = false;
                        break;
                    default:
                        throw new NotSupportedException("DialogResult not accounted for");
                }
            }
        }

        private void comboBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (sender as ComboBox) ?? throw new ArgumentNullException("sender is not ComboBox");

            Friend friend = (combo.SelectedItem as Friend) ?? new Friend();

            this.friendSheet.SetFriend(friend);

            List<Item> broughtItems = friend.ListBring;
            List<Item> wantedItems = friend.ListWant;

            this.listBring.SetItems(broughtItems);
            this.listWant.SetItems(wantedItems);

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

            if (index == 0)
            {
                this.friendSheet.SetFriend(new Friend());

                List<Item> broughtItems = friend.ListBring;
                List<Item> wantedItems = friend.ListWant;

                this.listBring.SetItems(broughtItems);
                this.listWant.SetItems(wantedItems);
            }

            // Set the selected index to be one entry above position 
            // of the recently removed item
            this.ComboBoxFriends.SelectedIndex = index - 1;

        }

        private void buttonNewFriend_Click(object sender, EventArgs e)
        {
            // Unsaved changes check
            bool saved = CheckUnsavedData(this.friendSheet, this.listBring, this.listWant);
            if (!saved)
            {
                switch (DataNotSavedDialog())
                {
                    case DialogResult.Yes:
                        bool success = PerformSaveOp(); // Save the information
                        if (success)
                            break;
                        else
                            return;
                    case DialogResult.No:
                        break; // Let the process pass through
                    case DialogResult.Cancel:
                        return; // exit from the function
                    default:
                        throw new NotSupportedException("DialogResult not accounted for");
                }
            }

            // Retrieve comboBox
            if (this.ComboBoxFriends == null) throw new NullReferenceException("ComboBox is null");

            this.ComboBoxFriends.SelectedIndex = -1;
        }

        private void buttonResetFriend_Click(object sender, EventArgs e)
        {
            // Reset friend sheet
            this.friendSheet.ResetFriend();

            // Reset item lists
            this.listBring.ResetItemList();
            this.listWant.ResetItemList();
        }

        private void buttonSaveFriend_Click(object sender, EventArgs e)
        {
            PerformSaveOp();
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
