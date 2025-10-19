namespace e_shift_app.views.customer
{
    partial class CustomerGridView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerGridView));
            customerDatagrid = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            registeredDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerBindingSource1 = new BindingSource(components);
            btnCreateCustomer = new Button();
            btnRefresh = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)customerDatagrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // customerDatagrid
            // 
            customerDatagrid.AutoGenerateColumns = false;
            customerDatagrid.BackgroundColor = SystemColors.ActiveCaption;
            customerDatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDatagrid.Columns.AddRange(new DataGridViewColumn[] { Id, nameDataGridViewTextBoxColumn, Username, addressDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, registeredDateDataGridViewTextBoxColumn });
            customerDatagrid.DataSource = customerBindingSource1;
            customerDatagrid.Location = new Point(30, 150);
            customerDatagrid.Name = "customerDatagrid";
            customerDatagrid.RowHeadersWidth = 51;
            customerDatagrid.Size = new Size(1246, 459);
            customerDatagrid.TabIndex = 0;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.FillWeight = 299.46524F;
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.FillWeight = 66.75579F;
            nameDataGridViewTextBoxColumn.HeaderText = "Full Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // Username
            // 
            Username.DataPropertyName = "Username";
            Username.FillWeight = 66.75579F;
            Username.HeaderText = "Username";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.FillWeight = 66.75579F;
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            addressDataGridViewTextBoxColumn.Width = 200;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.FillWeight = 66.75579F;
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "Phone Number";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 110;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.FillWeight = 66.75579F;
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 110;
            // 
            // registeredDateDataGridViewTextBoxColumn
            // 
            registeredDateDataGridViewTextBoxColumn.DataPropertyName = "RegisteredDate";
            registeredDateDataGridViewTextBoxColumn.FillWeight = 66.75579F;
            registeredDateDataGridViewTextBoxColumn.HeaderText = "Registered Date";
            registeredDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            registeredDateDataGridViewTextBoxColumn.Name = "registeredDateDataGridViewTextBoxColumn";
            registeredDateDataGridViewTextBoxColumn.Width = 110;
            // 
            // customerBindingSource1
            // 
            customerBindingSource1.DataSource = typeof(models.Customer);
            // 
            // btnCreateCustomer
            // 
            btnCreateCustomer.Location = new Point(882, 51);
            btnCreateCustomer.Name = "btnCreateCustomer";
            btnCreateCustomer.Size = new Size(193, 54);
            btnCreateCustomer.TabIndex = 1;
            btnCreateCustomer.Text = "Create Customer";
            btnCreateCustomer.UseVisualStyleBackColor = true;
            btnCreateCustomer.Click += btnCreateCustomer_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1111, 51);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(152, 54);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // CustomerGridView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1324, 630);
            Controls.Add(pictureBox1);
            Controls.Add(btnRefresh);
            Controls.Add(btnCreateCustomer);
            Controls.Add(customerDatagrid);
            Name = "CustomerGridView";
            Text = "CustomerGrid";
            Load += CustomerGrid_Load;
            ((System.ComponentModel.ISupportInitialize)customerDatagrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView customerDatagrid;
        private BindingSource customerBindingSource1;
        private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn registeredDateDataGridViewTextBoxColumn;
        private Button btnCreateCustomer;
        private Button btnRefresh;
        private PictureBox pictureBox1;
    }
}