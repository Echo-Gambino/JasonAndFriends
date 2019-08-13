namespace JasonAndFriends.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ItemComparer : IComparer<Item>
    {

        private readonly bool sortAscending;

        public ItemComparer(bool sortAscending)
        {
            this.sortAscending = sortAscending;
        }

        public int Compare(Item x, Item y)
        {
            if ((x == null) && (y == null)) return 0;
            if (x == null) return SortDirection(-1);
            if (y == null) return SortDirection(1);

            int result = SortByName(x, y);

            result = SortDirection(result);

            return result;
        }

        public int SortByName(Item x, Item y)
        {
            int result = x.Name.CompareTo(y.Name);

            if (result != 0) return result;

            if (x.Quantity == y.Quantity)
            {
                result = 0;
            }
            else if (x.Quantity > y.Quantity)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }

            return result;
        }

        private int SortDirection(int result)
        {
            return sortAscending ? result : (result * -1);
        }

    }

    public class Item
    {
        private string name;

        private int quantity;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (!(value >= 0)) throw new ArgumentException("quantity must be set to a positive number");

                this.quantity = value;
            }
        }

        #region Constructor

        public Item()
        {
            this.name = string.Empty;
        }

        public Item(string name)
        {
            this.name = name;
            this.quantity = 0;
        }

        #endregion Constructor

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods

    }
}
