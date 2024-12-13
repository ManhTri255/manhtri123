using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVN_Tuan4
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private TTNhanVien nv;

        public NhanVien(TTNhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
            txt_msnv.Text = nv.Msnv;
            txt_tennv.Text = nv.Tennv;
            txt_luongcb.Text = nv.Luongcb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_msnv.Text) ||
                string.IsNullOrWhiteSpace(txt_tennv.Text) ||
                string.IsNullOrWhiteSpace(txt_luongcb.Text))
            {
                MessageBox.Show("Vui Long Nhap Day Du Thong Tin!!!", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán dữ liệu vào đối tượng TTNhanVien
            nv.Msnv = txt_msnv.Text.Trim();
            nv.Tennv = txt_tennv.Text.Trim();

            if (long.TryParse(txt_luongcb.Text, out long luongCB))
            {
                nv.Luongcb = (int) luongCB;
            }
            else
            {
                MessageBox.Show("Luong Co Ban Khong Hop le!!!", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng form với kết quả DialogResult.OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
