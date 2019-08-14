namespace JasonAndFriends.ItemListMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using System.Windows.Forms;

    using Classes;

    public class ItemListController
    {
        #region Events

        public event EventHandler ItemListChanged;

        #endregion Events

        #region Fields

        private readonly object listLock = new object();

        private string itemName;

        private ItemListView view;

        private List<Item> items;

        private string data;

        #endregion Fields

        #region Parameters

        public string ItemName
        {
            get { return this.itemName; }
            set { this.itemName = value; }
        }

        public ItemListView ItemListView
        {
            get { return this.view; }
        }

        public List<Item> Items
        {
            get
            {
                lock (listLock)
                {
                    return this.items;
                }
            }
            set
            {
                if (value == null) throw new ArgumentNullException();

                lock (listLock)
                {
                    this.items = value;
                }
            }
        }

        #endregion Parameters

        #region Constructors

        public ItemListController(ItemListView itemListView)
        {
            this.view = itemListView ?? throw new ArgumentNullException();

            this.itemName = "Item";

            lock (listLock)
            {
                this.items = new List<Item>();

                this.data = SerializeItems(this.items);

                SetItemsToView(this.view, this.items);
            }
        }

        public ItemListController(ItemListView itemListView, List<Item> items) : this(itemListView)
        {
            SetItems(items);
        }

        #endregion Constructors

        #region Methods

        #region Public

        public void ReplaceItem(Item target, Item replacer)
        {
            lock (listLock)
            {
                this.items.Remove(target);
                this.items.Add(replacer);

                SetItemsToView(this.view, this.items);

                ItemListChanged?.Invoke(this.items, new EventArgs());
            }
        }

        public void RemoveItem(Item target)
        {
            lock (listLock)
            {
                this.items.Remove(target);

                SetItemsToView(this.view, this.items);

                ItemListChanged?.Invoke(this.items, new EventArgs());
            }
        }

        public void AddItem(Item newItem)
        {
            lock (listLock)
            {
                this.items.Add(newItem);

                SetItemsToView(this.view, this.items);

                ItemListChanged?.Invoke(this.items, new EventArgs());
            }
        }

        public void SetItems(List<Item> items)
        {
            if (items == null) throw new ArgumentNullException();

            lock (listLock)
            {
                this.data = SerializeItems(items);

                this.items = DeserializeItems(data);

                SetItemsToView(this.view, this.items);
            }
        }

        public void ResetItemList()
        {
            lock (listLock)
            {
                this.items = DeserializeItems(this.data);

                SetItemsToView(this.view, this.items);
            }
        }

        public void SaveItemList()
        {
            lock (listLock)
            {
                this.data = SerializeItems(items);
            }
        }

        #endregion Public

        #region Private

        private Item OpenItemFormDialog(string formTitle, Item input = null)
        {
            Item output = null;

            using (ItemForm iform = new ItemForm(input))
            {
                iform.Text = formTitle;

                DialogResult result = iform.ShowDialog();

                if (result == DialogResult.OK)
                {
                    output = JsonConvert.DeserializeObject<Item>(iform.Data);
                }
            }

            return output;
        }

        private void SetItemsToView(ItemListView view, List<Item> items)
        {
            DelViewEventHandlers(view);

            items.Sort(new ItemComparer(true));
            view.SetItems(items);

            AddViewEventHandlers(view);
        }

        private void AddViewEventHandlers(ItemListView view)
        {
            this.view.RemItemRequested += new EventHandler(ButtonRemove_Click);
            this.view.EdtItemRequested += new EventHandler(ButtonEdit_Click);
            this.view.NewItemRequested += new EventHandler(ButtonNew_Click);
        }

        private void DelViewEventHandlers(ItemListView view)
        {
            this.view.RemItemRequested -= new EventHandler(ButtonRemove_Click);
            this.view.EdtItemRequested -= new EventHandler(ButtonEdit_Click);
            this.view.NewItemRequested -= new EventHandler(ButtonNew_Click);
        }

        private string SerializeItems(List<Item> items)
        {
            return JsonConvert.SerializeObject(items, Formatting.Indented);
        }

        private List<Item> DeserializeItems(string data)
        {
            return JsonConvert.DeserializeObject<List<Item>>(data);
        }

        #endregion Private

        #endregion Methods

        #region EventHandlers

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            ListBox lb = this.view?.ListBoxItems;

            if (lb == null) throw new ArgumentNullException("listbox is null");

            if (lb.Items.Count == 0)
            {
                MessageBox.Show("No items available for deletion", "Cannot delete");
                return;
            }

            int index = lb.SelectedIndex;
            if (index != -1)
            {
                Item item = (lb.Items[index] as Item) ?? throw new NullReferenceException();

                RemoveItem(item);

                lb.SelectedIndex = index - 1;
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Cannot delete");
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            ListBox lb = this.view?.ListBoxItems;

            if (lb == null) throw new ArgumentNullException("listbox is null");

            if (lb.Items.Count == 0)
            {
                MessageBox.Show("No items available to edit", "Cannot edit");
                return;
            }

            int index = lb.SelectedIndex;
            if (index != -1)
            {
                Item item = (lb.SelectedItem as Item) ?? throw new ArgumentNullException();

                Item newItem = OpenItemFormDialog(string.Format("Edit {0}", this.ItemName), item);

                if (newItem != null)
                {
                    ReplaceItem(item, newItem);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "Cannot edit");
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            ListBox lb = this.view?.ListBoxItems ?? throw new ArgumentNullException();

            if (lb == null) throw new ArgumentNullException("listbox is null");

            Item newItem = OpenItemFormDialog(string.Format("New {0}", this.ItemName));

            if (newItem != null)
            {
                AddItem(newItem);
            }
        }

        #endregion EventHandlers

    }
}
