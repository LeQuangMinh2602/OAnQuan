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

        private static bool isFirstLoggin1 = true;
        private static bool isFirstLoggin2 = true;
        public static bool soNguoiChoi;
        private SoundPlayer choiNhac;
        public static FrmMenu_48_Minh frmMenu_48_Minh;
        public static FrmMain2Player_48_Minh frmMain2_48_Minh;
        public static FrmMain2Player_48_Minh frmMain1_48_Minh;

        public FrmMenu_48_Minh()
        {
            InitializeComponent();
            this.Size = new Size(1200, 800);
        }

        private void frmMenu_48_Minh_Load(object sender, EventArgs e)
        {
            choiNhac = new SoundPlayer(Properties.Resources.FolkMusic);
            this.Size = new Size(1200, 800);
        }

        private void btnChoiTiep_48_Minh_Click(object sender, EventArgs e)
        {
            frmMenu_48_Minh = this;
            this.Hide();
            if (isFirstLoggin1 && isFirstLoggin2)
                soNguoiChoi = Properties.Settings.Default.soNguoiChoi;
            if (soNguoiChoi)
            {
                if (isFirstLoggin2)
                {
                    frmMain2_48_Minh = new FrmMain2Player_48_Minh();
                    isFirstLoggin2 = false;
                    frmMain2_48_Minh.docFile_48_Minh();
                }
                frmMain2_48_Minh.Size = this.Size;
                frmMain2_48_Minh.Location = this.Location;
                frmMain2_48_Minh.Show();
                frmMain2_48_Minh.tThoiGian_48_Minh.Start();
            }
            else
            {
                if (isFirstLoggin1)
                {
                    frmMain1_48_Minh = new FrmMain1Player_48_Minh();
                    isFirstLoggin1 = false;
                    frmMain1_48_Minh.docFile_48_Minh();
                }
                isFirstLoggin1 = false;
                frmMain1_48_Minh.Size = this.Size;
                frmMain1_48_Minh.Location = this.Location;
                
                frmMain1_48_Minh.Show();
                frmMain1_48_Minh.tThoiGian_48_Minh.Start();
            }
        }

        private void btnThoat_48_Minh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void cbNhac_48_Minh_CheckedChanged(object sender, EventArgs e)
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
            if (isFirstLoggin2)
                frmMain2_48_Minh = new FrmMain2Player_48_Minh();
            isFirstLoggin2 = false;
            soNguoiChoi = true;
            frmMenu_48_Minh = this;
            this.Hide();
            frmMain2_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt");
            frmMain2_48_Minh.Size = this.Size;
            frmMain2_48_Minh.Location = this.Location;
            frmMain2_48_Minh.Show();
            frmMain2_48_Minh.tThoiGian_48_Minh.Start();
        }

        private void btnVanMoi1Player_48_Minh_Click(object sender, EventArgs e)
        {
            if (isFirstLoggin1)
                frmMain1_48_Minh = new FrmMain1Player_48_Minh();
            isFirstLoggin1 = false;
            soNguoiChoi = false;
            frmMenu_48_Minh = this;
            this.Hide();
            frmMain1_48_Minh.docFile_48_Minh("OAnQuan.Resources.Data.txt");
            frmMain1_48_Minh.Size = this.Size;
            frmMain1_48_Minh.Location = this.Location;
            frmMain1_48_Minh.Show();
            frmMain1_48_Minh.tThoiGian_48_Minh.Start();
        }
    }
}
