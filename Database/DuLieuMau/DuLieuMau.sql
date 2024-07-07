SET DATEFORMAT DMY

-- Du lieu mau bang QUY_DINH
INSERT INTO QUY_DINH VALUES (18, 55, 6, 8, 5, 7, 10, 1000)

-- Số tuổi nhỏ nhất là 18 tuổi
-- Số tuổi lớn nhất là 55 tuổi
-- Thời hạn thẻ độc giả là 6 tháng
-- Số năm xuất bản có thể nhập là 8 năm
-- Số sách độc giả có thể mượn trong 7 ngày là 5 quyển
-- Số ngày giới hạn số sách độc giả mượn là 7 ngày
-- Thời hạn độc giả có thể mượn sách là 10 ngày
-- Phí phạt nếu trả sách trễ là 1000đ/ngày

INSERT INTO ThoiGian_ThongKe (Thang, Nam) VALUES (7, 2024);

-- Du lieu mau cho bang TAIKHOAN
INSERT INTO TAIKHOAN (MaTK, TK_Username, TK_Password, LoaiTK) VALUES
('TK001', 'user1', 'password1', 'Reader'),
('TK002', 'user2', 'password2', 'Reader'),
('TK003', 'user3', 'password3', 'Reader'),
('TK004', 'user4', 'password4', 'Reader'),
('TK005', 'user5', 'password5', 'Reader'),
('TK006', 'user6', 'password6', 'Reader'),
('TK007', 'user7', 'password7', 'Reader'),
('TK008', 'user8', 'password8', 'Reader'),
('TK009', 'user9', 'password9', 'Reader'),
('TK010', 'user10', 'password10', 'Reader'),
('TK011', 'user11', 'password11', 'Reader'),
('TK012', 'user12', 'password12', 'Reader'),
('TK013', 'user13', 'password13', 'Reader'),
('TK014', 'user14', 'password14', 'Reader'),
('TK015', 'user15', 'password15', 'Reader'),
('TK016', 'user16', 'password16', 'Reader'),
('TK017', 'user17', 'password17', 'Reader'),
('TK018', 'user18', 'password18', 'Reader'),
('TK019', 'user19', 'password19', 'Reader'),
('TK020', 'user20', 'password20', 'Reader'),
('TK021', 'librarian1', 'password21', 'Librarian'),
('TK022', 'librarian2', 'password22', 'Librarian');

