using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Connectsql
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter; //se truy xuat toan bo du lieu vao data table
        SqlCommand sqlCommand; //dung de truy van va cap nhat toi CSDL
        public Modify()
        { 
        }
        public DataTable getAllChiTietHDCC()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from CHITIETHDCC";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable getAllSanPham()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM SANPHAM";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public DataTable GetAllHopDongCungCap()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM HOPDONGCUNGCAP";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insertChiTietHDCC(ChiTietHDCC chiTietHDCC)
         {
             SqlConnection sqlConnection = Connection.GetSqlConnection();
             string query = "insert into CHITIETHDCC values (@maHDCC,@maSanPham,@soLuong,@donGia,@trangThai) ";
        try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maHDCC", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.MaHDCC;
                sqlCommand.Parameters.Add("@maSanPham", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.MaSanPham;
                sqlCommand.Parameters.Add("@soLuong", sqlDbType: SqlDbType.Int).Value = chiTietHDCC.SoLuong;
                sqlCommand.Parameters.Add("@donGia", sqlDbType: SqlDbType.Int).Value = chiTietHDCC.DonGia;
                sqlCommand.Parameters.Add("@trangThai", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.TrangThai;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
         }

        public bool updateCTHDCC(ChiTietHDCC chiTietHDCC)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "update CHITIETHDCC set soLuong=@soLuong,donGia=@donGia,trangThai=@trangThai Where maHDCC = @maHDCC AND maSanPham =@maSanPham";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maHDCC", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.MaHDCC;
                sqlCommand.Parameters.Add("@maSanPham", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.MaSanPham;
                sqlCommand.Parameters.Add("@soLuong", sqlDbType: SqlDbType.Int).Value = chiTietHDCC.SoLuong;
                sqlCommand.Parameters.Add("@donGia", sqlDbType: SqlDbType.Int).Value = chiTietHDCC.DonGia;
                sqlCommand.Parameters.Add("@trangThai", sqlDbType: SqlDbType.NVarChar).Value = chiTietHDCC.TrangThai;
                sqlCommand.ExecuteNonQuery();//thuc thi lenh truy van
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public bool InsertSanPham(SanPham sanPham)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "INSERT INTO SanPham (maSanPham, tenSanPham, maLoaiSanPham, donGia, maNCC, soLuong) VALUES (@maSanPham, @tenSanPham, @maLoaiSanPham, @donGia, @maNCC, @soLuong)";

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maSanPham", SqlDbType.NVarChar).Value = sanPham.MaSanPham;
                sqlCommand.Parameters.Add("@tenSanPham", SqlDbType.NVarChar).Value = sanPham.TenSanPham;
                sqlCommand.Parameters.Add("@maLoaiSanPham", SqlDbType.NVarChar).Value = sanPham.MaLoaiSanPham;
                sqlCommand.Parameters.Add("@donGia", SqlDbType.Int).Value = sanPham.DonGia;
                sqlCommand.Parameters.Add("@maNCC", SqlDbType.NVarChar).Value = sanPham.MaNCC;
                sqlCommand.Parameters.Add("@soLuong", SqlDbType.Int).Value = sanPham.SoLuong;

                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }

        public bool InsertHDCC(HopDongCungCap hopDongCungCap)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "INSERT INTO HopDongCungCap (maHDCC, ngayThanhLapHD, triGia, maNCC, trangThai) VALUES (@maHDCC, @ngayThanhLapHD, @triGia, @maNCC, @trangThai)";

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maHDCC", SqlDbType.NVarChar).Value = hopDongCungCap.MaHDCC;
                sqlCommand.Parameters.Add("@ngayThanhLapHD", SqlDbType.DateTime).Value = hopDongCungCap.NgayThanhLapHD;
                sqlCommand.Parameters.Add("@triGia", SqlDbType.NVarChar).Value = hopDongCungCap.TriGia;
                sqlCommand.Parameters.Add("@maNCC", SqlDbType.Int).Value = hopDongCungCap.MaNCC;
                sqlCommand.Parameters.Add("@trangThai", SqlDbType.NVarChar).Value = hopDongCungCap.TrangThai;
               

                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }
        public bool updateSanPham(SanPham sanPham)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "UPDATE SANPHAM " +
               "SET tenSanPham = @tenSanPham, maLoaiSanPham = @maLoaiSanPham, " +
               "donGia = @donGia, maNCC = @maNCC, soLuong = @soLuong " +
               "WHERE maSanPham = @maSanPham";


            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maSanPham", SqlDbType.NVarChar).Value = sanPham.MaSanPham;
                sqlCommand.Parameters.Add("@tenSanPham", SqlDbType.NVarChar).Value = sanPham.TenSanPham;
                sqlCommand.Parameters.Add("@maLoaiSanPham", SqlDbType.NVarChar).Value = sanPham.MaLoaiSanPham;
                sqlCommand.Parameters.Add("@donGia", SqlDbType.Int).Value = sanPham.DonGia;
                sqlCommand.Parameters.Add("@maNCC", SqlDbType.NVarChar).Value = sanPham.MaNCC;
                sqlCommand.Parameters.Add("@soLuong", SqlDbType.Int).Value = sanPham.SoLuong;

                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }
        public bool updateHDCC(HopDongCungCap hopDongCungCap)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "UPDATE HOPDONGCUNGCAP " +
               "SET maHDCC= @maHDCC, ngayThanhLapHD = @ngayThanhLapHD, " +
               "triGia = @triGia, maNCC = @maNCC, trangThai = @trangThai" +
               "WHERE maHDCC = @maHDCC";


            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maHDCC", SqlDbType.NVarChar).Value = hopDongCungCap.MaHDCC;
                sqlCommand.Parameters.Add("@ngayThanhLapHD", SqlDbType.NVarChar).Value = hopDongCungCap.NgayThanhLapHD;
                sqlCommand.Parameters.Add("@triGia", SqlDbType.Int).Value = hopDongCungCap.TriGia;
                sqlCommand.Parameters.Add("@maNCC", SqlDbType.NVarChar).Value = hopDongCungCap.MaNCC;
                sqlCommand.Parameters.Add("@trangThai", SqlDbType.Int).Value = hopDongCungCap.TrangThai;

                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }
        public bool delete(int maHDCC)
        {
            SqlConnection sqlConnection = Connection.GetSqlConnection();
            string query = "delete HOPDONGCUNGCAP where maHDCC = @maHDCC";


            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maHDCC", SqlDbType.Int).Value = maHDCC;
               
                sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }
        public void CallTriggers()
        {
             
           string connectionString = @"Data Source=LAPTOP-UEQBLNF9;Initial Catalog=CUAHANGBACHHOA;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Gọi trigger tr_kiemtrasoluong
                    using (SqlCommand command3 = new SqlCommand("INSERT INTO CHITIETHDCC (soLuong) VALUES (-10)", connection))
                    {
                        try
                        {
                            command3.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            // Xử lý lỗi từ trigger tr_kiemtrasoluong
                            Console.WriteLine("Error from trigger tr_kiemtrasoluong: " + ex.Message);
                        }
                    }

                    // Gọi trigger tr_kiemtradulieukhixoa
                    using (SqlCommand command2 = new SqlCommand("DELETE FROM HOPDONGCUNGCAP WHERE maHDCC = 'your_maHDCC_here'", connection))
                    {
                        try
                        {
                            command2.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            // Xử lý lỗi từ trigger tr_kiemtradulieukhixoa
                            Console.WriteLine("Error from trigger tr_kiemtradulieukhixoa: " + ex.Message);
                        }
                    }

                    // Gọi trigger them vao bang san pham
                    using (SqlCommand command3 = new SqlCommand("INSERT INTO CHITIETHDCC (maSanPham, soLuong) VALUES ('your_maSanPham_here', 10)", connection))
                    {
                        command3.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi trigger: {ex.Message}");
            }
        }

        // goi thu tuc khi tim kiem 
        public DataTable GetChitietHDCCByMa(string maHDCC, string maSanPham)
        {
            DataTable dataTable = new DataTable();
            string query = "GetChitietHDCCByMa";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maHDCC", maHDCC);
                    sqlCommand.Parameters.AddWithValue("@maSanPham", maSanPham);

                    dataAdapter = new SqlDataAdapter(sqlCommand);
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi gọi thủ tục: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return dataTable;
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            
        }


    }
}
