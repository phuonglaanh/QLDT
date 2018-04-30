using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DataAccess;

namespace QuanLyBanDienThoai
{
	public partial class NguoiDung : DevComponents.DotNetBar.OfficeForm
	{
		public NguoiDung()
		{
			InitializeComponent();
		}

		BaseFunctions<TaiKhoan> nd = new BaseFunctions<TaiKhoan>();

		private void HienThiDuLieu()
		{
			dataGridViewNguoiDung.DataSource = nd.SelectAll();
		}

		private void NguoiDung_Load(object sender, EventArgs e)
		{
			HienThiDuLieu();
		}

		private void HienThiLenControl()
		{
			if(dataGridViewNguoiDung.SelectedRows.Count > 0)
			{
				textBoxTenTKND.Text = dataGridViewNguoiDung.SelectedRows[0].Cells[0].Value.ToString();
				this.textBoxMatKhauND.Text = dataGridViewNguoiDung.SelectedRows[0].Cells[1].Value.ToString();
			}
		}

		private void dataGridViewNguoiDung_SelectionChanged(object sender, EventArgs e)
		{
			HienThiLenControl();
		}

		private TaiKhoan LayThongTinControl()
		{
			TaiKhoan tk = new TaiKhoan(this.textBoxTenTKND.Text, this.textBoxMatKhauND.Text);
			return tk;
		}

		private void buttonThem_Click(object sender, EventArgs e)
		{
			if(nd.Add(LayThongTinControl()) > 0)
			{
				MessageBox.Show("Thêm thành công!");
				HienThiDuLieu();
			}
			MessageBox.Show("Thêm thất bại!");
		}

		private void buttonSua_Click(object sender, EventArgs e)
		{
			if (nd.Update(LayThongTinControl()) > 0)
			{
				MessageBox.Show("Cập nhật thành công!");
				HienThiDuLieu();
			}
			else
				MessageBox.Show("Cập nhật thất bại!");
		}

		private void buttonXoa_Click(object sender, EventArgs e)
		{
			if (nd.Delete(LayThongTinControl()) > 0 && this.textBoxTenTKND.Text.Length > 0)
			{
				MessageBox.Show("Xóa thành công!");
				HienThiDuLieu();
			}
			else
				MessageBox.Show("Xóa thất bại!");
		}

		private void TimTheoTenTaiKhoan()
		{
			if(this.textBoxTimKiemND.Text.Length > 0)
			{
				List<TaiKhoan> tkTim = new List<TaiKhoan>();
				tkTim = nd.SelectByID("TenTaiKhoan", textBoxTimKiemND.Text);
				this.dataGridViewNguoiDung.DataSource = tkTim;
			}
		}

		private void buttonTimND_Click(object sender, EventArgs e)
		{
			if(radioButtonTenTK.Checked == true)
				TimTheoTenTaiKhoan();
		}
	}
}