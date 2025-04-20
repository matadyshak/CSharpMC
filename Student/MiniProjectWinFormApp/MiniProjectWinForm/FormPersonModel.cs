using DemoLibrary;
using System.ComponentModel;
using System.Windows.Forms;

namespace MiniProjectWinForm
{
    public partial class FormPersonModel : Form, ISaveAddress
    {
        private PersonModel personModel = new PersonModel();
        private AddressModel addressModel = new AddressModel();
        private BindingList<string> nameAddressData = new BindingList<string>();

        public FormPersonModel()
        {
            InitializeComponent();
            NameAddressList.DataSource = nameAddressData;
            SetEnterAddressButtonEnable();
        }

        private void AddressEntry_Click(object sender, System.EventArgs e)
        {
            FormAddressModel addressForm = new FormAddressModel(this);
            // Modal dialog - Keeps focus until you close it.  Use Show() for modeless dialog
            DialogResult result = addressForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                //SaveAddress() has already run before Address Form was closed
                personModel.FirstName = this.FirstNameText.Text;
                personModel.LastName = this.LastNameText.Text;
                string nameAddressText = $"{personModel.FirstName} {personModel.LastName} {addressModel.AddressLine1} {addressModel.AddressLine2} {addressModel.City} {addressModel.State}  {addressModel.Zipcode}";
                nameAddressData.Add(nameAddressText);
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

        private void FirstName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(this.FirstNameText.Text);
            this.FirstNameText.Text = temp;
            this.FirstNameText.SelectionStart = this.FirstNameText.TextLength;
            SetEnterAddressButtonEnable();
        }

        private void LastName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(this.LastNameText.Text);
            this.LastNameText.Text = temp;
            this.LastNameText.SelectionStart = this.LastNameText.TextLength;
            SetEnterAddressButtonEnable();
        }

        private void ClearNames()
        {
            this.FirstNameText.Text = "";
            this.LastNameText.Text = "";
            SetEnterAddressButtonEnable();
        }
        private bool SetEnterAddressButtonEnable()
        {
            bool enableButton = false;

            if ((string.IsNullOrEmpty(this.FirstNameText.Text) == false) &&
                (string.IsNullOrEmpty(this.LastNameText.Text) == false))
            {
                enableButton = true;
            }

            this.EnterAddressButton.Enabled = enableButton;
            return enableButton;
        }

    }
}
