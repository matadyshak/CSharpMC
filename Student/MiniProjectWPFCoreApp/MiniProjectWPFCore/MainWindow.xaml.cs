using DemoLibrary;
using System.Collections.ObjectModel;
using System.Windows;

////////////////////////////////////////////////////////////////////////
/// CHANGES REQUIRED GOING FROM WINFORMS TO WPF
////////////////////////////////////////////////////////////////////////
/// This file began as a new WPF project
/// The code from the MiniProjectWinFormApp project was dropped in.
/// FormPersonModel.cs became MainWindow.xaml.cs
/// Base class 'Form' becomes 'Window'
/// All variables were left with the same names
/// The 'this.' prefix for all dialog variables is removed using Find/Replace
/// button.enabled => button.IsEnabled
/// textBoxFirstName.TextLength   =>  textBoxFirstName.Text.Length
/// listBoxNamesAddresses.DataSource => listBoxNamesAddresses.DataContext
/// ShowDialog returns DialogResult => ShowDialog returns bool? false=Cancel true=OK
/// using System.Windows.Forms; is taken out
/// using System.Windows; is added
/// Add ItemsSource="{Binding}" to XAML file for ListBox
/// Add this.DataContext = this; to constructor
/// BindingList => ObservableCollection More common in WPF for data binding
///   because it automatically updates the UI when the collection changes
////////////////////////////////////////////////////////////////////////
/// Yes, C# has established naming conventions that help make code more readable and maintainable. Here are the common conventions:
///
/// Pascal Case: Used for class names, properties, and methods. Each word starts with an uppercase letter.
/// Class Names: PersonModel, AddressModel
/// Properties: FirstName, LastName
/// Methods: SaveAddress(), SetEnterAddressButtonEnable()
///
/// Camel Case: Used for local variables and parameters. The first word starts with a lowercase letter
/// Local Variables: addressLine1Text, textBoxAddressLine1
/// Parameters: address, sender
///
/// Uppercase: Used for constants and static readonly fields.
/// Constants: MAX_VALUE, DEFAULT_TIMEOUT
///
/// Underscore Prefix: Sometimes used for private fields, though this is less common in modern C# code.
/// Private Fields: _firstName, _lastName
////////////////////////////////////////////////////////////////////////
/// In modern C# coding conventions, it's generally preferred to use 
/// descriptive names without the type prefix, as Hungarian notation is
/// considered obsolete. Therefore, FirstNameText would be preferred 
/// over textBoxFirstName.
///
/// Here's why: 
/// Readability: FirstNameText is more readable and clearly indicates the purpose of the variable without needing to know the type.
/// Consistency: It aligns with the convention of using camel case for local variables and parameters, and Pascal case for properties and methods.
/// Maintainability: If the type of the control changes (e.g., from TextBox to RichTextBox), the variable name doesn't need to change, 
/// reducing the risk of errors during refactoring.
///
/// Default access mode is private except for interfaces which take no access modifier and are always public
///  
/// Copied DemoLibrary.DLL from MiniProjectWinFormApp to MiniProjectWinFormApp\DemoLibrary\bin\Debug
/// R Click Dependencies
/// Add project reference
/// Browse to the DLL file in folder where .exe file goes
/// Check box for DemoLibrary.DLL and click OK
/// Working.  DLL is .NET Framework.  WPF app is .NET Core 3.1
////////////////////////////////////////////////////////////////////////////////////////////////
namespace MiniProjectWPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISaveAddress
    {
        private PersonModel personModel = new PersonModel();
        private AddressModel addressModel = new AddressModel();
        private ObservableCollection<string> nameAddressData = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            // Makes sure that the DataContext of the Window itself is not overriding the ListBox
            this.DataContext = this;
            NameAddressList.DataContext = nameAddressData;
            SetEnterAddressButtonEnable();
        }

        private void AddressEntry_Click(object sender, System.EventArgs e)
        {
            AddressEntry addressForm = new AddressEntry(this);
            // Modal dialog - Keeps focus until you close it.  Use Show() for modeless dialog
            bool? result = addressForm.ShowDialog();
            if (result == true)
            {
                //SaveAddress() has already run before Address Form was closed
                personModel.FirstName = FirstNameText.Text;
                personModel.LastName = LastNameText.Text;
                string NameAddressText = $"{personModel.FirstName} {personModel.LastName} {addressModel.AddressLine1} {addressModel.AddressLine2} {addressModel.City} {addressModel.State}  {addressModel.Zipcode}";
                nameAddressData.Add(NameAddressText);
                ClearNames();
            }
        }

        public void SaveAddress(AddressModel address)
        {
            addressModel = address;
        }

        private void FirstName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(FirstNameText.Text);
            FirstNameText.Text = temp;
            FirstNameText.SelectionStart = FirstNameText.Text.Length;
            SetEnterAddressButtonEnable();
        }

        private void LastName_TextChanged(object sender, System.EventArgs e)
        {
            string temp = personModel.ValidateName(LastNameText.Text);
            LastNameText.Text = temp;
            LastNameText.SelectionStart = LastNameText.Text.Length;
            SetEnterAddressButtonEnable();
        }

        private void ClearNames()
        {
            FirstNameText.Text = "";
            LastNameText.Text = "";
            SetEnterAddressButtonEnable();
        }
        private bool SetEnterAddressButtonEnable()
        {
            bool enableButton = false;

            if ((string.IsNullOrEmpty(FirstNameText.Text) == false) &&
                (string.IsNullOrEmpty(LastNameText.Text) == false))
            {
                enableButton = true;
            }

            EnterAddressButton.IsEnabled = enableButton;
            return enableButton;
        }
    }
}
