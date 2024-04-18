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
    public partial class FormAddHDCC : Form
    {
        private FormHopDongCungCap parentForm;

        public FormAddHDCC()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (formHopDongCungCap != null)
            {
                string maHDCC = textBox5.Text;
                formHopDongCungCap.XoaHopDongCungCap(maHDCC);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thực hiện thao tác. Biến formHopDongCungCap không được khởi tạo.");
            }

        }

        private FormHopDongCungCap formHopDongCungCap;

        // Khởi tạo FormAddHDCC và truyền vào formHopDongCungCap
        public FormAddHDCC(FormHopDongCungCap formHopDongCungCap)
        {
            InitializeComponent();
            this.formHopDongCungCap = formHopDongCungCap;

        }
        private void FormAddHDCC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
