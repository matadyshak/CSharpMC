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
            this.buttonEnterAddress = new System.Windows.Forms.Button();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.listBoxNamesAddresses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonEnterAddress
            // 
            this.buttonEnterAddress.Location = new System.Drawing.Point(384, 382);
            this.buttonEnterAddress.Margin = new System.Windows.Forms.Padding(12);
            this.buttonEnterAddress.Name = "buttonEnterAddress";
            this.buttonEnterAddress.Size = new System.Drawing.Size(211, 38);
            this.buttonEnterAddress.TabIndex = 7;
            this.buttonEnterAddress.Text = "Enter Address Info";
            this.buttonEnterAddress.UseVisualStyleBackColor = true;
            this.buttonEnterAddress.Click += new System.EventHandler(this.ButtonEnterAddress_Click);
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(648, 25);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(115, 25);
            this.labelLastName.TabIndex = 3;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(175, 25);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(116, 25);
            this.labelFirstName.TabIndex = 4;
            this.labelFirstName.Text = "First Name";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(513, 62);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(12);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(452, 31);
            this.textBoxLastName.TabIndex = 6;
            this.textBoxLastName.TextChanged += new System.EventHandler(this.TextBoxLastName_TextChanged);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(21, 62);
            this.textBoxFirstName.Margin = new System.Windows.Forms.Padding(12);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(468, 31);
            this.textBoxFirstName.TabIndex = 5;
            this.textBoxFirstName.TextChanged += new System.EventHandler(this.TextBoxFirstName_TextChanged);
            // 
            // listBoxNamesAddresses
            // 
            this.listBoxNamesAddresses.FormattingEnabled = true;
            this.listBoxNamesAddresses.ItemHeight = 25;
            this.listBoxNamesAddresses.Location = new System.Drawing.Point(21, 121);
            this.listBoxNamesAddresses.Name = "listBoxNamesAddresses";
            this.listBoxNamesAddresses.Size = new System.Drawing.Size(944, 229);
            this.listBoxNamesAddresses.TabIndex = 8;
            // 
            // FormPersonModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 441);
            this.Controls.Add(this.listBoxNamesAddresses);
            this.Controls.Add(this.buttonEnterAddress);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormPersonModel";
            this.Text = "Person Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnterAddress;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.ListBox listBoxNamesAddresses;
    }
}

