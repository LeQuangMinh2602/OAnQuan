using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace OAnQuan
{
    public partial class FrmMenu_48_Minh : Form
    {

        private static bool isFirstLoggin = true;
        private bool soNguoiChoi;
        private SoundPlayer choiNhac;
        public static FrmMenu_48_Minh frmMenu_48_Minh;
        public static FrmMain2Player_48_Minh frmMain2_48_Minh = new FrmMain2Player_48_Minh();
        public static FrnMain1Player_48_Minh frmMain1_48_Minh = new FrnMain1Player_48_Minh();

        public FrmMenu_48_Minh()
        {
            InitializeComponent();
            this.Size = new Size(1200, 800);
        }

        private void frmMenu_48_Minh_Load(object sender, EventArgs e)
        {
            choiNhac = new SoundPlayer(Properties.Resources.FolkMusic);
        }

        private void btnChoiTiep_48_Minh_Click(object sender, EventArgs e)
        {
            frmMenu_48_Minh = this;
            this.Hide();
            if (soNguoiChoi)
            {
                frmMain2_48_Minh.Size = this.Size;
                frmMain2_48_Minh.Location = this.Location;
                if (isFirstLoggin)
                {
                    isFirstLoggin = false;
                    frmMain2_48_Minh.docFile_48_Minh();
                }
                frmMain2_48_Minh.Show();
                frmMain2_48_Minh.tThoiGian_48_Minh.Start();
            }
            else
            {
                frmMain1_48_Minh.Size = this.Size;
                frmMain1_48_Minh.Location = this.Location;
                if (isFirstLoggin)
                {
                    isFirstLoggin = false;
                    frmMain1_48_Minh.docFile_48_Minh();
                }
                frmMain1_48_Minh.Show();
                frmMain1_48_Minh.tThoiGian_48_Minh.Start();
            }
        }

        private void btnThoat_48_Minh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void cbNhac_48_Minh_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbNhac_48_Minh.Checked)
                choiNhac.PlayLooping();
            else
                choiNhac.Stop();
        }

        private void frmMenu_48_Minh_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVanMoi2Player_48_Minh_Click(object sender, EventArgs e)
        {
            soNguoiChoi = true;
            frmMenu_48_Minh = this;
            this.Hide();
            isFirstLoggin = false;
            frmMain2_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt");
            frmMain2_48_Minh.Size = this.Size;
            frmMain2_48_Minh.Location = this.Location;
            frmMain2_48_Minh.Show();
            frmMain2_48_Minh.tThoiGian_48_Minh.Start();
        }

        private void btnVanMoi1Player_48_Minh_Click(object sender, EventArgs e)
        {
            soNguoiChoi = false;
            frmMenu_48_Minh = this;
            this.Hide();
            isFirstLoggin = false;
            frmMain1_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt");
            frmMain1_48_Minh.Size = this.Size;
            frmMain1_48_Minh.Location = this.Location;
            frmMain1_48_Minh.Show();
            frmMain1_48_Minh.tThoiGian_48_Minh.Start();
        }
    }
}
