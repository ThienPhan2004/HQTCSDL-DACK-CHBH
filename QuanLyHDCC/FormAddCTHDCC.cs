using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connectsql
{
    public partial class FormAddCTHDCC : Form
    {
        public FormAddCTHDCC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormAddCTHDCC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maHDCC = this.textBox2.Text;
            string maSanPham = this.textBox3.Text;
            int soLuong;
            if (!int.TryParse(this.textBox1.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }

            int donGia;
            if (!int.TryParse(this.textBox4.Text, out donGia))
            {
                MessageBox.Show("Đơn giá phải là một số nguyên.");
                return; // Dừng lại nếu đơn giá không hợp lệ
            }
            string trangThai = this.textBox5.Text;
            ChiTietHDCC chiTietHDCC = new ChiTietHDCC(maHDCC, maSanPham, soLuong, donGia, trangThai );
            Modify modify = new Modify();
            modify.insert(chiTietHDCC);
            FormChiTietHDCC formChiTietHDCC = Application.OpenForms["FormChiTietHDCC"] as FormChiTietHDCC;
            if (formChiTietHDCC != null)
            {
                formChiTietHDCC.UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Form ChiTietHDCC không tìm thấy.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string maHDCC = this.textBox2.Text;
            string maSanPham = this.textBox3.Text;
            int soLuong;
            if (!int.TryParse(this.textBox1.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }

            int donGia;
            if (!int.TryParse(this.textBox4.Text, out donGia))
            {
                MessageBox.Show("Đơn giá phải là một số nguyên.");
                return; // Dừng lại nếu đơn giá không hợp lệ
            }
            string trangThai = this.textBox5.Text;
            ChiTietHDCC chiTietHDCC = new ChiTietHDCC(maHDCC, maSanPham, soLuong, donGia, trangThai);
            Modify modify = new Modify();
            modify.updateCTHDCC(chiTietHDCC);
            FormChiTietHDCC formChiTietHDCC = Application.OpenForms["FormChiTietHDCC"] as FormChiTietHDCC;
            if (formChiTietHDCC != null)
            {
                formChiTietHDCC.UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Form ChiTietHDCC không tìm thấy.");
            }

        }
    }
}
