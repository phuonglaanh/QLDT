namespace QuanLyBanDienThoai
{
	partial class PhanQuyen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxPhanHe = new System.Windows.Forms.GroupBox();
            this.dataGridViewMenuPQ = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTaiKhoan = new System.Windows.Forms.ComboBox();
            this.labelTaiKhoan = new System.Windows.Forms.Label();
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.dataGridViewChucNang = new System.Windows.Forms.DataGridView();
            this.buttonDong = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxPhanHe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuPQ)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChucNang)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxPhanHe);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxChucNang);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 523);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBoxPhanHe
            // 
            this.groupBoxPhanHe.Controls.Add(this.dataGridViewMenuPQ);
            this.groupBoxPhanHe.Location = new System.Drawing.Point(17, 147);
            this.groupBoxPhanHe.Name = "groupBoxPhanHe";
            this.groupBoxPhanHe.Size = new System.Drawing.Size(310, 348);
            this.groupBoxPhanHe.TabIndex = 1;
            this.groupBoxPhanHe.TabStop = false;
            this.groupBoxPhanHe.Text = "Phân hệ";
            // 
            // dataGridViewMenuPQ
            // 
            this.dataGridViewMenuPQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenuPQ.Location = new System.Drawing.Point(20, 48);
            this.dataGridViewMenuPQ.Name = "dataGridViewMenuPQ";
            this.dataGridViewMenuPQ.Size = new System.Drawing.Size(275, 281);
            this.dataGridViewMenuPQ.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTaiKhoan);
            this.groupBox1.Controls.Add(this.labelTaiKhoan);
            this.groupBox1.Location = new System.Drawing.Point(17, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Người sử dụng";
            // 
            // comboBoxTaiKhoan
            // 
            this.comboBoxTaiKhoan.FormattingEnabled = true;
            this.comboBoxTaiKhoan.Location = new System.Drawing.Point(79, 35);
            this.comboBoxTaiKhoan.Name = "comboBoxTaiKhoan";
            this.comboBoxTaiKhoan.Size = new System.Drawing.Size(216, 21);
            this.comboBoxTaiKhoan.TabIndex = 1;
            // 
            // labelTaiKhoan
            // 
            this.labelTaiKhoan.AutoSize = true;
            this.labelTaiKhoan.Location = new System.Drawing.Point(7, 38);
            this.labelTaiKhoan.Name = "labelTaiKhoan";
            this.labelTaiKhoan.Size = new System.Drawing.Size(55, 13);
            this.labelTaiKhoan.TabIndex = 0;
            this.labelTaiKhoan.Text = "Tài khoản";
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.dataGridViewChucNang);
            this.groupBoxChucNang.Location = new System.Drawing.Point(8, 38);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Size = new System.Drawing.Size(682, 456);
            this.groupBoxChucNang.TabIndex = 0;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng";
            // 
            // dataGridViewChucNang
            // 
            this.dataGridViewChucNang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChucNang.Location = new System.Drawing.Point(6, 43);
            this.dataGridViewChucNang.Name = "dataGridViewChucNang";
            this.dataGridViewChucNang.Size = new System.Drawing.Size(676, 394);
            this.dataGridViewChucNang.TabIndex = 0;
            // 
            // buttonDong
            // 
            this.buttonDong.Location = new System.Drawing.Point(430, 544);
            this.buttonDong.Name = "buttonDong";
            this.buttonDong.Size = new System.Drawing.Size(84, 38);
            this.buttonDong.TabIndex = 2;
            this.buttonDong.Text = "Đóng";
            this.buttonDong.UseVisualStyleBackColor = true;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(166, 544);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(84, 38);
            this.buttonLuu.TabIndex = 3;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            // 
            // PhanQuyen
            // 
            this.ClientSize = new System.Drawing.Size(1057, 593);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonDong);
            this.Controls.Add(this.buttonLuu);
            this.DoubleBuffered = true;
            this.Name = "PhanQuyen";
            this.Text = "PhanQuyen";
            this.Load += new System.EventHandler(this.PhanQuyen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxPhanHe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuPQ)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChucNang)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBoxPhanHe;
		private System.Windows.Forms.DataGridView dataGridViewMenuPQ;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBoxTaiKhoan;
		private System.Windows.Forms.Label labelTaiKhoan;
		private System.Windows.Forms.GroupBox groupBoxChucNang;
		private System.Windows.Forms.DataGridView dataGridViewChucNang;
		private System.Windows.Forms.Button buttonDong;
		private System.Windows.Forms.Button buttonLuu;
	}
}