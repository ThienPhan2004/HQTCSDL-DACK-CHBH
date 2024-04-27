using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string maHDCC = this.textBox5.Text;
            DateTime ngayThanhLapHD;
            if (DateTime.TryParseExact(this.textBox4.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayThanhLapHD))
            {
                // Thực hiện các hoạt động với biến maSanPham ở đây
            }
            else
            {
                // Xử lý trường hợp không thể chuyển đổi
                MessageBox.Show("Định dạng ngày không hợp lệ!");
            }

            int triGia;
            if (!int.TryParse(this.textBox2.Text, out triGia))
            {
                MessageBox.Show("Đơn giá phải là một số nguyên.");
                return; // Dừng lại nếu đơn giá không hợp lệ
            }
            string maNCC = this.textBox1.Text;
            string trangThai = this.textBox3.Text;
            HopDongCungCap hopDongCungCap = new HopDongCungCap(maHDCC, ngayThanhLapHD, triGia, maNCC, trangThai);
            Modify modify = new Modify();
            modify.InsertHDCC(hopDongCungCap);
            FormHopDongCungCap formHopDongCungCap = Application.OpenForms["FormHopDongCungCap"] as FormHopDongCungCap;
            if (formHopDongCungCap != null)
            {
                formHopDongCungCap.UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Form HopDongCungCap không tìm thấy.");
            }
        }
    }
}
