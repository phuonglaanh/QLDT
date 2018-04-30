namespace QuanLyBanDienThoai
{
	partial class FormDangNhap
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
			this.buttonHuy = new System.Windows.Forms.Button();
			this.buttonDangNhap = new System.Windows.Forms.Button();
			this.textBoxMatKhau = new System.Windows.Forms.TextBox();
			this.textBoxTenTK = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonHuy
			// 
			this.buttonHuy.Location = new System.Drawing.Point(274, 145);
			this.buttonHuy.Name = "buttonHuy";
			this.buttonHuy.Size = new System.Drawing.Size(75, 23);
			this.buttonHuy.TabIndex = 10;
			this.buttonHuy.Text = "Hủy bỏ";
			this.buttonHuy.UseVisualStyleBackColor = true;
			// 
			// buttonDangNhap
			// 
			this.buttonDangNhap.Location = new System.Drawing.Point(127, 145);
			this.buttonDangNhap.Name = "buttonDangNhap";
			this.buttonDangNhap.Size = new System.Drawing.Size(75, 23);
			this.buttonDangNhap.TabIndex = 11;
			this.buttonDangNhap.Text = "Đăng nhập";
			this.buttonDangNhap.UseVisualStyleBackColor = true;
			this.buttonDangNhap.Click += new System.EventHandler(this.buttonDangNhap_Click);
			// 
			// textBoxMatKhau
			// 
			this.textBoxMatKhau.Location = new System.Drawing.Point(127, 98);
			this.textBoxMatKhau.Name = "textBoxMatKhau";
			this.textBoxMatKhau.Size = new System.Drawing.Size(298, 20);
			this.textBoxMatKhau.TabIndex = 7;
			this.textBoxMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMatKhau_KeyPress);
			// 
			// textBoxTenTK
			// 
			this.textBoxTenTK.Location = new System.Drawing.Point(127, 61);
			this.textBoxTenTK.Name = "textBoxTenTK";
			this.textBoxTenTK.Size = new System.Drawing.Size(298, 20);
			this.textBoxTenTK.TabIndex = 8;
			this.textBoxTenTK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTenTK_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Mật Khẩu:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tên Đăng Nhập:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(151, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(178, 31);
			this.label3.TabIndex = 13;
			this.label3.Text = "ĐĂNG NHẬP";
			// 
			// FormDangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 199);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonHuy);
			this.Controls.Add(this.buttonDangNhap);
			this.Controls.Add(this.textBoxMatKhau);
			this.Controls.Add(this.textBoxTenTK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormDangNhap";
			this.Text = "Đăng nhập";
			this.Load += new System.EventHandler(this.FormDangNhap_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonHuy;
		private System.Windows.Forms.Button buttonDangNhap;
		private System.Windows.Forms.TextBox textBoxMatKhau;
		private System.Windows.Forms.TextBox textBoxTenTK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
	}
}