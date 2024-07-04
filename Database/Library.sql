CREATE DATABASE QUANLYTHUVIEN
GO
USE QUANLYTHUVIEN
GO

	

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
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE td
    SET NgayHetHan = DATEADD(MONTH, Q.Thoi_Han_The_Doc_Gia, td.NgayLapTheDocGia)
    FROM THE_DOCGIA td JOIN inserted i ON td.MaDG = i.MaDG
    JOIN QUY_DINH Q ON 1=1
    WHERE td.MaDG = i.MaDG
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

CREATE OR ALTER TRIGGER DieuKienMuon ON PHIEU_MUON_SACH
FOR INSERT
AS
BEGIN
    DECLARE @MaxBooksPerMember INT
    DECLARE @MaxDaysToReturn INT

    SELECT @MaxBooksPerMember = Q.So_Sach_Doc_Gia_Muon_Duoc_Trong_Mot_ThoiGian,
           @MaxDaysToReturn = Q.So_Ngay_Gioi_Han_So_Luong_Sach_Muon
    FROM QUY_DINH Q

    -- Kiểm tra các bản ghi trong inserted
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN THE_DOCGIA dg ON i.MaDG = dg.MaDG
        WHERE dg.NgayHetHan < GETDATE()
    )
    BEGIN
        PRINT 'The doc gia da het han'
        ROLLBACK TRANSACTION
    END

    -- Kiểm tra số lượng sách mượn của từng độc giả trong khoảng thời gian quy định
    IF EXISTS (
        SELECT 1
        FROM (
            SELECT MaDG, SUM(SoLuongSach) AS TongSoLuongSachMuon
            FROM PHIEU_MUON_SACH
            WHERE MaDG IN (SELECT MaDG FROM inserted)
              AND NgayMuon >= DATEADD(DAY, -@MaxDaysToReturn, GETDATE())
            GROUP BY MaDG
        ) AS A
        WHERE A.TongSoLuongSachMuon > @MaxBooksPerMember
    )
    BEGIN
        PRINT 'So luong sach muon da vuot muc toi da.'
        ROLLBACK TRANSACTION
    END
END
-- QD5: Moi ngay tra tre phat 1.000 dong/ngay. (Moi sach duoc muon toi da 10 ngay.)
CREATE TRIGGER TinhPhiPhat ON PHIEU_TRA_SACH
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @ThoiHanMuonSach INT
    DECLARE @PhiPhatTheoNGay INT

    SELECT @ThoiHanMuonSach = Q.Thoi_Han_Muon_Sach,
           @PhiPhatTheoNGay = Q.Phi_Phat_Theo_Mot_Ngay_Tre
    FROM QUY_DINH Q

    UPDATE pts
    SET SoNgayTre = CASE
                        WHEN pts.NgayTra <= DATEADD(DAY, @ThoiHanMuonSach, pm.NgayMuon) THEN 0
                        ELSE DATEDIFF(DAY, DATEADD(DAY, @ThoiHanMuonSach, pm.NgayMuon), pts.NgayTra)
                    END,
        SoTienPhat = CASE
                        WHEN pts.NgayTra <= DATEADD(DAY, @ThoiHanMuonSach, pm.NgayMuon) THEN 0
                        ELSE DATEDIFF(DAY, DATEADD(DAY, @ThoiHanMuonSach, pm.NgayMuon), pts.NgayTra) * @PhiPhatTheoNGay
                    END
    FROM PHIEU_TRA_SACH pts
    JOIN PHIEU_MUON_SACH pm ON pts.MaPhieuMuon = pm.MaPhieuMuon
    JOIN inserted i ON pts.MaPhieuTra = i.MaPhieuTra
END

--QD: So tien thu khong duoc vuot qua so tien doc gia dang no.
CREATE TRIGGER ThuTienPhat ON PHIEU_THU_TIEN_PHAT
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE p
    SET TienConLai = CASE
                        WHEN i.TienNhanDuoc > i.TongTienPhat THEN p.TienConLai
                        ELSE i.TongTienPhat - i.TienNhanDuoc
                    END
    FROM PHIEU_THU_TIEN_PHAT p
    JOIN inserted i ON p.MaPhieuPhat = i.MaPhieuPhat;
END