-- Du lieu mau cua bang THE_DOCGIA
INSERT INTO THE_DOCGIA (MaDG, HoTen, MaTaiKhoan, NgaySinh, DiaChi, Email, Sdt, NgayLapTheDocGia, NgayHetHan) VALUES
('DG001', N'Nguyễn Văn An', 'TK001', '01-01-1990', N'123 Đường A', 'an.nguyen@example.com', '0912345678', '15-02-2024', '15-01-2025'),
('DG002', N'Trần Thị Bích', 'TK002', '15-02-1985', N'456 Đường B', 'bich.tran@example.com', '0912345679', '25-02-2024', '25-01-2025'),
('DG003', N'Lê Hoàng Cường', 'TK003', '20-03-1979', N'789 Đường C', 'cuong.le@example.com', '0912345680', '07-02-2024', '07-02-2025'),
('DG004', N'Phạm Minh Duy', 'TK004', '10-04-1992', N'101 Đường D', 'duy.pham@example.com', '0912345681', '12-02-2024', '12-02-2025'),
('DG005', N'Hoàng Thị Em', 'TK005', '25-05-1987', N'202 Đường E', 'em.hoang@example.com', '0912345682', '28-02-2024', '28-02-2025'),
('DG006', N'Bùi Văn Phát', 'TK006', '30-06-1983', N'303 Đường F', 'phat.bui@example.com', '0912345683', '05-03-2024', '05-03-2025'),
('DG007', N'Đỗ Thị Gấm', 'TK007', '15-07-1995', N'404 Đường G', 'gam.do@example.com', '0912345684', '18-03-2024', '18-03-2025'),
('DG008', N'Vũ Hoàng Hà', 'TK008', '10-08-1981', N'505 Đường H', 'ha.vu@example.com', '0912345685', '23-03-2024', '23-03-2025'),
('DG009', N'Phạm Văn Khang', 'TK009', '05-09-1988', N'606 Đường I', 'khang.pham@example.com', '0912345686', '07-04-2024', '07-04-2025'),
('DG010', N'Nguyễn Thị Lan', 'TK010', '20-10-1993', N'707 Đường J', 'lan.nguyen@example.com', '0912345687', '18-04-2024', '18-04-2025'),
('DG011', N'Trần Văn Minh', 'TK011', '25-11-1984', N'808 Đường K', 'minh.tran@example.com', '0912345688', '25-04-2024', '25-04-2025'),
('DG012', N'Lê Thị Ngọc', 'TK012', '30-12-1990', N'909 Đường L', 'ngoc.le@example.com', '0912345689', '07-05-2024', '07-05-2025'),
('DG013', N'Hoàng Văn Nam', 'TK013', '15-01-1986', N'111 Đường M', 'nam.hoang@example.com', '0912345690', '17-05-2024', '17-05-2025'),
('DG014', N'Bùi Thị Oanh', 'TK014', '10-02-1991', N'222 Đường N', 'oanh.bui@example.com', '0912345691', '25-05-2024', '25-05-2025'),
('DG015', N'Đỗ Văn Phú', 'TK015', '05-03-1978', N'333 Đường O', 'phu.do@example.com', '0912345692', '02-06-2024', '02-06-2025'),
('DG016', N'Vũ Thị Quyên', 'TK016', '20-04-1989', N'444 Đường P', 'quyen.vu@example.com', '0912345693', '18-06-2024', '18-06-2025'),
('DG017', N'Phạm Văn Sơn', 'TK017', '25-05-1982', N'555 Đường Q', 'son.pham@example.com', '0912345694', '30-06-2024', '30-06-2025'),
('DG018', N'Nguyễn Thị Tâm', 'TK018', '30-06-1994', N'666 Đường R', 'tam.nguyen@example.com', '0912345695', '05-07-2024', '05-07-2025'),
('DG019', N'Trần Văn Tài', 'TK019', '10-07-1980', N'777 Đường S', 'tai.tran@example.com', '0912345696', '10-07-2024', '12-07-2025'),
('DG020', N'Lê Thị Uyên', 'TK020', '05-08-1996', N'888 Đường T', 'uyen.le@example.com', '0912345697', '15-07-2024', '25-07-2025');

-- Du lieu mau cho bang THUTHU
INSERT INTO THUTHU (MaTT, HoTen, MaTaiKhoan, NgayTaoTK, NgaySinh, DiaChi, Email, Sdt) VALUES
('TT001', N'Lê Thị Bích Ngọc', 'TK021', '01-01-2023', '05-05-1985', N'123 Đường V', 'ngoc.lethi@example.com', '0912345698'),
('TT002', N'Nguyễn Văn Hùng', 'TK022', '01-01-2023', '20-07-1980', N'456 Đường W', 'hung.nguyen@example.com', '0912345699');

-- Du lieu mau cho bang THELOAI_SACH
INSERT INTO THELOAI_SACH (MaTheLoai, TenTheLoai, MaTT) VALUES
('TL001', N'Văn học', 'TT001'),
('TL002', N'Khoa học', 'TT002'),
('TL003', N'Lịch sử', 'TT001'),
('TL004', N'Tâm lý', 'TT002'),
('TL005', N'Giáo dục', 'TT001');

-- Du lieu mau cho bang TACGIA
INSERT INTO TACGIA (MaTacGia, TenTacGia) VALUES
('TG001', N'Tô Hoài'),
('TG002', N'Nguyễn Nhật Ánh'),
('TG003', N'Mark Twain'),
('TG004', N'Jane Austen'),
('TG005', N'Victor Hugo');

