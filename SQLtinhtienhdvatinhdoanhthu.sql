-- hàm tính tiền hóa đơn
create function dbo.TinhTienHoaDon (@maHoaDon int)-- tham số đầu vào
returns decimal(18,2) -- trả về giá trị kiểu decimal
as -- bắt đầu thân hàm
begin
	declare @tongTien decimal(18,2) -- khai báo biến kiểu dữ liệu decimal
	select @tongTien = sum(SANPHAM.donGia * CHITIETHOADON.soLuong)
	from CHITIETHOADON
	INNER JOIN SANPHAM ON CHITIETHOADON.maSanPham = SANPHAM.maSanPham -- liên kết 2 bảng bằng maSP
	where CHITIETHOADON.maHoaDon = @maHoaDon;-- lọc các mục trong bảng chi tiết có mã hóa đơn bằng mã nhập vào

	RETURN @tongTien;
end;

-- hàm tính doanh thu theo tháng theo năm
CREATE FUNCTION TinhDoanhThu (
    @thoiGian NVARCHAR(20),  -- 'thang' hoặc 'nam'
    @ngayBatDau DATE,
    @ngayKetThuc DATE
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @doanhThu DECIMAL(18, 2) -- khai báo biến

    IF @thoiGian = 'thang'
    BEGIN
        SELECT @doanhThu = SUM(giaTri)
        FROM HOADON
        WHERE ngay >= @ngayBatDau
          AND ngay < DATEADD(MONTH, 1, @ngayKetThuc)-- nhỏ hơn tháng trong ngày kết thúc cộng 1
    END
    ELSE IF @thoiGian = 'nam'
    BEGIN
        SELECT @doanhThu = SUM(giaTri)
        FROM HOADON
        WHERE ngay >= @ngayBatDau
          AND ngay < DATEADD(YEAR, 1, @ngayKetThuc)-- nhỏ hơn năm trong ngày kết thúc cộng 1
    END
    ELSE
    BEGIN
        SET @doanhThu = 0
    END

    RETURN @doanhThu
END


