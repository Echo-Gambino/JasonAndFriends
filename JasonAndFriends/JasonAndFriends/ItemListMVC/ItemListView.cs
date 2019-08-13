namespace JasonAndFriends.ItemListMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Windows.Forms;

    using Classes;

    public class ItemListView
    {
        #region Events

        public event EventHandler SelectedItemChanged;

        public event EventHandler NewItemRequested;

        public event EventHandler RemItemRequested;

        public event EventHandler EdtItemRequested;

        #endregion Events

        #region Fields

        private ListBox listBoxItems;

        private Button buttonNew;

        private Button buttonRem;

        private Button buttonEdt;

        #endregion Fields

        #region Parameters

        public ListBox ListBoxItems
        {
            get { return this.listBoxItems; }
            set
            {
                if (this.listBoxItems != null)
                {
                    this.listBoxItems.SelectedIndexChanged -= new EventHandler(ItemList_SelIndexChanged);
                }

                this.listBoxItems = value ?? throw new ArgumentNullException();

                this.listBoxItems.SelectedIndexChanged += new EventHandler(ItemList_SelIndexChanged);
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

        #endregion Parameters

        #region Constructors

        public ItemListView()
        {
        }

        #endregion Constructors

        #region Methods

        public void SetItems(List<Item> items)
        {
            ListBox.ObjectCollection LBcollection = this.listBoxItems?.Items;

            if (LBcollection != null)
            {
                FillLB(items, LBcollection);
            }

        }

        public void FillCLB(List<Item> items, CheckedListBox.ObjectCollection collection)
        {
            if ((collection == null) || (items == null)) throw new ArgumentNullException();

            collection.Clear();

            foreach (Item i in items)
            {
                collection.Add(i);
            }
        }

        public void FillLB(List<Item> items, ListBox.ObjectCollection collection)
        {
            if ((collection == null) || (items == null)) throw new ArgumentNullException();

            collection.Clear();

            foreach (Item i in items)
            {
                collection.Add(i);
            }
        }

        #endregion Methods

        #region Event Handlers

        private void ItemList_SelIndexChanged(object sender, EventArgs e)
        {
            SelectedItemChanged?.Invoke(sender, e);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            NewItemRequested?.Invoke(sender, e);
        }

        private void ButtonRem_Click(object sender, EventArgs e)
        {
            RemItemRequested?.Invoke(sender, e);
        }

        private void ButtonEdt_Click(object sender, EventArgs e)
        {
            EdtItemRequested?.Invoke(sender, e);
        }

        #endregion Event Handlers



    }
}
