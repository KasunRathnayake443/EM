
namespace EM
{
    partial class Feedbacks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feedbacks));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ENametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HospitalityCb = new System.Windows.Forms.ComboBox();
            this.PunctualityCb = new System.Windows.Forms.ComboBox();
            this.VenueCb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.Submitbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EventDatecomboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EventId = new System.Windows.Forms.Label();
            this.FeedbacksDGV = new System.Windows.Forms.DataGridView();
            this.EventIdCb = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbacksDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Olive;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 94);
            this.panel1.TabIndex = 42;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage FeedBack";
            // 
            // ENametxt
            // 
            this.ENametxt.Location = new System.Drawing.Point(177, 337);
            this.ENametxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ENametxt.Name = "ENametxt";
            this.ENametxt.Size = new System.Drawing.Size(132, 22);
            this.ENametxt.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "Event Name";
            // 
            // HospitalityCb
            // 
            this.HospitalityCb.FormattingEnabled = true;
            this.HospitalityCb.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "OK",
            "Bad"});
            this.HospitalityCb.Location = new System.Drawing.Point(728, 336);
            this.HospitalityCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HospitalityCb.Name = "HospitalityCb";
            this.HospitalityCb.Size = new System.Drawing.Size(160, 24);
            this.HospitalityCb.TabIndex = 69;
            this.HospitalityCb.SelectedIndexChanged += new System.EventHandler(this.HospitalitycomboBox_SelectedIndexChanged);
            // 
            // PunctualityCb
            // 
            this.PunctualityCb.FormattingEnabled = true;
            this.PunctualityCb.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "OK",
            "Bad"});
            this.PunctualityCb.Location = new System.Drawing.Point(533, 337);
            this.PunctualityCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PunctualityCb.Name = "PunctualityCb";
            this.PunctualityCb.Size = new System.Drawing.Size(160, 24);
            this.PunctualityCb.TabIndex = 68;
            // 
            // VenueCb
            // 
            this.VenueCb.FormattingEnabled = true;
            this.VenueCb.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "OK",
            "Bad"});
            this.VenueCb.Location = new System.Drawing.Point(335, 337);
            this.VenueCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VenueCb.Name = "VenueCb";
            this.VenueCb.Size = new System.Drawing.Size(160, 24);
            this.VenueCb.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(339, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "Venue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(529, 310);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 65;
            this.label6.Text = "Punctuality";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(748, 310);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 64;
            this.label5.Text = "Hospitality";
            // 
            // Resetbtn
            // 
            this.Resetbtn.BackColor = System.Drawing.Color.Olive;
            this.Resetbtn.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resetbtn.Location = new System.Drawing.Point(541, 437);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(100, 28);
            this.Resetbtn.TabIndex = 63;
            this.Resetbtn.Text = "Reset";
            this.Resetbtn.UseVisualStyleBackColor = false;
            // 
            // Submitbtn
            // 
            this.Submitbtn.BackColor = System.Drawing.Color.Olive;
            this.Submitbtn.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submitbtn.Location = new System.Drawing.Point(179, 439);
            this.Submitbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Submitbtn.Name = "Submitbtn";
            this.Submitbtn.Size = new System.Drawing.Size(100, 28);
            this.Submitbtn.TabIndex = 61;
            this.Submitbtn.Text = "Submit";
            this.Submitbtn.UseVisualStyleBackColor = false;
            this.Submitbtn.Click += new System.EventHandler(this.Submitbtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Olive;
            this.panel2.Controls.Add(this.EventDatecomboBox);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox7);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(-3, 485);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 70);
            this.panel2.TabIndex = 72;
            // 
            // EventDatecomboBox
            // 
            this.EventDatecomboBox.FormattingEnabled = true;
            this.EventDatecomboBox.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "OK",
            "Bad"});
            this.EventDatecomboBox.Location = new System.Drawing.Point(239, -140);
            this.EventDatecomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EventDatecomboBox.Name = "EventDatecomboBox";
            this.EventDatecomboBox.Size = new System.Drawing.Size(160, 24);
            this.EventDatecomboBox.TabIndex = 21;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(625, 10);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(423, 12);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(49, 46);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 8;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(733, 11);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(56, 46);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(516, 12);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(56, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(300, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EventId
            // 
            this.EventId.AutoSize = true;
            this.EventId.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventId.Location = new System.Drawing.Point(21, 314);
            this.EventId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EventId.Name = "EventId";
            this.EventId.Size = new System.Drawing.Size(81, 20);
            this.EventId.TabIndex = 73;
            this.EventId.Text = "Event ID";
            // 
            // FeedbacksDGV
            // 
            this.FeedbacksDGV.BackgroundColor = System.Drawing.Color.White;
            this.FeedbacksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FeedbacksDGV.GridColor = System.Drawing.Color.White;
            this.FeedbacksDGV.Location = new System.Drawing.Point(0, 95);
            this.FeedbacksDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FeedbacksDGV.Name = "FeedbacksDGV";
            this.FeedbacksDGV.RowHeadersWidth = 51;
            this.FeedbacksDGV.Size = new System.Drawing.Size(975, 196);
            this.FeedbacksDGV.TabIndex = 75;
            // 
            // EventIdCb
            // 
            this.EventIdCb.FormattingEnabled = true;
            this.EventIdCb.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "OK",
            "Bad"});
            this.EventIdCb.Location = new System.Drawing.Point(-1, 337);
            this.EventIdCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EventIdCb.Name = "EventIdCb";
            this.EventIdCb.Size = new System.Drawing.Size(160, 24);
            this.EventIdCb.TabIndex = 76;
            this.EventIdCb.SelectionChangeCommitted += new System.EventHandler(this.EventIdCb_SelectionChangeCommitted);
            // 
            // Feedbacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 554);
            this.Controls.Add(this.EventIdCb);
            this.Controls.Add(this.FeedbacksDGV);
            this.Controls.Add(this.EventId);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ENametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HospitalityCb);
            this.Controls.Add(this.PunctualityCb);
            this.Controls.Add(this.VenueCb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Resetbtn);
            this.Controls.Add(this.Submitbtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Feedbacks";
            this.Text = "Feedbacks";
            this.Load += new System.EventHandler(this.Feedbacks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbacksDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ENametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox HospitalityCb;
        private System.Windows.Forms.ComboBox PunctualityCb;
        private System.Windows.Forms.ComboBox VenueCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button Submitbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox EventDatecomboBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label EventId;
        private System.Windows.Forms.DataGridView FeedbacksDGV;
        private System.Windows.Forms.ComboBox EventIdCb;
    }
}