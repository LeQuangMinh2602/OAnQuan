using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace OAnQuan
{
    public partial class FrmMain1Player_48_Minh : OAnQuan.FrmMain2Player_48_Minh
    {
        int[,] arrPossibleChoice_48_Minh = new int[10, 11];
        int[] arrValue_48_Minh = new int[12];
        bool[] arrQuan_48_Minh = new bool[2];

        public FrmMain1Player_48_Minh()
        {
            InitializeComponent();
        }

        private void botCalc_48_Minh(int[] arrV, bool[] arrQ, ref int possibleChoice, int row, int col)
        {
            int index;
            bool direct;
            if (col == 0)
            {
                if (0 <= row && row <= 4)
                {
                    index = row + 7;
                    direct = true;
                }
                else
                {
                    index = row + 2;
                    direct = false;
                }
            }
            else
            {
                if (1 <= col && col <= 5)
                {
                    index = col;
                    direct = true;
                }
                else
                {
                    index = col - 5;
                    direct = false;
                }

                //muonda:
                int dem = 0;
                for (int i = 1; i <= 5; i++)
                {
                    if (arrV[i] == 0)
                        dem++;
                    else
                        break;
                }
                if (dem == 5)
                {
                    for (int i = 1; i <= 5; i++)
                        arrV[i] = 1;
                    if(col == 1)
                        arrPossibleChoice_48_Minh[row, 0] += 5;
                }
            }
            int temp = arrV[index];
            if (arrV[index] > 0)
            {
                //raida:
                do
                {
                    int n = arrV[index];
                    arrV[index] = 0;
                    if (direct)
                        index = noiThuTu_48_Minh(index + 1);
                    else
                        index = noiThuTu_48_Minh(index - 1);
                    for (int k = 0; k < n; k++)
                    {
                        arrV[index] = arrV[index] + 1;
                        if (direct)
                            index = noiThuTu_48_Minh(index + 1);
                        else
                            index = noiThuTu_48_Minh(index - 1);
                    }
                } while (arrV[index] != 0 && index != 0 && index != 6);

                //anda:
                while (arrV[index] == 0)
                {
                    if (direct)
                        index = noiThuTu_48_Minh(index + 1);
                    else
                        index = noiThuTu_48_Minh(index - 1);
                    if (arrV[index] != 0)
                    {
                        if ((index == 0 && arrQ[0]) || (index == 6 && arrQ[1]))
                        {
                            possibleChoice += arrV[index];
                            arrV[index] = 0;
                            possibleChoice += 10;
                            if (index == 0)
                                arrQ[0] = false;
                            else
                                arrQ[1] = false;
                        }
                        else
                        {
                            possibleChoice += arrV[index];
                            arrV[index] = 0;
                        }
                        if (direct)
                            index = noiThuTu_48_Minh(index + 1);
                        else
                            index = noiThuTu_48_Minh(index - 1);
                    }
                    else
                        break;
                }

                //chienthang:
                if (col == 0 && arrV[0] == 0 && arrQ[0] == false && arrQ[1] == false && arrV[6] == 0 &&
                   possibleChoice + int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text) > int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text))
                {
                    possibleChoice += 70;
                    return;
                }
                if (col != 0 && arrV[0] == 0 && arrQ[0] == false && arrQ[1] == false && arrV[6] == 0 &&
                   possibleChoice + int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text) > arrPossibleChoice_48_Minh[row, 0] + int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text))
                    possibleChoice += 70;
            }
            else
                possibleChoice = -1;

            //raida nguoi choi
            if (col != 0 || temp > 0)
            {
                int[] arrTempValue = new int[arrButton.Count];
                for (int i = 0; i < arrButton.Count; i++)
                    arrTempValue[i] = arrValue_48_Minh[i];
                bool[] arrTempQuan = new bool[2];
                for (int i = 0; i < 2; i++)
                    arrTempQuan[i] = arrQuan_48_Minh[i];
                col++;
                if (col < 11)
                    botCalc_48_Minh(arrTempValue, arrTempQuan, ref arrPossibleChoice_48_Minh[row, col], row, col);
                else
                    return;
            }
        }

        private int botChoosing_48_Minh()
        {
            for (int i = 0; i < arrPossibleChoice_48_Minh.GetLength(0); i++)
                for (int j = 0; j < arrPossibleChoice_48_Minh.GetLength(1); j++)
                    arrPossibleChoice_48_Minh[i, j] = 0;
            for (int i = 0; i < arrPossibleChoice_48_Minh.GetLength(0); i++)
            {
                if (lbQuan1_48_Minh.Text == "1")
                    arrQuan_48_Minh[0] = true;
                else
                    arrQuan_48_Minh[0] = false;
                if (lbQuan2_48_Minh.Text == "1")
                    arrQuan_48_Minh[1] = true;
                else
                    arrQuan_48_Minh[1] = false;
                for (int k = 0; k < arrButton.Count; k++)
                    arrValue_48_Minh[k] = int.Parse(arrButton[k].Text);

                botCalc_48_Minh(arrValue_48_Minh, arrQuan_48_Minh, ref arrPossibleChoice_48_Minh[i, 0], i, 0);
            }

            int result, optim;
            for (int i = 0; i < arrPossibleChoice_48_Minh.GetLength(0); i++)
            {
                optim = 140;
                if (arrPossibleChoice_48_Minh[i, 0] != -1)
                {
                    if (arrPossibleChoice_48_Minh[i, 0] < 70)
                    {
                        for (int j = 1; j < arrPossibleChoice_48_Minh.GetLength(1); j++)
                        {
                            if (arrPossibleChoice_48_Minh[i, j] != -1 && optim > arrPossibleChoice_48_Minh[i, 0] - arrPossibleChoice_48_Minh[i, j])
                                optim = arrPossibleChoice_48_Minh[i, 0] - arrPossibleChoice_48_Minh[i, j];
                        }
                        arrPossibleChoice_48_Minh[i, 0] = optim;
                    }
                    else
                    {
                        if (0 <= i && i <= 4)
                            return i + 7;
                        else
                            return -(i + 2);
                    }
                }
                else
                    arrPossibleChoice_48_Minh[i, 0] = -140;
            }
            optim = arrPossibleChoice_48_Minh[0, 0];
            result = 7;
            for (int i = 1; i < arrPossibleChoice_48_Minh.GetLength(0); i++)
            {
                if (optim < arrPossibleChoice_48_Minh[i, 0])
                {
                    optim = arrPossibleChoice_48_Minh[i, 0];
                    if (0 <= i && i <= 4)
                    {
                        result = i + 7;
                    }
                    else
                    {
                        result = -(i + 2);
                    }
                }
            }
            return result;
        }

        protected override void hienKetQua_48_Minh()
        {
            string thongTin;
            if (checkWinner_48_Minh() == 1)
                thongTin = "BẠN ĐÃ CHIẾN THẮNG!\n\n\n";
            else if (checkWinner_48_Minh() == -1)
                thongTin = "NGƯỜI CHIẾN THẮNG: MÁY!\n\n\n";
            else
                thongTin = "HAI NGƯỜI CHƠI HÒA NHAU!\n\n";
            thongTin += String.Format("Bạn:\n\tSố dân ăn được {0}.\n\tSố quan ăn được {1}\n\tTổng điểm {2}\n\n" +
                                            "Máy:\n\tSố dân ăn được {3}.\n\tSố quan ăn được {4}\n\tTổng điểm: {5}",
                                            txtDiem1_48_Minh.Text, txtDiemQuan1_48_Minh.Text, int.Parse(txtDiem1_48_Minh.Text) + 10 * int.Parse(txtDiemQuan1_48_Minh.Text),
                                            txtDiem2_48_Minh.Text, txtDiemQuan2_48_Minh.Text, int.Parse(txtDiem2_48_Minh.Text) + 10 * int.Parse(txtDiemQuan2_48_Minh.Text));
            MessageBox.Show(thongTin, "Kêt quả", MessageBoxButtons.OK);
            this.Hide();
            docFile_48_Minh("OAnQuan.Resources.Data.txt");
            Application.Restart();
        }

        protected override void doiLuotChoi_48_Minh()
        {
            btnLeft_48_Minh.Visible = false;
            btnRight_48_Minh.Visible = false;
            int dem = 0;
            if (nguoiChoi)
            {
                gbPlayer1_48_Minh.Enabled = false;
                gbPlayer2_48_Minh.Enabled = false;
                nguoiChoi = false;
                txtThoiGian1_48_Minh.Text = "15";
                for (int i = 7; i <= 11; i++)
                {
                    if (arrButton[i].Text.Equals("0"))
                        dem++;
                    else
                        break;
                }
                if (dem == 5)
                    muonDa_48_Minh();
                hoatAnh_48_Minh(gbPlayer2_48_Minh, 0, Color.Yellow, 800);
                tThoiGian_48_Minh.Stop();              

                int botChoice = botChoosing_48_Minh();
                layDa_48_Minh(arrButton[Math.Abs(botChoice)]);
                if (botChoice < 0)
                {
                    raiDa_48_Minh(ref giaTri, ref thuTu, false);
                    anDa_48_Minh(false);
                }
                else
                {
                    raiDa_48_Minh(ref giaTri, ref thuTu, true);
                    anDa_48_Minh(true);
                }
                if (checkGameOver_48_Minh())
                    hienKetQua_48_Minh();
                doiLuotChoi_48_Minh();
                tThoiGian_48_Minh.Start();

            }
            else
            {
                foreach (var btn in arrButton)
                {
                    if (btn.Text.Equals("0") || btn == arrButton[0] || btn == arrButton[6])
                        btn.Enabled = false;
                    else
                        btn.Enabled = true;
                }
                gbPlayer1_48_Minh.Enabled = true;
                gbPlayer2_48_Minh.Enabled = false;
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
                if (dem == 5)
                    muonDa_48_Minh();
            }
            giaTri = thuTu = 0;
        }

        protected override void btnMenu_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            FrmMenu_48_Minh.frmMenu_48_Minh.Size = FrmMenu_48_Minh.frmMain1_48_Minh.Size;
            FrmMenu_48_Minh.frmMenu_48_Minh.Location = FrmMenu_48_Minh.frmMain1_48_Minh.Location;
            FrmMenu_48_Minh.frmMenu_48_Minh.Show();
            this.Hide();
        }
    }
}
