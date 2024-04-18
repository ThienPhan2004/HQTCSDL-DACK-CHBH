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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void chiTiếtHợpĐồngCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChiTietHDCC formChiTietHDCC = new FormChiTietHDCC();
            this.Hide();
            formChiTietHDCC.ShowDialog();
            this.Show();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        Modify modify;
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getAllSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddSP formAddSP = new FormAddSP();
            formAddSP.ShowDialog();
        }
        public void UpdateDataGridView()
        {
            dataGridView1.DataSource = modify.getAllSanPham();
        }

        private void hợpĐồngCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHopDongCungCap formHopDongCungCap = new FormHopDongCungCap();
            this.Hide();
            formHopDongCungCap.ShowDialog();
            this.Show();
        }
    }
}
