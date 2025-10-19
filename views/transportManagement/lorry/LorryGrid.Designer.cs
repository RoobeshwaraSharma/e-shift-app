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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LorryGrid));
            lorryGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            registrationNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            capacityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            lorryBindingSource = new BindingSource(components);
            btnLorry = new Button();
            btnRefresh = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)lorryGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lorryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lorryGridView
            // 
            lorryGridView.AutoGenerateColumns = false;
            lorryGridView.BackgroundColor = SystemColors.ActiveCaption;
            lorryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lorryGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, modelDataGridViewTextBoxColumn, yearDataGridViewTextBoxColumn, registrationNumberDataGridViewTextBoxColumn, capacityDataGridViewTextBoxColumn, Status });
            lorryGridView.DataSource = lorryBindingSource;
            lorryGridView.GridColor = SystemColors.MenuHighlight;
            lorryGridView.Location = new Point(36, 159);
            lorryGridView.Name = "lorryGridView";
            lorryGridView.RowHeadersWidth = 51;
            lorryGridView.Size = new Size(746, 316);
            lorryGridView.TabIndex = 0;
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
            // lorryBindingSource
            // 
            lorryBindingSource.DataSource = typeof(models.Lorry);
            // 
            // btnLorry
            // 
            btnLorry.Location = new Point(547, 77);
            btnLorry.Name = "btnLorry";
            btnLorry.Size = new Size(136, 29);
            btnLorry.TabIndex = 2;
            btnLorry.Text = "Create Lorry";
            btnLorry.UseVisualStyleBackColor = true;
            btnLorry.Click += btnLorry_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(700, 77);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(91, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // LorryGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(814, 496);
            Controls.Add(pictureBox1);
            Controls.Add(btnRefresh);
            Controls.Add(btnLorry);
            Controls.Add(lorryGridView);
            Name = "LorryGrid";
            Text = "Lorry Dashboard";
            Load += LorryGrid_Load;
            ((System.ComponentModel.ISupportInitialize)lorryGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)lorryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}