
SET DATEFORMAT DMY

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
('DG001', 'Nguyễn Văn An', 'TK001', '01-01-1990', '123 Đường A', 'an.nguyen@example.com', '0912345678', '01-01-2023', '01-01-2024'),
('DG002', 'Trần Thị Bích', 'TK002', '15-02-1985', '456 Đường B', 'bich.tran@example.com', '0912345679', '01-02-2023', '01-02-2024'),
('DG003', 'Lê Hoàng Cường', 'TK003', '20-03-1979', '789 Đường C', 'cuong.le@example.com', '0912345680', '01-03-2023', '01-03-2024'),
('DG004', 'Phạm Minh Duy', 'TK004', '10-04-1992', '101 Đường D', 'duy.pham@example.com', '0912345681', '01-04-2023', '01-04-2024'),
('DG005', 'Hoàng Thị Em', 'TK005', '25-05-1987', '202 Đường E', 'em.hoang@example.com', '0912345682', '01-05-2023', '01-05-2024'),
('DG006', 'Bùi Văn Phát', 'TK006', '30-06-1983', '303 Đường F', 'phat.bui@example.com', '0912345683', '01-06-2023', '01-06-2024'),
('DG007', 'Đỗ Thị Gấm', 'TK007', '15-07-1995', '404 Đường G', 'gam.do@example.com', '0912345684', '01-07-2023', '01-07-2024'),
('DG008', 'Vũ Hoàng Hà', 'TK008', '10-08-1981', '505 Đường H', 'ha.vu@example.com', '0912345685', '01-08-2023', '01-08-2024'),
('DG009', 'Phạm Văn Khang', 'TK009', '05-09-1988', '606 Đường I', 'khang.pham@example.com', '0912345686', '01-09-2023', '01-09-2024'),
('DG010', 'Nguyễn Thị Lan', 'TK010', '20-10-1993', '707 Đường J', 'lan.nguyen@example.com', '0912345687', '01-10-2023', '01-10-2024'),
('DG011', 'Trần Văn Minh', 'TK011', '25-11-1984', '808 Đường K', 'minh.tran@example.com', '0912345688', '01-11-2023', '01-11-2024'),
('DG012', 'Lê Thị Ngọc', 'TK012', '30-12-1990', '909 Đường L', 'ngoc.le@example.com', '0912345689', '01-12-2023', '01-12-2024'),
('DG013', 'Hoàng Văn Nam', 'TK013', '15-01-1986', '111 Đường M', 'nam.hoang@example.com', '0912345690', '15-01-2023', '15-01-2024'),
('DG014', 'Bùi Thị Oanh', 'TK014', '10-02-1991', '222 Đường N', 'oanh.bui@example.com', '0912345691', '15-02-2023', '15-02-2024'),
('DG015', 'Đỗ Văn Phú', 'TK015', '05-03-1978', '333 Đường O', 'phu.do@example.com', '0912345692', '15-03-2023', '15-03-2024'),
('DG016', 'Vũ Thị Quyên', 'TK016', '20-04-1989', '444 Đường P', 'quyen.vu@example.com', '0912345693', '15-04-2023', '15-04-2024'),
('DG017', 'Phạm Văn Sơn', 'TK017', '25-05-1982', '555 Đường Q', 'son.pham@example.com', '0912345694', '15-05-2023', '15-05-2024'),
('DG018', 'Nguyễn Thị Tâm', 'TK018', '30-06-1994', '666 Đường R', 'tam.nguyen@example.com', '0912345695', '15-06-2023', '15-06-2024'),
('DG019', 'Trần Văn Tài', 'TK019', '10-07-1980', '777 Đường S', 'tai.tran@example.com', '0912345696', '15-07-2023', '15-07-2024'),
('DG020', 'Lê Thị Uyên', 'TK020', '05-08-1996', '888 Đường T', 'uyen.le@example.com', '0912345697', '15-08-2023', '15-08-2024');




-- Du lieu mau cho bang THUTHU
INSERT INTO THUTHU (MaTT, HoTen, MaTaiKhoan, NgayTaoTK, NgaySinh, DiaChi, Email, Sdt) VALUES
('TT001', 'Lê Thị Bích Ngọc', 'TK021', '01-01-2023', '05-05-1985', '123 Đường V', 'ngoc.lethi@example.com', '0912345698'),
('TT002', 'Nguyễn Văn Hùng', 'TK022', '01-01-2023', '20-07-1980', '456 Đường W', 'hung.nguyen@example.com', '0912345699');





-- Du lieu mau cho bang THELOAI_SACH
INSERT INTO THELOAI_SACH (MaTheLoai, TenTheLoai) VALUES
('TL001', 'Tiểu thuyết'),
('TL002', 'Khoa học'),
('TL003', 'Lịch sử'),
('TL004', 'Tự truyện'),
('TL005', 'Viễn tưởng'),
('TL006', 'Công nghệ');



