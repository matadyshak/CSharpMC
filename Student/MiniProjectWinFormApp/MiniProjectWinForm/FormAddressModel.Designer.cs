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
            this.textBoxAddressLine1 = new System.Windows.Forms.TextBox();
            this.textBoxAddressLine2 = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.textBoxZipcode = new System.Windows.Forms.TextBox();
            this.labelAddressLine1 = new System.Windows.Forms.Label();
            this.labelAddressLine2 = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.labelZipcode = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddressLine1
            // 
            this.textBoxAddressLine1.Location = new System.Drawing.Point(32, 64);
            this.textBoxAddressLine1.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxAddressLine1.Name = "textBoxAddressLine1";
            this.textBoxAddressLine1.Size = new System.Drawing.Size(698, 32);
            this.textBoxAddressLine1.TabIndex = 0;
            this.textBoxAddressLine1.TextChanged += new System.EventHandler(this.textBoxAddressLine1_TextChanged);
            // 
            // textBoxAddressLine2
            // 
            this.textBoxAddressLine2.Location = new System.Drawing.Point(32, 167);
            this.textBoxAddressLine2.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxAddressLine2.Name = "textBoxAddressLine2";
            this.textBoxAddressLine2.Size = new System.Drawing.Size(698, 32);
            this.textBoxAddressLine2.TabIndex = 1;
            this.textBoxAddressLine2.TextChanged += new System.EventHandler(this.textBoxAddressLine2_TextChanged);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(32, 270);
            this.textBoxCity.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(479, 32);
            this.textBoxCity.TabIndex = 2;
            this.textBoxCity.TextChanged += new System.EventHandler(this.textBoxCity_TextChanged);
            // 
            // textBoxState
            // 
            this.textBoxState.Location = new System.Drawing.Point(523, 270);
            this.textBoxState.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(46, 32);
            this.textBoxState.TabIndex = 3;
            this.textBoxState.TextChanged += new System.EventHandler(this.textBoxState_TextChanged);
            // 
            // textBoxZipcode
            // 
            this.textBoxZipcode.Location = new System.Drawing.Point(581, 270);
            this.textBoxZipcode.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxZipcode.Name = "textBoxZipcode";
            this.textBoxZipcode.Size = new System.Drawing.Size(149, 32);
            this.textBoxZipcode.TabIndex = 4;
            this.textBoxZipcode.TextChanged += new System.EventHandler(this.textBoxZipcode_TextChanged);
            // 
            // labelAddressLine1
            // 
            this.labelAddressLine1.AutoSize = true;
            this.labelAddressLine1.Location = new System.Drawing.Point(303, 33);
            this.labelAddressLine1.Name = "labelAddressLine1";
            this.labelAddressLine1.Size = new System.Drawing.Size(157, 26);
            this.labelAddressLine1.TabIndex = 5;
            this.labelAddressLine1.Text = "Address Line 1";
            // 
            // labelAddressLine2
            // 
            this.labelAddressLine2.AutoSize = true;
            this.labelAddressLine2.Location = new System.Drawing.Point(303, 135);
            this.labelAddressLine2.Name = "labelAddressLine2";
            this.labelAddressLine2.Size = new System.Drawing.Size(157, 26);
            this.labelAddressLine2.TabIndex = 6;
            this.labelAddressLine2.Text = "Address Line 2";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(242, 238);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(50, 26);
            this.labelCity.TabIndex = 7;
            this.labelCity.Text = "City";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(518, 238);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(63, 26);
            this.labelState.TabIndex = 8;
            this.labelState.Text = "State";
            // 
            // labelZipcode
            // 
            this.labelZipcode.AutoSize = true;
            this.labelZipcode.Location = new System.Drawing.Point(601, 238);
            this.labelZipcode.Name = "labelZipcode";
            this.labelZipcode.Size = new System.Drawing.Size(104, 26);
            this.labelZipcode.TabIndex = 9;
            this.labelZipcode.Text = "ZIP Code";
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(189, 351);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(142, 44);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(351, 351);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(142, 44);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAddressModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 417);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelZipcode);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelAddressLine2);
            this.Controls.Add(this.labelAddressLine1);
            this.Controls.Add(this.textBoxZipcode);
            this.Controls.Add(this.textBoxState);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxAddressLine2);
            this.Controls.Add(this.textBoxAddressLine1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormAddressModel";
            this.Text = "AddressInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddressLine1;
        private System.Windows.Forms.TextBox textBoxAddressLine2;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.TextBox textBoxZipcode;
        private System.Windows.Forms.Label labelAddressLine1;
        private System.Windows.Forms.Label labelAddressLine2;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelZipcode;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}