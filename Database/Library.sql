CREATE DATABASE QUANLYTHUVIEN
GO
USE QUANLYTHUVIEN
GO

SET DATEFORMAT DMY

CREATE TABLE TAIKHOAN(
	MaTK VARCHAR(255) PRIMARY KEY,
	TK_Username VARCHAR(255),
	TK_Password VARCHAR(255),
	LoaiTK VARCHAR(255)
)

CREATE TABLE THE_DOCGIA(
	MaDG VARCHAR(255) PRIMARY KEY,
	HoTen VARCHAR(255),
	MaTaiKhoan VARCHAR(255) REFERENCES TAIKHOAN(MaTK),
	NgaySinh SMALLDATETIME,
	DiaChi VARCHAR(255),
	Email VARCHAR(255),
	Sdt VARCHAR(255),
	NgayLapTheDocGia SMALLDATETIME,
	NgayHetHan SMALLDATETIME
)

CREATE TABLE THUTHU(
	MaTT VARCHAR(255) PRIMARY KEY,
	HoTen VARCHAR(255),
	MaTaiKhoan VARCHAR(255) REFERENCES TAIKHOAN(MaTK),
	NgayTaoTK SMALLDATETIME,
	NgaySinh SMALLDATETIME,
	DiaChi VARCHAR(255),
	Email VARCHAR(255),
	Sdt VARCHAR(255)
)



CREATE TABLE THELOAI_SACH(
	MaTheLoai VARCHAR(255) PRIMARY KEY,
	TenTheLoai VARCHAR(255)
)

CREATE TABLE SACH(
	MaSach VARCHAR(255) PRIMARY KEY,
	TenSach VARCHAR(255),
	MaTheLoai VARCHAR(255) REFERENCES THELOAI_SACH(MaTheLoai),
	TacGia VARCHAR(255),
	NamXuatBan INT,
	NhaXuatBan VARCHAR(255),
	SoLuong INT,
	GiaSach MONEY
)

CREATE TABLE PHIEU_MUON_SACH(
	MaPhieuMuon VARCHAR(255) PRIMARY KEY,
	MaDG VARCHAR(255) REFERENCES THE_DOCGIA(MaDG),
	MaTT VARCHAR(255) REFERENCES THUTHU(MaTT),
	SoLuongSach INT,
	NgayMuon SMALLDATETIME
)

CREATE TABLE PHIEU_TRA_SACH(
	MaPhieuTra VARCHAR(255)  PRIMARY KEY,
	MaPhieuMuon VARCHAR(255) REFERENCES PHIEU_MUON_SACH(MaPhieuMuon),
	MaDG VARCHAR(255) REFERENCES THE_DOCGIA(MaDG),
	MaTT VARCHAR(255) REFERENCES THUTHU(MaTT),
	NgayTra SMALLDATETIME,
	SoLuongSach INT,
	SoNgayTre INT,
	SoTienPhat MONEY
)

CREATE TABLE CHITIET_MUONTRA(
	MaPhieuMuon VARCHAR(255) REFERENCES PHIEU_MUON_SACH(MaPhieuMuon),
	MaSach VARCHAR(255) REFERENCES SACH(MaSach),
	SoLuong INT,
	CONSTRAINT PK_CTMT PRIMARY KEY (MaPhieuMuon, MaSach)
)

CREATE TABLE PHIEU_THU_TIEN_PHAT(
	MaPhieuPhat VARCHAR(255) PRIMARY KEY,
	MaDG VARCHAR(255) REFERENCES THE_DOCGIA(MaDG),
	TongTienPhat MONEY,
	TienNhanDuoc MONEY,
	TienConLai MONEY,
	NgayTraTien SMALLDATETIME
)


CREATE TABLE QUY_DINH(
	MinAge INT,
	MaxAge INT,
	Thoi_Han_The_Doc_Gia INT,
	So_Nam_Xuat_Ban INT,
	So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian INT,
	So_Ngay_Gioi_Han_So_Luong_Sach_Muon INT,
	Thoi_Han_Muon_Sach INT,
	Phi_Phat_Theo_Mot_Ngay_Tre INT,
)

