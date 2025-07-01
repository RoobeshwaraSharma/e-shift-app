namespace e_shift_app.views.transportManagement.container
{
    partial class ContainerGrid
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
            containerGridView = new DataGridView();
            containerBindingSource = new BindingSource(components);
            btnAddContainer = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            capacityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)containerGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)containerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // containerGridView
            // 
            containerGridView.AutoGenerateColumns = false;
            containerGridView.BackgroundColor = SystemColors.GradientInactiveCaption;
            containerGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            containerGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Status, capacityDataGridViewTextBoxColumn });
            containerGridView.DataSource = containerBindingSource;
            containerGridView.GridColor = SystemColors.HotTrack;
            containerGridView.Location = new Point(53, 75);
            containerGridView.Name = "containerGridView";
            containerGridView.RowHeadersWidth = 51;
            containerGridView.Size = new Size(419, 187);
            containerGridView.TabIndex = 0;
            // 
            // containerBindingSource
            // 
            containerBindingSource.DataSource = typeof(models.Container);
            // 
            // btnAddContainer
            // 
            btnAddContainer.Location = new Point(343, 27);
            btnAddContainer.Name = "btnAddContainer";
            btnAddContainer.Size = new Size(147, 29);
            btnAddContainer.TabIndex = 1;
            btnAddContainer.Text = "Add Container";
            btnAddContainer.UseVisualStyleBackColor = true;
            btnAddContainer.Click += btnAddContainer_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // capacityDataGridViewTextBoxColumn
            // 
            capacityDataGridViewTextBoxColumn.DataPropertyName = "Capacity";
            capacityDataGridViewTextBoxColumn.HeaderText = "Capacity (KG)";
            capacityDataGridViewTextBoxColumn.MinimumWidth = 6;
            capacityDataGridViewTextBoxColumn.Name = "capacityDataGridViewTextBoxColumn";
            capacityDataGridViewTextBoxColumn.Width = 125;
            // 
            // ContainerGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 305);
            Controls.Add(btnAddContainer);
            Controls.Add(containerGridView);
            Name = "ContainerGrid";
            Text = "Container Dashboard";
            Load += ContainerGrid_Load;
            ((System.ComponentModel.ISupportInitialize)containerGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)containerBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView containerGridView;
        private BindingSource containerBindingSource;
        private Button btnAddContainer;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn capacityDataGridViewTextBoxColumn;
    }
}