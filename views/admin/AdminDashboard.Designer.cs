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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            btnCustomers = new Button();
            btnAdmins = new Button();
            groupBox1 = new GroupBox();
            jobsGridView = new DataGridView();
            jobIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startLocationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endLocationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jobBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            btnAssistant = new Button();
            btnDriver = new Button();
            btnContainer = new Button();
            btnLorry = new Button();
            btnTransportUnit = new Button();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jobsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jobBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(40, 47);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(129, 40);
            btnCustomers.TabIndex = 0;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnAdmins
            // 
            btnAdmins.Location = new Point(222, 47);
            btnAdmins.Name = "btnAdmins";
            btnAdmins.Size = new Size(137, 40);
            btnAdmins.TabIndex = 1;
            btnAdmins.Text = "Admins";
            btnAdmins.UseVisualStyleBackColor = true;
            btnAdmins.Click += btnAdmins_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCustomers);
            groupBox1.Controls.Add(btnAdmins);
            groupBox1.Location = new Point(181, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 134);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Users";
            // 
            // jobsGridView
            // 
            jobsGridView.AutoGenerateColumns = false;
            jobsGridView.BackgroundColor = SystemColors.ActiveCaption;
            jobsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jobsGridView.Columns.AddRange(new DataGridViewColumn[] { jobIdDataGridViewTextBoxColumn, customerIdDataGridViewTextBoxColumn, startLocationDataGridViewTextBoxColumn, endLocationDataGridViewTextBoxColumn, startDateDataGridViewTextBoxColumn, endDateDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn });
            jobsGridView.DataSource = jobBindingSource;
            jobsGridView.GridColor = SystemColors.GradientActiveCaption;
            jobsGridView.Location = new Point(25, 176);
            jobsGridView.Name = "jobsGridView";
            jobsGridView.RowHeadersWidth = 51;
            jobsGridView.Size = new Size(1197, 438);
            jobsGridView.TabIndex = 3;
            // 
            // jobIdDataGridViewTextBoxColumn
            // 
            jobIdDataGridViewTextBoxColumn.DataPropertyName = "JobId";
            jobIdDataGridViewTextBoxColumn.Frozen = true;
            jobIdDataGridViewTextBoxColumn.HeaderText = "Job Id";
            jobIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            jobIdDataGridViewTextBoxColumn.Name = "jobIdDataGridViewTextBoxColumn";
            jobIdDataGridViewTextBoxColumn.ReadOnly = true;
            jobIdDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            jobIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            customerIdDataGridViewTextBoxColumn.Frozen = true;
            customerIdDataGridViewTextBoxColumn.HeaderText = "Customer Id";
            customerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            customerIdDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            customerIdDataGridViewTextBoxColumn.Width = 80;
            // 
            // startLocationDataGridViewTextBoxColumn
            // 
            startLocationDataGridViewTextBoxColumn.DataPropertyName = "StartLocation";
            startLocationDataGridViewTextBoxColumn.HeaderText = "Start Location";
            startLocationDataGridViewTextBoxColumn.MinimumWidth = 6;
            startLocationDataGridViewTextBoxColumn.Name = "startLocationDataGridViewTextBoxColumn";
            startLocationDataGridViewTextBoxColumn.Width = 125;
            // 
            // endLocationDataGridViewTextBoxColumn
            // 
            endLocationDataGridViewTextBoxColumn.DataPropertyName = "EndLocation";
            endLocationDataGridViewTextBoxColumn.HeaderText = "End Location";
            endLocationDataGridViewTextBoxColumn.MinimumWidth = 6;
            endLocationDataGridViewTextBoxColumn.Name = "endLocationDataGridViewTextBoxColumn";
            endLocationDataGridViewTextBoxColumn.Width = 125;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            startDateDataGridViewTextBoxColumn.HeaderText = "Start Date";
            startDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            startDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            endDateDataGridViewTextBoxColumn.HeaderText = "End Date";
            endDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            endDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // jobBindingSource
            // 
            jobBindingSource.DataSource = typeof(models.Job);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAssistant);
            groupBox2.Controls.Add(btnDriver);
            groupBox2.Controls.Add(btnContainer);
            groupBox2.Controls.Add(btnLorry);
            groupBox2.Controls.Add(btnTransportUnit);
            groupBox2.Location = new Point(577, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(660, 134);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Transport Management";
            // 
            // btnAssistant
            // 
            btnAssistant.Location = new Point(548, 47);
            btnAssistant.Name = "btnAssistant";
            btnAssistant.Size = new Size(97, 40);
            btnAssistant.TabIndex = 6;
            btnAssistant.Text = "Assistants";
            btnAssistant.UseVisualStyleBackColor = true;
            btnAssistant.Click += btnAssistant_Click;
            // 
            // btnDriver
            // 
            btnDriver.Location = new Point(420, 47);
            btnDriver.Name = "btnDriver";
            btnDriver.Size = new Size(97, 40);
            btnDriver.TabIndex = 5;
            btnDriver.Text = "Drivers";
            btnDriver.UseVisualStyleBackColor = true;
            btnDriver.Click += btnDriver_Click;
            // 
            // btnContainer
            // 
            btnContainer.Location = new Point(292, 47);
            btnContainer.Name = "btnContainer";
            btnContainer.Size = new Size(97, 40);
            btnContainer.TabIndex = 4;
            btnContainer.Text = "Containers";
            btnContainer.UseVisualStyleBackColor = true;
            btnContainer.Click += btnContainer_Click;
            // 
            // btnLorry
            // 
            btnLorry.Location = new Point(169, 47);
            btnLorry.Name = "btnLorry";
            btnLorry.Size = new Size(97, 40);
            btnLorry.TabIndex = 3;
            btnLorry.Text = "Lorries";
            btnLorry.UseVisualStyleBackColor = true;
            btnLorry.Click += btnLorry_Click;
            // 
            // btnTransportUnit
            // 
            btnTransportUnit.Location = new Point(16, 47);
            btnTransportUnit.Name = "btnTransportUnit";
            btnTransportUnit.Size = new Size(129, 40);
            btnTransportUnit.TabIndex = 2;
            btnTransportUnit.Text = "Transport Units";
            btnTransportUnit.UseVisualStyleBackColor = true;
            btnTransportUnit.Click += btnTransportUnit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1266, 670);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox2);
            Controls.Add(jobsGridView);
            Controls.Add(groupBox1);
            Name = "AdminDashboard";
            Text = "Admin Dashboard";
            Load += AdminDashboard_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)jobsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)jobBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCustomers;
        private Button btnAdmins;
        private GroupBox groupBox1;
        private DataGridView jobsGridView;
        private GroupBox groupBox2;
        private Button btnTransportUnit;
        private Button btnLorry;
        private Button btnContainer;
        private Button btnDriver;
        private Button btnAssistant;
        private BindingSource jobBindingSource;
        private DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startLocationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endLocationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private PictureBox pictureBox1;
    }
}