-------------------------------------------------------------

--TAO TRIGGER

--QD1: TUOI DOC GIA TU 18 DEN 55.

CREATE TRIGGER KiemTraTuoi ON THE_DOCGIA
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @MinAge INT
    DECLARE @MaxAge INT

	SELECT @MinAge = Q.MinAge,
		   @MaxAge = Q.MaxAge
	FROM QUY_DINH Q

    IF EXISTS (
        SELECT 1
        FROM inserted
		--- Lay ngay hom nay tru ngay sinh, ket qua tra ve la so tuoi.
        WHERE DATEDIFF(YEAR, NgaySinh, GETDATE()) < @MinAge OR DATEDIFF(YEAR, NgaySinh, GETDATE()) > @MaxAge
    )
    BEGIN
        PRINT 'Tuoi cua doc gia phai trong gioi han quy dinh'
        ROLLBACK TRANSACTION
    END
END

--QD1: The doc gia co thoi han la vai thang theo quy dinh.
CREATE TRIGGER HSD ON THE_DOCGIA
FOR INSERT
AS
BEGIN
    DECLARE @MaDG VARCHAR(255)
    DECLARE @NgayLapTheDocGia SMALLDATETIME
    DECLARE @NgayHetHan SMALLDATETIME
	DECLARE @ThoiHanThe INT

	SELECT @ThoiHanThe = Q.Thoi_Han_The_Doc_Gia
	FROM QUY_DINH Q

    SELECT @MaDG = inserted.MaDG,
           @NgayLapTheDocGia = inserted.NgayLapTheDocGia
    FROM inserted

    -- Tinh ngay het han
    SET @NgayHetHan = DATEADD(MONTH, @ThoiHanThe, @NgayLapTheDocGia)

    -- Cap nhat ngay het han vao bang THE_DOCGIA
    UPDATE THE_DOCGIA
    SET NgayHetHan = @NgayHetHan
    WHERE MaDG = @MaDG
END

--QD2: CHI NHAN SACH XUAT BAN TRONG VONG VAI NAM THEO QUY DINH.

CREATE TRIGGER KiemTraNamXuatBan ON SACH
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @NamXuatBanCaoNhat INT
    DECLARE @NamXuatBanThapNhat INT
	DECLARE @So_Nam_Xuat_Ban_Quy_Dinh INT

	SELECT @So_Nam_Xuat_Ban_Quy_Dinh = Q.So_Nam_Xuat_Ban
	FROM QUY_DINH Q

    -- Lay nam hien tai
    SET @NamXuatBanCaoNhat = YEAR(GETDATE())
    -- Tinh nam nho nhat duoc phep xuat ban
    SET @NamXuatBanThapNhat = @NamXuatBanCaoNhat - @So_Nam_Xuat_Ban_Quy_Dinh

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE NamXuatBan < @NamXuatBanThapNhat OR NamXuatBan > @NamXuatBanCaoNhat
    )
    BEGIN
        PRINT 'So nam xuat ban cua sach phai trong khoang cho phep'
        ROLLBACK TRANSACTION
    END
END

--QD3: Chi cho muon voi the con han. Chi muon duoc mot so luong sach nhat dinh trong mot thoi gian

CREATE TRIGGER DieuKienMuon ON PHIEU_MUON_SACH
FOR INSERT
AS
BEGIN
    DECLARE @MaxBooksPerMember INT
    DECLARE @MaxDaysToReturn INT
	DECLARE @MaSach VARCHAR(255)

	SELECT @MaxBooksPerMember = Q.So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian,
		   @MaxDaysToReturn = Q.So_Ngay_Gioi_Han_So_Luong_Sach_Muon
	FROM QUY_DINH Q

    -- Kiem tra the doc gia co con han không
    IF EXISTS (
        SELECT 1
        FROM inserted i JOIN THE_DOCGIA dg ON i.MaDG = dg.MaDG
        WHERE NgayHetHan < GETDATE()
    )
    BEGIN
        PRINT 'The doc gia da het han'
        ROLLBACK TRANSACTION
    END

	-- Kiem tra so luong sach muon cua doc gia trong mot khoang thoi gian theo quy dinh
    IF (
        SELECT SUM(SoLuongSach)
        FROM PHIEU_MUON_SACH
        WHERE MaDG = (SELECT MaDG FROM inserted) AND NgayMuon >= DATEADD(DAY, -@MaxDaysToReturn, GETDATE())
    ) >= @MaxBooksPerMember
    BEGIN
        PRINT 'So luong sach muon da vuot muc toi da.'
        ROLLBACK TRANSACTION
    END
