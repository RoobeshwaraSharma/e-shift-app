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
            assistantGridView = new DataGridView();
            assistantBindingSource = new BindingSource(components);
            btnAddAssistant = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)assistantGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)assistantBindingSource).BeginInit();
            SuspendLayout();
            // 
            // assistantGridView
            // 
            assistantGridView.AutoGenerateColumns = false;
            assistantGridView.BackgroundColor = SystemColors.GradientInactiveCaption;
            assistantGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            assistantGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, Status, nameDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn });
            assistantGridView.DataSource = assistantBindingSource;
            assistantGridView.GridColor = SystemColors.HotTrack;
            assistantGridView.Location = new Point(48, 74);
            assistantGridView.Name = "assistantGridView";
            assistantGridView.RowHeadersWidth = 51;
            assistantGridView.Size = new Size(493, 253);
            assistantGridView.TabIndex = 0;
            // 
            // assistantBindingSource
            // 
            assistantBindingSource.DataSource = typeof(models.Assistant);
            // 
            // btnAddAssistant
            // 
            btnAddAssistant.Location = new Point(463, 31);
            btnAddAssistant.Name = "btnAddAssistant";
            btnAddAssistant.Size = new Size(114, 29);
            btnAddAssistant.TabIndex = 1;
            btnAddAssistant.Text = "Add Assistant";
            btnAddAssistant.UseVisualStyleBackColor = true;
            btnAddAssistant.Click += btnAddAssistant_Click;
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
            // AssistantGrid
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 361);
            Controls.Add(btnAddAssistant);
            Controls.Add(assistantGridView);
            Name = "AssistantGrid";
            Text = "Assistant Dashboard";
            Load += AssistantGrid_Load;
            ((System.ComponentModel.ISupportInitialize)assistantGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)assistantBindingSource).EndInit();
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
    }
}