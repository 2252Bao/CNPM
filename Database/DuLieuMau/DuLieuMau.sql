
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
('DG019', N'Trần Văn Tài', 'TK019', '10-07-1980', N'777 Đường S', 'tai.tran@example.com', '0912345696', '1-07-2024', '12-07-2025'),
('DG020', N'Lê Thị Uyên', 'TK020', '05-08-1996', N'888 Đường T', 'uyen.le@example.com', '0912345697', '3-07-2024', '25-07-2025');



-- Du lieu mau cho bang THUTHU
INSERT INTO THUTHU (MaTT, HoTen, MaTaiKhoan, NgayTaoTK, NgaySinh, DiaChi, Email, Sdt) VALUES
('TT001', N'Lê Thị Bích Ngọc', 'TK021', '01-01-2023', '05-05-1985', N'123 Đường V', 'ngoc.lethi@example.com', '0912345698'),
('TT002', N'Nguyễn Văn Hùng', 'TK022', '01-01-2023', '20-07-1980', N'456 Đường W', 'hung.nguyen@example.com', '0912345699');



-- Du lieu mau cho bang THELOAI_SACH
INSERT INTO THELOAI_SACH (MaTheLoai, TenTheLoai) VALUES
('TL001', N'Tiểu thuyết'),
('TL002', N'Khoa học'),
('TL003', N'Lịch sử'),
('TL004', N'Tự truyện'),
('TL005', N'Viễn tưởng'),
('TL006', N'Công nghệ');



-- Du lieu mau cho bang SACH
INSERT INTO SACH (MaSach, TenSach, MaTheLoai, TacGia, NamXuatBan, NhaXuatBan, SoLuong, GiaSach) VALUES
('S001', N'Mắt Biếc', 'TL001', N'Nguyễn Nhật Ánh', 2016, N'NXB Trẻ', 10, 100000),
('S002', N'Cho tôi xin một vé đi về tuổi thơ', 'TL001', N'Nguyễn Nhật Ánh', 2017, N'NXB Trẻ', 8, 150000),
('S003', N'Tôi thấy hoa vàng trên cỏ xanh', 'TL001', N'Nguyễn Nhật Ánh', 2018, N'NXB Trẻ', 5, 180000),
('S004', N'Cánh đồng bất tận', 'TL001', N'Nguyễn Ngọc Tư', 2016, N'NXB Trẻ', 12, 200000),
('S005', N'Chuyện người con gái Nam Xương', N'TL001', N'Nguyễn Dữ', 2019, N'NXB Văn Học', 7, 220000),
('S006', N'Sống mòn', 'TL001', N'Nam Cao', 2020, N'NXB Văn Học', 9, 300000),
('S007', N'Dế mèn phiêu lưu ký', 'TL001', N'Tô Hoài', 2021, N'NXB Kim Đồng', 6, 270000),
('S008', N'Nhà giả kim', 'TL002', N'Paulo Coelho', 2016, N'NXB Văn Học', 8, 200000),
('S009', N'Đắc nhân tâm', 'TL002', 'Dale Carnegie', 2017, N'NXB Trẻ', 10, 350000),
('S010', N'Khéo ăn nói sẽ có được thiên hạ', 'TL002', N'Trác Nhã', 2018, N'NXB Văn Học', 15, 400000),
('S011', N'Tuổi trẻ đáng giá bao nhiêu', 'TL002', N'Rosie Nguyễn', 2019, N'NXB Trẻ', 11, 320000),
('S012', N'Đường mây qua xứ tuyết', 'TL002', 'Anagarika Govinda', 2020, N'NXB Văn Hóa Thông Tin', 13, 370000),
('S013', N'Cẩm nang luyện thi đại học', 'TL002', N'Nhiều tác giả', 2021, N'NXB Giáo Dục', 20, 450000),
('S014', N'Lịch sử Việt Nam', 'TL003', N'Nhiều tác giả', 2016, N'NXB Giáo Dục', 18, 420000),
('S015', N'Việt Nam sử lược', 'TL003', N'Trần Trọng Kim', 2017, N'NXB Văn Học', 14, 500000),
('S016', N'Sử ký Tư Mã Thiên', 'TL003', N'Tư Mã Thiên', 2018, N'NXB Văn Học', 17, 380000),
('S017', N'Hồi ký của một Geisha', 'TL004', 'Arthur Golden', 2019, N'NXB Văn Học', 10, 210000),
('S018', N'Những câu chuyện về Bác Hồ', 'TL004', N'Nhiều tác giả', 2020, N'NXB Kim Đồng', 12, 240000),
('S019', N'Hồi ký Lý Quang Diệu', 'TL004', N'Lý Quang Diệu', 2021, N'NXB Trẻ', 9, 450000),
('S020', N'Đêm hội Long Trì', 'TL005', N'Ngô Tất Tố', 2016, N'NXB Văn Học', 11, 230000),
('S021', N'Mê cung hồi ức', 'TL005', N'Đinh Mặc', 2017, N'NXB Trẻ', 8, 280000),
('S022', N'Con đường hồi giáo', 'TL005', 'Tariq Ramadan', 2018, N'NXB Văn Học', 10, 300000),
('S023', N'Tôi là Bêtô', 'TL005', N'Nguyễn Nhật Ánh', 2019, N'NXB Trẻ', 14, 350000),
('S024', N'Nếu biết trăm năm là hữu hạn', 'TL005', N'Phạm Lữ Ân', 2020, N'NXB Trẻ', 15, 500000),
('S025', N'Mười người da đen nhỏ', 'TL005', 'Agatha Christie', 2021, N'NXB Văn Học', 13, 400000),
('S026', N'Công nghệ giáo dục', 'TL006', N'Nguyễn Thành Nam', 2016, N'NXB Giáo Dục', 12, 310000),
('S027', N'Startup Việt', 'TL006', N'Nhiều tác giả', 2017, N'NXB Trẻ', 16, 320000),
('S028', N'Công nghệ blockchain', 'TL006', N'Nguyễn Thành Công', 2018, N'NXB Công Nghệ', 18, 290000),
('S029', N'Cách mạng công nghiệp 4.0', 'TL006', 'Klaus Schwab', 2019, N'NXB Trẻ', 20, 300000),
('S030', N'Hành trình về phương Đông', 'TL006', 'Baird T. Spalding', 2020, N'NXB Văn Hóa Thông Tin', 19, 340000);



