using DemoLibrary;
using System.Windows.Forms;

namespace MiniProjectWinForm
{
    public partial class FormAddressModel : Form
    {
        ISaveAddress _parent;

        // This is needed to call the validation code
        AddressModel address = new AddressModel();

        public FormAddressModel(ISaveAddress parent)
        {
            InitializeComponent();
            _parent = parent;       //this pointer of class that opened FormAddressModel
        }

        private void AddressLine1_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine1(this.AddressLine1Text.Text);
            this.AddressLine1Text.Text = temp;
            this.AddressLine1Text.SelectionStart = this.AddressLine1Text.TextLength;
            SetResetOKButtonEnable();
        }

        private void AddressLine2_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateAddressLine2(this.AddressLine2Text.Text);
            this.AddressLine2Text.Text = temp;
            this.AddressLine2Text.SelectionStart = this.AddressLine2Text.TextLength;
            SetResetOKButtonEnable();
        }

        private void City_TextChanged(object sender, System.EventArgs e)
        {
            string temp = address.ValidateCity(this.CityText.Text);
            this.CityText.Text = temp;
            this.CityText.SelectionStart = this.CityText.TextLength;
            SetResetOKButtonEnable();
        }

        private void State_TextChanged(object sender, System.EventArgs e)
        {
            if (this.StateText.TextLength < 2)
            {
                this.StateText.Text = this.StateText.Text.ToUpper();
                this.StateText.SelectionStart = this.StateText.TextLength;
                return;
            }
            string temp = address.ValidateState(this.StateText.Text);
            this.StateText.Text = temp;
            this.StateText.SelectionStart = this.StateText.TextLength;
            SetResetOKButtonEnable();
            return;
        }

        private void Zipcode_TextChanged(object sender, System.EventArgs e)
        {
            if ((this.ZipcodeText.TextLength < 5) ||
               ((this.ZipcodeText.TextLength > 5) && (this.ZipcodeText.TextLength < 10)))
            {
                SetResetOKButtonEnable();
                return;
            }

            if (this.ZipcodeText.Text.Length > 10)
            {
                this.ZipcodeText.Text = this.ZipcodeText.Text.Substring(0, 10);
            }

            string temp = address.ValidateZipcode(this.ZipcodeText.Text);
            this.ZipcodeText.Text = temp;
            this.ZipcodeText.SelectionStart = this.ZipcodeText.TextLength;
            SetResetOKButtonEnable();
            return;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            address.AddressLine1 = this.AddressLine1Text.Text;
            address.AddressLine2 = this.AddressLine2Text.Text;
            address.City = this.CityText.Text;
            address.State = this.StateText.Text;
            address.Zipcode = this.ZipcodeText.Text;

            _parent.SaveAddress(address);

            this.Close();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private bool SetResetOKButtonEnable()
        {
            bool enableOKButton = false;

            if ((this.AddressLine1Text.Text.Length > 0) &&
                (this.CityText.Text.Length > 0) &&
                (this.StateText.Text.Length == 2) &&
                ((this.ZipcodeText.Text.Length == 5) || (this.ZipcodeText.Text.Length == 10)))
            {
                enableOKButton = true;
            }

            this.OKButton.Enabled = enableOKButton;
            return enableOKButton;
        }
    }
}
