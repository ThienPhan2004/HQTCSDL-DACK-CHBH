use CUAHANGBACHHOA
if exists(select name from sys.triggers
where name='tr_kiemtrasoluong')
drop TRIGGER tr_kiemtrasoluong
go
CREATE TRIGGER tr_kiemtrasoluong
ON CHITIETHDCC
AFTER INSERT, UPDATE
AS
	IF EXISTS (SELECT 1 FROM inserted WHERE soLuong < 0)
	BEGIN 
		print N'Phải nhập số lượng lớn hơn không'
		RollBack Tran
	END
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='tr_kiemtradulieukhixoa')
drop TRIGGER tr_kiemtradulieukhixoa
go
CREATE TRIGGER tr_kiemtradulieukhixoa
	on HOPDONGCUNGCAP instead of delete
	As Declare @soHDCC int, @ErrMsg char(200)
	set @soHDCC= (select count (CHITIETHDCC.maHDCC)
	from deleted,CHITIETHDCC where CHITIETHDCC.maHDCC = deleted.maHDCC)

	if @soHDCC>0
		Begin
			set @ErrMsg=N'Hợp đồng đã được nhập trong chi tiết hợp đồng cung cấp'
			+'. Không thể hủy hợp đồng!'
			print @ErrMsg
			Rollback Tran
		End
	Else
		Delete HOPDONGCUNGCAP where maHDCC in (Select maHDCC from Deleted)
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='trg_UpdateSanPhamSoLuong')
drop TRIGGER trg_UpdateSanPhamSoLuong
go
CREATE TRIGGER trg_UpdateSanPhamSoLuong
ON CHITIETHDCC
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật số lượng sản phẩm trong bảng SANPHAM
    UPDATE SANPHAM
    SET SANPHAM.soLuong = SANPHAM.soLuong + (SELECT SUM(inserted.soLuong - deleted.soLuong) 
                                              FROM inserted
                                              JOIN deleted ON inserted.maSanPham = deleted.maSanPham)
    WHERE SANPHAM.maSanPham IN (SELECT maSanPham FROM inserted)
END
go

use CUAHANGBACHHOA
if exists(select name from sys.triggers where name='trg_UpdateSanPhamSoLuong')
drop TRIGGER trg_UpdateSanPhamSoLuong
go
CREATE TRIGGER trg_UpdateSanPhamSoLuong
ON CHITIETHDCC
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật số lượng sản phẩm trong bảng SANPHAM
    UPDATE SANPHAM
    SET SANPHAM.soLuong = SANPHAM.soLuong + (
        SELECT SUM(ISNULL(inserted.soLuong, 0) - ISNULL(deleted.soLuong, 0))
        FROM inserted
        LEFT JOIN deleted ON inserted.maSanPham = deleted.maSanPham
        WHERE SANPHAM.maSanPham = inserted.maSanPham -- Chỉ cập nhật cho sản phẩm tương ứng
    )
    WHERE EXISTS (
        SELECT 1
        FROM inserted
        WHERE SANPHAM.maSanPham = inserted.maSanPham -- Chỉ cập nhật cho sản phẩm tương ứng
    );
END
