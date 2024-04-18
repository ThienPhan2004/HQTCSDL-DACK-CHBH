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
    public partial class FormHopDongCungCap : Form
    {


        public void XoaHopDongCungCap(string maHDCC)
        {
            // Lặp qua các dòng trong DataGridView để tìm dòng chứa mã hợp đồng cung cấp cần xóa
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["MaHDCC"].Value.ToString() == maHDCC)
                {
                    // Xóa dòng tương ứng
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }
        }

        public FormHopDongCungCap()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddHDCC formAddHDCC = new FormAddHDCC(this);
            formAddHDCC.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        Modify modify;
        private void FormHopDongCungCap_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.GetAllHopDongCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chiTiếtHợpĐồngCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChiTietHDCC formChiTietHDCC = new FormChiTietHDCC();
            this.Hide();
            formChiTietHDCC.ShowDialog();
            this.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham formSanPham = new FormSanPham();
            this.Hide();
            formSanPham.ShowDialog();
            this.Show();
        }
    }
}
