namespace JasonAndFriends.FriendSheetMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using System.Windows.Forms;

    using Classes;

    public class FriendSheetController
    {
        #region Fields

        private readonly object friendLock = new object();

        private FriendSheetView view;

        private Friend friend;

        private string data;

        #endregion Fields

        #region Parameters

        public FriendSheetView FriendSheetView
        {
            get { return this.view; }
        }

        public Friend Friend
        {
            get { return this.friend; }
        }

        [JsonIgnore]
        public string FriendData
        {
            get { return SerializeFriend(this.friend); }
        }

        [JsonIgnore]
        public string SavedData
        {
            get { return this.data; }
        }

        #endregion Parameters

        #region Initializers

        public FriendSheetController(FriendSheetView friendSheetView)
        {
            this.view = friendSheetView ?? throw new ArgumentNullException();

            lock (friendLock)
            {
                this.friend = new Friend();

                this.data = SerializeFriend(this.friend);

                SetFriendValuesToView(this.view, this.friend);
            }

        }

        public FriendSheetController(
            FriendSheetView friendSheetView,
            Friend friend
            ) : this(friendSheetView)
        {
            SetFriend(friend);
        }

        #endregion Initializers

        #region Methods

        #region Public 

        public void SetName(string name)
        {
            lock (friendLock)
            {
                this.friend.Name = name;
            }
        }

        public void SetDietary(bool yesno)
        {
            lock (friendLock)
            {
                this.friend.DietaryRestrictions = yesno;
            }
        }

        public void SetCanDrink(bool yesno)
        {
            lock (friendLock)
            {
                this.friend.CanDrink = yesno;
            }
        }

        public void SetFriend(Friend friend)
        {
            lock (friendLock)
            {
                this.data = SerializeFriend(friend);

                this.friend = DeserializeFriend(this.data);

                SetFriendValuesToView(this.view, this.friend);
            }
        }

        public void ResetFriend()
        {
            lock (friendLock)
            {
                this.friend = DeserializeFriend(this.data);

                SetFriendValuesToView(this.view, this.friend);
            }
        }

        public void SaveFriend()
        {
            lock (friendLock)
            {
                this.data = SerializeFriend(this.friend);
            }
        }

        #endregion Public

        #region Private

        private void SetFriendValuesToView(FriendSheetView view, Friend friend)
        {
            DelViewEventHandlers(view);

            view.SetName(friend.Name);
            view.SetDietary(friend.DietaryRestrictions);
            view.SetCanDrink(friend.CanDrink);

            AddViewEventHandlers(view);
        }

        private void AddViewEventHandlers(FriendSheetView view)
        {
            view.NameChanged += new EventHandler(TextBoxName_SaveToFriend);
            view.DietaryChanged += new EventHandler(RadioButtonDietary_SaveToFriend);
            view.CanDrinkChanged += new EventHandler(RadioButtonCanDrink_SaveToFriend);
        }

        private void DelViewEventHandlers(FriendSheetView view)
        {
            view.NameChanged -= new EventHandler(TextBoxName_SaveToFriend);
            view.DietaryChanged -= new EventHandler(RadioButtonDietary_SaveToFriend);
            view.CanDrinkChanged -= new EventHandler(RadioButtonCanDrink_SaveToFriend);
        }

        private string SerializeFriend(Friend friend)
        {
            return JsonConvert.SerializeObject(friend, Formatting.Indented);
        }

        private Friend DeserializeFriend(string data)
        {
            return JsonConvert.DeserializeObject<Friend>(data);
        }

        #endregion Private

        #endregion Methods

        #region Event Handlers

        private void TextBoxName_SaveToFriend(object sender, EventArgs e)
        {
            TextBox textBox = (sender as TextBox) ?? throw new ArgumentNullException();

            SetName(textBox.Text);
        }

        private void RadioButtonDietary_SaveToFriend(object sender, EventArgs e)
        {
            int index = (int)sender;

            switch (index)
            {
                case 0:
                    SetDietary(true);
                    break;
                case 1:
                    SetDietary(false);
                    break;
                default:
                    throw new ArgumentException("sender produces invalid index");
            }
        }

        private void RadioButtonCanDrink_SaveToFriend(object sender, EventArgs e)
        {
            int index = (int)sender;

            switch (index)
            {
                case 0:
                    SetCanDrink(true);
                    break;
                case 1:
                    SetCanDrink(false);
                    break;
                default:
                    throw new ArgumentException("sender produces invalid index");
            }
        }


        #endregion Event Handlers
    }
}
