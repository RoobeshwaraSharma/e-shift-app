namespace e_shift_app.views.job
{
    partial class JobForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobForm));
            label1 = new Label();
            txtStartLocationAddress = new TextBox();
            label2 = new Label();
            txtEndLocationAddress = new TextBox();
            dtpStart = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            dtpEnd = new DateTimePicker();
            btnSubmit = new Button();
            btnReset = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(241, 139);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 0;
            label1.Text = "Start Location Address";
            // 
            // txtStartLocationAddress
            // 
            txtStartLocationAddress.Location = new Point(487, 106);
            txtStartLocationAddress.Multiline = true;
            txtStartLocationAddress.Name = "txtStartLocationAddress";
            txtStartLocationAddress.Size = new Size(225, 79);
            txtStartLocationAddress.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 246);
            label2.Name = "label2";
            label2.Size = new Size(203, 20);
            label2.TabIndex = 2;
            label2.Text = "Destination Location Address";
            label2.Click += label2_Click;
            // 
            // txtEndLocationAddress
            // 
            txtEndLocationAddress.Location = new Point(487, 216);
            txtEndLocationAddress.Multiline = true;
            txtEndLocationAddress.Name = "txtEndLocationAddress";
            txtEndLocationAddress.Size = new Size(225, 77);
            txtEndLocationAddress.TabIndex = 3;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(483, 329);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 4;
            dtpStart.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 336);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 5;
            label3.Text = "Pickup Date";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(241, 405);
            label4.Name = "label4";
            label4.Size = new Size(164, 20);
            label4.TabIndex = 6;
            label4.Text = "Expected Delivery Date";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(483, 400);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 7;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(462, 512);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(627, 512);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(31, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // JobForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(829, 640);
            Controls.Add(pictureBox1);
            Controls.Add(btnReset);
            Controls.Add(btnSubmit);
            Controls.Add(dtpEnd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtpStart);
            Controls.Add(txtEndLocationAddress);
            Controls.Add(label2);
            Controls.Add(txtStartLocationAddress);
            Controls.Add(label1);
            Name = "JobForm";
            Text = "Job Form";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtStartLocationAddress;
        private Label label2;
        private TextBox txtEndLocationAddress;
        private DateTimePicker dtpStart;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpEnd;
        private Button btnSubmit;
        private Button btnReset;
        private PictureBox pictureBox1;
    }
}