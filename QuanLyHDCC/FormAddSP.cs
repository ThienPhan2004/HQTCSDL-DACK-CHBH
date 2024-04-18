using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connectsql
{
    public partial class FormAddSP : Form
    {
        public FormAddSP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maSanPham = this.textBox2.Text;
            string tenSanPham = this.textBox1.Text;
            string maLoaiSanPham = this.textBox5.Text;
            int donGia;
            if (!int.TryParse(this.textBox4.Text, out donGia))
            {
                MessageBox.Show("Dơn giá phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }
            string maNCC = this.textBox6.Text;
            int soLuong;
            if (!int.TryParse(this.textBox3.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }
            SanPham sanPham = new SanPham(maSanPham, tenSanPham, maLoaiSanPham, donGia, maNCC, soLuong);
            Modify modify = new Modify();
            modify.InsertSanPham(sanPham);
            FormSanPham formSanPham = Application.OpenForms["FormSanPham"] as FormSanPham;
            if (formSanPham != null)
            {
                formSanPham.UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Form SanPham không tìm thấy.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddSP_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maSanPham = this.textBox2.Text;
            string tenSanPham = this.textBox1.Text;
            string maLoaiSanPham = this.textBox5.Text;
            int donGia;
            if (!int.TryParse(this.textBox4.Text, out donGia))
            {
                MessageBox.Show("Dơn giá phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }
            string maNCC = this.textBox6.Text;
            int soLuong;
            if (!int.TryParse(this.textBox3.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.");
                return; // Dừng lại nếu số lượng không hợp lệ
            }
            SanPham sanPham = new SanPham(maSanPham, tenSanPham, maLoaiSanPham, donGia, maNCC, soLuong);
            Modify modify = new Modify();
            modify.updateSanPham(sanPham);
            FormSanPham formSanPham = Application.OpenForms["FormSanPham"] as FormSanPham;
            if (formSanPham != null)
            {
                formSanPham.UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Form SanPham không tìm thấy.");
            }
        }
    }
}