-- Dữ liệu mẫu cho bảng PHIEU_MUON_SACH
INSERT INTO PHIEU_MUON_SACH (MaPhieuMuon, MaDG, MaTT, SoLuongSach, NgayMuon) VALUES 
('PM001', 'DG001', 'TT001', 5, '16-01-2024'),
('PM002', 'DG002', 'TT002', 3, '20-02-2024'),
('PM003', 'DG003', 'TT001', 1, '10-03-2024'),
('PM004', 'DG004', 'TT002', 4, '05-04-2024'),
('PM005', 'DG005', 'TT001', 4, '25-05-2024'),
('PM006', 'DG006', 'TT002', 3, '12-07-2024'),
('PM007', 'DG007', 'TT002', 1, '05-05-2024'),
('PM008', 'DG008', 'TT001', 4, '18-04-2024'),
('PM009', 'DG009', 'TT001', 5, '22-05-2024'),
('PM010', 'DG010', 'TT001', 2, '30-06-2024'),
('PM011', 'DG011', 'TT002', 2, '10-06-2024'),
('PM012', 'DG012', 'TT001', 3, '12-06-2024'),
('PM013', 'DG013', 'TT002', 3, '15-06-2024'),
('PM014', 'DG014', 'TT001', 5, '20-06-2024'),
('PM015', 'DG015', 'TT002', 4, '26-05-2024'),
('PM016', 'DG016', 'TT001', 4, '21-06-2024'),
('PM017', 'DG017', 'TT002', 3, '07-07-2024'),
('PM018', 'DG018', 'TT001', 1, '05-07-2024'),
('PM019', 'DG019', 'TT002', 2, '03-07-2024'),
('PM020', 'DG020', 'TT001', 2, '04-07-2024');


