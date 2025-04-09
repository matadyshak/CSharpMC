namespace WinFormMiniProject
{
    partial class AddressEntry
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
            this.cityText = new System.Windows.Forms.TextBox();
            this.streetAddressText = new System.Windows.Forms.TextBox();
            this.streetAddressLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.zipCodeText = new System.Windows.Forms.TextBox();
            this.stateText = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.saveRecord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(216, 137);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(267, 35);
            this.cityText.TabIndex = 6;
            // 
            // streetAddressText
            // 
            this.streetAddressText.Location = new System.Drawing.Point(216, 84);
            this.streetAddressText.Name = "streetAddressText";
            this.streetAddressText.Size = new System.Drawing.Size(267, 35);
            this.streetAddressText.TabIndex = 5;
            // 
            // streetAddressLabel
            // 
            this.streetAddressLabel.AutoSize = true;
            this.streetAddressLabel.Location = new System.Drawing.Point(38, 87);
            this.streetAddressLabel.Name = "streetAddressLabel";
            this.streetAddressLabel.Size = new System.Drawing.Size(172, 29);
            this.streetAddressLabel.TabIndex = 3;
            this.streetAddressLabel.Text = "Street Address";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(157, 143);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(53, 29);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City";
            // 
            // zipCodeText
            // 
            this.zipCodeText.Location = new System.Drawing.Point(216, 246);
            this.zipCodeText.Name = "zipCodeText";
            this.zipCodeText.Size = new System.Drawing.Size(267, 35);
            this.zipCodeText.TabIndex = 10;
            // 
            // stateText
            // 
            this.stateText.Location = new System.Drawing.Point(216, 193);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(267, 35);
            this.stateText.TabIndex = 9;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(142, 196);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(68, 29);
            this.stateLabel.TabIndex = 7;
            this.stateLabel.Text = "State";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Location = new System.Drawing.Point(98, 249);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(112, 29);
            this.zipCodeLabel.TabIndex = 8;
            this.zipCodeLabel.Text = "Zip Code";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(176, 19);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(249, 39);
            this.headerLabel.TabIndex = 11;
            this.headerLabel.Text = "Address Entry";
            // 
            // saveRecord
            // 
            this.saveRecord.Location = new System.Drawing.Point(216, 307);
            this.saveRecord.Name = "saveRecord";
            this.saveRecord.Size = new System.Drawing.Size(197, 50);
            this.saveRecord.TabIndex = 12;
            this.saveRecord.Text = "Save";
            this.saveRecord.UseVisualStyleBackColor = true;
            this.saveRecord.Click += new System.EventHandler(this.SaveRecord_Click);
            // 
            // AddressEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 381);
            this.Controls.Add(this.saveRecord);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.zipCodeText);
            this.Controls.Add(this.stateText);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.streetAddressText);
            this.Controls.Add(this.streetAddressLabel);
            this.Controls.Add(this.cityLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "AddressEntry";
            this.Text = "Address Entry Form by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.TextBox streetAddressText;
        private System.Windows.Forms.Label streetAddressLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox zipCodeText;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button saveRecord;
    }
}