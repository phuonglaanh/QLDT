USE [QLCuaHangDienThoai]
GO
/****** Object:  StoredProcedure [dbo].[BangGia_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BangGia_DELETE]
    @SoBangGia int
AS
DELETE [BangGia]
WHERE [SoBangGia] = @SoBangGia




GO
/****** Object:  StoredProcedure [dbo].[BangGia_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BangGia_Insert]
    @SoBangGia int output,
	@MaHH int,
    @GiaBan int,
    @NgayApDung date,
    @NgayKetThuc date,
    @GiamGia int
AS
BEGIN
INSERT INTO [BangGia]
(
    [MaHH],
    [GiaBan],
    [NgayApDung],
    [NgayKetThuc],
    [GiamGia]
)
VALUES
(
    @MaHH,
    @GiaBan,
    @NgayApDung,
    @NgayKetThuc,
    @GiamGia
)
SET @SoBangGia = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[BangGia_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BangGia_UPDATE]
    @SoBangGia int,
	@MaHH int,
    @GiaBan int,
    @NgayApDung date,
    @NgayKetThuc date,
    @GiamGia int
AS
BEGIN
UPDATE [BangGia] SET
    [MaHH] = @MaHH,
    [GiaBan] = @GiaBan,
    [NgayApDung] = @NgayApDung,
    [NgayKetThuc] = @NgayKetThuc,
    [GiamGia] = @GiamGia
WHERE [SoBangGia] = @SoBangGia
END



GO
/****** Object:  StoredProcedure [dbo].[BaoHanh_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BaoHanh_DELETE]
    @SoPhieu int
	AS
DELETE [BaoHanh]
WHERE [SoPhieu] = @SoPhieu



GO
/****** Object:  StoredProcedure [dbo].[BaoHanh_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BaoHanh_Insert]
    @SoPhieu int output,
    @MaHH int,
    @SoEmei nvarchar(50),
    @MaKH int,
    @NgayMua date,
    @ThoiGianBaoHanh nvarchar
AS
BEGIN
INSERT INTO [BaoHanh]
(
    [MaHH],
    [SoEmei],
    [MaKH],
    [NgayMua],
    [ThoiGianBaoHanh]
)
VALUES
(
    @MaHH,
    @SoEmei,
    @MaKH,
    @NgayMua,
    @ThoiGianBaoHanh
)
SET @SoPhieu = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[BaoHanh_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BaoHanh_UPDATE]
    @SoPhieu int,
    @MaHH int,
    @SoEmei nvarchar(50),
    @MaKH int,
    @NgayMua date,
    @ThoiGianBaoHanh nvarchar
AS
BEGIN
UPDATE [BaoHanh] SET
    [MaHH] = @MaHH,
    [SoEmei] = @SoEmei,
    [MaKH] = @MaKH,
    [NgayMua] = @NgayMua,
    [ThoiGianBaoHanh] = @ThoiGianBaoHanh
WHERE [SoPhieu] = @SoPhieu
END



GO
/****** Object:  StoredProcedure [dbo].[ChiTietHoaDon_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ChiTietHoaDon_DELETE]
    @SoHoaDon int,
	@MaKH int
	AS
DELETE [ChiTietHoaDon]
WHERE SoHoaDon=@SoHoaDon AND [MaKH] = @MaKH



GO
/****** Object:  StoredProcedure [dbo].[ChiTietHoaDon_INSERT]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ChiTietHoaDon_INSERT]
    @SoHoaDon int,
    @MaKH int,
    @MaHH int,
    @SoLuong int,
    @GiaBan int
AS
BEGIN
INSERT INTO [ChiTietHoaDon]
(
	[SoHoaDon],
    [MaKH],
    [MaHH],
    [SoLuong],
    [GiaBan]
)
VALUES
(
@SoHoaDon,
    @MaKH,
    @MaHH,
    @SoLuong,
    @GiaBan
)
END



GO
/****** Object:  StoredProcedure [dbo].[ChiTietHoaDon_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ChiTietHoaDon_UPDATE]
@SoHoaDon int,
    @MaKH int,
    @MaHH int,
    @SoLuong int,
    @GiaBan int
AS
UPDATE  [ChiTietHoaDon]
SET
	[MaHH]=@MaHH,
    [SoLuong]=@SoLuong,
   [GiaBan]= @GiaBan
WHERE MaKH=@MaKH and SoHoaDon=@SoHoaDon



GO
/****** Object:  StoredProcedure [dbo].[ChiTietNhapHang_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietNhapHang_DELETE]
    @MaPhieuNhap int,
    @MaHH int
	AS
DELETE [ChiTietNhapHang]
WHERE [MaHH] = @MaHH AND [MaPhieuNhap] = @MaPhieuNhap



GO
/****** Object:  StoredProcedure [dbo].[ChiTietNhapHang_INSERT]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietNhapHang_INSERT]
    @MaPhieuNhap int,
    @MaHH int,
    @SoLuong int,
    @DonGia int,
    @ThanhTien float
AS
BEGIN
INSERT INTO [ChiTietNhapHang]
(
    [MaPhieuNhap],
    [MaHH],
    [SoLuong],
    [DonGia],
    [ThanhTien]
)
VALUES
(
    @MaPhieuNhap,
    @MaHH,
    @SoLuong,
    @DonGia,
    @ThanhTien
)
END



GO
/****** Object:  StoredProcedure [dbo].[ChiTietNhapHang_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietNhapHang_UPDATE]
    @MaPhieuNhap int,
    @MaHH int
	AS
DELETE [ChiTietNhapHang]
WHERE [MaHH] = @MaHH AND [MaPhieuNhap] = @MaPhieuNhap



GO
/****** Object:  StoredProcedure [dbo].[ChiTietTraHang_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietTraHang_DELETE]
    @MaPhieuTra int,
    @MaHH int
	AS
DELETE [ChiTietTraHang]
WHERE [MaHH] = @MaHH AND [MaPhieuTra] = @MaPhieuTra



GO
/****** Object:  StoredProcedure [dbo].[ChiTietTraHang_INSERT]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietTraHang_INSERT]
    @MaPhieuTra int,
    @MaHH int,
    @SoLuong int
AS
BEGIN
INSERT INTO [ChiTietTraHang]
(
    [MaPhieuTra],
    [MaHH],
    [SoLuong]
)
VALUES
(
    @MaPhieuTra,
    @MaHH,
    @SoLuong
)
END



GO
/****** Object:  StoredProcedure [dbo].[ChiTietTraHang_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChiTietTraHang_UPDATE]
    @MaPhieuTra int,
    @MaHH int,
    @SoLuong int
	AS
	UPDATE ChiTietTraHang SET
	 
    [SoLuong]=@SoLuong
	WHERE [MaHH] = @MaHH AND [MaPhieuTra] = @MaPhieuTra



GO
/****** Object:  StoredProcedure [dbo].[DangNhap_Select]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DangNhap_Select]
	@TenTaiKhoan nvarchar(30),
	@MatKhau nvarchar(30)
as
begin
select * from TaiKhoan where TenTaiKhoan = @TenTaiKhoan and MatKhau = @MatKhau
end


GO
/****** Object:  StoredProcedure [dbo].[Find]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[Find]
    @TableName nvarchar(128),
    @ColumnName nvarchar(128),
    @Key nvarchar(128)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(4000)
SET @STMT = 'SELECT * FROM [' + @TableName + '] WHERE [' + @ColumnName + '] like ' + '"%'+@Key+'%"'
EXEC (@STMT)





GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[GetAll]
    @TableName nvarchar(128),
    @OrderBy nvarchar(512)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(1000)
SET @STMT = 'SELECT * FROM [' + @TableName + '] ' + @OrderBy
EXEC (@STMT)





GO
/****** Object:  StoredProcedure [dbo].[GetByPage]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[GetByPage]
    @TableName nvarchar(128),
    @FieldList nvarchar(512),
    @Filter nvarchar(1000),
    @OrderBy nvarchar(512),
    @PageNum int,
    @PageSize int,
    @PageCount int
AS
SET NOCOUNT ON

IF @PageCount <= 0
   RETURN

IF @PageNum < 1 OR @PageNum > @PageCount
   RETURN

IF @FieldList = '' SET @FieldList = '*'

DECLARE @STMT nvarchar(4000)

IF @PageCount > 1
BEGIN
   DECLARE @Max int,
           @Min int

   SET @Min = (@PageNum - 1) * @PageSize
   SET @Max = @Min + @PageSize

   SET @STMT =
     'SELECT ' + @FieldList
   + ' FROM'
   + ' ( SELECT TOP ' + CONVERT(varchar(10), @Max) + ' ROW_NUMBER() OVER(' + @OrderBy + ')'
   + ' AS row, * FROM [' + @TableName + '] ' + @Filter
   + ' ) AS tbl'
   + ' WHERE row >= ' + CONVERT(varchar(10), @Min + 1) 
   + ' AND row <= '   + CONVERT(varchar(10), @Max)
END
ELSE
   SET @STMT = 'SELECT ' + @FieldList + ' FROM [' + @TableName + '] ' + @Filter +  ' ' + @OrderBy

EXEC (@STMT)





GO
/****** Object:  StoredProcedure [dbo].[HangHoa_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[HangHoa_Delete]
    @MaHH int
AS
DELETE [HangHoa]
WHERE [MaHH] = @MaHH



GO
/****** Object:  StoredProcedure [dbo].[HangHoa_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HangHoa_GetAll]
as
begin
select * from HangHoa order by TenHH
end


GO
/****** Object:  StoredProcedure [dbo].[HangHoa_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[HangHoa_Insert]
    @MaHH int output,
    @TenHH nvarchar(100),
    @SoLuong int,
    @NhaCC nvarchar(50),
	@MaLoai int,
    @DonViTinh char(15),
    @Hinh nvarchar(100),
	@TinhNang nvarchar(100)
AS
BEGIN
INSERT INTO [HangHoa]
(
    [TenHH],
    [SoLuong],
    [NhaCC],
    [MaLoai],
    [DonViTinh],
	[Hinh],
	[TinhNang]
)
VALUES
(
    @TenHH, 
	@SoLuong,
	@NhaCC,
	@MaLoai,
	@DonViTinh,
	@Hinh,
	@TinhNang 
)
SET @MaHH = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[HangHoa_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HangHoa_Update]
    @MaHH int output,
    @TenHH nvarchar(100),
    @SoLuong int,
    @NhaCC nvarchar(50),
	@MaLoai int,
    @DonViTinh char(15),
    @Hinh nvarchar(100),
	@TinhNang nvarchar(100)
AS
BEGIN
UPDATE [HangHoa] SET
    [TenHH] = @TenHH,
    [SoLuong] = @SoLuong,
    [NhaCC] = @NhaCC,
    [MaLoai] = @MaLoai,
    [DonViTinh] = @DonViTinh,
	[Hinh] = @Hinh,
	[TinhNang] = @TinhNang 
where MaHH = @MaHH
END


GO
/****** Object:  StoredProcedure [dbo].[HoaDon_DELETE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HoaDon_DELETE]
    @SoHoaDon int
	AS
DELETE [HoaDon]
WHERE [SoHoaDon] = @SoHoaDon




GO
/****** Object:  StoredProcedure [dbo].[HoaDon_INSERT]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HoaDon_INSERT]
    @SoHoaDon int output,
    @MaNV int,
    @MaKH int,
    @NgayLap date,
    @TongTien float
AS
BEGIN
INSERT INTO [HoaDon]
(
    [MaNV],
    [MaKH],
    [NgayLap],
    [TongTien]
)
VALUES
(
    @MaNV,
    @MaKH,
    @NgayLap,
    @TongTien
)
SET @SoHoaDon = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[HoaDon_UPDATE]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HoaDon_UPDATE]
    @SoHoaDon int,
    @MaNV int,
    @MaKH int,
    @NgayLap date,
    @TongTien float
AS
BEGIN
UPDATE [HoaDon] SET
    [MaNV] = @MaNV,
    [MaKH] = @MaKH,
    [NgayLap] = @NgayLap,
    [TongTien] = @TongTien
WHERE [SoHoaDon] = @SoHoaDon
END



GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KhachHang_Delete]
    @MaKH int
AS
DELETE [KhachHang]
WHERE [MaKH] = @MaKH



GO
/****** Object:  StoredProcedure [dbo].[Khachhang_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Khachhang_GetAll]
as
begin
select * from KhachHang order by TenKH
end




GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KhachHang_Insert]
    @MaKH int output,
    @TenKH nvarchar(50),
    @DiaChi nvarchar(100),
    @SDT char(15),
    @Mail nvarchar(50)
AS
BEGIN
INSERT INTO [KhachHang]
(
    [TenKH],
    [DiaChi],
    [SDT],
    [Mail]
)
VALUES
(
    @TenKH,
    @DiaChi,
    @SDT,
    @Mail
)
SET @MaKH = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[KhachHang_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KhachHang_Update]
    @MaKH int output,
    @TenKH nvarchar(50),
    @DiaChi nvarchar(100),
    @SDT char(15),
    @Mail nvarchar(50)
AS
BEGIN
UPDATE [KhachHang] SET
    [TenKH] = @TenKH,
    [DiaChi] = @DiaChi,
    [SDT] = @SDT,
    [Mail] = @Mail
WHERE [MaKH] = @MaKH
END



GO
/****** Object:  StoredProcedure [dbo].[Loai_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Loai_Delete]
    @MaLoai int
AS
BEGIN
DELETE [Loai]
WHERE [MaLoai] = @MaLoai

END




GO
/****** Object:  StoredProcedure [dbo].[Loai_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Loai_Insert]
    @MaLoai int output,
    @TenLoai nvarchar(30)
AS
BEGIN
INSERT INTO [Loai]
(
    [TenLoai]
)
VALUES
(
    @TenLoai
)
SET @MaLoai = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[Loai_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Loai_Update]
    @MaLoai int output,
    @TenLoai nvarchar(30)
AS
BEGIN
UPDATE [Loai] SET
    [TenLoai] = @TenLoai
WHERE [MaLoai] = @MaLoai
END



GO
/****** Object:  StoredProcedure [dbo].[MenuPQ_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MenuPQ_GetAll]
as
select * from Menu
return 0
GO
/****** Object:  StoredProcedure [dbo].[NhanVien_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhanVien_Delete]
    @MaNV int output
AS
DELETE [NhanVien]
WHERE [MaNV] = @MaNV




GO
/****** Object:  StoredProcedure [dbo].[NhanVien_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhanVien_GetAll]
as
begin
select * from NhanVien order by TenNV
end


GO
/****** Object:  StoredProcedure [dbo].[NhanVien_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhanVien_Insert]
    @MaNV int output,
    @TenNV nvarchar(50),
    @GioiTinh bit,
    @NgaySinh date,
    @SDT char(15),
    @DiaChi nvarchar(100),
    @Mail nvarchar(50),
    @CMND char(15),
    @Hinh nvarchar(100),
    @TinhTrang nvarchar(30),
    @TenTaiKhoan nvarchar(30)
AS
BEGIN
INSERT INTO [NhanVien]
(
    [TenNV],
    [GioiTinh],
    [NgaySinh],
    [SDT],
    [DiaChi],
    [Mail],
    [CMND],
    [Hinh],
    [TinhTrang],
    [TenTaiKhoan]
)
VALUES
(
    @TenNV,
    @GioiTinh,
    @NgaySinh,
    @SDT,
    @DiaChi,
    @Mail,
    @CMND,
    @Hinh,
    @TinhTrang,
    @TenTaiKhoan
)
SET @MaNV = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[NhanVien_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhanVien_Update]
    @MaNV int,
    @TenNV nvarchar(50),
    @GioiTinh bit,
    @NgaySinh date,
    @SDT char(15),
    @DiaChi nvarchar(100),
    @Mail nvarchar(50),
    @CMND char(15),
    @Hinh nvarchar(100),
    @TinhTrang nvarchar(30),
    @TenTaiKhoan nvarchar(30)
AS
BEGIN
UPDATE [NhanVien] SET
    [TenNV] = @TenNV,
    [GioiTinh] = @GioiTinh,
    [NgaySinh] = @NgaySinh,
    [SDT] = @SDT,
    [DiaChi] = @DiaChi,
    [Mail] = @Mail,
    [CMND] = @CMND,
    [Hinh] = @Hinh,
    [TinhTrang] = @TinhTrang,
    [TenTaiKhoan] = @TenTaiKhoan
WHERE [MaNV] = @MaNV
END



GO
/****** Object:  StoredProcedure [dbo].[NhapHang_Detele]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhapHang_Detele]
    @MaPhieuNhap int
AS
BEGIN
DELETE [NhapHang]
WHERE [MaPhieuNhap] = @MaPhieuNhap
END



GO
/****** Object:  StoredProcedure [dbo].[NhapHang_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NhapHang_Insert]
    @MaPhieuNhap int output,
    @MaNV int,
    @TongSoLuong int,
    @NgayNhap date,
    @NhaCC nvarchar(50),
    @DienThoaiNCC char(15),
    @DiaChiNhaCC nvarchar(100)
AS
BEGIN
INSERT INTO [NhapHang]
(
    [MaNV],
    [TongSoLuong],
    [NgayNhap],
    [NhaCC],
    [DienThoaiNCC],
    [DiaChiNhaCC]
)
VALUES
(
    @MaNV,
    @TongSoLuong,
    @NgayNhap,
    @NhaCC,
    @DienThoaiNCC,
    @DiaChiNhaCC
)
SET @MaPhieuNhap = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[NhapHang_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NhapHang_Update]
    @MaPhieuNhap int,
    @MaNV int,
    @TongSoLuong int,
    @NgayNhap date,
    @NhaCC nvarchar(50),
    @DienThoaiNCC char(15),
    @DiaChiNhaCC nvarchar(100)
AS
BEGIN
UPDATE [NhapHang] SET
    [MaNV] = @MaNV,
    [TongSoLuong] = @TongSoLuong,
    [NgayNhap] = @NgayNhap,
    [NhaCC] = @NhaCC,
    [DienThoaiNCC] = @DienThoaiNCC,
    [DiaChiNhaCC] = @DiaChiNhaCC
WHERE [MaPhieuNhap] = @MaPhieuNhap
END



GO
/****** Object:  StoredProcedure [dbo].[PhanQuyen_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PhanQuyen_Delete]
	@MenuID nchar(10),
	@TenTaiKhoan nvarchar(30)
as
begin
	Delete from PhanQuyen
	where MenuID = @MenuID and TenTaiKhoan = @TenTaiKhoan
end

GO
/****** Object:  StoredProcedure [dbo].[PhanQuyen_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PhanQuyen_GetAll]
as
select * from PhanQuyen
return 0

GO
/****** Object:  StoredProcedure [dbo].[PhanQuyen_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PhanQuyen_Insert]
	@MenuID nchar(10),
	@TenTaiKhoan nvarchar(30),
	@PhanQuyen bit,
	@MatKhau bit,
	@NguoiDung bit,
	@DangXuat bit,
	@HoaDon bit,
	@XemSanPham bit,
	@BaoHanh bit,
	@NhapHang bit,
	@TraHang bit,
	@KhachHang bit,
	@MatHang bit,
	@ThongTinNhanVien bit,
	@BangGia bit,
	@ThongKeDoanhThu bit,
	@ThongKeKhachhang bit,
	@ThongKeMatHang bit
as
set xact_abort on
begin tran
begin try
insert into PhanQuyen
(
	MenuID,
	TenTaiKhoan,
	PhanQuyen,
	MatKhau,
	NguoiDung,
	DangXuat,
	HoaDon,
	XemSanPham,
	BaoHanh,
	NhapHang,
	TraHang,
	KhachHang,
	MatHang,
	ThongTinNhanVien,
	BangGia,
	ThongKeDoanhThu,
	ThongKeKhachhang,
	ThongKeMatHang
)
values
(
	@MenuID,
	@TenTaiKhoan,
	@PhanQuyen,
	@MatKhau,
	@NguoiDung,
	@DangXuat,
	@HoaDon,
	@XemSanPham,
	@BaoHanh,
	@NhapHang,
	@TraHang,
	@KhachHang,
	@MatHang,
	@ThongTinNhanVien,
	@BangGia,
	@ThongKeDoanhThu,
	@ThongKeKhachhang,
	@ThongKeMatHang
)
commit
end try
begin catch
rollback
declare @ErrorMessage varchar(2000)
select @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
raiserror(@ErrorMessage, 16, 1)
end catch

GO
/****** Object:  StoredProcedure [dbo].[PhanQuyen_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PhanQuyen_Update]
	@MenuID nchar(10),
	@TenTaiKhoan nvarchar(30),
	@PhanQuyen bit,
	@MatKhau bit,
	@NguoiDung bit,
	@DangXuat bit,
	@HoaDon bit,
	@XemSanPham bit,
	@BaoHanh bit,
	@NhapHang bit,
	@TraHang bit,
	@KhachHang bit,
	@MatHang bit,
	@ThongTinNhanVien bit,
	@BangGia bit,
	@ThongKeDoanhThu bit,
	@ThongKeKhachhang bit,
	@ThongKeMatHang bit
as
set xact_abort on
begin tran
begin try
update PhanQuyen
	set PhanQuyen = @PhanQuyen,
	MatKhau = @MatKhau,
	NguoiDung = @NguoiDung,
	DangXuat = @DangXuat,
	HoaDon = @HoaDon,
	XemSanPham =  @XemSanPham,
	BaoHanh = @BaoHanh,
	NhapHang = @NhapHang,
	TraHang = @TraHang,
	KhachHang = @KhachHang,
	MatHang = @MatHang,
	ThongTinNhanVien = @ThongTinNhanVien,
	BangGia = @BangGia,
	ThongKeDoanhThu = @ThongKeDoanhThu,
	ThongKeKhachhang = @ThongKeKhachhang,
	ThongKeMatHang = @ThongKeMatHang
	where MenuID = @MenuID and TenTaiKhoan = @TenTaiKhoan
commit
end try
begin catch
rollback
declare @ErrorMessage varchar(2000)
select @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
raiserror(@ErrorMessage, 16, 1)
end catch

GO
/****** Object:  StoredProcedure [dbo].[TaiKhoan_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[TaiKhoan_Delete]
	@TenTaiKhoan nvarchar(30)
as
begin
Delete TaiKhoan
where TenTaiKhoan = @TenTaiKhoan
end
GO
/****** Object:  StoredProcedure [dbo].[TaiKhoan_GetAll]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[TaiKhoan_GetAll]
as
begin
select * from TaiKhoan order by TenTaiKhoan
end
GO
/****** Object:  StoredProcedure [dbo].[TaiKhoan_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[TaiKhoan_Insert]
	@TenTaiKhoan nvarchar(30),
	@MatKhau nvarchar(30)
as
begin
Insert into TaiKhoan
(
	TenTaiKhoan,
	MatKhau
)
values
(
	@TenTaiKhoan,
	@MatKhau
)
end
GO
/****** Object:  StoredProcedure [dbo].[TaiKhoan_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TaiKhoan_Update]
	@TenTaiKhoan nvarchar(30),
	@MatKhau nvarchar(30)
as
begin
update TaiKhoan
set
	MatKhau = @MatKhau
where TenTaiKhoan = @TenTaiKhoan
end
GO
/****** Object:  StoredProcedure [dbo].[TaiKhoanUser]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[TaiKhoanUser]
as
select TenTaiKhoan from TaiKhoan
return 0
GO
/****** Object:  StoredProcedure [dbo].[TotalRowCount]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[TotalRowCount]
    @TableName nvarchar(128),
    @Filter nvarchar(1000)
AS
SET NOCOUNT ON
DECLARE @STMT nvarchar(4000)
SET @STMT = 'SELECT COUNT(1) FROM [' + @TableName + '] ' + @Filter
EXEC (@STMT)





GO
/****** Object:  StoredProcedure [dbo].[TraHang_Delete]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraHang_Delete]
    @MaPhieuTra int
AS
BEGIN
DELETE [TraHang]
WHERE [MaPhieuTra] = @MaPhieuTra

END



GO
/****** Object:  StoredProcedure [dbo].[TraHang_Insert]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraHang_Insert]
    @MaPhieuTra int output,
    @MaNV int,
    @TongSoLuong int,
    @NgayTra date,
    @NhaCC nvarchar(50),
    @DienThoaiNCC char(15),
    @DiaChiNhaCC nvarchar(100)
AS
BEGIN
INSERT INTO [TraHang]
(
    [MaNV],
    [TongSoLuong],
    [NgayTra],
    [NhaCC],
    [DienThoaiNCC],
    [DiaChiNhaCC]
)
VALUES
(
    @MaNV,
    @TongSoLuong,
    @NgayTra,
    @NhaCC,
    @DienThoaiNCC,
    @DiaChiNhaCC
)
SET @MaPhieuTra = @@identity
END



GO
/****** Object:  StoredProcedure [dbo].[TraHang_Update]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraHang_Update]
    @MaPhieuTra int,
    @MaNV int,
    @TongSoLuong int,
    @NgayTra date,
    @NhaCC nvarchar(50),
    @DienThoaiNCC char(15),
    @DiaChiNhaCC nvarchar(100)
AS
BEGIN
UPDATE [TraHang] SET
    [MaNV] = @MaNV,
    [TongSoLuong] = @TongSoLuong,
    [NgayTra] = @NgayTra,
    [NhaCC] = @NhaCC,
    [DienThoaiNCC] = @DienThoaiNCC,
    [DiaChiNhaCC] = @DiaChiNhaCC
WHERE [MaPhieuTra] = @MaPhieuTra
END



GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 5/1/2018 12:30:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[SoBangGia] [int] IDENTITY(1,1) NOT NULL,
	[MaHH] [int] NULL,
	[GiaBan] [int] NOT NULL,
	[NgayApDung] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[GiamGia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SoBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaoHanh]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoHanh](
	[SoPhieu] [int] IDENTITY(1,1) NOT NULL,
	[MaHH] [int] NULL,
	[SoEmei] [nvarchar](50) NULL,
	[MaKH] [int] NULL,
	[NgayMua] [date] NULL,
	[ThoiGianBaoHanh] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[SoHoaDon] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[MaHH] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC,
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietNhapHang]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhapHang](
	[MaPhieuNhap] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[ThanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietTraHang]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTraHang](
	[MaPhieuTra] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuTra] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [int] IDENTITY(1,1) NOT NULL,
	[TenHH] [nvarchar](100) NOT NULL,
	[SoLuong] [int] NULL,
	[NhaCC] [nvarchar](50) NULL,
	[MaLoai] [int] NULL,
	[DonViTinh] [nvarchar](10) NULL,
	[Hinh] [nvarchar](100) NULL,
	[TinhNang] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[SoHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[MaKH] [int] NULL,
	[NgayLap] [date] NULL,
	[TongTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [char](15) NULL,
	[Mail] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [nchar](10) NOT NULL,
	[MenuName] [nvarchar](50) NULL,
 CONSTRAINT [PK__Menu__C99ED250C1FE00DE] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [date] NULL,
	[SDT] [char](15) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Mail] [nvarchar](50) NULL,
	[CMND] [char](15) NULL,
	[Hinh] [nvarchar](100) NULL,
	[TinhTrang] [bit] NULL,
	[TenTaiKhoan] [nvarchar](30) NULL,
 CONSTRAINT [PK__NhanVien__2725D70AE3AC16D6] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhapHang]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhapHang](
	[MaPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[TongSoLuong] [int] NULL,
	[NgayNhap] [date] NULL,
	[NhaCC] [nvarchar](50) NULL,
	[DienThoaiNCC] [char](15) NULL,
	[DiaChiNhaCC] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MenuID] [nchar](10) NOT NULL,
	[TenTaiKhoan] [nvarchar](30) NOT NULL,
	[PhanQuyen] [bit] NULL,
	[MatKhau] [bit] NULL,
	[NguoiDung] [bit] NULL,
	[DangXuat] [bit] NULL,
	[HoaDon] [bit] NULL,
	[XemSanPham] [bit] NULL,
	[BaoHanh] [bit] NULL,
	[NhapHang] [bit] NULL,
	[TraHang] [bit] NULL,
	[KhachHang] [bit] NULL,
	[MatHang] [bit] NULL,
	[ThongTinNhanVien] [bit] NULL,
	[BangGia] [bit] NULL,
	[ThongKeDoanhThu] [bit] NULL,
	[ThongKeKhachhang] [bit] NULL,
	[ThongKeMatHang] [bit] NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC,
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTaiKhoan] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TraHang]    Script Date: 5/1/2018 12:30:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TraHang](
	[MaPhieuTra] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[TongSoLuong] [int] NULL,
	[NgayTra] [date] NULL,
	[NhaCC] [nvarchar](50) NULL,
	[DienThoaiNCC] [char](15) NULL,
	[DiaChiNhaCC] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HangHoa] ON 

INSERT [dbo].[HangHoa] ([MaHH], [TenHH], [SoLuong], [NhaCC], [MaLoai], [DonViTinh], [Hinh], [TinhNang]) VALUES (3, N'a', 1, N'', 2, N'cái       ', N'', N'')
SET IDENTITY_INSERT [dbo].[HangHoa] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Mail]) VALUES (2, N'Lee Minh Phuong', N'DaLat', N'phuong@gmail.co', N'01111111111')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Mail]) VALUES (3, N'Duong Thi Kim Chi', N'DaLat', N'Chi@gmail.com  ', N'01111111111')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT], [Mail]) VALUES (4, N'', N'', N'               ', N'')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (1, N'Iphone')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (2, N'SamSung')
SET IDENTITY_INSERT [dbo].[Loai] OFF
INSERT [dbo].[Menu] ([MenuID], [MenuName]) VALUES (N'a         ', N'a')
INSERT [dbo].[Menu] ([MenuID], [MenuName]) VALUES (N'BC-TK     ', N'Báo cáo thống kê')
INSERT [dbo].[Menu] ([MenuID], [MenuName]) VALUES (N'DM        ', N'Nghiệp vụ')
INSERT [dbo].[Menu] ([MenuID], [MenuName]) VALUES (N'HT        ', N'Hệ thống')
INSERT [dbo].[Menu] ([MenuID], [MenuName]) VALUES (N'NV        ', N'Nghiệp vụ')
INSERT [dbo].[PhanQuyen] ([MenuID], [TenTaiKhoan], [PhanQuyen], [MatKhau], [NguoiDung], [DangXuat], [HoaDon], [XemSanPham], [BaoHanh], [NhapHang], [TraHang], [KhachHang], [MatHang], [ThongTinNhanVien], [BangGia], [ThongKeDoanhThu], [ThongKeKhachhang], [ThongKeMatHang]) VALUES (N'BC-TK     ', N'admin', 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[PhanQuyen] ([MenuID], [TenTaiKhoan], [PhanQuyen], [MatKhau], [NguoiDung], [DangXuat], [HoaDon], [XemSanPham], [BaoHanh], [NhapHang], [TraHang], [KhachHang], [MatHang], [ThongTinNhanVien], [BangGia], [ThongKeDoanhThu], [ThongKeKhachhang], [ThongKeMatHang]) VALUES (N'DM        ', N'admin', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[PhanQuyen] ([MenuID], [TenTaiKhoan], [PhanQuyen], [MatKhau], [NguoiDung], [DangXuat], [HoaDon], [XemSanPham], [BaoHanh], [NhapHang], [TraHang], [KhachHang], [MatHang], [ThongTinNhanVien], [BangGia], [ThongKeDoanhThu], [ThongKeKhachhang], [ThongKeMatHang]) VALUES (N'HT        ', N'admin', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[PhanQuyen] ([MenuID], [TenTaiKhoan], [PhanQuyen], [MatKhau], [NguoiDung], [DangXuat], [HoaDon], [XemSanPham], [BaoHanh], [NhapHang], [TraHang], [KhachHang], [MatHang], [ThongTinNhanVien], [BangGia], [ThongKeDoanhThu], [ThongKeKhachhang], [ThongKeMatHang]) VALUES (N'NV        ', N'admin', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[TaiKhoan] ([TenTaiKhoan], [MatKhau]) VALUES (N'admin', N'admin')
INSERT [dbo].[TaiKhoan] ([TenTaiKhoan], [MatKhau]) VALUES (N'Trandong', N'1234567')
ALTER TABLE [dbo].[BangGia]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[BaoHanh]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[BaoHanh]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([SoHoaDon])
REFERENCES [dbo].[HoaDon] ([SoHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[ChiTietNhapHang]  WITH CHECK ADD FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[NhapHang] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietNhapHang]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietTraHang]  WITH CHECK ADD FOREIGN KEY([MaPhieuTra])
REFERENCES [dbo].[TraHang] ([MaPhieuTra])
GO
ALTER TABLE [dbo].[ChiTietTraHang]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaNV__571DF1D5] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaNV__571DF1D5]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__TenTai__5812160E] FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTaiKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__TenTai__5812160E]
GO
ALTER TABLE [dbo].[NhapHang]  WITH CHECK ADD  CONSTRAINT [FK__NhapHang__MaNV__59063A47] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NhapHang] CHECK CONSTRAINT [FK__NhapHang__MaNV__59063A47]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_Menu]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_TaiKhoan] FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTaiKhoan])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_TaiKhoan]
GO
ALTER TABLE [dbo].[TraHang]  WITH CHECK ADD  CONSTRAINT [FK__TraHang__MaNV__59FA5E80] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TraHang] CHECK CONSTRAINT [FK__TraHang__MaNV__59FA5E80]
GO
