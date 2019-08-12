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


        #region Methods

        #region Private

        private void SetItemsToView(ItemListView view, List<Item> items)
        {
            DelViewEventHandlers(view);

            items.Sort();
            view.SetItems(items);

            AddViewEventHandlers(view);
        }

        private void AddViewEventHandlers(ItemListView view)
        {
            // ...
        }

        private void DelViewEventHandlers(ItemListView view)
        {
            // ...
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

    }
}