-- Du lieu mau cho bang SACH
INSERT INTO SACH (MaSach, TenSach, MaTheLoai, TacGia, NamXuatBan, NhaXuatBan, SoLuong, GiaSach) VALUES
('S001', 'Mắt Biếc', 'TL001', 'Nguyễn Nhật Ánh', 2016, 'NXB Trẻ', 10, 100000),
('S002', 'Cho tôi xin một vé đi tuổi thơ', 'TL001', 'Nguyễn Nhật Ánh', 2017, 'NXB Trẻ', 8, 150000),
('S003', 'Tôi thấy hoa vàng trên cỏ xanh', 'TL001', 'Nguyễn Nhật Ánh', 2018, 'NXB Trẻ', 5, 180000),
('S004', 'Cánh đồng bất tận', 'TL001', 'Nguyễn Ngọc Tư', 2016, 'NXB Trẻ', 12, 200000),
('S005', 'Chuyện người con gái Nam Xương', 'TL001', 'Nguyễn Dữ', 2019, 'NXB Văn Học', 7, 220000),
('S006', 'Sống mòn', 'TL001', 'Nam Cao', 2020, 'NXB Văn Học', 9, 300000),
('S007', 'Dế mèn phiêu lưu ký', 'TL001', 'Tô Hoài', 2021, 'NXB Kim Đồng', 6, 270000),
('S008', 'Nhà giả kim', 'TL002', 'Paulo Coelho', 2016, 'NXB Văn Học', 8, 200000),
('S009', 'Đắc nhân tâm', 'TL002', 'Dale Carnegie', 2017, 'NXB Trẻ', 10, 350000),
('S010', 'Khéo ăn nói sẽ có được thiên hạ', 'TL002', 'Trác Nhã', 2018, 'NXB Văn Học', 15, 400000),
('S011', 'Tuổi trẻ đáng giá bao nhiêu', 'TL002', 'Rosie Nguyễn', 2019, 'NXB Trẻ', 11, 320000),
('S012', 'Đường mây qua xứ tuyết', 'TL002', 'Anagarika Govinda', 2020, 'NXB Văn Hóa Thông Tin', 13, 370000),
('S013', 'Cẩm nang luyện thi đại học', 'TL002', 'Nhiều tác giả', 2021, 'NXB Giáo Dục', 20, 450000),
('S014', 'Lịch sử Việt Nam', 'TL003', 'Nhiều tác giả', 2016, 'NXB Giáo Dục', 18, 420000),
('S015', 'Việt Nam sử lược', 'TL003', 'Trần Trọng Kim', 2017, 'NXB Văn Học', 14, 500000),
('S016', 'Sử ký Tư Mã Thiên', 'TL003', 'Tư Mã Thiên', 2018, 'NXB Văn Học', 17, 380000),
('S017', 'Hồi ký của một Geisha', 'TL004', 'Arthur Golden', 2019, 'NXB Văn Học', 10, 210000),
('S018', 'Những câu chuyện về Bác Hồ', 'TL004', 'Nhiều tác giả', 2020, 'NXB Kim Đồng', 12, 240000),
('S019', 'Hồi ký Lý Quang Diệu', 'TL004', 'Lý Quang Diệu', 2021, 'NXB Trẻ', 9, 450000),
('S020', 'Đêm hội Long Trì', 'TL005', 'Ngô Tất Tố', 2016, 'NXB Văn Học', 11, 230000),
('S021', 'Mê cung hồi ức', 'TL005', 'Đinh Mặc', 2017, 'NXB Trẻ', 8, 280000),
('S022', 'Con đường hồi giáo', 'TL005', 'Tariq Ramadan', 2018, 'NXB Văn Học', 10, 300000),
('S023', 'Tôi là Bêtô', 'TL005', 'Nguyễn Nhật Ánh', 2019, 'NXB Trẻ', 14, 350000),
('S024', 'Nếu biết trăm năm là hữu hạn', 'TL005', 'Phạm Lữ Ân', 2020, 'NXB Trẻ', 15, 500000),
('S025', 'Mười người da đen nhỏ', 'TL005', 'Agatha Christie', 2021, 'NXB Văn Học', 13, 400000),
('S026', 'Công nghệ giáo dục', 'TL006', 'Nguyễn Thành Nam', 2016, 'NXB Giáo Dục', 12, 310000),
('S027', 'Startup Việt', 'TL006', 'Nhiều tác giả', 2017, 'NXB Trẻ', 16, 320000),
('S028', 'Công nghệ blockchain', 'TL006', 'Nguyễn Thành Công', 2018, 'NXB Công Nghệ', 18, 290000),
('S029', 'Cách mạng công nghiệp 4.0', 'TL006', 'Klaus Schwab', 2019, 'NXB Trẻ', 20, 300000),
('S030', 'Hành trình về phương Đông', 'TL006', 'Baird T. Spalding', 2020, 'NXB Văn Hóa Thông Tin', 19, 340000);


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
