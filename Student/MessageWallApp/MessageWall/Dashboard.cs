using System;
using System.Windows.Forms;
using UIHelperLibrary;

namespace MessageWall
{
    public partial class Dashboard : Form
    {
        PersonModel person = new PersonModel();
        bool showGreeting = false;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            // Validate first name
            string temp = person.ValidateName(this.textBoxFirstName.Text);
            this.textBoxFirstName.Text = temp;
            this.textBoxFirstName.SelectionStart = this.textBoxFirstName.TextLength;
            person.FirstName = temp;
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            // Validate last name 
            string temp = person.ValidateName(this.textBoxLastName.Text);
            this.textBoxLastName.Text = temp;
            this.textBoxLastName.SelectionStart = this.textBoxLastName.TextLength;
            person.LastName = temp;
        }

        private void buttonClickMe_Click(object sender, EventArgs e)
        {
            // Change to greeting message
            showGreeting = !showGreeting;
            if (showGreeting)
            {
                this.buttonClickMe.Text = $"Hello {person.FirstName} {person.LastName}";
            }
            else
            {
                this.buttonClickMe.Text = "Click Me";
            }
        }
    }
}
