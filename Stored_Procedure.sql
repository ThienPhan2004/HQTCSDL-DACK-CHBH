CREATE PROCEDURE GetChitietHDCCByMa
    @maHDCC varchar(50) = NULL,
    @maSanPham varchar(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @maHDCC IS NOT NULL
    BEGIN
        -- Truy vấn thông tin từ bảng CHITIETHDCC dựa trên mã HDCC
        SELECT *
        FROM CHITIETHDCC
        WHERE maHDCC = @maHDCC;
    END
    ELSE IF @maSanPham IS NOT NULL
    BEGIN
        -- Truy vấn thông tin từ bảng CHITIETHDCC dựa trên mã sản phẩm
        SELECT *
        FROM CHITIETHDCC
        WHERE maSanPham = @maSanPham;
    END
    ELSE
    BEGIN
        -- Nếu cả hai mã HDCC và mã sản phẩm đều không được cung cấp, không thực hiện gì cả
        PRINT 'Vui lòng cung cấp ít nhất một trong hai mã (maHDCC hoặc maSanPham)';
    END
END


