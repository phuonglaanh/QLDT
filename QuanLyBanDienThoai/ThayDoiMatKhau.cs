using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyBanDienThoai
{
	public partial class ThayDoiMatKhau : DevComponents.DotNetBar.OfficeForm
	{
		public ThayDoiMatKhau()
		{
			InitializeComponent();
		}

		private void buttonLuu_Click(object sender, EventArgs e)
		{
			if (textBoxMatKhauHienTai.Text == "") MessageBox.Show("Bạn chưa nhập mật khẩu hiện tại!");
			if (textBoxMatKhauMoi.Text == "") MessageBox.Show("Bạn chưa nhập mật khẩu mới!");
			if (textBoxXacNhanMatKhauMoi.Text == "") MessageBox.Show("Bạn chưa nhập lại mật khẩu mới!");
			if (textBoxMatKhauMoi.Text != textBoxXacNhanMatKhauMoi.Text) MessageBox.Show("Mật khẩu không khớp!"); 
		}
	}
}