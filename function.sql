CREATE FUNCTION TinhTienNhapHang
(
    @thoiGian NVARCHAR(20),  -- 'thang' hoac 'nam'
    @ngayBatDau DATE,
    @ngayKetThuc DATE
)
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @tongTienNhap DECIMAL(18, 2)

    IF @thoiGian = 'thang'
    BEGIN
        SELECT @tongTienNhap = SUM(triGia)
        FROM HOPDONGCUNGCAP
        WHERE ngayThanhLapHD >= DATEADD(MONTH, DATEDIFF(MONTH, 0, @ngayBatDau), 0)
          AND ngayThanhLapHD < DATEADD(MONTH, DATEDIFF(MONTH, 0, @ngayKetThuc) + 1, 0)
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
