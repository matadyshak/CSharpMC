using DemoLibrary;
using System.ComponentModel;
using System.Windows.Forms;

namespace MiniProjectWinForm
{
    public partial class FormPersonModel : Form, ISaveAddress
    {
        PersonModel person = new PersonModel();
        AddressModel address = new AddressModel();
        BindingList<string> messages = new BindingList<string>();
        public FormPersonModel()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            listBoxNamesAddresses.DataSource = messages;
        }
        private void buttonEnterAddress_Click(object sender, System.EventArgs e)
        {
            FormAddressModel addressModel = new FormAddressModel();
            DialogResult result = addressModel.ShowDialog();
            if (result == DialogResult.OK)
            {
                address = addressModel.GetAddressModel();
                string messageText = $"{person.FirstName} {person.LastName} {address.AddressLine1} {address.AddressLine2} {address.City} {address.State}  {address.Zipcode}";
                messages.Add(messageText);
                clearNames();
            }
        }

        private void textBoxFirstName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = person.ValidateName(this.textBoxFirstName.Text);
            this.textBoxFirstName.Text = temp;
            this.textBoxFirstName.SelectionStart = this.textBoxFirstName.TextLength;
            person.FirstName = temp;
        }

        private void textBoxLastName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = person.ValidateName(this.textBoxLastName.Text);
            this.textBoxLastName.Text = temp;
            this.textBoxLastName.SelectionStart = this.textBoxLastName.TextLength;
            person.LastName = temp;
        }

        private void clearNames()
        {
            this.textBoxFirstName.Text = "";
            person.FirstName = "";
            this.textBoxLastName.Text = "";
            person.LastName = "";
        }

        public void SaveAddress(AddressModel address)
        {
            listBoxNamesAddresses.Add(address);
        }
    }
}
