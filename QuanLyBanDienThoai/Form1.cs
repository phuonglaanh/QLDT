using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Core;

namespace QuanLyBanDienThoai
{
	public partial class FormQLCHBanDT : DevComponents.DotNetBar.Office2007RibbonForm
	{
		public FormQLCHBanDT()
		{
			InitializeComponent();
		}

		private void ribbonTabItemQuanLy_Click(object sender, EventArgs e)
		{

		}

		private void tabControlMain_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
		{
			if(MessageBox.Show("Bạn chắc chắn muốn tắt?", "Xác nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				TabItem tabitem = tabControlMain.SelectedTab;
				tabControlMain.Tabs.Remove(tabitem);
			}
			
		}

		private void buttonItemKhachHang_Click(object sender, EventArgs e)
		{
			TabItem tabitem = tabControlMain.SelectedTab;
			tabControlMain.Tabs.Add(tabitem);
		}
		private void addNewTab(String srtTabName, String Name)
		{
			foreach(TabItem tabPage in tabControlMain.Tabs)
				if(tabPage.Text == srtTabName && tabPage.Name == Name)
				{
					tabControlMain.SelectedTab = tabPage;
					return;
				}
		}

		private void buttonItemPhanQuyen_Click(object sender, EventArgs e)
		{
			PhanQuyen fr = new PhanQuyen();
			fr.ShowDialog();
		}

		private void buttonItemNguoiDung_Click(object sender, EventArgs e)
		{
			NguoiDung fr = new NguoiDung();
			fr.ShowDialog();
		}

		private void buttonItemMatKhau_Click(object sender, EventArgs e)
		{
			ThayDoiMatKhau fr = new ThayDoiMatKhau();
			fr.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			FormTinhNang fr = new FormTinhNang();
			fr.ShowDialog();
		}
		//----------------- khách hàng ----------------------------- //
		BaseFunctions<Khachhang> kh = new BaseFunctions<Khachhang>();

		private Khachhang GetInformation()
		{
			int id = (this.maskedTextBoxMaKH.Text.Length == 0) ? 0 : int.Parse(this.maskedTextBoxMaKH.Text);
			Khachhang p = new Khachhang(id, this.textBoxTenKH.Text, this.textBoxDiaChiKH.Text, this.textBoxMailKH.Text,this.maskedTextBoxSDTKhachhang.Text);
			return p;
		}

		private void buttonThemKH_Click(object sender, EventArgs e)
		{
			if (kh.Add(GetInformation()) > 0)
			{
				MessageBox.Show("Add sucessful");
                LoadDataKhachHang();
                ResetKhachHang();
			}
			else
				MessageBox.Show("Add unsucessful");
		}

        private void buttonSuaKH_Click(object sender, EventArgs e)
        {
            if (kh.Update(GetInformation()) > 0)
            {
                MessageBox.Show("Update sucessful");
                LoadDataKhachHang();
                ResetKhachHang();
            }
            else
                MessageBox.Show("Update unsucessful");
        }

        private void LoadDataKhachHang()
        {
            this.dataGridViewKhachHang.DataSource = kh.SelectAll();
        }

        private void groupPanelKhachhang_Click(object sender, EventArgs e)
        {
            LoadDataKhachHang();
        }

        private void FormQLCHBanDT_Load(object sender, EventArgs e)
        {
            LoadDataKhachHang();
			LoadDataNhanVien();
			LoadDataHangHoa();
        }

        private void SetDataConTrolsKhachHang()
        {
            if(dataGridViewKhachHang.SelectedRows.Count > 0)
            {
                this.maskedTextBoxMaKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[0].Value.ToString();
                this.textBoxTenKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[1].Value.ToString();
                this.textBoxDiaChiKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[2].Value.ToString();
                this.maskedTextBoxSDTKhachhang.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[4].Value.ToString();
                this.textBoxMailKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[3].Value.ToString();
            }
           
        }

        private void dataGridViewKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            SetDataConTrolsKhachHang();
        }

