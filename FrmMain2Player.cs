using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAnQuan
{

    public partial class FrmMain2Player_48_Minh : Form
    {

        protected List<Button> arrButton;
        protected int giaTri;
        protected int thuTu;
        protected bool nguoiChoi = true;

        protected int noiThuTu_48_Minh(int tt)
        {
            if (tt == arrButton.Count)
                return 0;
            else if (tt == -1)
                return arrButton.Count - 1;
            else
                return tt;
        }

        protected void hoatAnh_48_Minh(Control ct, int sizeDiff, Image im, int time)
        {
            int size = (int)ct.Font.Size;
            Image crrIm = ct.BackgroundImage;
            ct.BackgroundImage = im;
            ct.Font = new Font("Lucida Handwriting", size + sizeDiff);
            ct.Update();
            Thread.Sleep(time);
            ct.BackgroundImage = crrIm;
            ct.Font = new Font("Lucida Handwriting", size);
            ct.Update();
        }

        protected void hoatAnh_48_Minh(Control ct, int sizeDiff, Color cl, int time)
        {
            int size = (int)ct.Font.Size;
            ct.BackColor = cl;
            ct.Font = new Font("Lucida Handwriting", size + sizeDiff);
            ct.Update();
            Thread.Sleep(time);
            ct.BackColor = Color.White;
            ct.Font = new Font("Lucida Handwriting", size);
            ct.Update();
        }

        protected void layDa_48_Minh(Button btn)
        {
            giaTri = int.Parse(btn.Text);
            for (int i = 0; i < arrButton.Count; i++)
            {
                if (btn.Name == arrButton[i].Name)
                {
                    thuTu = i;
                    break;
                }
            }
        }

        protected void raiDa_48_Minh(ref int giaTri, ref int thuTu, bool flag)
        {
            if (giaTri > 0 || thuTu > 0)
            {
                if (flag == true)
                {
                    arrButton[thuTu].Text = "0";
                    if (thuTu == 0 || thuTu == 6)
                        hoatAnh_48_Minh(arrButton[thuTu], -2, Properties.Resources.OQuan2, 800);
                    else
                        hoatAnh_48_Minh(arrButton[thuTu], -2, Properties.Resources.ODan2, 800);

                    for (int i = 0; i < giaTri; i++)
                    {
                        thuTu = noiThuTu_48_Minh(thuTu + 1);
                        arrButton[thuTu].Text = (int.Parse(arrButton[thuTu].Text) + 1).ToString();
                        if (thuTu == 0 || thuTu == 6)
                            hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.OQuan2, 500);
                        else
                            hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.ODan2, 500);
                    }

                    if (!arrButton[noiThuTu_48_Minh(thuTu + 1)].Text.Equals("0") && noiThuTu_48_Minh(thuTu + 1) != 0 && noiThuTu_48_Minh(thuTu + 1) != 6)
                    {
                        thuTu = noiThuTu_48_Minh(thuTu + 1);
                        layDa_48_Minh(arrButton[thuTu]);
                        raiDa_48_Minh(ref giaTri, ref thuTu, flag);
                    }
                }
                else
                {
                    arrButton[thuTu].Text = "0";
                    if (thuTu == 0 || thuTu == 6)
                        hoatAnh_48_Minh(arrButton[thuTu], -2, Properties.Resources.OQuan2, 800);
                    else
                        hoatAnh_48_Minh(arrButton[thuTu], -2, Properties.Resources.ODan2, 800);
                    for (int i = 0; i < giaTri; i++)
                    {
                        thuTu = noiThuTu_48_Minh(thuTu - 1);
                        arrButton[thuTu].Text = (int.Parse(arrButton[thuTu].Text) + 1).ToString();
                        if (thuTu == 0 || thuTu == 6)
                            hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.OQuan2, 500);
                        else
                            hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.ODan2, 500);
                    }
                    if (!arrButton[noiThuTu_48_Minh(thuTu - 1)].Text.Equals("0") && noiThuTu_48_Minh(thuTu - 1) != 0 && noiThuTu_48_Minh(thuTu - 1)  != 6)
                    {
                        thuTu = noiThuTu_48_Minh(thuTu - 1);
                        layDa_48_Minh(arrButton[thuTu]);
                        raiDa_48_Minh(ref giaTri, ref thuTu, flag);

                    }
                }
            }
            
        }

        protected void congDiem_48_Minh(bool flag)
        {
            if (flag)
            {
                txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) + giaTri).ToString();
                arrButton[thuTu].Text = "0";
                if (thuTu == 0 || thuTu == 6)
                    hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.OQuan2, 1000);
                else
                    hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.ODan2, 1000);
                hoatAnh_48_Minh(txtDiem1_48_Minh, 4, Color.LightBlue, 1000);
            }
            else
            {
                txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) + giaTri).ToString();
                arrButton[thuTu].Text = "0";
                if (thuTu == 0 || thuTu == 6)
                    hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.OQuan2, 1000);
                else
                    hoatAnh_48_Minh(arrButton[thuTu], 4, Properties.Resources.ODan2, 1000);
                hoatAnh_48_Minh(txtDiem2_48_Minh, 4, Color.LightBlue, 1000);
            } 
        }

        protected void anDa_48_Minh(bool flag)
        {
            if (flag)
                while (arrButton[noiThuTu_48_Minh(thuTu + 1)].Text.Equals("0") && !arrButton[noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu + 1) + 1)].Text.Equals("0"))
                {
                    if (noiThuTu_48_Minh(thuTu + 1) == 0 || noiThuTu_48_Minh(thuTu + 1) == 6)
                        hoatAnh_48_Minh(arrButton[noiThuTu_48_Minh(thuTu + 1)], 0, Properties.Resources.OQuan2, 500);
                    else
                        hoatAnh_48_Minh(arrButton[noiThuTu_48_Minh(thuTu + 1)], 0, Properties.Resources.ODan2, 500);
                    thuTu = noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu + 1) + 1);
                    layDa_48_Minh(arrButton[thuTu]);
                  
                    if ((thuTu == 0 && lbQuan1_48_Minh.Text.Equals("1")) || (thuTu == 6 && lbQuan2_48_Minh.Text.Equals("1")))
                    {
                        congDiem_48_Minh(nguoiChoi);
                        if (nguoiChoi)
                        { 
                            txtDiemQuan1_48_Minh.Text = (int.Parse(txtDiemQuan1_48_Minh.Text) + 1).ToString();
                            if (thuTu == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan1_48_Minh, 4, Color.LightBlue, 1000);
                        }
                        else
                        {
                            txtDiemQuan2_48_Minh.Text = (int.Parse(txtDiemQuan2_48_Minh.Text) + 1).ToString();
                            if (thuTu == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();   
                            }
                            hoatAnh_48_Minh(txtDiemQuan2_48_Minh, 4, Color.LightBlue, 1000);
                        }
                    }
                    else
                        congDiem_48_Minh(nguoiChoi);
                }
            else
                while (arrButton[noiThuTu_48_Minh(thuTu - 1)].Text.Equals("0") && !arrButton[noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu - 1) - 1)].Text.Equals("0"))
                {
                    if (noiThuTu_48_Minh(thuTu - 1) == 0 || noiThuTu_48_Minh(thuTu - 1) == 6)
                        hoatAnh_48_Minh(arrButton[noiThuTu_48_Minh(thuTu - 1)], 0, Properties.Resources.OQuan2, 500);
                    else
                        hoatAnh_48_Minh(arrButton[noiThuTu_48_Minh(thuTu - 1)], 0, Properties.Resources.ODan2, 500);
                    thuTu = noiThuTu_48_Minh(noiThuTu_48_Minh(thuTu - 1) - 1);
                    layDa_48_Minh(arrButton[thuTu]);
                   
                    if ((thuTu == 0 && lbQuan1_48_Minh.Text.Equals("1")) || (thuTu == 6 && lbQuan2_48_Minh.Text.Equals("1")))
                    {
                        congDiem_48_Minh(nguoiChoi);
                        if (nguoiChoi)
                        {
                            txtDiemQuan1_48_Minh.Text = (int.Parse(txtDiemQuan1_48_Minh.Text) + 1).ToString();
                            if (thuTu == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan1_48_Minh, 4, Color.LightBlue, 1000);
                        }
                        else
                        {
                            txtDiemQuan2_48_Minh.Text = (int.Parse(txtDiemQuan2_48_Minh.Text) + 1).ToString();
                            if (thuTu == 0)
                            {
                                lbQuan1_48_Minh.Text = "0";
                                lbQuan1_48_Minh.Update();
                            }
                            else
                            {
                                lbQuan2_48_Minh.Text = "0";
                                lbQuan2_48_Minh.Update();
                            }
                            hoatAnh_48_Minh(txtDiemQuan2_48_Minh, 4, Color.LightBlue, 1000);
                        }
                    }
                    else
                        congDiem_48_Minh(nguoiChoi); 
                }
        }

        protected void muonDa_48_Minh()
        {
            if (nguoiChoi)
            {
                for (int i = 1; i <= 5; i++)
                {
                    arrButton[i].Text = "1";
                    arrButton[i].Enabled = true;
                }
                hoatAnh_48_Minh(gbPlayer1_48_Minh, 2, Color.LightPink, 1200);
                txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) - 5).ToString();
                hoatAnh_48_Minh(txtDiem1_48_Minh, -2, Color.LightPink, 1200);
            }
            else
            {
                for (int i = 7; i <= 11; i++)
                {
                    arrButton[i].Text = "1";
                    arrButton[i].Enabled = true;
                }
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 2, Color.LightPink, 1200);
                txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) - 5).ToString();
                hoatAnh_48_Minh(txtDiem2_48_Minh, -2, Color.LightPink, 1200);
            }
        }

        protected virtual void doiLuotChoi_48_Minh()
        {
            btnLeft_48_Minh.Visible = false;
            btnRight_48_Minh.Visible = false;
            foreach (var btn in arrButton)
            {
                if (btn.Text.Equals("0") || btn == arrButton[0] || btn == arrButton[6])
                    btn.Enabled = false;
                else
                    btn.Enabled = true;
            }
            gbPlayer1_48_Minh.Enabled = !nguoiChoi;
            gbPlayer2_48_Minh.Enabled = nguoiChoi;
            int dem = 0;
            if (nguoiChoi) {
                nguoiChoi = false;
                txtThoiGian1_48_Minh.Text = "15";
                for (int i = 7; i <= 11; i++)
                {
                    if (arrButton[i].Text.Equals("0"))
                        dem++;
                    else
                        break;
                }
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 0, Color.Yellow, 800);
            }
            else {
                nguoiChoi = true;
                txtThoiGian2_48_Minh.Text = "15";
                for (int i = 1; i <= 5; i++)
                {
                    if (arrButton[i].Text.Equals("0"))
                        dem++;
                    else
                        break;
                }
                hoatAnh_48_Minh(gbPlayer1_48_Minh, 0, Color.Yellow, 800);
            }
            if (dem == 5)
                muonDa_48_Minh();
            

            giaTri = thuTu = 0;
        }

        protected bool checkGameOver_48_Minh()
        {
            if (arrButton[0].Text.Equals("0") && lbQuan1_48_Minh.Text.Equals("0")
                && arrButton[6].Text.Equals("0") && lbQuan2_48_Minh.Text.Equals("0"))
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!arrButton[i].Text.Equals("0"))
                    {
                        layDa_48_Minh(arrButton[i]);
                        congDiem_48_Minh(true);
                    }
                }
                for (int i = 7; i <= 11; i++)
                {
                    if (!arrButton[i].Text.Equals("0"))
                    {
                        layDa_48_Minh(arrButton[i]);
                        congDiem_48_Minh(false);
                    }
                }
                if (int.Parse(txtDiem1_48_Minh.Text) < 0)
                {
                    txtDiem2_48_Minh.Text = (int.Parse(txtDiem2_48_Minh.Text) - int.Parse(txtDiem1_48_Minh.Text)).ToString();                   
                    txtDiem1_48_Minh.Text = "0";
                    hoatAnh_48_Minh(txtDiem1_48_Minh, 6, Color.LightBlue, 1500);
                    hoatAnh_48_Minh(txtDiem2_48_Minh, 6, Color.LightBlue, 1500);
                }
                if (int.Parse(txtDiem2_48_Minh.Text) < 0)
                {
                    txtDiem1_48_Minh.Text = (int.Parse(txtDiem1_48_Minh.Text) - int.Parse(txtDiem2_48_Minh.Text)).ToString();
                    txtDiem2_48_Minh.Text = "0";
                    hoatAnh_48_Minh(txtDiem2_48_Minh, 6, Color.LightBlue, 1500);
                    hoatAnh_48_Minh(txtDiem1_48_Minh, 6, Color.LightBlue, 1500);
                }    
                return true;
            }
            return false;
        }

        protected int checkWinner_48_Minh()
        {
            if (int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) > int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
                return 1;
            else if (int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) < int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
                return -1;
            else
                return 0;
        }          

        protected virtual void hienKetQua_48_Minh()
        {
            string thongTin;
            if (checkWinner_48_Minh() == 1)
                thongTin = "NGƯỜI CHIẾN THẮNG: NGƯỜI CHƠI 1!\n\n\n";
            else if (checkWinner_48_Minh() == -1)
                thongTin = "NGƯỜI CHIẾN THẮNG: NGƯỜI CHƠI 2!\n\n\n";
            else
                thongTin = "HAI NGƯỜI CHƠI HÒA NHAU!\n\n";
            thongTin += String.Format("Người chơi 1:\n\tSố dân ăn được {0}.\n\tSố quan ăn được {1}\n\tTổng điểm {2}\n\n" +
                                            "Người chơi 2:\n\tSố dân ăn được {3}.\n\tSố quan ăn được {4}\n\tTổng điểm {5}\n\n",
                                            txtDiem1_48_Minh.Text, txtDiemQuan1_48_Minh.Text, int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text),
                                            txtDiem2_48_Minh.Text, txtDiemQuan2_48_Minh.Text, int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text));
            MessageBox.Show(thongTin, "Kêt quả", MessageBoxButtons.OK);
            this.Hide();
            docFile_48_Minh("OAnQuan.Resources.Data.txt");
            Application.Restart();
        }

        public void docFile_48_Minh(String path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(path));
            try
            {

                nguoiChoi = bool.Parse(reader.ReadLine());
                txtDiem1_48_Minh.Text = reader.ReadLine();
                txtDiemQuan1_48_Minh.Text = reader.ReadLine();
                txtDiem2_48_Minh.Text = reader.ReadLine();
                txtDiemQuan2_48_Minh.Text = reader.ReadLine();
                lbQuan1_48_Minh.Text = reader.ReadLine();
                lbQuan2_48_Minh.Text = reader.ReadLine();
                txtThoiGian1_48_Minh.Text = reader.ReadLine();
                txtThoiGian2_48_Minh.Text = reader.ReadLine();
                foreach (var btn in arrButton)
                {
                    btn.Text = reader.ReadLine();
                    if (btn.Text.Equals("0") || btn == arrButton[0] || btn == arrButton[6])
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
                gbPlayer1_48_Minh.Enabled = nguoiChoi;
                gbPlayer2_48_Minh.Enabled = !nguoiChoi;
                FrmMenu_48_Minh.soNguoiChoi = bool.Parse(reader.ReadLine());

            }
            catch (Exception)
            { }
            finally
            {
                reader.Close();
            }
        }

        public void docFile_48_Minh()
        {
            nguoiChoi = Properties.Settings.Default.nguoiChoi;
            txtDiem1_48_Minh.Text = Properties.Settings.Default.txtDiem1_48_Minh;
            txtDiem2_48_Minh.Text = Properties.Settings.Default.txtDiem2_48_Minh;
            txtDiemQuan1_48_Minh.Text = Properties.Settings.Default.txtDiemQuan1_48_Minh;
            txtDiemQuan2_48_Minh.Text = Properties.Settings.Default.txtDiemQuan2_48_Minh;
            lbQuan1_48_Minh.Text = Properties.Settings.Default.lbQuan1_48_Minh;
            lbQuan2_48_Minh.Text = Properties.Settings.Default.lbQuan2_48_Minh;
            txtThoiGian1_48_Minh.Text = Properties.Settings.Default.txtThoiGian1_48_Minh;
            txtThoiGian2_48_Minh.Text = Properties.Settings.Default.txtThoiGian2_48_Minh;
            btnO0_48_Minh.Text = Properties.Settings.Default.btnO0_48_Minh;
            btnO1_48_Minh.Text = Properties.Settings.Default.btnO1_48_Minh;
            btnO2_48_Minh.Text = Properties.Settings.Default.btnO2_48_Minh;
            btnO3_48_Minh.Text = Properties.Settings.Default.btnO3_48_Minh;
            btnO4_48_Minh.Text = Properties.Settings.Default.btnO4_48_Minh;
            btnO5_48_Minh.Text = Properties.Settings.Default.btnO5_48_Minh;
            btnO6_48_Minh.Text = Properties.Settings.Default.btnO6_48_Minh;
            btnO7_48_Minh.Text = Properties.Settings.Default.btnO7_48_Minh;
            btnO8_48_Minh.Text = Properties.Settings.Default.btnO8_48_Minh;
            btnO9_48_Minh.Text = Properties.Settings.Default.btnO9_48_Minh;
            btnO10_48_Minh.Text = Properties.Settings.Default.btnO10_48_Minh;
            btnO11_48_Minh.Text = Properties.Settings.Default.btnO11_48_Minh;
            foreach (var btn in arrButton)
                {
                    if (btn.Text.Equals("0") || btn == arrButton[0] || btn == arrButton[6])
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
                gbPlayer1_48_Minh.Enabled = nguoiChoi;
                gbPlayer2_48_Minh.Enabled = !nguoiChoi;
        }

        private void ghiFile_48_Minh()
        {
            Properties.Settings.Default.nguoiChoi = nguoiChoi;
            Properties.Settings.Default.txtDiem1_48_Minh = txtDiem1_48_Minh.Text;
            Properties.Settings.Default.txtDiem2_48_Minh = txtDiem2_48_Minh.Text;
            Properties.Settings.Default.txtDiemQuan1_48_Minh = txtDiemQuan1_48_Minh.Text;
            Properties.Settings.Default.txtDiemQuan2_48_Minh = txtDiemQuan2_48_Minh.Text;
            Properties.Settings.Default.lbQuan1_48_Minh = lbQuan1_48_Minh.Text;
            Properties.Settings.Default.lbQuan2_48_Minh = lbQuan2_48_Minh.Text;
            Properties.Settings.Default.txtThoiGian1_48_Minh = txtThoiGian1_48_Minh.Text;
            Properties.Settings.Default.txtThoiGian2_48_Minh = txtThoiGian2_48_Minh.Text;
            Properties.Settings.Default.btnO0_48_Minh = btnO0_48_Minh.Text;
            Properties.Settings.Default.btnO1_48_Minh = btnO1_48_Minh.Text;
            Properties.Settings.Default.btnO2_48_Minh = btnO2_48_Minh.Text;
            Properties.Settings.Default.btnO3_48_Minh = btnO3_48_Minh.Text;
            Properties.Settings.Default.btnO4_48_Minh = btnO4_48_Minh.Text;
            Properties.Settings.Default.btnO5_48_Minh = btnO5_48_Minh.Text;
            Properties.Settings.Default.btnO6_48_Minh = btnO6_48_Minh.Text;
            Properties.Settings.Default.btnO7_48_Minh = btnO7_48_Minh.Text;
            Properties.Settings.Default.btnO8_48_Minh = btnO8_48_Minh.Text;
            Properties.Settings.Default.btnO9_48_Minh = btnO9_48_Minh.Text;
            Properties.Settings.Default.btnO10_48_Minh = btnO10_48_Minh.Text;
            Properties.Settings.Default.btnO11_48_Minh = btnO11_48_Minh.Text;
            Properties.Settings.Default.soNguoiChoi = FrmMenu_48_Minh.soNguoiChoi;
            Properties.Settings.Default.Save();
        }
       
        public FrmMain2Player_48_Minh()
        {
            InitializeComponent();
            arrButton = new List<Button>
            {btnO0_48_Minh, btnO1_48_Minh, btnO2_48_Minh, btnO3_48_Minh, btnO4_48_Minh, btnO5_48_Minh,
             btnO6_48_Minh, btnO7_48_Minh, btnO8_48_Minh, btnO9_48_Minh, btnO10_48_Minh, btnO11_48_Minh};
            for (int i = 0; i < arrButton.Count; i++)
            {
                arrButton[i].Click += new EventHandler(arrButton_Click);
                arrButton[i].Tag = i + 1;
            }
        }

        private void arrButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btnLeft_48_Minh.Visible = true;
            btnRight_48_Minh.Visible = true;
            layDa_48_Minh(btn);
        }

        private void btnLeft_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            raiDa_48_Minh(ref giaTri, ref thuTu, !nguoiChoi);
            anDa_48_Minh(!nguoiChoi);
            if (checkGameOver_48_Minh())
                hienKetQua_48_Minh();
            else
                doiLuotChoi_48_Minh();
            tThoiGian_48_Minh.Start();
        }

        private void btnRight_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            raiDa_48_Minh(ref giaTri, ref thuTu, nguoiChoi);
            anDa_48_Minh(nguoiChoi);          
            if (checkGameOver_48_Minh())
                hienKetQua_48_Minh();
            else
                doiLuotChoi_48_Minh();
            tThoiGian_48_Minh.Start();
        }

        private void tThoiGian_48_Minh_Tick(object sender, EventArgs e)
        {
            if (nguoiChoi)
                txtThoiGian1_48_Minh.Text = String.Format("{0:00}", int.Parse(txtThoiGian1_48_Minh.Text) - 1);
            else
                txtThoiGian2_48_Minh.Text = String.Format("{0:00}", int.Parse(txtThoiGian2_48_Minh.Text) - 1);
            if (int.Parse(txtThoiGian1_48_Minh.Text) == -1 || int.Parse(txtThoiGian2_48_Minh.Text) == -1)
            {
                tThoiGian_48_Minh.Stop();
                foreach (Button btn in arrButton)
                    if (btn.Enabled == true)
                    {
                        layDa_48_Minh(btn);
                        raiDa_48_Minh(ref giaTri, ref thuTu, nguoiChoi);
                        anDa_48_Minh(nguoiChoi);                     
                        if (checkGameOver_48_Minh())
                            hienKetQua_48_Minh();
                        doiLuotChoi_48_Minh();
                        break;
                    }
                tThoiGian_48_Minh.Start();
            }    
        }

        private void FrmMain_48_Minh_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghiFile_48_Minh();
            Application.Exit();
        }

        protected virtual void btnMenu_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            FrmMenu_48_Minh.frmMenu_48_Minh.Size = FrmMenu_48_Minh.frmMain2_48_Minh.Size;
            FrmMenu_48_Minh.frmMenu_48_Minh.Location = FrmMenu_48_Minh.frmMain2_48_Minh.Location;
            FrmMenu_48_Minh.frmMenu_48_Minh.Show();
            this.Hide();
        }

        private void FrmMain2Player_48_Minh_Load(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Enabled = true;
        }
    }

}
