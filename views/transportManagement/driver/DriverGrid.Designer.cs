namespace e_shift_app.views.transportManagement.driver
{
    partial class DriverGrid
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
            driverGridView = new DataGridView();
            driverBindingSource = new BindingSource(components);
            btnAddDriver = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            LicenseNumber = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)driverGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).BeginInit();
            SuspendLayout();
            // 
            // driverGridView
            // 
            driverGridView.AutoGenerateColumns = false;
            driverGridView.BackgroundColor = SystemColors.GradientInactiveCaption;
            driverGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driverGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, LicenseNumber, Status });
            driverGridView.DataSource = driverBindingSource;
            driverGridView.GridColor = SystemColors.HotTrack;
            driverGridView.Location = new Point(72, 112);
            driverGridView.Name = "driverGridView";
            driverGridView.RowHeadersWidth = 51;
            driverGridView.Size = new Size(452, 275);
            driverGridView.TabIndex = 0;
            // 
            // driverBindingSource
            // 
            driverBindingSource.DataSource = typeof(models.Driver);
            // 
            // btnAddDriver
            // 
            btnAddDriver.Location = new Point(450, 51);
            btnAddDriver.Name = "btnAddDriver";
            btnAddDriver.Size = new Size(94, 29);
            btnAddDriver.TabIndex = 1;
            btnAddDriver.Text = "Add Driver";
            btnAddDriver.UseVisualStyleBackColor = true;
            btnAddDriver.Click += btnAddDriver_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.Frozen = true;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 51;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 78;
            // 
            // LicenseNumber
            // 
            LicenseNumber.DataPropertyName = "LicenseNumber";
            LicenseNumber.HeaderText = "License Number";
            LicenseNumber.MinimumWidth = 6;
            LicenseNumber.Name = "LicenseNumber";
            LicenseNumber.Width = 132;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // DriverGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 419);
            Controls.Add(btnAddDriver);
            Controls.Add(driverGridView);
            Name = "DriverGrid";
            Text = "Driver Dashboard";
            Load += DriverGrid_Load;
            ((System.ComponentModel.ISupportInitialize)driverGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView driverGridView;
        private DataGridViewTextBoxColumn licenseNumberDataGridViewTextBoxColumn;
        private BindingSource driverBindingSource;
        private Button btnAddDriver;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn LicenseNumber;
        private DataGridViewTextBoxColumn Status;
    }
}