        private void buttonXoaKH_Click(object sender, EventArgs e)
        {
            if (this.maskedTextBoxMaKH.Text.Length > 0 && kh.Delete(int.Parse(this.maskedTextBoxMaKH.Text)) > 0)
            {
                MessageBox.Show("Delete sucessful");
                LoadDataKhachHang();
                ResetKhachHang();
            }
            else
                MessageBox.Show("Delete unsucessful");
        }

        private void ResetKhachHang()
        {
            this.maskedTextBoxMaKH.Text = "";
            this.textBoxTenKH.Text = "";
            this.textBoxDiaChiKH.Text = "";
            this.maskedTextBoxSDTKhachhang.Text = "";
            this.textBoxMailKH.Text = "";
        }


        private void buttonTimKH_Click(object sender, EventArgs e)
        {
            if (this.radioButtonMaKH.Checked == true)
                TimKhachHangTheoMa();
            else if (this.radioButtonTenKH.Checked == true)
                TimKhachHangTheoTen();
        }

		private void TimKhachHangTheoMa()
		{
			if (this.textBoxTimKH.Text.Length > 0)
			{
				List<Khachhang> KhTim = new List<Khachhang>();
				int n;
				if (int.TryParse(this.textBoxTimKH.Text, out n))
					KhTim = kh.SelectByID("MaKH", n);
				this.dataGridViewKhachHang.DataSource = KhTim;
			}
		}
		private void TimKhachHangTheoTen()
		{
			if (this.textBoxTimKH.Text.Length > 0)
			{
				List<Khachhang> KhTim = new List<Khachhang>();
				KhTim = kh.SelectByID("TenKH", this.textBoxTimKH.Text);
				this.dataGridViewKhachHang.DataSource = KhTim;
			}
		}

		
		//===================================================================//
		//----------------- Nhân viên --------------------------------------//
		BaseFunctions<NhanVien> nv = new BaseFunctions<NhanVien>();

		private void LoadDataNhanVien()
		{
			this.dataGridViewNhanVien.DataSource = nv.SelectAll();
		}

		

		private void buttonThemNV_Click(object sender, EventArgs e)
		{
			
		}

		// --------------------------- Hàng hóa ---------------------------------//
		BaseFunctions<HangHoa> hh = new BaseFunctions<HangHoa>();

		private void LoadDataHangHoa()
		{
			this.dataGridViewHangHoa.DataSource = hh.SelectAll();
		}
		
		private HangHoa Thongtinhanghoa()
		{
			int id = (this.maskedTextBoxMaHH.Text.Length == 0) ? 0 : int.Parse(this.maskedTextBoxMaHH.Text);
			HangHoa p = new HangHoa(id, this.textBoxTenHH.Text, int.Parse(this.textBoxSoLuongHH.Text), this.textBoxNhaCungCap.Text, int.Parse(this.maskedTextBoxMaLoai.Text), this.textBoxDonViTinhHH.Text, this.textBoxHinhHH.Text, this.comboBoxTinhNang.Text);
			return p;
		}

		private void buttonThemHH_Click(object sender, EventArgs e)
		{
			if(hh.Add(Thongtinhanghoa()) > 0)
			{
				MessageBox.Show("Add sucessful");
				LoadDataHangHoa();
			}
			else
				MessageBox.Show("Add unsucessful");
		}

		private void buttonXoaHH_Click(object sender, EventArgs e)
		{
			if (maskedTextBoxMaHH.Text.Length > 0  && hh.Delete(int.Parse(maskedTextBoxMaHH.Text)) > 0)
			{
				MessageBox.Show("Delete sucessful");
				LoadDataHangHoa();
			}
			else
				MessageBox.Show("Delete unsucessful ");
		}

		private void buttonSuaHH_Click(object sender, EventArgs e)
		{
			if(hh.Update(Thongtinhanghoa()) > 0)
			{
				MessageBox.Show("Update sucessful");
				LoadDataHangHoa();
			}
			MessageBox.Show("Update unsucessful");
		}

		private void TimHangHoaTheoMa()
		{
			if (this.textBoxTimHH.Text.Length > 0)
			{
				List<HangHoa> HHTim = new List<HangHoa>();
				int n;
				if (int.TryParse(this.textBoxTimHH.Text, out n))
					HHTim = hh.SelectByID("MaHH", n);
				this.dataGridViewHangHoa.DataSource = HHTim;
			}
		}

