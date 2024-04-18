using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectsql
{
    internal class HopDongCungCap
    {
        private int _maHDCC;
        private DateTime _ngayThanhLapHD;
        private int _triGia;
        private int _maNCC;
        private string _trangThai;

        public HopDongCungCap()
        {
        }

        public HopDongCungCap(int maHDCC, DateTime ngayThanhLapHD, int triGia, int maNCC, string trangThai)
        {
            MaHDCC = maHDCC;
            NgayThanhLapHD = ngayThanhLapHD;
            TriGia = triGia;
            MaNCC = maNCC;
            TrangThai = trangThai;
        }

        public int MaHDCC { get => _maHDCC; set => _maHDCC = value; }
        public DateTime NgayThanhLapHD { get => _ngayThanhLapHD; set => _ngayThanhLapHD = value; }
        public int TriGia { get => _triGia; set => _triGia = value; }
        public int MaNCC { get => _maNCC; set => _maNCC = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
    
}
}
