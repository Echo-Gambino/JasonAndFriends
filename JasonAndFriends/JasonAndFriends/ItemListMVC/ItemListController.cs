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

        #endregion Events

        #region Fields

        private readonly object listLock = new object();

        private ItemListView view;

        private List<Item> items;

        private string data;

        #endregion Fields

        #region Parameters

        public ItemListView ItemListView
        {
            get { return this.view; }
        }

        public List<Item> Items
        {
            get { return this.items; }
        }

        #endregion Parameters

        #region Constructors

        public ItemListController(ItemListView itemListView)
        {
            this.view = itemListView ?? throw new ArgumentNullException();

            lock (listLock)
            {
                this.items = new List<Item>();

                this.data = SerializeItems(this.items);

                SetItemsToView(this.view, this.items);
            }
        }

        public ItemListController(ItemListView itemListView, List<Item> items) : this(itemListView)
        {
            lock (listLock)
            {
                this.items = items;

                this.data = SerializeItems(this.items);

                SetItemsToView(this.view, this.items);
            }
        }

        #endregion Constructors

        #region Methods

        #region Private

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
        }

        private void DelViewEventHandlers(ItemListView view)
        {
            this.view.RemItemRequested -= new EventHandler(ButtonRemove_Click);
            this.view.EdtItemRequested -= new EventHandler(ButtonEdit_Click);
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

        public void ButtonRemove_Click(object sender, EventArgs e)
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
                lb.Items.RemoveAt(index);
                lb.SelectedIndex = index - 1;
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Cannot delete");
            }
        }

        public void ButtonEdit_Click(object sender, EventArgs e)
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

                using (ItemForm iform = new ItemForm(item))
                {
                    iform.ShowDialog();

                    MessageBox.Show("Within iform");

                }

                MessageBox.Show("Out of iform");

                
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "Cannot edit");
            }

        }

        #endregion EventHandlers

    }
}
