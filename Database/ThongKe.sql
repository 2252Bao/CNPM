
-- Độc giả mượn nhiều sách nhất
SELECT TOP 15 dg.MaDG, dg.HoTen, dg.Sdt, dg.Email, dg.DiaChi,SUM(ct.SoLuong) AS TongSoLuongSachMuon
FROM THE_DOCGIA dg JOIN PHIEU_MUON_SACH pm ON dg.MaDG = pm.MaDG JOIN CHITIET_MUONTRA ct ON pm.MaPhieuMuon = ct.MaPhieuMuon
GROUP BY dg.MaDG, dg.HoTen, dg.Sdt, dg.Email, dg.DiaChi
ORDER BY TongSoLuongSachMuon DESC, dg.MaDG ASC


-- Thống kê sách được mượn nhiều nhất

SELECT TOP 15 s.MaSach, s.TenSach, s.TacGia, s.NhaXuatBan, s.NamXuatBan, SUM(ct.SoLuong) AS TongSoLuongDuocMuon
FROM SACH s JOIN CHITIET_MUONTRA ct ON s.MaSach = ct.MaSach
GROUP BY s.MaSach, s.TenSach, s.TacGia, s.NhaXuatBan, s.NamXuatBan
ORDER BY TongSoLuongDuocMuon DESC, s.MaSach ASC