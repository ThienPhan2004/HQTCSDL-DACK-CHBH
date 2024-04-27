
-- tạo bảng phân quyền
USE CUAHANGBACHHOA;
CREATE TABLE [QUYEN] (
	maQuyen INT PRIMARY KEY,
	tenQuyen NVARCHAR(50)
);

-- tạo bảng người dùng
USE CUAHANGBACHHOA
CREATE TABLE [USER] (
	maUser INT PRIMARY KEY IDENTITY(1,1),
	tenUser NVARCHAR (100) not null,
	matKhau NVARCHAR (50) not null,
	maChu int ,
	maNhanVien int,
	maQuyen int not null,
	maKhachHang int,
	constraint FK_maNhanVien FOREIGN KEY (maNhanVien) REFERENCES NHANVIEN(maNhanVien),
	constraint FK_maQuyen FOREIGN KEY (maQuyen)  REFERENCES QUYEN(maQuyen),
	constraint FK_maKhachHang FOREIGN KEY (maKhachHang) REFERENCES KHACHHANG(maKhachHang)
);

-- thêm dữ liệu vào bảng phân quyền
INSERT INTO QUYEN (maQuyen, tenQuyen) VALUES
(1, N'Chủ'),
(2, N'Nhân viên bán hàng'),
(3, N'Nhân viên nhập kho'),
(4, N'Khách Hàng');

 
 -- thêm dữ liệu vào bảng USER
 INSERT INTO [USER] ( tenUser, matKhau, maChu, maNhanVien, maQuyen, maKhachHang) values
 (N'Hoàng Đăng Khoa', N'c123', 1, NULL,1,NULL),
 (N'Nguyễn Văn C', N'nv02', NULL, 1, 2, NULL),
 (N'Tran Thi D', N'nv03', NULL, 2, 2, NULL),
 (N'Mai Van H', N'nv04', NULL, 7, 2, NULL),
 (N'Lương Thị I', N'nv05', NULL, 8, 2, NULL),
 (N'Trần Văn F', N'nv06', NULL, 9, 2, NULL),
 (N'Hoàng Thị G', N'nv07', NULL, 10, 2, NULL),
 (N'Lê Thành D', N'nv08', NULL, 3, 3, NULL),
 (N'Phạm Thị F', N'nv09', NULL, 4, 3, NULL),
 (N'Hoàng Thị G', N'nv10', NULL, 6, 3, NULL),
 (N'Huỳnh Thành F', N'kh01', NULL, NULL, 4, 6),
 (N'Lê Tuấn O', N'kh02', NULL, NULL, 4, 12),
 (N'Đặng Văn V', N'kh03', NULL, NULL, 4, 19),
 (N'Trần Thị HH', N'kh04', NULL, NULL, 4, 31);

