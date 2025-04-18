using DemoLibrary;
using System.Windows;

namespace MiniProjectWPFCore
{
    /// <summary>
    /// Interaction logic for FormAddressModel.xaml
    /// </summary>
    /// 
    /// Changed textBoxState.SelectionStart = textBoxState.TextLength;   to  textBoxState.SelectionStart = textBoxState.Text.Length;
    /// Added SaveAddress(AddressModel addr)
    /// Added DemoLibrary dependency to project MiniProjectWPFCore
    /// Changed event handler's names to Pascal case


    public partial class FormAddressModel : Window, ISaveAddress
    {
        ISaveAddress _parent;

        // This is needed to call the validation code
        AddressModel address = new AddressModel();

        public FormAddressModel(ISaveAddress parent)
        {
            InitializeComponent();
            _parent = parent;       //this pointer of class that opened FormAddressModel
        }
        public void SaveAddress(AddressModel addr)
        {
            address = addr;
        }
        private void TextBoxAddressLine1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine1(textBoxAddressLine1.Text);
            textBoxAddressLine1.Text = temp;
            textBoxAddressLine1.SelectionStart = textBoxAddressLine1.Text.Length;
            SetResetOKButtonEnable();
        }

        private void TextBoxAddressLine2_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine2(textBoxAddressLine2.Text);
            textBoxAddressLine2.Text = temp;
            textBoxAddressLine2.SelectionStart = textBoxAddressLine2.Text.Length;
            SetResetOKButtonEnable();
        }

        private void TextBoxCity_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateCity(textBoxCity.Text);
            textBoxCity.Text = temp;
            textBoxCity.SelectionStart = textBoxCity.Text.Length;
            SetResetOKButtonEnable();
        }

        private void TextBoxState_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxState.Text.Length < 2)
            {
                textBoxState.Text = textBoxState.Text.ToUpper();
                textBoxState.SelectionStart = textBoxState.Text.Length;
                return;
            }
            string temp = address.ValidateState(textBoxState.Text);
            textBoxState.Text = temp;
            textBoxState.SelectionStart = textBoxState.Text.Length;
            SetResetOKButtonEnable();
            return;
        }

        private void TextBoxZipcode_TextChanged(object sender, System.EventArgs e)
        {
            if ((textBoxZipcode.Text.Length < 5) ||
               ((textBoxZipcode.Text.Length > 5) && (textBoxZipcode.Text.Length < 10)))
            {
                SetResetOKButtonEnable();
                return;
            }

            if (textBoxZipcode.Text.Length > 10)
            {
                textBoxZipcode.Text = textBoxZipcode.Text.Substring(0, 10);
            }

            string temp = address.ValidateZipcode(textBoxZipcode.Text);
            textBoxZipcode.Text = temp;
            textBoxZipcode.SelectionStart = textBoxZipcode.Text.Length;
            SetResetOKButtonEnable();
            return;
        }

        private void ButtonOKClicked(object sender, System.EventArgs e)
        {
            address.AddressLine1 = textBoxAddressLine1.Text;
            address.AddressLine2 = textBoxAddressLine2.Text;
            address.City = textBoxCity.Text;
            address.State = textBoxState.Text;
            address.Zipcode = textBoxZipcode.Text;

            _parent.SaveAddress(address);

            Close();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private bool SetResetOKButtonEnable()
        {
            bool enableOKButton = false;

            if ((textBoxAddressLine1.Text.Length > 0) &&
                (textBoxCity.Text.Length > 0) &&
                (textBoxState.Text.Length == 2) &&
                ((textBoxZipcode.Text.Length == 5) || (textBoxZipcode.Text.Length == 10)))
            {
                enableOKButton = true;
            }

            buttonOK.IsEnabled = enableOKButton;
            return enableOKButton;
        }
    }
}
