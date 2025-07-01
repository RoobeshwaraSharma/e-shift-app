namespace e_shift_app.views.transportManagement.transportUnit
{
    partial class TransportUnitGrid
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
            transportUnitGridView = new DataGridView();
            transportUnitBindingSource = new BindingSource(components);
            btnAddTransportUnit = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            lorryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            LorryNumber = new DataGridViewTextBoxColumn();
            driverIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DriverName = new DataGridViewTextBoxColumn();
            assistantIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            AssistantName = new DataGridViewTextBoxColumn();
            containerIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ContainerCapacity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)transportUnitGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transportUnitBindingSource).BeginInit();
            SuspendLayout();
            // 
            // transportUnitGridView
            // 
            transportUnitGridView.AutoGenerateColumns = false;
            transportUnitGridView.BackgroundColor = SystemColors.GradientInactiveCaption;
            transportUnitGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transportUnitGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Status, lorryIdDataGridViewTextBoxColumn, LorryNumber, driverIdDataGridViewTextBoxColumn, DriverName, assistantIdDataGridViewTextBoxColumn, AssistantName, containerIdDataGridViewTextBoxColumn, ContainerCapacity });
            transportUnitGridView.DataSource = transportUnitBindingSource;
            transportUnitGridView.GridColor = SystemColors.HotTrack;
            transportUnitGridView.Location = new Point(22, 100);
            transportUnitGridView.Name = "transportUnitGridView";
            transportUnitGridView.RowHeadersWidth = 51;
            transportUnitGridView.Size = new Size(1263, 359);
            transportUnitGridView.TabIndex = 0;
            // 
            // transportUnitBindingSource
            // 
            transportUnitBindingSource.DataSource = typeof(models.TransportUnit);
            // 
            // btnAddTransportUnit
            // 
            btnAddTransportUnit.Location = new Point(1133, 42);
            btnAddTransportUnit.Name = "btnAddTransportUnit";
            btnAddTransportUnit.Size = new Size(152, 29);
            btnAddTransportUnit.TabIndex = 1;
            btnAddTransportUnit.Text = "Add Transport Unit";
            btnAddTransportUnit.UseVisualStyleBackColor = true;
            btnAddTransportUnit.Click += btnAddTransportUnit_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.Frozen = true;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            idDataGridViewTextBoxColumn.Width = 80;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // lorryIdDataGridViewTextBoxColumn
            // 
            lorryIdDataGridViewTextBoxColumn.DataPropertyName = "LorryId";
            lorryIdDataGridViewTextBoxColumn.HeaderText = "Lorry Id";
            lorryIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            lorryIdDataGridViewTextBoxColumn.Name = "lorryIdDataGridViewTextBoxColumn";
            lorryIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // LorryNumber
            // 
            LorryNumber.HeaderText = "Lorry Number";
            LorryNumber.MinimumWidth = 6;
            LorryNumber.Name = "LorryNumber";
            LorryNumber.Width = 125;
            // 
            // driverIdDataGridViewTextBoxColumn
            // 
            driverIdDataGridViewTextBoxColumn.DataPropertyName = "DriverId";
            driverIdDataGridViewTextBoxColumn.HeaderText = "Driver Id";
            driverIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            driverIdDataGridViewTextBoxColumn.Name = "driverIdDataGridViewTextBoxColumn";
            driverIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // DriverName
            // 
            DriverName.HeaderText = "Driver Name";
            DriverName.MinimumWidth = 6;
            DriverName.Name = "DriverName";
            DriverName.Width = 125;
            // 
            // assistantIdDataGridViewTextBoxColumn
            // 
            assistantIdDataGridViewTextBoxColumn.DataPropertyName = "AssistantId";
            assistantIdDataGridViewTextBoxColumn.HeaderText = "Assistant Id";
            assistantIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            assistantIdDataGridViewTextBoxColumn.Name = "assistantIdDataGridViewTextBoxColumn";
            assistantIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // AssistantName
            // 
            AssistantName.HeaderText = "Assistant Name";
            AssistantName.MinimumWidth = 6;
            AssistantName.Name = "AssistantName";
            AssistantName.Width = 125;
            // 
            // containerIdDataGridViewTextBoxColumn
            // 
            containerIdDataGridViewTextBoxColumn.DataPropertyName = "ContainerId";
            containerIdDataGridViewTextBoxColumn.HeaderText = "Container Id";
            containerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            containerIdDataGridViewTextBoxColumn.Name = "containerIdDataGridViewTextBoxColumn";
            containerIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // ContainerCapacity
            // 
            ContainerCapacity.HeaderText = "Container Capacity";
            ContainerCapacity.MinimumWidth = 6;
            ContainerCapacity.Name = "ContainerCapacity";
            ContainerCapacity.Width = 125;
            // 
            // TransportUnitGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 485);
            Controls.Add(btnAddTransportUnit);
            Controls.Add(transportUnitGridView);
            Name = "TransportUnitGrid";
            Text = "TransportUnit Dashboard";
            Load += TransportUnitGrid_Load;
            ((System.ComponentModel.ISupportInitialize)transportUnitGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)transportUnitBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView transportUnitGridView;
        private BindingSource transportUnitBindingSource;
        private Button btnAddTransportUnit;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn lorryIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn LorryNumber;
        private DataGridViewTextBoxColumn driverIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DriverName;
        private DataGridViewTextBoxColumn assistantIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AssistantName;
        private DataGridViewTextBoxColumn containerIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ContainerCapacity;
    }
}