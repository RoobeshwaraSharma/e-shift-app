namespace e_shift_app.views.customer
{
    partial class CustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboard));
            button1 = new Button();
            jobsGridView = new DataGridView();
            JobId = new DataGridViewTextBoxColumn();
            StartLocation = new DataGridViewTextBoxColumn();
            EndLocation = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jobBindingSource = new BindingSource(components);
            btnRefresh = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)jobsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jobBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(841, 48);
            button1.Name = "button1";
            button1.Size = new Size(149, 48);
            button1.TabIndex = 0;
            button1.Text = "Create Job";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // jobsGridView
            // 
            jobsGridView.AutoGenerateColumns = false;
            jobsGridView.BackgroundColor = SystemColors.ActiveCaption;
            jobsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jobsGridView.Columns.AddRange(new DataGridViewColumn[] { JobId, StartLocation, EndLocation, StartDate, EndDate, statusDataGridViewTextBoxColumn });
            jobsGridView.DataSource = jobBindingSource;
            jobsGridView.Location = new Point(36, 142);
            jobsGridView.Name = "jobsGridView";
            jobsGridView.RowHeadersWidth = 51;
            jobsGridView.Size = new Size(1133, 404);
            jobsGridView.TabIndex = 1;
            // 
            // JobId
            // 
            JobId.DataPropertyName = "JobId";
            JobId.HeaderText = "Job Id";
            JobId.MinimumWidth = 6;
            JobId.Name = "JobId";
            JobId.ReadOnly = true;
            JobId.Width = 125;
            // 
            // StartLocation
            // 
            StartLocation.DataPropertyName = "StartLocation";
            StartLocation.HeaderText = "Start Location";
            StartLocation.MinimumWidth = 6;
            StartLocation.Name = "StartLocation";
            StartLocation.ReadOnly = true;
            StartLocation.Width = 125;
            // 
            // EndLocation
            // 
            EndLocation.DataPropertyName = "EndLocation";
            EndLocation.HeaderText = "End Location";
            EndLocation.MinimumWidth = 6;
            EndLocation.Name = "EndLocation";
            EndLocation.ReadOnly = true;
            EndLocation.Width = 125;
            // 
            // StartDate
            // 
            StartDate.DataPropertyName = "StartDate";
            StartDate.HeaderText = "Start Date";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            StartDate.ReadOnly = true;
            StartDate.Width = 125;
            // 
            // EndDate
            // 
            EndDate.DataPropertyName = "EndDate";
            EndDate.HeaderText = "End Date";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            EndDate.ReadOnly = true;
            EndDate.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // jobBindingSource
            // 
            jobBindingSource.DataSource = typeof(models.Job);
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1014, 48);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(155, 48);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(36, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1206, 558);
            Controls.Add(pictureBox1);
            Controls.Add(btnRefresh);
            Controls.Add(jobsGridView);
            Controls.Add(button1);
            Name = "CustomerDashboard";
            Text = "Customer Dashboard";
            Load += CustomerDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)jobsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)jobBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView jobsGridView;
        private BindingSource jobBindingSource;
        private DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startLocationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endLocationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn JobId;
        private DataGridViewTextBoxColumn StartLocation;
        private DataGridViewTextBoxColumn EndLocation;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private Button btnRefresh;
        private PictureBox pictureBox1;
    }
}