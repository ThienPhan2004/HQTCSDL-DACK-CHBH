CREATE FUNCTION TinhTienNhapHang
(
    @thoiGian NVARCHAR(20),  -- tham số đầu vào 'thang' hoac 'nam'
    @ngayBatDau DATE,
    @ngayKetThuc DATE
)
RETURNS DECIMAL(18, 2) -- trả về giá trị kiểu decimal 
AS
BEGIN
    DECLARE @tongTienNhap DECIMAL(18, 2) -- khởi tạo biến 

    IF @thoiGian = 'thang' 
    BEGIN
        SELECT @tongTienNhap = SUM(triGia)
        FROM HOPDONGCUNGCAP
        WHERE ngayThanhLapHD >= DATEADD(MONTH, DATEDIFF(MONTH, 0, @ngayBatDau), 0)-- nếu ngày lập hd lớn hơn hoặc bằng tháng trong ngày bắt đầu
          AND ngayThanhLapHD < DATEADD(MONTH, DATEDIFF(MONTH, 0, @ngayKetThuc) + 1, 0)-- nhỏ hơn tháng hơn trong ngày kết thúc +1, dateadd cộng thêm 1 tháng vào ngày kết thúc để lấy giá trị nhỏ hơn ngày kthuc
    END
    ELSE IF @thoiGian = 'nam'
    BEGIN
        SELECT @tongTienNhap = SUM(triGia)
        FROM HOPDONGCUNGCAP
        WHERE ngayThanhLapHD >= DATEADD(YEAR, DATEDIFF(YEAR, 0, @ngayBatDau), 0)
          AND ngayThanhLapHD < DATEADD(YEAR, DATEDIFF(YEAR, 0, @ngayKetThuc) + 1, 0)
    END
    ELSE
    BEGIN
        SET @tongTienNhap = 0
    END

    RETURN @tongTienNhap
END
