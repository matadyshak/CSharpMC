namespace MiniProjectWinForm
{
    partial class FormAddressModel
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
            this.AddressLine1Text = new System.Windows.Forms.TextBox();
            this.AddressLine2Text = new System.Windows.Forms.TextBox();
            this.CityText = new System.Windows.Forms.TextBox();
            this.StateText = new System.Windows.Forms.TextBox();
            this.ZipcodeText = new System.Windows.Forms.TextBox();
            this.AddressLine1Label = new System.Windows.Forms.Label();
            this.AddressLine2Label = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.ZipcodeLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddressLine1
            // 
            this.AddressLine1Text.Location = new System.Drawing.Point(32, 64);
            this.AddressLine1Text.Margin = new System.Windows.Forms.Padding(6);
            this.AddressLine1Text.Name = "AddressLine1Text";
            this.AddressLine1Text.Size = new System.Drawing.Size(698, 32);
            this.AddressLine1Text.TabIndex = 0;
            this.AddressLine1Text.TextChanged += new System.EventHandler(this.AddressLine1_TextChanged);
            // 
            // textBoxAddressLine2
            // 
            this.AddressLine2Text.Location = new System.Drawing.Point(32, 167);
            this.AddressLine2Text.Margin = new System.Windows.Forms.Padding(6);
            this.AddressLine2Text.Name = "AddressLine2Text";
            this.AddressLine2Text.Size = new System.Drawing.Size(698, 32);
            this.AddressLine2Text.TabIndex = 1;
            this.AddressLine2Text.TextChanged += new System.EventHandler(this.AddressLine2_TextChanged);
            // 
            // textBoxCity
            // 
            this.CityText.Location = new System.Drawing.Point(32, 270);
            this.CityText.Margin = new System.Windows.Forms.Padding(6);
            this.CityText.Name = "CityText";
            this.CityText.Size = new System.Drawing.Size(479, 32);
            this.CityText.TabIndex = 2;
            this.CityText.TextChanged += new System.EventHandler(this.City_TextChanged);
            // 
            // textBoxState
            // 
            this.StateText.Location = new System.Drawing.Point(523, 270);
            this.StateText.Margin = new System.Windows.Forms.Padding(6);
            this.StateText.Name = "StateText";
            this.StateText.Size = new System.Drawing.Size(46, 32);
            this.StateText.TabIndex = 3;
            this.StateText.TextChanged += new System.EventHandler(this.State_TextChanged);
            // 
            // textBoxZipcode
            // 
            this.ZipcodeText.Location = new System.Drawing.Point(581, 270);
            this.ZipcodeText.Margin = new System.Windows.Forms.Padding(6);
            this.ZipcodeText.Name = "ZipcodeText";
            this.ZipcodeText.Size = new System.Drawing.Size(149, 32);
            this.ZipcodeText.TabIndex = 4;
            this.ZipcodeText.TextChanged += new System.EventHandler(this.Zipcode_TextChanged);
            // 
            // labelAddressLine1
            // 
            this.AddressLine1Label.AutoSize = true;
            this.AddressLine1Label.Location = new System.Drawing.Point(303, 33);
            this.AddressLine1Label.Name = "AddressLine1Label";
            this.AddressLine1Label.Size = new System.Drawing.Size(157, 26);
            this.AddressLine1Label.TabIndex = 5;
            this.AddressLine1Label.Text = "Address Line 1";
            // 
            // labelAddressLine2
            // 
            this.AddressLine2Label.AutoSize = true;
            this.AddressLine2Label.Location = new System.Drawing.Point(303, 135);
            this.AddressLine2Label.Name = "AddressLine2Label";
            this.AddressLine2Label.Size = new System.Drawing.Size(157, 26);
            this.AddressLine2Label.TabIndex = 6;
            this.AddressLine2Label.Text = "Address Line 2";
            // 
            // labelCity
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(242, 238);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(50, 26);
            this.CityLabel.TabIndex = 7;
            this.CityLabel.Text = "City";
            // 
            // labelState
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(518, 238);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(63, 26);
            this.StateLabel.TabIndex = 8;
            this.StateLabel.Text = "State";
            // 
            // labelZipcode
            // 
            this.ZipcodeLabel.AutoSize = true;
            this.ZipcodeLabel.Location = new System.Drawing.Point(601, 238);
            this.ZipcodeLabel.Name = "ZipcodeLabel";
            this.ZipcodeLabel.Size = new System.Drawing.Size(104, 26);
            this.ZipcodeLabel.TabIndex = 9;
            this.ZipcodeLabel.Text = "ZIP Code";
            // 
            // buttonOK
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(189, 351);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(142, 44);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // buttonCancel
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(351, 351);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(142, 44);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FormAddressModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 417);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ZipcodeLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.AddressLine2Label);
            this.Controls.Add(this.AddressLine1Label);
            this.Controls.Add(this.ZipcodeText);
            this.Controls.Add(this.StateText);
            this.Controls.Add(this.CityText);
            this.Controls.Add(this.AddressLine2Text);
            this.Controls.Add(this.AddressLine1Text);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormAddressModel";
            this.Text = "AddressInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddressLine1Text;
        private System.Windows.Forms.TextBox AddressLine2Text;
        private System.Windows.Forms.TextBox CityText;
        private System.Windows.Forms.TextBox StateText;
        private System.Windows.Forms.TextBox ZipcodeText;
        private System.Windows.Forms.Label AddressLine1Label;
        private System.Windows.Forms.Label AddressLine2Label;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label ZipcodeLabel;
        private System.Windows.Forms.Button OKButton;
        private new System.Windows.Forms.Button CancelButton;
    }
}