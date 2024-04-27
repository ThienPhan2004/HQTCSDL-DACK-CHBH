USE [master]
GO 

create LOGIN [Hoàng Đăng Khoa] with password = 'c123', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Nguyễn Văn C] with password = 'nv02', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Trần Thị D] with password = 'nv03', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Mai Van H] with password = 'nv04', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Lương Thị I] with password = 'nv05', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Trần Văn F] with password = 'nv06', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Hoàng Thị G] with password = 'nv07', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Lê Thành D] with password = 'nv08', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Phạm Thị F] with password = 'nv09', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Huỳnh Thành F] with password = 'kh01', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Lê Thuấn O] with password = 'kh02', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Đặng Văn V] with password = 'kh03', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF
create LOGIN [Trần Thị HH] with password = 'kh04', default_database = [CUAHANGBACHHOA], CHECK_POLICY = OFF


USE [CUAHANGBACHHOA]
GO
create user [Hoàng Đăng Khoa] for login [Hoàng Đăng Khoa]
create user [Nguyễn Văn C] for login [Nguyễn Văn C]
create user [Tran Thi D] for login [Trần Thị D]
create user [Mai Van H] for login [Mai Van H]
create user [Luong Thi I] for login [Lương Thị I]
create user [Trần Văn F] for login [Trần Văn F]
create user [Hoàng Thị G] for login [Hoàng Thị G]
create user [Lê Thành D] for login [Lê Thành D]
create user [Phạm Thị F] for login [Phạm Thị F]
create user [Huỳnh Thành F] for login [Huỳnh Thành F]
create user [Lê Tuấn O] for login [Lê Tuấn O]
create user [Đặng Văn V] for login [Đặng Văn V]
create user [Trần Thị HH] for login [Trần Thị HH]