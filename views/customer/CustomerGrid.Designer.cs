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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            customerDatagrid = new DataGridView();
            customerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            registeredDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)customerDatagrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // customerDatagrid
            // 
            customerDatagrid.AutoGenerateColumns = false;
            customerDatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customerDatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDatagrid.Columns.AddRange(new DataGridViewColumn[] { customerIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, registeredDateDataGridViewTextBoxColumn });
            customerDatagrid.DataSource = customerBindingSource1;
            customerDatagrid.Location = new Point(21, 12);
            customerDatagrid.Name = "customerDatagrid";
            customerDatagrid.RowHeadersWidth = 51;
            customerDatagrid.Size = new Size(1205, 447);
            customerDatagrid.TabIndex = 0;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            customerIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            customerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // registeredDateDataGridViewTextBoxColumn
            // 
            registeredDateDataGridViewTextBoxColumn.DataPropertyName = "RegisteredDate";
            registeredDateDataGridViewTextBoxColumn.HeaderText = "RegisteredDate";
            registeredDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            registeredDateDataGridViewTextBoxColumn.Name = "registeredDateDataGridViewTextBoxColumn";
            // 
            // customerBindingSource1
            // 
            customerBindingSource1.DataSource = typeof(models.Customer);
            // 
            // CustomerGridView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 575);
            Controls.Add(customerDatagrid);
            Name = "CustomerGridView";
            Text = "CustomerGrid";
            Load += CustomerGrid_Load;
            ((System.ComponentModel.ISupportInitialize)customerDatagrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView customerDatagrid;
        private BindingSource customerBindingSource1;
        private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn registeredDateDataGridViewTextBoxColumn;
    }
}