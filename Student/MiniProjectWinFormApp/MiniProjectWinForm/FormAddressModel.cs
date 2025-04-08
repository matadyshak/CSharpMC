using System.Windows.Forms;
using UIHelperLibrary;

namespace MiniProjectWinForm
{
    public partial class FormAddressModel : Form
    {
        AddressModel address = new AddressModel();
        public FormAddressModel()
        {
            InitializeComponent();
        }
        private void textBoxAddressLine1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine1(this.textBoxAddressLine1.Text);
            this.textBoxAddressLine1.Text = temp;
            this.textBoxAddressLine1.SelectionStart = this.textBoxAddressLine1.TextLength;
            address.AddressLine1 = temp;
            SetResetOKButtonEnable();
        }

        private void textBoxAddressLine2_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine2(this.textBoxAddressLine2.Text);
            this.textBoxAddressLine2.Text = temp;
            this.textBoxAddressLine2.SelectionStart = this.textBoxAddressLine2.TextLength;
            address.AddressLine2 = temp;
            SetResetOKButtonEnable();
        }

        private void textBoxCity_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateCity(this.textBoxCity.Text);
            this.textBoxCity.Text = temp;
            this.textBoxCity.SelectionStart = this.textBoxCity.TextLength;
            address.City = temp;
            SetResetOKButtonEnable();
        }

        private void textBoxState_TextChanged(object sender, System.EventArgs e)
        {
            if (this.textBoxState.TextLength < 2)
            {
                this.textBoxState.Text = this.textBoxState.Text.ToUpper();
                this.textBoxState.SelectionStart = this.textBoxState.TextLength;
                return;
            }
            string temp = address.ValidateState(this.textBoxState.Text);
            this.textBoxState.Text = temp;
            this.textBoxState.SelectionStart = this.textBoxState.TextLength;
            address.State = temp;
            SetResetOKButtonEnable();
            return;
        }

        private void textBoxZipcode_TextChanged(object sender, System.EventArgs e)
        {
            if ((this.textBoxZipcode.TextLength < 5) ||
               ((this.textBoxZipcode.TextLength > 5) && (this.textBoxZipcode.TextLength < 10)))
            {
                return;
            }

            if (this.textBoxZipcode.Text.Length > 10)
            {
                this.textBoxZipcode.Text = this.textBoxZipcode.Text.Substring(0, 10);
            }

            string temp = address.ValidateZipcode(this.textBoxZipcode.Text);
            this.textBoxZipcode.Text = temp;
            this.textBoxZipcode.SelectionStart = this.textBoxZipcode.TextLength;
            address.Zipcode = temp;
            SetResetOKButtonEnable();
            return;
        }
        private void buttonOKClicked(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        public AddressModel GetAddressModel()
        {
            return address;
        }

        private bool SetResetOKButtonEnable()
        {
            bool enableOKButton = false;

            if ((this.textBoxAddressLine1.Text.Length > 0) &&
                (this.textBoxCity.Text.Length > 0) &&
                (this.textBoxState.Text.Length > 0) &&
                (this.textBoxZipcode.Text.Length > 0))
            {
                enableOKButton = true;
            }

            this.buttonOK.Enabled = enableOKButton;
            return enableOKButton;
        }
    }
}
