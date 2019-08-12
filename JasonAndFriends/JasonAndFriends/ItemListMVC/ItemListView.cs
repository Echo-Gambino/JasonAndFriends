namespace JasonAndFriends.ItemListMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Windows.Forms;

    public class ItemListView
    {
        #region Events

        public event EventHandler SelectedItemChanged;

        public event EventHandler ItemChecked;

        public event EventHandler NewItemRequested;

        public event EventHandler RemItemRequested;

        public event EventHandler EdtItemRequested;

        #endregion Events

        #region Fields

        private CheckedListBox itemList;

        private Button buttonNew;

        private Button buttonRem;

        private Button buttonEdt;

        private int currentlyChecked;

        #endregion Fields

        #region Parameters

        public CheckedListBox ItemList
        {
            get { return this.itemList; }
            set
            {
                if (this.itemList != null)
                {
                    this.itemList.SelectedIndexChanged -= new EventHandler(ItemList_SelIndexChanged);
                    this.itemList.ItemCheck -= new ItemCheckEventHandler(ItemList_ItemChecked);
                }

                this.itemList = value ?? throw new ArgumentNullException();

                this.itemList.SelectedIndexChanged += new EventHandler(ItemList_SelIndexChanged);
                this.itemList.ItemCheck += new ItemCheckEventHandler(ItemList_ItemChecked);
            }
        }

        public Button ButtonNew
        {
            get { return this.buttonNew; }
            set
            {
                if (this.buttonNew != null)
                {
                    this.buttonNew.Click -= new EventHandler(ButtonNew_Click);
                }

                this.buttonNew = value ?? throw new ArgumentNullException();

                this.buttonNew.Click += new EventHandler(ButtonNew_Click);
            }
        }

        public Button ButtonRem
        {
            get { return this.buttonRem; }
            set
            {
                if (this.buttonRem != null)
                {
                    this.buttonRem.Click -= new EventHandler(ButtonRem_Click);
                }

                this.buttonRem = value ?? throw new ArgumentNullException();

                this.buttonRem.Click += new EventHandler(ButtonRem_Click);
            }
        }

        public Button ButtonEdt
        {
            get { return this.buttonEdt; }
            set
            {
                if (this.buttonEdt != null)
                {
                    this.buttonEdt.Click -= new EventHandler(ButtonEdt_Click);
                }

                this.buttonEdt = value ?? throw new ArgumentNullException();

                this.buttonEdt.Click += new EventHandler(ButtonEdt_Click);
            }

        }

        public int CurrentlyChecked
        {
            get { return this.currentlyChecked; }
            set { this.currentlyChecked = value; }
        }

        #endregion Parameters

        public ItemListView()
        {
            this.currentlyChecked = -1;
        }


        #region Event Handlers

        public void ItemList_SelIndexChanged(object sender, EventArgs e)
        {
            SelectedItemChanged?.Invoke(sender, e);
        }

        public void ItemList_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;

            if (e.NewValue == CheckState.Checked)
            {
                if (this.currentlyChecked != -1)
                {
                    clb.SetItemChecked(this.currentlyChecked, false);
                }

                this.currentlyChecked = e.Index;
            }
            else
            {
                if (this.currentlyChecked != e.Index)
                {
                    clb.SetItemChecked(this.currentlyChecked, false);
                }

                this.currentlyChecked = -1;
            }

            ItemChecked?.Invoke(sender, e);
        }

        public void ButtonNew_Click(object sender, EventArgs e)
        {
            NewItemRequested?.Invoke(sender, e);
        }

        public void ButtonRem_Click(object sender, EventArgs e)
        {
            RemItemRequested?.Invoke(sender, e);
        }

        public void ButtonEdt_Click(object sender, EventArgs e)
        {
            EdtItemRequested?.Invoke(sender, e);
        }



        #endregion Event Handlers



    }
}