END
-- QD5: Moi ngay tra tre phat 1.000 dong/ngay. (Moi sach duoc muon toi da 10 ngay.)
CREATE TRIGGER TinhPhiPhat ON PHIEU_TRA_SACH
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @MaPhieuTra VARCHAR(255)
	DECLARE @MaPhieuMuon VARCHAR(255)
    DECLARE @NgayTra SMALLDATETIME
	DECLARE @NgayMuon SMALLDATETIME
    DECLARE @SoNgayTre INT
    DECLARE @PhiPhat MONEY
	DECLARE @ThoiHanMuonSach INT
	DECLARE @PhiPhatTheoNGay INT


	SELECT @ThoiHanMuonSach = Q.Thoi_Han_Muon_Sach,
		   @PhiPhatTheoNGay = Q.Phi_Phat_Theo_Mot_Ngay_Tre
	FROM QUY_DINH Q
    

    SELECT @MaPhieuTra = inserted.MaPhieuTra,
           @NgayTra = inserted.NgayTra,
		   @MaPhieuMuon = inserted.MaPhieuMuon
    FROM inserted

	SELECT @NgayMuon = NgayMuon
	FROM PHIEU_MUON_SACH
	WHERE @MaPhieuMuon = MaPhieuMuon
    
    -- Tinh so ngay tre
	IF (@NgayTra <= DATEADD(DAY, @ThoiHanMuonSach, @NgayMuon)) SET @PhiPhat = 0
	ELSE
	BEGIN
    SELECT @SoNgayTre = DATEDIFF(DAY, DATEADD(DAY, @ThoiHanMuonSach, @NgayMuon), @NgayTra)
    FROM PHIEU_MUON_SACH
    WHERE MaPhieuMuon = (SELECT MaPhieuMuon FROM PHIEU_TRA_SACH WHERE MaPhieuTra = @MaPhieuTra)
	
    
    -- Tinh phi phat
    SET @PhiPhat = @SoNgayTre * @PhiPhatTheoNGay
    END
    -- Cap nhat phi phat vao bang PHIEU_TRA_SACH
    UPDATE PHIEU_TRA_SACH
    SET SoNgayTre = @SoNgayTre,
        SoTienPhat = @PhiPhat
    WHERE MaPhieuTra = @MaPhieuTra
END

--QD: So tien thu khong duoc vuot qua so tien doc gia dang no.
CREATE TRIGGER ThuTienPhat ON PHIEU_THU_TIEN_PHAT
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @MaPhieuPhat VARCHAR(255)
	DECLARE @TongTienPhat MONEY
    DECLARE @TienNhanDuoc MONEY
	DECLARE @TienConLai MONEY

	SELECT @MaPhieuPhat = inserted.MaPhieuPhat,
           @TongTienPhat = inserted.TongTienPhat,
           @TienNhanDuoc = inserted.TienNhanDuoc
    FROM inserted

	IF (@TienNhanDuoc > @TongTienPhat)
    BEGIN
        PRINT 'So tien thu khong duoc vuot qua so tien doc gia dang no'
        ROLLBACK TRANSACTION
    END
	ELSE
	BEGIN
	SET @TienConLai = @TongTienPhat - @TienNhanDuoc
	UPDATE PHIEU_THU_TIEN_PHAT
	SET TienConLai = @TienConLai
	WHERE @MaPhieuPhat = MaPhieuPhat
	END
END
