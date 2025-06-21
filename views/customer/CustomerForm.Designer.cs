
namespace e_shift_app
{
    partial class CustomerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            label1 = new Label();
            txtAddress = new TextBox();
            Address = new Label();
            txtPhoneNumber = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            lblUsername = new Label();
            txtPassword = new Label();
            txtUsername = new TextBox();
            txtUserPassword = new TextBox();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(347, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(248, 27);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 48);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Name\r\n";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(347, 101);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(248, 27);
            txtAddress.TabIndex = 2;
            // 
            // Address
            // 
            Address.AutoSize = true;
            Address.Location = new Point(138, 104);
            Address.Name = "Address";
            Address.Size = new Size(62, 20);
            Address.TabIndex = 3;
            Address.Text = "Address";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(347, 160);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(248, 27);
            txtPhoneNumber.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 163);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 5;
            label2.Text = "Phone Number";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(347, 223);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(248, 27);
            txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 226);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(267, 455);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Create";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(527, 455);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(138, 279);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 11;
            lblUsername.Text = "Username";
            lblUsername.Click += label4_Click;
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.Location = new Point(138, 334);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(70, 20);
            txtPassword.TabIndex = 12;
            txtPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(347, 276);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(248, 27);
            txtUsername.TabIndex = 13;
            // 
            // txtUserPassword
            // 
            txtUserPassword.Location = new Point(347, 331);
            txtUserPassword.Name = "txtUserPassword";
            txtUserPassword.PasswordChar = '*';
            txtUserPassword.Size = new Size(248, 27);
            txtUserPassword.TabIndex = 14;
            txtUserPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(138, 390);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 15;
            label4.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(347, 387);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(248, 27);
            txtConfirmPassword.TabIndex = 16;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 523);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label4);
            Controls.Add(txtUserPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtPhoneNumber);
            Controls.Add(Address);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "CustomerForm";
            Text = "Customer Form";
            Load += CustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private TextBox txtAddress;
        private Label Address;
        private TextBox txtPhoneNumber;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private Button btnSubmit;
        private Button btnCancel;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label lblUsername;
        private Label txtPassword;
        private TextBox txtUsername;
        private TextBox txtUserPassword;
        private Label label4;
        private TextBox txtConfirmPassword;
    }
}
