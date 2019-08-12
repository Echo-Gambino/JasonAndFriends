namespace JasonAndFriends.FriendSheetMVC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.Windows.Forms;

    public class FriendSheetView
    {
        #region Events

        public event EventHandler NameChanged;

        public event EventHandler DietaryChanged;

        public event EventHandler CanDrinkChanged;

        #endregion Events

        #region Fields

        private TextBox textBoxName;

        private List<RadioButton> radioButtonDietary;

        private List<RadioButton> radioButtonCanDrink;

        #endregion Fields

        #region Parameters

        public TextBox TextBoxName
        {
            get { return this.textBoxName; }
            set
            {
                if (this.textBoxName != null)
                {
                    this.textBoxName.Leave -= new EventHandler(TextBoxName_Leave);
                    this.textBoxName.KeyDown -= new KeyEventHandler(TextBoxName_EnterPressed);
                }

                this.textBoxName = value ?? throw new ArgumentNullException();

                this.textBoxName.Leave += new EventHandler(TextBoxName_Leave);
                this.textBoxName.KeyDown += new KeyEventHandler(TextBoxName_EnterPressed);
            }
        }

        public List<RadioButton> RadioButtonDietary
        {
            get { return this.radioButtonDietary; }
            set
            {
                if (this.radioButtonDietary != null)
                {
                    foreach (RadioButton rb in this.radioButtonDietary)
                    {
                        rb.Click -= new EventHandler(RadioButtonDietary_Click);
                    }
                }

                this.radioButtonDietary = value ?? throw new ArgumentNullException();

                foreach (RadioButton rb in this.radioButtonDietary)
                {
                    rb.Click += new EventHandler(RadioButtonDietary_Click);
                }
            }
        }

        public List<RadioButton> RadioButtonCanDrink
        {
            get { return this.radioButtonCanDrink; }
            set
            {
                if (this.radioButtonCanDrink != null)
                {
                    foreach (RadioButton rb in this.radioButtonCanDrink)
                    {
                        rb.Click -= new EventHandler(RadioButtonCanDrink_Click);
                    }
                }

                this.radioButtonCanDrink = value ?? throw new ArgumentNullException();

                foreach (RadioButton rb in this.radioButtonCanDrink)
                {
                    rb.Click += new EventHandler(RadioButtonCanDrink_Click);
                }
            }
        }

        #endregion Parameters

        public FriendSheetView()
        {
        }

        public void SetName(string name)
        {
            if (this.TextBoxName == null) throw new ArgumentNullException();

            this.TextBoxName.Text = name;
        }

        public void SetDietary(bool yesno)
        {
            if (this.RadioButtonDietary == null) throw new ArgumentNullException();
            if (this.RadioButtonDietary.Count < 2) throw new ArgumentException();

            if (yesno == true)
            {
                this.RadioButtonDietary[0].Select();
            }
            else
            {
                this.RadioButtonDietary[1].Select();
            }
        }

        public void SetCanDrink(bool yesno)
        {
            if (this.RadioButtonCanDrink == null) throw new ArgumentNullException();
            if (this.RadioButtonCanDrink.Count < 2) throw new ArgumentException();

            if (yesno == true)
            {
                this.RadioButtonCanDrink[0].Select();
            }
            else
            {
                this.RadioButtonCanDrink[1].Select();
            }
        }

        #region Event Handlers

        public void TextBoxName_Leave(object sender, EventArgs e)
        {
            NameChanged?.Invoke(sender, e);
        }

        public void TextBoxName_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) NameChanged?.Invoke(sender, e);
        }

        public void RadioButtonDietary_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            int index = radioButtonDietary.IndexOf(rb);
            if (index >= 0)
            {
                DietaryChanged?.Invoke(index, e);
            }
            else
            {
                MessageBox.Show("Error: Radiobutton bounded incorrectly");
            }
        }

        public void RadioButtonCanDrink_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            int index = radioButtonCanDrink.IndexOf(rb);
            if (index >= 0)
            {
                CanDrinkChanged?.Invoke(index, e);
            }
            else
            {
                MessageBox.Show("Error: Radiobutton bounded incorrectly");
            }
        }

        #endregion Event Handlers
    }
}
