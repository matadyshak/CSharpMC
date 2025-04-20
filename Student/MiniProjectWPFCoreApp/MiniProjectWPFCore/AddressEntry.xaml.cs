using DemoLibrary;
using System.Windows;

namespace MiniProjectWPFCore
{
    /// <summary>
    /// Interaction logic for AddressEntry.xaml
    /// </summary>
    /// 
    /// Changed textBoxState.SelectionStart = textBoxState.TextLength;   to  textBoxState.SelectionStart = textBoxState.Text.Length;
    /// Added SaveAddress(AddressModel addr)
    /// Added DemoLibrary dependency to project MiniProjectWPFCore
    /// Changed event handler's names to Pascal case


    public partial class AddressEntry : Window, ISaveAddress
    {
        ISaveAddress _parent;

        // This is needed to call the validation code
        AddressModel address = new AddressModel();

        public AddressEntry(ISaveAddress parent)
        {
            InitializeComponent();
            _parent = parent;       //this pointer of class that opened FormAddressModel
        }

        public void SaveAddress(AddressModel addr)
        {
            address = addr;
        }

        private void AddressLine1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine1(AddressLine1Text.Text);
            AddressLine1Text.Text = temp;
            AddressLine1Text.SelectionStart = AddressLine1Text.Text.Length;
            SetResetOKButtonEnable();
        }

        private void AddressLine2_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine2(AddressLine2Text.Text);
            AddressLine2Text.Text = temp;
            AddressLine2Text.SelectionStart = AddressLine2Text.Text.Length;
            SetResetOKButtonEnable();
        }

        private void City_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateCity(CityText.Text);
            CityText.Text = temp;
            CityText.SelectionStart = CityText.Text.Length;
            SetResetOKButtonEnable();
        }

        private void State_TextChanged(object sender, System.EventArgs e)
        {
            if (StateText.Text.Length < 2)
            {
                StateText.Text = StateText.Text.ToUpper();
                StateText.SelectionStart = StateText.Text.Length;
                return;
            }
            string temp = address.ValidateState(StateText.Text);
            StateText.Text = temp;
            StateText.SelectionStart = StateText.Text.Length;
            SetResetOKButtonEnable();
            return;
        }

        private void Zipcode_TextChanged(object sender, System.EventArgs e)
        {
            if ((ZipcodeText.Text.Length < 5) ||
               ((ZipcodeText.Text.Length > 5) && (ZipcodeText.Text.Length < 10)))
            {
                SetResetOKButtonEnable();
                return;
            }

            if (ZipcodeText.Text.Length > 10)
            {
                ZipcodeText.Text = ZipcodeText.Text.Substring(0, 10);
            }

            string temp = address.ValidateZipcode(ZipcodeText.Text);
            ZipcodeText.Text = temp;
            ZipcodeText.SelectionStart = ZipcodeText.Text.Length;
            SetResetOKButtonEnable();
            return;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            address.AddressLine1 = AddressLine1Text.Text;
            address.AddressLine2 = AddressLine2Text.Text;
            address.City = CityText.Text;
            address.State = StateText.Text;
            address.Zipcode = ZipcodeText.Text;

            _parent.SaveAddress(address);
            this.DialogResult = true;

            Close();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private bool SetResetOKButtonEnable()
        {
            bool enableOKButton = false;

            if ((AddressLine1Text.Text.Length > 0) &&
                (CityText.Text.Length > 0) &&
                (StateText.Text.Length == 2) &&
                ((ZipcodeText.Text.Length == 5) || (ZipcodeText.Text.Length == 10)))
            {
                enableOKButton = true;
            }

            OKButton.IsEnabled = enableOKButton;
            return enableOKButton;
        }
    }
}
