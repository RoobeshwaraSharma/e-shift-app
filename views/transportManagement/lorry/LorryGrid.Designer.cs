namespace e_shift_app.views.transportManagement.lorry
{
    partial class LorryGrid
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
            lorryGridView = new DataGridView();
            lorryBindingSource = new BindingSource(components);
            btnLorry = new Button();
            btnRefresh = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            registrationNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            capacityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)lorryGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lorryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lorryGridView
            // 
            lorryGridView.AutoGenerateColumns = false;
            lorryGridView.BackgroundColor = SystemColors.ButtonFace;
            lorryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lorryGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, modelDataGridViewTextBoxColumn, yearDataGridViewTextBoxColumn, registrationNumberDataGridViewTextBoxColumn, capacityDataGridViewTextBoxColumn, Status });
            lorryGridView.DataSource = lorryBindingSource;
            lorryGridView.GridColor = SystemColors.MenuHighlight;
            lorryGridView.Location = new Point(36, 65);
            lorryGridView.Name = "lorryGridView";
            lorryGridView.RowHeadersWidth = 51;
            lorryGridView.Size = new Size(746, 316);
            lorryGridView.TabIndex = 0;
            // 
            // lorryBindingSource
            // 
            lorryBindingSource.DataSource = typeof(models.Lorry);
            // 
            // btnLorry
            // 
            btnLorry.Location = new Point(538, 21);
            btnLorry.Name = "btnLorry";
            btnLorry.Size = new Size(136, 29);
            btnLorry.TabIndex = 2;
            btnLorry.Text = "Create Lorry";
            btnLorry.UseVisualStyleBackColor = true;
            btnLorry.Click += btnLorry_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(691, 21);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(91, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.Frozen = true;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 80;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            modelDataGridViewTextBoxColumn.HeaderText = "Model";
            modelDataGridViewTextBoxColumn.MinimumWidth = 6;
            modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            modelDataGridViewTextBoxColumn.Width = 125;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            yearDataGridViewTextBoxColumn.HeaderText = "Year";
            yearDataGridViewTextBoxColumn.MinimumWidth = 6;
            yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            yearDataGridViewTextBoxColumn.Width = 125;
            // 
            // registrationNumberDataGridViewTextBoxColumn
            // 
            registrationNumberDataGridViewTextBoxColumn.DataPropertyName = "RegistrationNumber";
            registrationNumberDataGridViewTextBoxColumn.HeaderText = "Registration Number";
            registrationNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            registrationNumberDataGridViewTextBoxColumn.Name = "registrationNumberDataGridViewTextBoxColumn";
            registrationNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // capacityDataGridViewTextBoxColumn
            // 
            capacityDataGridViewTextBoxColumn.DataPropertyName = "Capacity";
            capacityDataGridViewTextBoxColumn.HeaderText = "Capacity (KG)";
            capacityDataGridViewTextBoxColumn.MinimumWidth = 6;
            capacityDataGridViewTextBoxColumn.Name = "capacityDataGridViewTextBoxColumn";
            capacityDataGridViewTextBoxColumn.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // LorryGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 402);
            Controls.Add(btnRefresh);
            Controls.Add(btnLorry);
            Controls.Add(lorryGridView);
            Name = "LorryGrid";
            Text = "LorryGrid";
            Load += LorryGrid_Load;
            ((System.ComponentModel.ISupportInitialize)lorryGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)lorryBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView lorryGridView;
        private BindingSource lorryBindingSource;
        private Button btnLorry;
        private Button btnRefresh;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn registrationNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn capacityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Status;
    }
}