-- Dữ liệu mẫu cho bảng PHIEU_TRA_SACH
INSERT INTO PHIEU_TRA_SACH (MaPhieuTra, MaPhieuMuon, MaDG, MaTT, NgayTra, SoLuongSach, SoNgayTre, SoTienPhat) VALUES 
('PT001', 'PM001', 'DG001', 'TT001', '25-01-2024', 5, 0, 0),
('PT002', 'PM002', 'DG002', 'TT002', '01-02-2024', 3, 10, 100000),
('PT003', 'PM003', 'DG003', 'TT001', '20-03-2024', 1, 0, 0),
('PT004', 'PM004', 'DG004', 'TT002', '10-04-2024', 4, 0, 0),
('PT005', 'PM005', 'DG005', 'TT001', '30-05-2024', 4, 0, 0),
('PT006', 'PM006', 'DG006', 'TT002', '20-07-2024', 3, 0, 0),
('PT007', 'PM007', 'DG007', 'TT002', '15-05-2024', 1, 0, 0),
('PT008', 'PM008', 'DG008', 'TT001', '28-04-2024', 4, 0, 0),
('PT009', 'PM009', 'DG009', 'TT001', '01-06-2024', 5, 0, 0),
('PT010', 'PM010', 'DG010', 'TT001', '05-07-2024', 2, 0, 0),
('PT011', 'PM011', 'DG011', 'TT002', '20-06-2024', 2, 0, 0),
('PT012', 'PM012', 'DG012', 'TT001', '21-06-2024', 3, 0, 0),
('PT013', 'PM013', 'DG013', 'TT002', '27-06-2024', 3, 2, 20000),
('PT014', 'PM014', 'DG014', 'TT001', '30-06-2024', 5, 0, 0),
('PT015', 'PM015', 'DG015', 'TT002', '05-06-2024', 4, 0, 0),
('PT016', 'PM016', 'DG016', 'TT001', '22-06-2024', 3, 0, 0),
('PT017', 'PM017', 'DG017', 'TT002', '17-07-2024', 3, 0, 0),
('PT018', 'PM018', 'DG018', 'TT001', '10-07-2024', 1, 0, 0),
('PT019', 'PM019', 'DG019', 'TT002', '12-07-2024', 2, 0, 0),
('PT020', 'PM020', 'DG020', 'TT001', '07-07-2024', 2, 0, 0);

-- Dữ liệu mẫu cho bảng CHITIET_MUONTRA
INSERT INTO CHITIET_MUONTRA (MaPhieuMuon, MaSach, SoLuong) VALUES 
('PM001', 'S001', 1),
('PM001', 'S002', 2),
('PM001', 'S003', 3),
('PM002', 'S004', 2),
('PM002', 'S005', 1),
('PM003', 'S006', 1),
('PM004', 'S007', 4),
('PM005', 'S011', 2),
('PM005', 'S012', 2),
('PM006', 'S013', 2),
('PM006', 'S014', 1),
('PM007', 'S015', 1),
('PM008', 'S016', 2),
('PM008', 'S017', 1),
('PM008', 'S018', 1),
('PM009', 'S019', 2),
('PM009', 'S020', 2),
('PM009', 'S021', 1),
('PM010', 'S022', 1),
('PM010', 'S023', 1),
('PM011', 'S024', 2),
('PM012', 'S027', 1),
('PM012', 'S028', 2),
('PM013', 'S030', 3),
('PM014', 'S012', 5),
('PM015', 'S015', 3),
('PM015', 'S005', 1),
('PM016', 'S004', 2),
('PM016', 'S029', 1),
('PM017', 'S017', 2),
('PM017', 'S019', 1),
('PM018', 'S010', 1),
('PM019', 'S003', 2),
('PM020', 'S014', 1),
('PM020', 'S025', 1);
