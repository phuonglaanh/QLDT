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
	public partial class PhanQuyen : DevComponents.DotNetBar.OfficeForm
	{
		public PhanQuyen()
		{
			InitializeComponent();
		}
		BaseFunctions<Phanquyen> pq = new BaseFunctions<Phanquyen>();
		private void LoadDL()
		{
			this.dataGridViewChucNang.DataSource = pq.PhanQuyen_Get();
			this.dataGridViewMenuPQ.DataSource = pq.MenuPQ_Get();
		}

		private void PhanQuyen_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'qLCuaHangDienThoaiDataSet.TaiKhoan' table. You can move, or remove it, as needed.
			//this.taiKhoanTableAdapter.Fill(this.qLCuaHangDienThoaiDataSet.TaiKhoan);
			dataGridViewChucNang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewMenuPQ.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			LoadDL();
			
		}
	}
}