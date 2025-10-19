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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverGrid));
            driverGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            LicenseNumber = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            driverBindingSource = new BindingSource(components);
            btnAddDriver = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)driverGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // driverGridView
            // 
            driverGridView.AutoGenerateColumns = false;
            driverGridView.BackgroundColor = SystemColors.ActiveCaption;
            driverGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            driverGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, LicenseNumber, Status });
            driverGridView.DataSource = driverBindingSource;
            driverGridView.GridColor = SystemColors.HotTrack;
            driverGridView.Location = new Point(36, 153);
            driverGridView.Name = "driverGridView";
            driverGridView.RowHeadersWidth = 51;
            driverGridView.Size = new Size(587, 293);
            driverGridView.TabIndex = 0;
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
            // driverBindingSource
            // 
            driverBindingSource.DataSource = typeof(models.Driver);
            // 
            // btnAddDriver
            // 
            btnAddDriver.Location = new Point(508, 62);
            btnAddDriver.Name = "btnAddDriver";
            btnAddDriver.Size = new Size(115, 38);
            btnAddDriver.TabIndex = 1;
            btnAddDriver.Text = "Add Driver";
            btnAddDriver.UseVisualStyleBackColor = true;
            btnAddDriver.Click += btnAddDriver_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // DriverGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(656, 475);
            Controls.Add(pictureBox1);
            Controls.Add(btnAddDriver);
            Controls.Add(driverGridView);
            Name = "DriverGrid";
            Text = "Driver Dashboard";
            Load += DriverGrid_Load;
            ((System.ComponentModel.ISupportInitialize)driverGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}