namespace MiniProjectWinForm
{
    partial class FormPersonModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnterAddressButton = new System.Windows.Forms.Button();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.NameAddressList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // EnterAddressButton
            // 
            this.EnterAddressButton.Location = new System.Drawing.Point(384, 382);
            this.EnterAddressButton.Margin = new System.Windows.Forms.Padding(12);
            this.EnterAddressButton.Name = "EnterAddressButton";
            this.EnterAddressButton.Size = new System.Drawing.Size(211, 38);
            this.EnterAddressButton.TabIndex = 7;
            this.EnterAddressButton.Text = "Address Entry";
            this.EnterAddressButton.UseVisualStyleBackColor = true;
            this.EnterAddressButton.Click += new System.EventHandler(this.AddressEntry_Click);
            // 
            // labelLastName
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(648, 25);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(115, 25);
            this.LastNameLabel.TabIndex = 3;
            this.LastNameLabel.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(175, 25);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(116, 25);
            this.FirstNameLabel.TabIndex = 4;
            this.FirstNameLabel.Text = "First Name";
            // 
            // textBoxLastName
            // 
            this.LastNameText.Location = new System.Drawing.Point(513, 62);
            this.LastNameText.Margin = new System.Windows.Forms.Padding(12);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(452, 31);
            this.LastNameText.TabIndex = 6;
            this.LastNameText.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // textBoxFirstName
            // 
            this.FirstNameText.Location = new System.Drawing.Point(21, 62);
            this.FirstNameText.Margin = new System.Windows.Forms.Padding(12);
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.Size = new System.Drawing.Size(468, 31);
            this.FirstNameText.TabIndex = 5;
            this.FirstNameText.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // listBoxNamesAddresses
            // 
            this.NameAddressList.FormattingEnabled = true;
            this.NameAddressList.ItemHeight = 25;
            this.NameAddressList.Location = new System.Drawing.Point(21, 121);
            this.NameAddressList.Name = "NameAddressList";
            this.NameAddressList.Size = new System.Drawing.Size(944, 229);
            this.NameAddressList.TabIndex = 8;
            // 
            // FormPersonModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 441);
            this.Controls.Add(this.NameAddressList);
            this.Controls.Add(this.EnterAddressButton);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.LastNameText);
            this.Controls.Add(this.FirstNameText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormPersonModel";
            this.Text = "Person Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterAddressButton;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.TextBox FirstNameText;
        private System.Windows.Forms.ListBox NameAddressList;
    }
}