-- Du lieu mau cho bang SACH
INSERT INTO SACH (MaSach, TenSach, MaTheLoai, MaTacGia, NamXuatBan, NhaXuatBan, TinhTrang) VALUES
('S001', N'Dế Mèn Phiêu Lưu Ký', 'TL001', 'TG001', 2000, N'Nhà xuất bản Kim Đồng', 'Tốt'),
('S002', N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 'TL001', 'TG002', 2015, N'Nhà xuất bản Trẻ', 'Tốt'),
('S003', N'Tom Sawyer', 'TL002', 'TG003', 1876, N'American Publishing Company', 'Tốt'),
('S004', N'Pride and Prejudice', 'TL002', 'TG004', 1813, N'T. Egerton, Whitehall', 'Tốt'),
('S005', N'Les Misérables', 'TL003', 'TG005', 1862, N'A. Lacroix, Verboeckhoven & Cie.', 'Tốt'),
('S006', N'Khoa Học Vũ Trụ', 'TL002', 'TG003', 2020, N'Nhà xuất bản Giáo Dục', 'Tốt'),
('S007', N'Lịch Sử Thế Giới', 'TL003', 'TG004', 2018, N'Nhà xuất bản Tổng Hợp', 'Tốt'),
('S008', N'Tâm Lý Học Phát Triển', 'TL004', 'TG005', 2019, N'Nhà xuất bản Đại Học Quốc Gia', 'Tốt'),
('S009', N'Giáo Dục Trẻ Em', 'TL005', 'TG001', 2021, N'Nhà xuất bản Giáo Dục', 'Tốt'),
('S010', N'Những Người Khốn Khổ', 'TL003', 'TG005', 1862, N'Nhà xuất bản Trẻ', 'Tốt');

-- Du lieu mau cho bang PHIEUMUON
INSERT INTO PHIEUMUON (MaPhieuMuon, MaDG, MaTT, NgayMuon, NgayTra, TinhTrang) VALUES
('PM001', 'DG001', 'TT001', '20-01-2024', '25-01-2024', 'Đã trả'),
('PM002', 'DG002', 'TT002', '25-01-2024', '01-02-2024', 'Đã trả'),
('PM003', 'DG003', 'TT001', '10-02-2024', '20-03-2024', 'Đã trả'),
('PM004', 'DG004', 'TT002', '15-02-2024', '10-04-2024', 'Đã trả'),
('PM005', 'DG005', 'TT001', '01-03-2024', '30-05-2024', 'Đã trả'),
('PM006', 'DG006', 'TT002', '10-03-2024', '20-07-2024', 'Đã trả'),
('PM007', 'DG007', 'TT001', '25-03-2024', '15-05-2024', 'Đã trả'),
('PM008', 'DG008', 'TT002', '05-04-2024', '28-04-2024', 'Đã trả'),
('PM009', 'DG009', 'TT001', '15-04-2024', '01-06-2024', 'Đã trả'),
('PM010', 'DG010', 'TT002', '01-05-2024', '05-07-2024', 'Đã trả'),
('PM011', 'DG011', 'TT001', '15-05-2024', '20-06-2024', 'Đã trả'),
('PM012', 'DG012', 'TT002', '20-05-2024', '21-06-2024', 'Đã trả'),
('PM013', 'DG013', 'TT001', '25-05-2024', '27-06-2024', 'Đã trả'),
('PM014', 'DG014', 'TT002', '05-06-2024', '30-06-2024', 'Đã trả'),
('PM015', 'DG015', 'TT001', '15-06-2024', '05-06-2024', 'Đã trả'),
('PM016', 'DG016', 'TT002', '25-06-2024', '22-06-2024', 'Đã trả'),
('PM017', 'DG017', 'TT001', '05-07-2024', '17-07-2024', 'Đã trả'),
('PM018', 'DG018', 'TT002', '15-07-2024', '10-07-2024', 'Đã trả'),
('PM019', 'DG019', 'TT001', '20-07-2024', '12-07-2024', 'Đã trả'),
('PM020', 'DG020', 'TT002', '25-07-2024', '07-07-2024', 'Đã trả');

