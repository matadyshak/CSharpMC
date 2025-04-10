using DemoLibrary;
using System.Windows.Forms;

namespace MiniProjectWinForm
{
    public partial class FormAddressModel : Form
    {
        ISaveAddress _parent;

        // This is needed to call the validation
        AddressModel address = new AddressModel();

        public FormAddressModel(ISaveAddress parent)
        {
            InitializeComponent();
            _parent = parent;       //this pointer of class that opened FormAddressModel
        }

        private void textBoxAddressLine1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine1(this.textBoxAddressLine1.Text);
            this.textBoxAddressLine1.Text = temp;
            this.textBoxAddressLine1.SelectionStart = this.textBoxAddressLine1.TextLength;
            SetResetOKButtonEnable();
        }

        private void textBoxAddressLine2_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine2(this.textBoxAddressLine2.Text);
            this.textBoxAddressLine2.Text = temp;
            this.textBoxAddressLine2.SelectionStart = this.textBoxAddressLine2.TextLength;
            SetResetOKButtonEnable();
        }

        private void textBoxCity_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateCity(this.textBoxCity.Text);
            this.textBoxCity.Text = temp;
            this.textBoxCity.SelectionStart = this.textBoxCity.TextLength;
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
            SetResetOKButtonEnable();
            return;
        }

        private void buttonOKClicked(object sender, System.EventArgs e)
        {
	    address.AddressLine1 = this.textBoxAddressLine1.Text;
	    address.AddressLine2 = this.textBoxAddressLine2.Text;
	    address.City = this.textBoxCity.Text;
	    address.State = this.textBoxState.Text;
	    address.Zipcode = this.textBoxZipcode.Text;

	    _parent.SaveAddress(address);

            this.Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private bool SetResetOKButtonEnable()
        {
            bool enableOKButton = false;

            if ((this.textBoxAddressLine1.Text.Length > 0) &&
                (this.textBoxCity.Text.Length > 0) &&
                (this.textBoxState.Text.Length == 2) &&
                ((this.textBoxZipcode.Text.Length == 5) || (this.textBoxZipcode.Text.Length == 10)))
            {
                enableOKButton = true;
            }

            this.buttonOK.Enabled = enableOKButton;
            return enableOKButton;
        }
    }
}
