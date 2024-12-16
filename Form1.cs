using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_02
{
    public partial class frmSanpham : Form
    {
        public frmSanpham()
        {
            InitializeComponent();
        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
            LoadSanpham();
            LoadLoaiSP();
            ResetControlState();
        }


        private void dtgSanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgSanpham.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                dtNgaynhap.Value = DateTime.Parse(row.Cells["NgayNhap"].Value.ToString());
                cboLoaiSP.Text = row.Cells["LoaiSP"].Value.ToString();
            }
            dtgSanpham.CellClick += new DataGridViewCellEventHandler(dtgSanpham_CellContentClick);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text) || cboLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Đầy Đủ Thông Tin!!!");
                return;
            }
            dtgSanpham.Rows.Add(txtMaSP.Text, txtTenSP.Text, dtNgaynhap.Value.ToString("dd/MM/yyyy"), cboLoaiSP.Text);
            ResetControlState();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dtgSanpham.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Bạn Có Chắc Muốn Xóa Sản Phẩm Này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtgSanpham.SelectedRows)
                    {
                        dtgSanpham.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm Cần Xóa!!!");
            }
        }

        private void ResetControlState()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            dtNgaynhap.Value = DateTime.Now;
            cboLoaiSP.SelectedIndex = -1;

            btLuu.Enabled = false;
            btKLuu.Enabled = false;
        }

        private void LoadLoaiSP()
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.Add("L1");
            cboLoaiSP.Items.Add("L2");
        }

        private void LoadSanpham()
        {
            if (dtgSanpham.Columns.Count == 0)
            {
                dtgSanpham.Columns.Add("MaSP", "Mã SP");
                dtgSanpham.Columns.Add("TenSP", "Tên sản phẩm");
                dtgSanpham.Columns.Add("NgayNhap", "Ngày nhập");
                dtgSanpham.Columns.Add("LoaiSP", "Loại SP");
            }
            dtgSanpham.Rows.Clear();
            dtgSanpham.Rows.Add("SP0001", "iPhone X", "2024/06/06", "L1");
            dtgSanpham.Rows.Add("SP0002", "OPPO A53", "2024/05/25", "L1");
            dtgSanpham.Rows.Add("SP0003", "JBL 5", "2024/06/17", "L2");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát Không?", "Xác Nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //chon Yes hay No
            if (result == DialogResult.Yes)
            {
                Application.Exit(); //thoat
            }
        }
    }
}

