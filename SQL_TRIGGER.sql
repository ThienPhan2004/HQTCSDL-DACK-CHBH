use CUAHANGBACHHOA
if exists(select name from sys.triggers
where name='tr_kiemtrasoluong')
drop TRIGGER tr_kiemtrasoluong
go
CREATE TRIGGER tr_kiemtrasoluong -- tạo trigger 
ON CHITIETHDCC -- trên bảng CHITIETHDCC 
AFTER INSERT, UPDATE -- sau khi có sự thay đổi về inser hoặc update
AS
	IF EXISTS (SELECT 1 FROM inserted WHERE soLuong < 0)-- kiểm tra số lượng <0 hay không
	BEGIN 
		print N'Phải nhập số lượng lớn hơn không'-- có, báo lỗi
		RollBack Tran -- hủy bỏ thay đổi trong giao dịch hiện tại
	END
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='tr_kiemtradulieukhixoa')
drop TRIGGER tr_kiemtradulieukhixoa
go
CREATE TRIGGER tr_kiemtradulieukhixoa
	on HOPDONGCUNGCAP instead of delete -- trigger kích hoạt thay cho hành động xóa
	As Declare @soHDCC int, @ErrMsg char(200) -- khai báo 2 biến
	set @soHDCC= (select count (CHITIETHDCC.maHDCC)
	from deleted,CHITIETHDCC where CHITIETHDCC.maHDCC = deleted.maHDCC)--Đếm số lượng bản ghi trong bảng CHITIETHDCC có mã hợp đồng (maHDCC) trùng với các mã hợp đồng được xóa (lưu trong bảng deleted). Kết quả được gán cho biến @soHDCC.

	if @soHDCC>0 --Kiểm tra xem có bất kỳ hợp đồng nào liên quan trong bảng CHITIETHDCC hay không.
		Begin -- nếu đúng
			set @ErrMsg=N'Hợp đồng đã được nhập trong chi tiết hợp đồng cung cấp'
			+'. Không thể hủy hợp đồng!' -- gán thông báo
			print @ErrMsg
			Rollback Tran -- quay lại trạng thái trước khi thực thi trigger
		End
	Else
		Delete HOPDONGCUNGCAP where maHDCC in (Select maHDCC from Deleted) --óa các hợp đồng có mã nằm trong danh sách các mã hợp đồng bị xóa (lưu trong bảng deleted).
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='trg_UpdateSanPhamSoLuong')
drop TRIGGER trg_UpdateSanPhamSoLuong -- nếu trigger đã tồn tại thì xóa đi
go
CREATE TRIGGER trg_UpdateSanPhamSoLuong
ON CHITIETHDCC
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON; -- tắt thông báo số hàng bị ảnh hưởng

    -- Cập nhật số lượng sản phẩm trong bảng SANPHAM
    UPDATE SANPHAM
    SET SANPHAM.soLuong = SANPHAM.soLuong + (SELECT SUM(inserted.soLuong - deleted.soLuong) -- đặt số lượng mới cho số lượng bảng sp, lấy tổng của hiệu số lượng mới và số lượng cũ 
                                              FROM inserted
                                              JOIN deleted ON inserted.maSanPham = deleted.maSanPham)-- từ 2 bảng kết hợp với nhau bằng mã
    WHERE SANPHAM.maSanPham IN (SELECT maSanPham FROM inserted)-- khi mã có trong bảng các mã được thêm vô hoặc cập nhập
END
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='trg_UpdateSanPhamSoLuong')
drop TRIGGER trg_UpdateSanPhamSoLuong-- nếu đã tồn tại trigger thì xóa đi
go
CREATE TRIGGER trg_UpdateSanPhamSoLuong
ON CHITIETHDCC
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;-- tắt thông báo số hàng bị ảnh hưởng

    -- Cập nhật số lượng sản phẩm trong bảng SANPHAM
    UPDATE SANPHAM
    SET SANPHAM.soLuong = SANPHAM.soLuong + (
        SELECT SUM(ISNULL(inserted.soLuong, 0) - ISNULL(deleted.soLuong, 0)) --Trong dấu ngoặc đơn là một câu truy vấn SELECT để tính toán giá trị sẽ được thêm vào số lượng sản phẩm. Lệnh ISNULL được sử dụng để đảm bảo rằng nếu giá trị soLuong trong inserted hoặc deleted là NULL, thì nó sẽ được coi là 0.
        FROM inserted -- từ ....
        LEFT JOIN deleted ON inserted.maSanPham = deleted.maSanPham --kết hợp 2 bảng dựa trên mã
        WHERE SANPHAM.maSanPham = inserted.maSanPham -- Chỉ cập nhật cho sản phẩm tương ứng
    )
    WHERE EXISTS (
        SELECT 1
        FROM inserted
        WHERE SANPHAM.maSanPham = inserted.maSanPham -- Chỉ cập nhật cho sản phẩm tương ứng
    );--Điều kiện này đảm bảo rằng chỉ có những hàng trong bảng SANPHAM tương ứng với các sản phẩm được thêm hoặc cập nhật sẽ được cập nhật.
END
