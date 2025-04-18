using DemoLibrary;
using System.ComponentModel;
using System.Windows;

// This file began as a new WPF project
// The code from the MiniProjectWinFormApp project was dropped in.
// FormPersonModel.cs became MainWindow.xaml.cs
// Base class 'Form' becomes 'Window'
// All variables were left with the same names
// The 'this.' prefix for all dialog variables is removed using Find/Replace
// button.enabled => button.IsEnabled

namespace MiniProjectWPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISaveAddress
    {
        PersonModel personModel = new PersonModel();
        AddressModel addressModel = new AddressModel();
        BindingList<string> NamesAndAddresses = new BindingList<string>();

        public MainWindow()
        {
            InitializeComponent();
            listBoxNamesAddresses. = NamesAndAddresses;
            //listBoxNamesAddresses.DisplayMember = nameof(AddressModel.AddressDisplayValue);
            SetEnterAddressButtonEnable();
        }

        private void ButtonEnterAddress_Click(object sender, System.EventArgs e)
        {
            FormAddressModel addressForm = new FormAddressModel(this);
            // Modal dialog - Keeps focus until you close it.  Use Show() for modeless dialog
            bool? result = addressForm.ShowDialog();
            if (result == true)
            {
                //SaveAddress() has already run before Address Form was closed
                personModel.FirstName = textBoxFirstName.Text;
                personModel.LastName = textBoxLastName.Text;
                string NameAndAddressText = $"{personModel.FirstName} {personModel.LastName} {addressModel.AddressLine1} {addressModel.AddressLine2} {addressModel.City} {addressModel.State}  {addressModel.Zipcode}";
                NamesAndAddresses.Add(NameAndAddressText);
                ClearNames();
            }
        }

        public void SaveAddress(AddressModel address)
        {
            addressModel = address;
        }

        private void TextBoxFirstName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(textBoxFirstName.Text);
            textBoxFirstName.Text = temp;
            textBoxFirstName.SelectionStart = textBoxFirstName.Text.Length;
            SetEnterAddressButtonEnable();
        }

        private void TextBoxLastName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(textBoxLastName.Text);
            textBoxLastName.Text = temp;
            textBoxLastName.SelectionStart = textBoxLastName.Text.Length;
            SetEnterAddressButtonEnable();
        }

        private void ClearNames()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            SetEnterAddressButtonEnable();
        }
        private bool SetEnterAddressButtonEnable()
        {
            bool enableButton = false;

            if ((string.IsNullOrEmpty(textBoxFirstName.Text) == false) &&
                (string.IsNullOrEmpty(textBoxLastName.Text) == false))
            {
                enableButton = true;
            }

            buttonEnterAddress.IsEnabled = enableButton;
            return enableButton;
        }
    }
}