		private void TimHangHoaTheoTen()
		{
			if (this.textBoxTimHH.Text.Length > 0)
			{
				List<HangHoa> HHTim = new List<HangHoa>();
				HHTim = hh.SelectByID("TenHH", this.buttonTimHH.Text);
				this.dataGridViewHangHoa.DataSource = HHTim;
			}
		}

		private void buttonTimHH_Click(object sender, EventArgs e)
		{
			if (radioButtonMaHH.Checked == true)
				TimHangHoaTheoMa();
			else if (radioButtonTenHH.Checked == true)
				TimHangHoaTheoTen();
		}

		private void LayDuLieuHangHoaLen()
		{
			if(dataGridViewHangHoa.SelectedRows.Count > 0)
			{
				this.maskedTextBoxMaHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[0].Value.ToString();
				this.textBoxTenHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[1].Value.ToString();
				this.textBoxSoLuongHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[2].Value.ToString();
				this.textBoxNCCHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[3].Value.ToString();
				this.maskedTextBoxMaLoai.Text = dataGridViewHangHoa.SelectedRows[0].Cells[4].Value.ToString();
				this.textBoxDonViTinhHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[5].Value.ToString();
				this.textBoxHinhHH.Text = dataGridViewHangHoa.SelectedRows[0].Cells[6].Value.ToString();
				this.comboBoxTinhNang.Text = dataGridViewHangHoa.SelectedRows[0].Cells[7].Value.ToString();
			}
		}

		private void dataGridViewHangHoa_SelectionChanged(object sender, EventArgs e)
		{
			LayDuLieuHangHoaLen();
		}
        //----------------Bao Hanh----------------------
        BaseFunctions<BaoHanh> bh = new BaseFunctions<BaoHanh>();


        //private BaoHanh ThongTinBaoHanh()
        //{
        //    int id = 0;
        //    BaoHanh p = new BaoHanh(id, this.textBoxTenSP.Text, this.textBoxSoEmei.Text, this.textBoxKhachHang.Text, this.dateTimePickerNgayMuaBH.Value, this.textBoxThoiGianBaoHanh.Text);
        //    return p;
        //}

        //private void buttonInBaoHanh_Click(object sender, EventArgs e)
        //{
        //    if (bh.Add(ThongTinBaoHanh()) > 0)
        //    {
        //        MessageBox.Show("Add sucessful");
        //    }
        //    else
        //        MessageBox.Show("Add unsucessful");
        //}



        //------------------------- NhapHang------------
        BaseFunctions<NhapHang> nh = new BaseFunctions<NhapHang>();

        //private NhapHang ThongTinNhapHang()
        //{
        //    int id = (this.maskedTextBoxMaPhieuNhap.Text.Length == 0) ? 0 : int.Parse(this.maskedTextBoxMaPhieuNhap.Text);
        //    NhapHang p = new NhapHang(id, this.textBoxTenHH.Text, int.Parse(this.textBoxSoLuongHH.Text), this.textBoxNhaCungCap.Text, int.Parse(this.maskedTextBoxMaLoai.Text), this.textBoxDonViTinhHH.Text, this.textBoxHinhHH.Text, this.comboBoxTinhNang.Text);
        //    return p;
        //}

        private void buttonThanhToanNhapHang_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // -------------------------------------- Hóa đơn --------------------------------//
        //private void ThongTinHangHoa()
        //{

        //   // dataGridViewHoaDon.
        //   // this.dataGridViewHoaDon.SelectedRows[0].Cells[0].Value = ;

        //    this.maskedTextBoxMaKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[0].Value.ToString();
        //        this.textBoxTenKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[1].Value.ToString();
        //        this.textBoxDiaChiKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[2].Value.ToString();
        //        this.maskedTextBoxSDTKhachhang.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[4].Value.ToString();
        //        this.textBoxMailKH.Text = this.dataGridViewKhachHang.SelectedRows[0].Cells[3].Value.ToString();
        //}
    }


}
