//VuManhTri_2280603381
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingList<TTNhanVien> ttnv;

        private void Form1_Load(object sender, EventArgs e)
        {
            ttnv = new BindingList<TTNhanVien>();

            TTNhanVien a = new TTNhanVien();
            a.Msnv = "NV001";
            a.Tennv = "Nguyễn Thị Thu Hiền";
            a.Luongcb = 8500000;

            ttnv.Add(a);
            HienThiDanhSach();
        }

        
        private void HienThiDanhSach()
        {
            dtgNhanVien.DataSource = null;
            dtgNhanVien.DataSource = ttnv;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            TTNhanVien nvMoi = new TTNhanVien();

            NhanVien nvForm = new NhanVien(nvMoi);

            if (nvForm.ShowDialog() == DialogResult.OK)
            {
                ttnv.Add(nvMoi);
                HienThiDanhSach();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.CurrentRow != null)
            {
                var nvSua = (TTNhanVien)dtgNhanVien.CurrentRow.DataBoundItem;

                NhanVien nvForm = new NhanVien(nvSua);

                if (nvForm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn xóa mục đã chọn không?", "Thông Báo",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (dtgNhanVien.CurrentRow != null)
                {
                    var nv_xoa = (TTNhanVien)dtgNhanVien.CurrentRow.DataBoundItem;
                    ttnv.Remove(nv_xoa);
                    HienThiDanhSach();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