-- Du lieu mau cho bang CHITIET_MUONTRA
INSERT INTO CHITIET_MUONTRA (MaPhieuMuon, MaSach, NgayTra, TinhTrang) VALUES
('PM001', 'S001', '25-01-2024', 'Tốt'),
('PM001', 'S002', '25-01-2024', 'Tốt'),
('PM001', 'S003', '25-01-2024', 'Tốt'),
('PM001', 'S004', '25-01-2024', 'Tốt'),
('PM001', 'S005', '25-01-2024', 'Tốt'),
('PM002', 'S006', '01-02-2024', 'Tốt'),
('PM002', 'S007', '01-02-2024', 'Tốt'),
('PM002', 'S008', '01-02-2024', 'Tốt'),
('PM003', 'S009', '20-03-2024', 'Tốt'),
('PM004', 'S010', '10-04-2024', 'Tốt'),
('PM004', 'S011', '10-04-2024', 'Tốt'),
('PM004', 'S012', '10-04-2024', 'Tốt'),
('PM004', 'S013', '10-04-2024', 'Tốt'),
('PM005', 'S014', '30-05-2024', 'Tốt'),
('PM005', 'S015', '30-05-2024', 'Tốt'),
('PM005', 'S016', '30-05-2024', 'Tốt'),
('PM005', 'S017', '30-05-2024', 'Tốt'),
('PM006', 'S018', '20-07-2024', 'Tốt'),
('PM006', 'S019', '20-07-2024', 'Tốt'),
('PM006', 'S020', '20-07-2024', 'Tốt'),
('PM007', 'S021', '15-05-2024', 'Tốt'),
('PM008', 'S022', '28-04-2024', 'Tốt'),
('PM008', 'S023', '28-04-2024', 'Tốt'),
('PM008', 'S024', '28-04-2024', 'Tốt'),
('PM008', 'S025', '28-04-2024', 'Tốt'),
('PM009', 'S026', '01-06-2024', 'Tốt'),
('PM009', 'S027', '01-06-2024', 'Tốt'),
('PM009', 'S028', '01-06-2024', 'Tốt'),
('PM009', 'S029', '01-06-2024', 'Tốt'),
('PM009', 'S030', '01-06-2024', 'Tốt'),
('PM010', 'S001', '05-07-2024', 'Tốt'),
('PM010', 'S002', '05-07-2024', 'Tốt'),
('PM011', 'S003', '20-06-2024', 'Tốt'),
('PM011', 'S004', '20-06-2024', 'Tốt'),
('PM012', 'S005', '21-06-2024', 'Tốt'),
('PM012', 'S006', '21-06-2024', 'Tốt'),
('PM012', 'S007', '21-06-2024', 'Tốt'),
('PM012', 'S008', '21-06-2024', 'Tốt'),
('PM013', 'S009', '27-06-2024', 'Tốt'),
('PM013', 'S010', '27-06-2024', 'Tốt'),
('PM013', 'S011', '27-06-2024', 'Tốt'),
('PM013', 'S012', '27-06-2024', 'Tốt'),
('PM014', 'S013', '30-06-2024', 'Tốt'),
('PM014', 'S014', '30-06-2024', 'Tốt'),
('PM015', 'S015', '05-06-2024', 'Tốt'),
('PM015', 'S016', '05-06-2024', 'Tốt'),
('PM016', 'S017', '22-06-2024', 'Tốt'),
('PM016', 'S018', '22-06-2024', 'Tốt'),
('PM016', 'S019', '22-06-2024', 'Tốt'),
('PM017', 'S020', '17-07-2024', 'Tốt'),
('PM017', 'S021', '17-07-2024', 'Tốt'),
('PM018', 'S022', '10-07-2024', 'Tốt'),
('PM018', 'S023', '10-07-2024', 'Tốt'),
('PM019', 'S024', '12-07-2024', 'Tốt'),
('PM019', 'S025', '12-07-2024', 'Tốt'),
('PM020', 'S026', '07-07-2024', 'Tốt'),
('PM020', 'S027', '07-07-2024', 'Tốt');
