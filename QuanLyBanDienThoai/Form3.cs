using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace QuanLyBanDienThoai
{
	public partial class FormDangNhap : Form
	{
		public FormDangNhap()
		{
			InitializeComponent();
		}

		public static string TenTaiKhoan = "";

		public string MaHoa(string key, string toEncrypt)//thêm mã hóa vào, ko cần giải mã
		{
			byte[] keyArray;
			byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
			MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			TripleDESCryptoServiceProvider tdes =
			new TripleDESCryptoServiceProvider();
			tdes.Key = keyArray;
			tdes.Mode = CipherMode.ECB;
			tdes.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tdes.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(
				toEncryptArray, 0, toEncryptArray.Length);
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		TaiKhoan tk = new TaiKhoan();

		private void buttonDangNhap_Click(object sender, EventArgs e)
		{
			if(textBoxTenTK.Text.Length == 0 || textBoxMatKhau.Text.Length == 0)
			{
				MessageBox.Show("Bạn chưa nhập tên hoặc mật khẩu");
			}
			else
			{
				int count = tk.DangNhap(textBoxTenTK.Text, MaHoa("Trandong", textBoxMatKhau.Text)).Rows.Count;
				int n = tk.DangNhap(textBoxTenTK.Text, textBoxMatKhau.Text).Rows.Count;
				if (n == 0)
				{
					MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
				}
				else
				{
					//TenTaiKhoan = tk.DangNhap(textBoxTenTK.Text, MaHoa("Trandong", textBoxMatKhau.Text)).Rows[0][1].ToString();
					TenTaiKhoan = tk.DangNhap(textBoxTenTK.Text, textBoxMatKhau.Text).Rows[0][1].ToString();
					MessageBox.Show("Bạn đã đăng nhập thành công!");
					this.Close();
				}
			}
		}

		private void FormDangNhap_Load(object sender, EventArgs e)
		{
			textBoxTenTK.Focus();
		}

		private void textBoxTenTK_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) textBoxMatKhau.Focus();
		}

		private void textBoxMatKhau_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) buttonDangNhap_Click(sender, e);
		}
	}
}
