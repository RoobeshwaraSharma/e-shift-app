namespace e_shift_app.views.admin
{
    partial class AdminDashboard
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
            btnCustomers = new Button();
            btnAdmins = new Button();
            SuspendLayout();
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(177, 62);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(94, 29);
            btnCustomers.TabIndex = 0;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnAdmins
            // 
            btnAdmins.Location = new Point(344, 62);
            btnAdmins.Name = "btnAdmins";
            btnAdmins.Size = new Size(94, 29);
            btnAdmins.TabIndex = 1;
            btnAdmins.Text = "Admins";
            btnAdmins.UseVisualStyleBackColor = true;
            btnAdmins.Click += btnAdmins_Click;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 468);
            Controls.Add(btnAdmins);
            Controls.Add(btnCustomers);
            Name = "AdminDashboard";
            Text = "Admin Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCustomers;
        private Button btnAdmins;
    }
}