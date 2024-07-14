
-- Độc giả mượn nhiều sách nhất
DECLARE @Year INT;
DECLARE @Month INT;

SELECT @Year = tg.Nam,		-- Có thể thay đổi thời gian thống kê bằng cách cập nhật giá trị trong bảng ThoiGian_ThongKe
	   @Month = tg.Thang
FROM ThoiGian_ThongKe tg

SELECT TOP 15 DG.MaDG, DG.HoTen, DG.Sdt, DG.Email, DG.DiaChi,SUM(CTMT.SoLuong) AS TongSoLuongSachMuon
FROM THE_DOCGIA DG JOIN PHIEU_MUON_SACH PMS ON DG.MaDG = PMS.MaDG JOIN CHITIET_MUONTRA CTMT ON PMS.MaPhieuMuon = CTMT.MaPhieuMuon
WHERE YEAR(PMS.NgayMuon) = @Year AND MONTH(PMS.NgayMuon) = @Month
GROUP BY DG.MaDG, DG.HoTen, DG.Sdt, DG.Email, DG.DiaChi
ORDER BY TongSoLuongSachMuon DESC, DG.MaDG ASC;



-- Thống kê sách được mượn nhiều nhất


SELECT @Year = tg.Nam,		-- Có thể thay đổi thời gian thống kê bằng cách cập nhật giá trị trong bảng ThoiGian_ThongKe
	   @Month = tg.Thang
FROM ThoiGian_ThongKe tg

SELECT TOP 15 S.MaSach, S.TenSach, S.TacGia, S.NhaXuatBan, S.NamXuatBan,SUM(CTMT.SoLuong) AS TongSoLuongSachMuon
FROM SACH S
JOIN CHITIET_MUONTRA CTMT ON S.MaSach = CTMT.MaSach
JOIN PHIEU_MUON_SACH PMS ON CTMT.MaPhieuMuon = PMS.MaPhieuMuon
WHERE YEAR(PMS.NgayMuon) = @Year AND MONTH(PMS.NgayMuon) = @Month
GROUP BY S.MaSach, S.TenSach, S.TacGia, S.NhaXuatBan, S.NamXuatBan
ORDER BY TongSoLuongSachMuon DESC, S.MaSach ASC
