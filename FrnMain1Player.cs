using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace OAnQuan
{
    public partial class FrnMain1Player_48_Minh : OAnQuan.FrmMain2Player_48_Minh
    {
        int[,] arrPossibleChoice = new int[10, 11];
        int[] arrValue;
        bool[] arrQuan = new bool[2];

        public FrnMain1Player_48_Minh()
        {
            InitializeComponent();
            arrValue = new int[arrButton.Count];
        }

        private void botCalc(int[] arrValue, bool[] arrQuan, ref int possibleChoice, int row, int col)
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
            }
            if (arrValue[index] > 0)
            {
                //raida:
                do
                {
                    int n = arrValue[index];
                    arrValue[index] = 0;
                    if (direct)
                        index = noiThuTu_48_Minh(index + 1);
                    else
                        index = noiThuTu_48_Minh(index - 1);
                    for (int k = 0; k < n; k++)
                    {
                        arrValue[index] = arrValue[index] + 1;
                        if (direct)
                            index = noiThuTu_48_Minh(index + 1);
                        else
                            index = noiThuTu_48_Minh(index - 1);
                    }
                } while (arrValue[index] != 0 && index != 0 && index != 6);

                //anda:
                while (arrValue[index] == 0)
                {
                    if (direct)
                        index = noiThuTu_48_Minh(index + 1);
                    else
                        index = noiThuTu_48_Minh(index - 1);
                    if (arrValue[index] != 0)
                    {
                        if ((index == 0 && lbQuan1_48_Minh.Text.Equals("1")) || (index == 6 && lbQuan2_48_Minh.Text.Equals("1")))
                        {
                            possibleChoice += arrValue[index];
                            arrValue[index] = 0;
                            possibleChoice += 10;
                            if (index == 0)
                                arrQuan[0] = false;
                            else
                                arrQuan[1] = false;
                        }
                        else
                        {
                            possibleChoice += arrValue[index];
                            arrValue[index] = 0;
                        }
                    }
                    else
                        break;
                }
            }
            else
                possibleChoice = -1;

            //chienthang:
            if (arrValue[0] == 0 && arrQuan[0] == false && arrQuan[1] == false && arrValue[6] == 0 &&
               possibleChoice + int.Parse(txtDiemQuan1_48_Minh.Text) > int.Parse(txtDiemQuan2_48_Minh.Text))
                possibleChoice += 70;
            int[] arrTempValue = arrValue;
            bool[] arrTempQuan = arrQuan;
            col++;
            if (col < 11)
                botCalc(arrTempValue, arrTempQuan, ref arrPossibleChoice[row, col], row, col);
            else
                return;
        }

        private int botChoosing()
        {
            for (int i = 0; i < arrPossibleChoice.GetLength(0); i++)
                for (int j = 0; j < arrPossibleChoice.GetLength(1); j++)
                    arrPossibleChoice[i, j] = 0;
            for (int i = 0; i < arrPossibleChoice.GetLength(0); i++)
            {
                if (lbQuan1_48_Minh.Text == "1")
                    arrQuan[0] = true;
                else
                    arrQuan[0] = false;
                if (lbQuan2_48_Minh.Text == "1")
                    arrQuan[1] = true;
                else
                    arrQuan[1] = false;
                for (int k = 0; k < arrButton.Count; k++)
                    arrValue[k] = int.Parse(arrButton[k].Text);

                botCalc(arrValue, arrQuan, ref arrPossibleChoice[i, 0], i, 0);
            }

            int result, optim;
            for (int i = 0; i < arrPossibleChoice.GetLength(0); i++)
            {
                optim = -1;
                result = -1;
                if (arrPossibleChoice[i, 0] != -1)
                {
                    for (int j = 1; j < arrPossibleChoice.GetLength(1); j++)
                    {
                        if (arrPossibleChoice[i, j] != -1)
                        {
                            if (optim < arrPossibleChoice[i, 0] - arrPossibleChoice[i, j])
                                optim = arrPossibleChoice[i, 0] - arrPossibleChoice[i, j];
                        }
                    }
                    arrPossibleChoice[i, 0] = optim;
                }
                else
                    arrPossibleChoice[i, 0] = -70;
            }
            optim = arrPossibleChoice[0, 0];
            result = 7;
            for (int i = 1; i < arrPossibleChoice.GetLength(0); i++)
            {
                if (optim < arrPossibleChoice[i, 0])
                {
                    optim = arrPossibleChoice[i, 0];
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
            thongTin += String.Format("Bạn:\n\tSố dân ăn được {0}.\n\tSố quan ăn được {1}\n\n" +
                                            "Máy:\n\tSố dân ăn được {2}.\n\tSố quan ăn được {3}",
                                            txtDiem1_48_Minh.Text, txtDiemQuan1_48_Minh.Text,
                                            txtDiem2_48_Minh.Text, txtDiemQuan2_48_Minh.Text);
            MessageBox.Show(thongTin, "Kêt quả", MessageBoxButtons.OK);
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

                int botChoice = botChoosing();
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

        private void btnMenu_48_Minh_Click(object sender, EventArgs e)
        {
            tThoiGian_48_Minh.Stop();
            FrmMenu_48_Minh.frmMain1_48_Minh.Size = this.Size;
            FrmMenu_48_Minh.frmMain1_48_Minh.Location = this.Location;
            FrmMenu_48_Minh.frmMenu_48_Minh.Show();
            this.Hide();
        }
    }

}
