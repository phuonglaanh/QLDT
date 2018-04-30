namespace QuanLyBanDienThoai
{
	partial class ThayDoiMatKhau
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxTenDN = new System.Windows.Forms.TextBox();
			this.textBoxMatKhauHienTai = new System.Windows.Forms.TextBox();
			this.textBoxXacNhanMatKhauMoi = new System.Windows.Forms.TextBox();
			this.textBoxMatKhauMoi = new System.Windows.Forms.TextBox();
			this.buttonLuu = new System.Windows.Forms.Button();
			this.buttonNhapLai = new System.Windows.Forms.Button();
			this.buttonQuaylai = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thông tin tài khoản";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Tên đăng nhập";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Mật khẩu hiện tại";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Mật khẩu mới";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 187);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Xác nhận mật khẩu mới";
			// 
			// textBoxTenDN
			// 
			this.textBoxTenDN.Location = new System.Drawing.Point(160, 60);
			this.textBoxTenDN.Name = "textBoxTenDN";
			this.textBoxTenDN.Size = new System.Drawing.Size(217, 20);
			this.textBoxTenDN.TabIndex = 1;
			// 
			// textBoxMatKhauHienTai
			// 
			this.textBoxMatKhauHienTai.Location = new System.Drawing.Point(160, 100);
			this.textBoxMatKhauHienTai.Name = "textBoxMatKhauHienTai";
			this.textBoxMatKhauHienTai.Size = new System.Drawing.Size(217, 20);
			this.textBoxMatKhauHienTai.TabIndex = 1;
			// 
			// textBoxXacNhanMatKhauMoi
			// 
			this.textBoxXacNhanMatKhauMoi.Location = new System.Drawing.Point(160, 184);
			this.textBoxXacNhanMatKhauMoi.Name = "textBoxXacNhanMatKhauMoi";
			this.textBoxXacNhanMatKhauMoi.Size = new System.Drawing.Size(217, 20);
			this.textBoxXacNhanMatKhauMoi.TabIndex = 1;
			// 
			// textBoxMatKhauMoi
			// 
			this.textBoxMatKhauMoi.Location = new System.Drawing.Point(160, 139);
			this.textBoxMatKhauMoi.Name = "textBoxMatKhauMoi";
			this.textBoxMatKhauMoi.Size = new System.Drawing.Size(217, 20);
			this.textBoxMatKhauMoi.TabIndex = 1;
			// 
			// buttonLuu
			// 
			this.buttonLuu.Location = new System.Drawing.Point(27, 239);
			this.buttonLuu.Name = "buttonLuu";
			this.buttonLuu.Size = new System.Drawing.Size(86, 29);
			this.buttonLuu.TabIndex = 2;
			this.buttonLuu.Text = "Lưu";
			this.buttonLuu.UseVisualStyleBackColor = true;
			this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
			// 
			// buttonNhapLai
			// 
			this.buttonNhapLai.Location = new System.Drawing.Point(160, 239);
			this.buttonNhapLai.Name = "buttonNhapLai";
			this.buttonNhapLai.Size = new System.Drawing.Size(86, 29);
			this.buttonNhapLai.TabIndex = 2;
			this.buttonNhapLai.Text = "Nhập lại";
			this.buttonNhapLai.UseVisualStyleBackColor = true;
			// 
			// buttonQuaylai
			// 
			this.buttonQuaylai.Location = new System.Drawing.Point(291, 239);
			this.buttonQuaylai.Name = "buttonQuaylai";
			this.buttonQuaylai.Size = new System.Drawing.Size(86, 29);
			this.buttonQuaylai.TabIndex = 2;
			this.buttonQuaylai.Text = "Quay lại";
			this.buttonQuaylai.UseVisualStyleBackColor = true;
			// 
			// ThayDoiMatKhau
			// 
			this.ClientSize = new System.Drawing.Size(406, 280);
			this.Controls.Add(this.buttonQuaylai);
			this.Controls.Add(this.buttonNhapLai);
			this.Controls.Add(this.buttonLuu);
			this.Controls.Add(this.textBoxMatKhauMoi);
			this.Controls.Add(this.textBoxXacNhanMatKhauMoi);
			this.Controls.Add(this.textBoxMatKhauHienTai);
			this.Controls.Add(this.textBoxTenDN);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.Name = "ThayDoiMatKhau";
			this.Text = "ThayDoiMatKhau";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxTenDN;
		private System.Windows.Forms.TextBox textBoxMatKhauHienTai;
		private System.Windows.Forms.TextBox textBoxXacNhanMatKhauMoi;
		private System.Windows.Forms.TextBox textBoxMatKhauMoi;
		private System.Windows.Forms.Button buttonLuu;
		private System.Windows.Forms.Button buttonNhapLai;
		private System.Windows.Forms.Button buttonQuaylai;
	}
}