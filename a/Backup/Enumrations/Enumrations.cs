using System;

namespace DataAccess
{
    public enum DataProviderAction
    {
        Insert, Update, Delete
    }
    public enum Table
    {
        BangGia,
        BaoHanh,
        ChiTietHoaDon,
        ChiTietNhapHang,
        ChiTietTraHang,
        HangHoa,
        HoaDon,
        KhachHang,
        Loai,
        NhanVien,
        NhapHang,
        TaiKhoan,
        TraHang,
    }
    public enum TableBangGia
    {
        SoBangGia,
        MaHH,
        GiaBan,
        NgayApDung,
        NgayKetThuc,
        GiamGia,
    }
    public enum TableBaoHanh
    {
        SoPhieu,
        MaHH,
        SoEmei,
        MaKH,
        NgayMua,
        ThoiGianBaoHanh,
    }
    public enum TableChiTietHoaDon
    {
        MaKH,
        MaHH,
        SoLuong,
        GiaBan,
    }
    public enum TableChiTietNhapHang
    {
        MaPhieuNhap,
        MaHH,
        SoLuong,
        DonGia,
        ThanhTien,
    }
    public enum TableChiTietTraHang
    {
        MaPhieuTra,
        MaHH,
        SoLuong,
    }
    public enum TableHangHoa
    {
        MaHH,
        TenHH,
        SoLuong,
        NhaCC,
        MaLoai,
        DonViTinh,
        Hinh,
        TinhNang,
    }
    public enum TableHoaDon
    {
        SoHoaDon,
        MaNV,
        MaKH,
        NgayLap,
        TongTien,
    }
    public enum TableKhachHang
    {
        MaKH,
        TenKH,
        DiaChi,
        SDT,
        Mail,
    }
    public enum TableLoai
    {
        MaLoai,
        TenLoai,
    }
    public enum TableNhanVien
    {
        MaNV,
        TenNV,
        GioiTinh,
        NgaySinh,
        SDT,
        DiaChi,
        Mail,
        CMND,
        Hinh,
        TinhTrang,
        TenTaiKhoan,
    }
    public enum TableNhapHang
    {
        MaPhieuNhap,
        MaNV,
        TongSoLuong,
        NgayNhap,
        NhaCC,
        DienThoaiNCC,
        DiaChiNhaCC,
    }
    public enum TableTaiKhoan
    {
        TenTaiKhoan,
        MatKhau,
        ChucNang,
        Quyen,
    }
    public enum TableTraHang
    {
        MaPhieuTra,
        MaNV,
        TongSoLuong,
        NgayTra,
        NhaCC,
        DienThoaiNCC,
        DiaChiNhaCC,
    }

}
