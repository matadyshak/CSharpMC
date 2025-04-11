using DemoLibrary;
using System.ComponentModel;
using System.Windows.Forms;

namespace MiniProjectWinForm
{
    public partial class FormPersonModel : Form, ISaveAddress
    {
        PersonModel personModel = new PersonModel();
        AddressModel addressModel = new AddressModel();
        BindingList<string> NamesAndAddresses = new BindingList<string>();

        public FormPersonModel()
        {
            InitializeComponent();
            listBoxNamesAddresses.DataSource = NamesAndAddresses;
            //listBoxNamesAddresses.DisplayMember = nameof(AddressModel.AddressDisplayValue);
            SetEnterAddressButtonEnable();
        }

        private void ButtonEnterAddress_Click(object sender, System.EventArgs e)
        {
            FormAddressModel addressForm = new FormAddressModel(this);
            // Modal dialog - Keeps focus until you close it.  Use Show() for modeless dialog
            DialogResult result = addressForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //SaveAddress() has already run before Address Form was closed
                personModel.FirstName = this.textBoxFirstName.Text;
                personModel.LastName = this.textBoxLastName.Text;
                string NameAndAddressText = $"{personModel.FirstName} {personModel.LastName} {addressModel.AddressLine1} {addressModel.AddressLine2} {addressModel.City} {addressModel.State}  {addressModel.Zipcode}";
                NamesAndAddresses.Add(NameAndAddressText);
                ClearNames();
            }
        }

        // This is called by SaveRecord_Click() after storing the form
        // data members in an AddressModel object but before the AddressForm is closed
        // Save button on AddressForm is like my OK button
        // I also have a cancel button
        public void SaveAddress(AddressModel address)
        {
            addressModel = address;
        }

        private void TextBoxFirstName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(this.textBoxFirstName.Text);
            this.textBoxFirstName.Text = temp;
            this.textBoxFirstName.SelectionStart = this.textBoxFirstName.TextLength;
            SetEnterAddressButtonEnable();
        }

        private void TextBoxLastName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(this.textBoxLastName.Text);
            this.textBoxLastName.Text = temp;
            this.textBoxLastName.SelectionStart = this.textBoxLastName.TextLength;
            SetEnterAddressButtonEnable();
        }

        private void ClearNames()
        {
            this.textBoxFirstName.Text = "";
            this.textBoxLastName.Text = "";
            SetEnterAddressButtonEnable();
        }
        private bool SetEnterAddressButtonEnable()
        {
            bool enableButton = false;

            if ((string.IsNullOrEmpty(this.textBoxFirstName.Text) == false) &&
                (string.IsNullOrEmpty(this.textBoxLastName.Text) == false))
            {
                enableButton = true;
            }

            this.buttonEnterAddress.Enabled = enableButton;
            return enableButton;
        }

    }
}
