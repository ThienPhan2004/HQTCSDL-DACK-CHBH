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
    public partial class FormChiTietHDCC : Form
    {
        public FormChiTietHDCC()
        {
            InitializeComponent();
        }
        Modify modify;
        public void FormChiTietHDCC_Load(object sender, EventArgs e)
        {
             modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getAllChiTietHDCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maHDCC = textBox1.Text.Trim();
            string maSanPham = textBox1.Text.Trim();

            try
            {
                DataTable result = modify.GetChitietHDCCByMa(maHDCC, maSanPham);
                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy lại tất cả dữ liệu từ database và gán lại cho DataGridView
                dataGridView1.DataSource = modify.getAllChiTietHDCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi trở về trạng thái ban đầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddCTHDCC formAddCTHDCC = new FormAddCTHDCC();
            formAddCTHDCC.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham formSanPham = new FormSanPham();
            this.Hide();
            formSanPham.ShowDialog();
            this.Show();
        }
        public void UpdateDataGridView()
        {
            dataGridView1.DataSource = modify.getAllChiTietHDCC();
        }

        private void hợpĐồngCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHopDongCungCap formHopDongCungCap = new FormHopDongCungCap();
            this.Hide();
            formHopDongCungCap.ShowDialog();
        }
    }
}
