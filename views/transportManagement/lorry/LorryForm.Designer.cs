﻿namespace e_shift_app.views.transportManagement.lorry
{
    partial class LorryForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtModel = new TextBox();
            txtRegistrationNumber = new TextBox();
            txtYear = new TextBox();
            nCapacity = new NumericUpDown();
            btnSubmit = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)nCapacity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 79);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 148);
            label3.Name = "label3";
            label3.Size = new Size(147, 20);
            label3.TabIndex = 2;
            label3.Text = "Registration Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 271);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 3;
            label4.Text = "Capacity (KG)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(94, 207);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 4;
            label5.Text = "Year";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(292, 76);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(150, 27);
            txtModel.TabIndex = 5;
            // 
            // txtRegistrationNumber
            // 
            txtRegistrationNumber.Location = new Point(292, 145);
            txtRegistrationNumber.Name = "txtRegistrationNumber";
            txtRegistrationNumber.Size = new Size(150, 27);
            txtRegistrationNumber.TabIndex = 6;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(292, 204);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(150, 27);
            txtYear.TabIndex = 7;
            // 
            // nCapacity
            // 
            nCapacity.DecimalPlaces = 1;
            nCapacity.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nCapacity.Location = new Point(292, 269);
            nCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nCapacity.Name = "nCapacity";
            nCapacity.Size = new Size(150, 27);
            nCapacity.TabIndex = 9;
            nCapacity.ThousandsSeparator = true;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(178, 355);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(338, 355);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // LorryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 455);
            Controls.Add(btnReset);
            Controls.Add(btnSubmit);
            Controls.Add(nCapacity);
            Controls.Add(txtYear);
            Controls.Add(txtRegistrationNumber);
            Controls.Add(txtModel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LorryForm";
            Text = "Lorry Form";
            ((System.ComponentModel.ISupportInitialize)nCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtModel;
        private TextBox txtRegistrationNumber;
        private TextBox txtYear;
        private NumericUpDown nCapacity;
        private Button btnSubmit;
        private Button btnReset;
    }
}