using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Connectsql
{
    class SanPham
    {
            private string _maSanPham;
            private string _tenSanPham;
            private string _maLoaiSanPham;
            private int _donGia;
            private string _maNCC;
            private int _soLuong;

    public SanPham()
    {
    }

    public SanPham(string maSanPham, string tenSanPham, string maLoaiSanPham, int donGia, string maNCC, int soLuong)
    {
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        MaLoaiSanPham = maLoaiSanPham;
        DonGia = donGia;
        MaNCC = maNCC;
        SoLuong = soLuong;
    }

    public string MaSanPham { get => _maSanPham; set => _maSanPham = value; }
    public string TenSanPham { get => _tenSanPham; set => _tenSanPham = value; }
    public string MaLoaiSanPham { get => _maLoaiSanPham; set => _maLoaiSanPham = value; }
    public int DonGia { get => _donGia; set => _donGia = value; }
    public string MaNCC { get => _maNCC; set => _maNCC = value; }
    public int SoLuong { get => _soLuong; set => _soLuong = value; }
    
    }

}
