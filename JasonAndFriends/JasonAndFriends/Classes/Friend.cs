namespace JasonAndFriends.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class Friend
    {
        #region Fields

        private string name;

        private bool dietaryRestrictions;

        private bool canDrink;

        #endregion Fields

        #region Parameters

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool DietaryRestrictions
        {
            get { return this.dietaryRestrictions; }
            set { this.dietaryRestrictions = value; }
        }

        public bool CanDrink
        {
            get { return this.canDrink; }
            set { this.canDrink = value; }
        }

        #endregion Parameters


        #region Constructors

        public Friend()
        {
            this.name = string.Empty;

            this.dietaryRestrictions = false;
            this.canDrink = false;
        }

        public Friend(string name) : this()
        {
            this.name = name ?? throw new ArgumentNullException();
        }

        #endregion Constructors

        #region Misc Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Misc Methods

    }
}
