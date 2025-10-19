namespace e_shift_app.views.transportManagement.Assistant
{
    partial class AssistantGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssistantGrid));
            assistantGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assistantBindingSource = new BindingSource(components);
            btnAddAssistant = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)assistantGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)assistantBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // assistantGridView
            // 
            assistantGridView.AutoGenerateColumns = false;
            assistantGridView.BackgroundColor = SystemColors.ActiveCaption;
            assistantGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            assistantGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Status, nameDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn });
            assistantGridView.DataSource = assistantBindingSource;
            assistantGridView.GridColor = SystemColors.HotTrack;
            assistantGridView.Location = new Point(63, 145);
            assistantGridView.Name = "assistantGridView";
            assistantGridView.RowHeadersWidth = 51;
            assistantGridView.Size = new Size(549, 266);
            assistantGridView.TabIndex = 0;
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
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "Phone Number";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // assistantBindingSource
            // 
            assistantBindingSource.DataSource = typeof(models.Assistant);
            // 
            // btnAddAssistant
            // 
            btnAddAssistant.Location = new Point(482, 57);
            btnAddAssistant.Name = "btnAddAssistant";
            btnAddAssistant.Size = new Size(140, 47);
            btnAddAssistant.TabIndex = 1;
            btnAddAssistant.Text = "Add Assistant";
            btnAddAssistant.UseVisualStyleBackColor = true;
            btnAddAssistant.Click += btnAddAssistant_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // AssistantGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(667, 443);
            Controls.Add(pictureBox1);
            Controls.Add(btnAddAssistant);
            Controls.Add(assistantGridView);
            Name = "AssistantGrid";
            Text = "Assistant Dashboard";
            Load += AssistantGrid_Load;
            ((System.ComponentModel.ISupportInitialize)assistantGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)assistantBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView assistantGridView;
        private BindingSource assistantBindingSource;
        private Button btnAddAssistant;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private PictureBox pictureBox1;
    }
}