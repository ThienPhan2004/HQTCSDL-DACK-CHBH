using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectsql
{
    internal class HopDongCungCap
    {
        private string _maHDCC;
        private DateTime _ngayThanhLapHD;
        private int _triGia;
        private string _maNCC;
        private string _trangThai;

        public HopDongCungCap()
        {
        }

        public HopDongCungCap(string maHDCC, DateTime ngayThanhLapHD, int triGia, string maNCC, string trangThai)
        {
            MaHDCC = maHDCC;
            NgayThanhLapHD = ngayThanhLapHD;
            TriGia = triGia;
            MaNCC = maNCC;
            TrangThai = trangThai;
        }

        public string MaHDCC { get => _maHDCC; set => _maHDCC = value; }
        public DateTime NgayThanhLapHD { get => _ngayThanhLapHD; set => _ngayThanhLapHD = value; }
        public int TriGia { get => _triGia; set => _triGia = value; }
        public string MaNCC { get => _maNCC; set => _maNCC = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
    
}
}
