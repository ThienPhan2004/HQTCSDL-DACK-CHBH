using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectsql
{
     class ChiTietHDCC
    {
        private string _maHDCC;
        private string _maSanPham;
        private int _soLuong;
        private int _donGia;
        private string _trangThai;

        public ChiTietHDCC()
        {
        }

        public ChiTietHDCC(string maHDCC, string maSanPham, int soLuong, int donGia, string trangThai)
        {
            MaHDCC = maHDCC;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DonGia = donGia;
            TrangThai = trangThai;
        }

        public string MaHDCC { get => _maHDCC; set => _maHDCC = value; }
        public string MaSanPham { get => _maSanPham; set => _maSanPham = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public int DonGia { get => _donGia; set => _donGia = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
    }
}
