using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString("dd/MM/yy");
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            this.toolStripStatusLabel1.Text = string.Format($"Hom Nay La Ngay: {date} - Bay Gio La: {time}");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Video File|*.mp4;*.avi;*.mkv;*.wmv";
            if (openFileDialog.ShowDialog() == DialogResult.OK )
            {
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
            }
        }
    }
}
